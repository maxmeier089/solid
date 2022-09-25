using OwnBrandCeilingLight;
using ExternalBrandFloorLamp;
using OwnBrandMultiSensor;
using OwnBrandMotionSensor1;
using OwnBrandMotionSensor2;
using OwnBrandSoundSensor;
using ExternalBrandSoundSensor;

CeilingLight ceilingLight = new();
ceilingLight.TurnOn();
ceilingLight.TurnOff();

FloorLamp floorLamp = new();
floorLamp.Status = true;
floorLamp.Status = false;

MultiSensor multiSensor = new();
MotionSensor1 motionSensor1 = new();
MotionSensor2 motionSensor2 = new();
SoundSensor soundSensor = new();
ExternalSoundSensor soundSensor2 = new();

while (true)
{
    Console.WriteLine("Multi Sensor (Motion): " + multiSensor.GetMotionActivity());
    Console.WriteLine("Multi Sensor (Sound): " + multiSensor.GetSoundActivity());
    Console.WriteLine("Motion Sensor 1: " + motionSensor1.GetMotionActivity());
    Console.WriteLine("Motion Sensor 2: " + motionSensor2.GetMotionActivity());
    Console.WriteLine("Sound Sensor: " + soundSensor.GetSoundActivity());
    Console.WriteLine("External Sound Sensor: " + soundSensor2.ReadSoundLevel());
    Console.WriteLine();

    Thread.Sleep(500);
}