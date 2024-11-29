using Physical;

// load history
History hist = new History("C:\\Users\\madsp\\RiderProjects\\oop-workshop\\data");
hist.PrettyPrint();

// register consumers for events
ISet<Channel> channels = hist.GetChannels();
foreach (Channel channel in channels) {
  channel.Subscribe(new DemoConsumer());
}

// step through timeline
hist.Replay();

// Main method starts here
Room room1 = new Room(1,1,"White House");

Sensor room1TempSensor = new Sensor("Sensor","Air","Celsius","Temperature",room1,4);
SetPoint room1SetPoint = new SetPoint("Setpoint","Air","Celsius","Temperature",room1,5);
Actuator actuator = new Actuator("Actuator","Air","Celsius","Temperature");

actuator.SetTemperature(room1TempSensor, room1SetPoint,channels);

class DemoConsumer : IChannelSubscriber {
  public void NewSample (Channel channel, Sample? sample) {
    Console.WriteLine("Got "+sample);
  }
}

