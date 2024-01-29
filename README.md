<h1>Features</h1>

- Real-time histogram plotting.
- Supports up to 16-bit resolution ADC.
- If the reference voltage is known, it can display values in volts or millivolts.
- The ability to save the histogram in PNG.
<br /><br />

<img width="764" alt="STH" src="https://github.com/DmitryMuravyev/Serial-To-Histogram/assets/152902525/cf2287d2-7d39-48b5-9573-0647da4b0204">

<h1>Details</h1>

A very simple application for plotting a histogram based on data from the serial port. It can be used to estimate the noise level of the ADC or to study the distribution of any other values. The application is written in .NET/Winforms (Visual Studio), because Winforms has a standard Control element (Chart) that allows to build such diagrams.
<br /><br />
<img width="764" alt="STH_mV" src="https://github.com/DmitryMuravyev/Serial-To-Histogram/assets/152902525/ce7fc65b-675a-4a28-9da1-602379ec40f5">
<br /><br />
To plot a histogram, it is necessary that the device (microcontroller or any other) sends strings containing integers and ending with the symbol LF ('\n') to the application via the serial port. This can be done, for example, using the following code (here and below are examples for the Arduino IDE):

```C
  uint16_t currentValue = analogRead(analogPin);
  Serial.println(currentValue);
```

Your device can also transfer additional data to the application using keywords and values separated by tabs ('\t'). Below is a list of parameters, keywords (case does not matter) and types of values to transmit:

Keyword | Type  | Comment
--------|-------|---------------------------------------------------------------------------------------------
Vref    | Float | The ADC reference voltage used for display in volts or millivolts.
Average | Float | Calibrated average value of the ADC readings, displayed as a vertical line on the histogram.
ADCRes  | Int   | ADC resolution (1-16 bits).


These parameters can be transmitted once or repeated periodically with some interval. E.g. for Arduino, the source code might look like this:

```C
void loop() {
  // put your main code here, to run repeatedly:

  Serial.print("Vref:\t");
  Serial.println(vRef, 4);
  
  Serial.print("Average:\t");
  Serial.println(averageValue, 8);

  Serial.print("ADCres:\t");
  Serial.println("10");

  for (uint32_t i = 0; i < NUMBER_OF_POLL_STEPS; i++) {

    uint16_t currentValue = analogRead(analogPin);
    Serial.println(currentValue);
    
  }

}
```

Feel free making changes to the source code to fix bugs and add more features.
