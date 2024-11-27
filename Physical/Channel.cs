namespace Physical;

public class Channel {
  IList<IChannelSubscriber>  subscribers = new List<IChannelSubscriber>();
  public IDictionary<string,string> Metadata { get; set; }
  public IList<Sample>              Samples { get; set; }
  
  public Channel (IDictionary<string,string> metadata, IList<Sample> samples) {
    Metadata = metadata;
    Samples  = samples;
  }
  
  public void Subscribe (IChannelSubscriber client) {
    subscribers.Add(client);
  }
  
  public void Unsubscribe (IChannelSubscriber client) {
    subscribers.Remove(client);
  }
  
  public void Tick (int time) {
    bool published = false;
    
    foreach (Sample sample in Samples) {
      if (sample.time == time) {
        Publish(sample);
        published = true;
        break;
      }
    }
    
    if (!published) Publish(null);
  }
  
  private void Publish (Sample? sample) {
    foreach (IChannelSubscriber subscriber in subscribers) {
      subscriber.NewSample(this, sample);
    }
  }
}
