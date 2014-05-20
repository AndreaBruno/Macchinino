//L'esc ha al suo interno un controllo che evita di andare in retromarcia velocemente, per sbaglio

//PIEDINATURA ARDUINO
//11 led verde
//12 led giallo
//9 esc
//6 servo1
//5 servo2


//CAMBIARE PIN SERIALE CON SOFTWARE SERIAL

#include <Servo.h>

#define MAX_ACC 150
#define MID_ACC 90
#define MIN_ACC 50
#define MAX_DIR 138
#define MID_DIR 98
#define MIN_DIR 58
#define LED_IN 13  //GIALLO
#define LED_CONN 12 //VERDE
#define LED_OK 11  //GIALLO
#define SERVO 6
#define ESC 9

Servo esc;
Servo servo;
boolean conn= false;
char vett[4];
int index = 0;
int interval = 500; //intervallo entro cui si deve ricevere un comando 
unsigned long prev_timer = 0;


void setup() {
  pinMode(LED_CONN, OUTPUT);
  pinMode(LED_OK, OUTPUT);
  pinMode(LED_IN, OUTPUT);
  digitalWrite(LED_CONN, LOW); //VERDE
  digitalWrite(LED_OK, LOW); //GIALLO
  digitalWrite(LED_IN, LOW);
  delay(3000);
  esc.attach(ESC);
  servo.attach(SERVO);
  //inizializziamo il servo
  digitalWrite(LED_CONN, HIGH);
  esc.write(MID_ACC);
  servo.write(MID_DIR);
  delay(20000);
  digitalWrite(LED_OK, HIGH);
  Serial.begin(9600); 
}

void loop() {
  unsigned long timer = millis();
  if (timer - prev_timer > interval) {
    vett[0] = 'A';
    vett[1] = '5';
    vett[2] = 'D';
    vett[3] = '5';
    index = 4;
    prev_timer = timer;
  }


  if (Serial.available() > 0) {

    char input =Serial.read();
    if (input != '\n' && input != '\r') {
      vett[index] = input;
      index++;
      //Serial.println(input);
    }
  }
  //controlli caratteri sbagliati

  if(index == 4)
  {
    prev_timer = timer;
    digitalWrite(LED_IN, HIGH);

    digitalWrite(LED_CONN, LOW);
    digitalWrite(LED_OK, HIGH);

    char num = vett[1];
    //per convertirlo in itn bisogna fare il cast e -48
    if(num == '1') servo.write(58);
    else if(num == '2') servo.write(68);
    else if(num == '3') servo.write(78);
    else if(num == '4') servo.write(88);
    else if(num == '5') servo.write(98);
    else if(num == '6') servo.write(108);
    else if(num == '7') servo.write(118);
    else if(num == '8') servo.write(128);
    else if(num == '9') servo.write(138);
    delay(15);

    digitalWrite(LED_OK, LOW);
    digitalWrite(LED_CONN, HIGH);

    num = vett[3];
    if(num == '1') esc.write(50);
    else if(num == '2') esc.write(60);
    else if(num == '3') esc.write(70);
    else if(num == '4') esc.write(80);
    else if(num == '5') esc.write(90);
    else if(num == '6') esc.write(100);
    else if(num == '7') esc.write(110);
    else if(num == '8') esc.write(130);
    else if(num == '9') esc.write(140); 
    delay(15);    
    index = 0;
  }
}





