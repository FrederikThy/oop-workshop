namespace Physical;

public interface IChannelSubscriber {
  // called whenever an event is replayed
  void NewSample (Channel channel, Sample? sample);
}
