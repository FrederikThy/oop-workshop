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
Console.WriteLine("Hello, World!");

Room room1 = new Room(1,1,"White House",4);

Sensor room1TempSensor = new Sensor("Temp","Air","Celsius","Temperature",room1);
room1TempSensor.TempSensor(room1,channels);

Console.WriteLine(channels.Count);



class DemoConsumer : IChannelSubscriber {
  public void NewSample (Channel channel, Sample? sample) {
    Console.WriteLine("Got "+sample);
  }
}

