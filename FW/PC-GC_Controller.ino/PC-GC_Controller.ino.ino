/*Uses the Nintendo library by Nicohood.*/
#include <Nintendo.h>

//This makes the controller bidirection data line on pin number 17.
CGamecubeConsole GamecubeConsole(17);      //Define a pin for sending data to the GameCube (connect the 'data' wire here).
Gamecube_Data_t d = defaultGamecubeData;   //Structure for data to be sent to console.

//This is needed but you don't have to connect anything to this pin.
CGamecubeController GamecubeController1(15);

//Reference the GameCube controller port pinout and connect Data, 3.3v and Ground. The remaining wires are not needed.


byte Input[] = {0,0,128,128,128,128,0,0};

void setup()
{
  Serial.begin(9600);

  //This is needed to run the code.
  GamecubeController1.read();

  Serial.setTimeout(1);
  while (!Serial) {}
}

void loop()
{
  /*while (Serial.available() < 2) {
    Serial.write("a");
  }*/
  //while (Serial.available() > 6) Serial.read();
  //Serial.readBytesUntil(0xff, bInput, 3);
  //while (Serial.available() <2) {}
  Serial.readBytes(Input, 8);
  Serial.print("a");
  byte bInput[] = {
    Input[0],
    Input[1],
    Input[2],
    Input[3],
    Input[4],
    Input[5],
    Input[6],
    Input[7]};
  
  //Reports data.
  d.report.a = (int)bInput[0] % 2;
  bInput[0] = bInput[0] >> 1;
  GamecubeConsole.write(d);
  d.report.b = (int)bInput[0] % 2;
  bInput[0] = bInput[0] >> 1;
  GamecubeConsole.write(d);
  d.report.x = (int)bInput[0] % 2;
  bInput[0] = bInput[0] >> 1;
  GamecubeConsole.write(d);
  d.report.y = (int)bInput[0] % 2;
  bInput[0] = bInput[0] >> 1;
  GamecubeConsole.write(d);
  d.report.z = (int)bInput[0] % 2;
  bInput[0] = bInput[0] >> 1;
  GamecubeConsole.write(d);
  d.report.start = (int)bInput[0] % 2;
  bInput[0] = bInput[0] >> 1;
  GamecubeConsole.write(d);
  d.report.r = (int)bInput[0] % 2;
  bInput[0] = bInput[0] >> 1;
  GamecubeConsole.write(d);
  d.report.l = (int)bInput[0] % 2;
  GamecubeConsole.write(d);
  
  d.report.dleft = (int)bInput[1] % 2;
  bInput[1] = bInput[1] >> 1;
  GamecubeConsole.write(d);
  d.report.dright = (int)bInput[1] % 2;
  bInput[1] = bInput[1] >> 1;
  GamecubeConsole.write(d);
  d.report.dup = (int)bInput[1] % 2;
  bInput[1] = bInput[1] >> 1;
  GamecubeConsole.write(d);
  d.report.ddown = (int)bInput[1] % 2;
  bInput[1] = bInput[1] >> 1;
  GamecubeConsole.write(d);
  bInput[1] = bInput[1] >> 1;
  if ((bool)bInput[1] %2) return;
  
  d.report.xAxis = (int)bInput[2];
  GamecubeConsole.write(d);
  d.report.yAxis = (int)bInput[3];
  GamecubeConsole.write(d);
  d.report.cxAxis = (int)bInput[4];
  GamecubeConsole.write(d);
  d.report.cyAxis = (int)bInput[5];
  GamecubeConsole.write(d);
  d.report.left = (int)bInput[6];
  GamecubeConsole.write(d);
  d.report.right = (int)bInput[7];
  GamecubeConsole.write(d);
}
