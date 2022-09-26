//#include <LedControl.h>
#include <Servo.h>


#define echoPin 2 
#define trigPin 3

long duration;
int distance;

//int DIN = 8; 
//int CS =  9;
//int CLK = 10;

int pos = 0;

//LedControl lc = LedControl(DIN,CLK,CS,0);
Servo myservo;
//
//byte a[8] = {0xA5,0x42,0xA5,0x00,0x00,0x85,0x42,0xA5,};
//byte b[8] = {0x18,0x18,0x18,0xFF,0xFF,0x18,0x18,0x18,};
//byte c[8] = {0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,};

void setup() 
{
  myservo.attach(6);
  myservo.write(pos);
//  lc.shutdown(0,false);       //The MAX72XX is in power-saving mode on startup
//  lc.setIntensity(0,5);       // Set the brightness to maximum value
//  lc.clearDisplay(0);          // and clear the display

  pinMode(trigPin, OUTPUT); // Sets the trigPin as an OUTPUT
  pinMode(echoPin, INPUT); // Sets the echoPin as an INPUT
  Serial.begin(9600); // // Serial Communication is starting with 9600 of baudrate speed

  
}

void loop() 
{
  // Clears the trigPin condition
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  // Sets the trigPin HIGH (ACTIVE) for 10 microseconds
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(2);
  digitalWrite(trigPin, LOW);
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(echoPin, HIGH);
  // Calculating the distance
  distance = duration * 0.034 / 2; // Speed of sound wave divided by 2 (go and back)
  // Displays the distance on the Serial Monitor
  Serial.print("Distance: ");
  Serial.print(distance);
  Serial.println(" cm");


  if(distance > 20)
  {
    myservo.write(pos);
  }
  else
  {
    myservo.write(200);
    distance = 0;
    delay(1000000);
  }
}

//void printByte(byte character []) 
//{
//
//  int i = 0;
//    for(i=0;i<8;i++)
//    {
//      lc.setRow(0,i,character[i]);
//    }
//
//}
