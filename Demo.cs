using Physical;

// load history
History hist = new History("data");
hist.PrettyPrint();

// register consumers for events
ISet<Channel> channels = hist.GetChannels();
foreach (Channel channel in channels) {
  channel.Subscribe(new DemoConsumer());
}

// step through timeline
hist.Replay();

class DemoConsumer : IChannelSubscriber {
  public void NewSample (Channel channel, Sample? sample) {
    Console.WriteLine("Got "+sample);
  }
}

