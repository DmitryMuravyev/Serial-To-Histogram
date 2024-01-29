/*
  A simple application for plotting histograms based on data read from the COM port in real time.
  
  MIT License

  Copyright (c) 2024 Dmitry Muravyev (youtube.com/@DmitryMuravyev)

  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the "Software"), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:

  The above copyright notice and this permission notice shall be included in all
  copies or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
  SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SerialToHistogram
{
    public partial class MainForm : Form
    {
        //
        // Private Declarations
        // Private Constants Declaration
        // Strings
        private const string connectString = "Connect";
        private const string disconnectString = "Disconnect";
        private const string floatDisplayFormat = "0.0000";
        private const string shortFloatDisplayFormat = "0.00";
        private const string intDisplayFormat = "0";
        private const string voltsValueString = " V";
        private const string millivoltsValueString = " mV";
        private const string lsbValueString = " LSB";
        private const string unknownValueString = "?";
        private const string verticalLineAnnotationName = "averageLine";
        private const string vRefMarkerString = "Vref";
        private const string averageMarkerString = "Average";
        private const string adcResMarkerString = "ADCres";
        // Numbers
        private const byte defaultADCResolution = 10;
        private const byte maxADCResolution = 16;
        private const int serialBufferSize = 1024;
        private const int chartUpdateMillisecondsInterval = 250;
        private const byte defaultPortBaudRateIndex = 5;
        private const int defaultPortTimeoutMilliseconds = 500;
        private const int chartFractionalDigitsNumber = 3;
        private const int readingsFactor = 10;
        private const int maxErrorsCount = 5;

        //  Private Variables Declaration
        private System.Timers.Timer _updateTimer;
        private SerialPort _serialPort;
        private volatile bool _justConnected;
        private volatile byte[] _buffer;
        private volatile int _position = 0;
        private volatile byte _errorsCount = 0;
        private volatile bool _dataError = false;
        private bool _errorDisplayed = false;
        private volatile UInt16[] _readings;
        private volatile UInt32[] _histogram;
        private volatile UInt16 _pointer = 0;
        private readonly Mutex _histogrgamMutex = new Mutex();
        private bool _displayVoltages = false;
        private bool _displayMillivolts = false;
        private volatile float _vRef = 0.0F;
        private volatile float _averageADCValue = 0.0F;
        private volatile float _averageValue = 0.0F;
        private volatile byte _resolution = defaultADCResolution;
        private volatile UInt32 _maxADCValue = (UInt32)(1 << defaultADCResolution);
        private string _currentPort = "";


        //--------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------
        //
        //  Implementation
        //
        //--------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------
        //  MainForm Class Constructor
        //--------------------------------------------------------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            // Cyclic array of ADC readings
            _readings = new UInt16[_maxADCValue * readingsFactor];

            // Histogram Array - the number of occurrences of each value
            _histogram = new UInt32[_maxADCValue];
            UpdateResolutionValue();

            // Udate Chart in real time
            _updateTimer = new System.Timers.Timer(chartUpdateMillisecondsInterval);
            _updateTimer.Elapsed += OnTimedEvent;
            _updateTimer.AutoReset = true;

            // Initialize serial port and small input buffer for raw data
            _serialPort = new SerialPort();
            _buffer = new byte[serialBufferSize];

            speedComboBox.SelectedIndex = defaultPortBaudRateIndex;
            UpdatePorts();

            // Set the read/write timeouts
            _serialPort.ReadTimeout = defaultPortTimeoutMilliseconds;
            _serialPort.WriteTimeout = defaultPortTimeoutMilliseconds;

        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Update available COM-ports list
        //--------------------------------------------------------------------------------------------------------------------------
        public void UpdatePorts()
        {
            var ports = SerialPort.GetPortNames().OrderBy(name => name);
            portsComboBox.Items.Clear();
            bool portFound = false;
            int portIndex = 0;
            foreach (string comPort in ports)
            {
                portIndex = portsComboBox.Items.Add(comPort);
                if (comPort.Equals(_currentPort))
                {
                    portsComboBox.SelectedIndex = portIndex;
                    portFound = true;
                }
            }

            if (!portFound)
            {
                DisconnectPort();
                if (portsComboBox.Items.Count > 0) portsComboBox.SelectedIndex = portIndex;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Connect serial port
        //--------------------------------------------------------------------------------------------------------------------------
        public void ConnectPort()
        {
            DisconnectPort();

            _currentPort = portsComboBox.SelectedItem.ToString();

            // Reset all data if a new port is selected
            if (!_currentPort.Equals(_serialPort.PortName))
            {
                Array.Clear(_readings, 0, _readings.Length);
                Array.Clear(_histogram, 0, _histogram.Length);
                _pointer = 0;
                _averageValue = _averageADCValue = 0.0F;
                _vRef = 0.0F;
                UpdateAverageValue();
                UpdateVrefValue();

                _serialPort.PortName = _currentPort;
            }

            _serialPort.BaudRate = Int32.Parse(speedComboBox.SelectedItem.ToString());

            _justConnected = true;
            _position = 0;
            _errorsCount = 0;
            _dataError = false;
            _serialPort.Open();
            _serialPort.DataReceived += Port_OnReceiveData;

            portsComboBox.Enabled = false;
            speedComboBox.Enabled = false;
            connectButton.Text = disconnectString;
            _updateTimer.Enabled = true;
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Disconnect serial port
        //--------------------------------------------------------------------------------------------------------------------------
        public void DisconnectPort()
        {
            _updateTimer.Enabled = false;
            _updateTimer.Stop();
            if (_serialPort.IsOpen)
            {
                _serialPort.DataReceived -= Port_OnReceiveData;
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                _serialPort.Close();
            }

            portsComboBox.Enabled = true;
            speedComboBox.Enabled = true;
            connectButton.Text = connectString;

        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Update histogram chart
        //--------------------------------------------------------------------------------------------------------------------------
        public void UpdateChart()
        {
            if (!_dataError)
            {

                histogramChart.Series[0].Points.Clear();
                double minimum = float.MaxValue;
                double maximum = 0.0F;
                bool valuesFound = false;

                _histogrgamMutex.WaitOne();

                for (int i = 0; i < _maxADCValue; i++)
                {
                    // Calculate Min/Max and update Chart
                    if (_histogram[i] > 0)
                    {
                        valuesFound = true;
                        double value = i;
                        if (_displayVoltages)
                        {
                            value = value * _vRef / _maxADCValue;
                            if (_displayMillivolts) value *= 1000.0F;
                        }
                        if (value < minimum) minimum = value;
                        if (value > maximum) maximum = value;
                        value = Math.Round(value, chartFractionalDigitsNumber);

                        histogramChart.Series[0].Points.AddXY(value, _histogram[i]);
                    }
                }

                _histogrgamMutex.ReleaseMutex();

                // Update Labels
                if (valuesFound)
                {
                    double ptp = maximum - minimum;
                    if (_displayVoltages)
                    {
                        string units = _displayMillivolts ? millivoltsValueString : voltsValueString;
                        minimumLabel.Text = minimum.ToString(floatDisplayFormat) + units;
                        maximumLabel.Text = maximum.ToString(floatDisplayFormat) + units;
                        ptpLabel.Text = ptp.ToString(floatDisplayFormat) + units;
                    }
                    else
                    {
                        minimumLabel.Text = minimum.ToString(intDisplayFormat);
                        maximumLabel.Text = maximum.ToString(intDisplayFormat);
                        ptpLabel.Text = ptp.ToString(intDisplayFormat) + lsbValueString;
                    }
                    if (!exportImageButton.Enabled) exportImageButton.Enabled = true;
                }
                else
                {
                    minimumLabel.Text = unknownValueString;
                    maximumLabel.Text = unknownValueString;
                    ptpLabel.Text = unknownValueString;
                    exportImageButton.Enabled = false;
                }


                if (_errorDisplayed)
                {
                    connectButton.BackColor = SystemColors.Control;
                    _errorDisplayed = false;
                }

            } else if (!_errorDisplayed) {
                connectButton.BackColor = Color.Red;
                _errorDisplayed = true;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Update calibrated average value Annotaion line and Label
        //--------------------------------------------------------------------------------------------------------------------------
        public void UpdateAverageValue()
        {
            VerticalLineAnnotation va = (VerticalLineAnnotation)histogramChart.Annotations.FindByName(verticalLineAnnotationName);

            if (_averageADCValue > 0.0F)
            {
                _averageValue = _averageADCValue;

                if (_displayVoltages)
                {
                    _averageValue = _averageValue * _vRef / _maxADCValue;
                    if (_displayMillivolts) _averageValue *= 1000.0F;
                    avgLabel.Text = _averageValue.ToString(floatDisplayFormat) + (_displayMillivolts ? millivoltsValueString : voltsValueString);
                }
                else
                {
                    avgLabel.Text = _averageValue.ToString(floatDisplayFormat);
                }

                va.X = _averageValue;
                va.Visible = true;
            }
            else
            {
                avgLabel.Text = unknownValueString;
                va.Visible = false;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Update Vref Label and available display modes Radio Buttons
        //--------------------------------------------------------------------------------------------------------------------------
        public void UpdateVrefValue()
        {
            if (_vRef > 0.0)
            {
                // If the reference voltage value is available, then it is possible to display the results in volts or millivolts.
                vRefLabel.Text = _vRef.ToString(floatDisplayFormat);
                voltsRadioButton.Enabled = true;
                millivoltsRadioButton.Enabled = true;
            }
            else
            {
                // If not, then the display is possible only in the form of original ADC readings.
                vRefLabel.Text = unknownValueString;
                voltsRadioButton.Checked = false;
                voltsRadioButton.Enabled = false;
                millivoltsRadioButton.Checked = false;
                millivoltsRadioButton.Enabled = false;
                valuesRadioButton.Checked = true;
                _displayVoltages = false;
                _displayMillivolts = false;
                UpdateAverageValue();
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Update ADC resolution Label
        //--------------------------------------------------------------------------------------------------------------------------
        public void UpdateResolutionValue()
        {
            resolutionLabel.Text = _resolution.ToString();
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Windows device list changed event
        //--------------------------------------------------------------------------------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 537: //WM_DEVICECHANGE
                    UpdatePorts();
                    break;
            }
            base.WndProc(ref m);
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Run the Method in the main thread
        //--------------------------------------------------------------------------------------------------------------------------
        private void RunTheMethod(Action methodName)
        {
            if (!this.IsHandleCreated) return;
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() => methodName()));
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                methodName();
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Process received message
        //--------------------------------------------------------------------------------------------------------------------------
        private void ProcessMessage(string message)
        {
            int intReading;
            bool isNumber = int.TryParse(message, out intReading);
            if (isNumber == true)
            {
                if (intReading >= _maxADCValue) intReading = (int)_maxADCValue - 1;

                _readings[_pointer] = (UInt16)intReading;

                // No need for the Mutex, because we writing data in this thread only
                //_histogrgamMutex.WaitOne();

                if (_histogram[intReading] < 0xFFFFFFFF) _histogram[intReading]++;

                // Cyclic array
                _pointer++;
                if (_pointer >= (_maxADCValue * readingsFactor)) _pointer = 0;

                UInt16 lastBufferedValue = _readings[_pointer];
                if (_histogram[lastBufferedValue] > 0) _histogram[lastBufferedValue]--;

                //_histogrgamMutex.ReleaseMutex();

                _errorsCount = 0;
                _dataError = false;
            }
            else
            {
                // Search for kyewords
                float floatReading;
                if (message.IndexOf(vRefMarkerString, 0, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    isNumber = float.TryParse(message.Substring(message.IndexOf('\t') + 1), NumberStyles.Any, CultureInfo.InvariantCulture, out floatReading);
                    if (isNumber)
                    {
                        _vRef = floatReading;
                    } else
                    {
                        _vRef = 0.0F;
                    }
                    RunTheMethod(UpdateVrefValue);
                }
                else
                if (message.IndexOf(averageMarkerString, 0, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    isNumber = float.TryParse(message.Substring(message.IndexOf('\t') + 1), NumberStyles.Any, CultureInfo.InvariantCulture, out floatReading);
                    if (isNumber)
                    {
                        _averageADCValue = floatReading;
                    } else
                    {
                        _averageADCValue = 0.0F;
                    }
                    RunTheMethod(UpdateAverageValue);
                }
                else
                if (message.IndexOf(adcResMarkerString, 0, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    intReading = _resolution;
                    isNumber = int.TryParse(message.Substring(message.IndexOf('\t') + 1), NumberStyles.Any, CultureInfo.InvariantCulture, out intReading);
                    if (isNumber)
                    {
                        if (intReading > maxADCResolution)
                        {
                            Console.WriteLine("Wrong ADC resolution selected by the MCU: {0}. The maximum allowed resolution will be used: {1}", intReading, maxADCResolution);
                            intReading = maxADCResolution;
                        }
                        if ((intReading != _resolution) && (intReading > 0))
                        {
                            // If the MCU has selected a new ADC resolution, we must allocate new buffers and reset the counter

                            _histogrgamMutex.WaitOne();

                            _resolution = (byte)intReading;
                            _maxADCValue = (UInt32)(1 << _resolution);
                            _readings = new UInt16[_maxADCValue * readingsFactor];
                            _histogram = new UInt32[_maxADCValue];

                            _pointer = 0;

                            _histogrgamMutex.ReleaseMutex();

                            RunTheMethod(UpdateResolutionValue);
                        }
                    }
                }
                else
                {
                    if (_errorsCount < maxErrorsCount)
                    {
                        _errorsCount++;
                    } else
                    {
                        _dataError = true;
                    }
                    Console.WriteLine(message);
                }
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Parse messages by the LF character
        //--------------------------------------------------------------------------------------------------------------------------
        private void Port_OnReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;

            int i = 0;
            int firstByte = 0;
            int lastByte = _position + port.Read(_buffer, _position, serialBufferSize - _position);
            byte previousByte = 0;
            do {

                byte currentByte = _buffer[i];

                // Search for End-of-String ignoring UTF-8 additional octets
                if (((char)currentByte == '\n') && ((previousByte & 0b10000000) == 0))
                {
                    // Ignore LF
                    byte removeLast = 0;
                    if (previousByte == '\r') removeLast = 1;
                    // Decode and process message
                    string receivedString = System.Text.Encoding.UTF8.GetString(_buffer, firstByte, i - firstByte - removeLast);
                    if (!_justConnected)
                    {
                        ProcessMessage(receivedString);
                    } else
                    {
                        _justConnected = false;
                    }
                    firstByte = i + 1;
                }

                previousByte = currentByte;
                i++;

            } while (i < lastByte);

            // Copy an incomplete message to the beginning of the buffer for later processing
            int bytesLeft = lastByte - firstByte;
            if ((bytesLeft > 0) && (firstByte > 0))
            {
                for (i = 0; i < bytesLeft; i++) _buffer[i] = _buffer[i + firstByte];
            }
            _position = bytesLeft;

            if (_position >= (serialBufferSize - 1))
            {
                _position = 0;
                _dataError = true;
                Console.WriteLine("Read buffer overflow. The buffer has been flushed.");
            }

        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Connect Button click event
        //--------------------------------------------------------------------------------------------------------------------------
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text.Equals(connectString))
            {
                ConnectPort();
            } else
            {
                DisconnectPort();
            }
            connectButton.BackColor = SystemColors.Control;
            _errorDisplayed = false;
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Radio Button click event
        //--------------------------------------------------------------------------------------------------------------------------
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (valuesRadioButton.Checked)
            {
                _displayVoltages = false;
                _displayMillivolts = false;
            } else
            {
                _displayVoltages = true;
                if (millivoltsRadioButton.Checked)
                {
                    _displayMillivolts = true;
                } else
                {
                    _displayMillivolts = false;
                }
            }
            histogramChart.Series[0].Points.Clear();
            UpdateAverageValue();
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Export Button click event
        //--------------------------------------------------------------------------------------------------------------------------
        private void exportImageButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PNG files (*.png)|*.png";
            saveFileDialog.Title = "Save an Image File";
            // saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            // Unfortunately, the label drawn in the Port_OnReceiveData method will not be saved. You can experiment with the RectangleAnnotation for the better results.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                histogramChart.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Chart Paint event - draw Label with the calibrated average value
        //--------------------------------------------------------------------------------------------------------------------------
        private void histogramChart_Paint(object sender, PaintEventArgs e)
        {
            if (_averageADCValue > 0.0)
            {
                string displayString = _averageValue.ToString(shortFloatDisplayFormat);
                SizeF stringSize = e.Graphics.MeasureString(displayString, Font);

                float gap = stringSize.Height / 4.0F;
                ChartArea ca = histogramChart.ChartAreas[0];
                float px = (float)ca.AxisX.ValueToPixelPosition(_averageValue) - stringSize.Width / 2.0F;
                float py = (float)ca.AxisY.ValueToPixelPosition(ca.AxisY.Maximum);

                // Draw background and text
                e.Graphics.FillRectangle(Brushes.Red, (px - gap), py, stringSize.Width + gap * 2.0F, stringSize.Height + gap * 2.0F);
                e.Graphics.DrawString(displayString, Font, Brushes.White, px, py + gap);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Timer event (update chart)
        //--------------------------------------------------------------------------------------------------------------------------
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            RunTheMethod(UpdateChart);
        }


        //--------------------------------------------------------------------------------------------------------------------------
        //  Cleanup before closing
        //--------------------------------------------------------------------------------------------------------------------------
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _updateTimer.Elapsed -= OnTimedEvent;
            DisconnectPort();
            // Because of "catch" in RunTheMethod it os not necessary to process events after disabling Port and Timer, but I leave it here just for the case.
            Application.DoEvents();
        }

    }
}

// END-OF-FILE
