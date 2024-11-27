namespace Physical;

using System.Globalization;

public class History {
  enum ParseState {
    Metadata,
    Samples
  }
  
  ISet<Channel> channels = new HashSet<Channel>();
  
  public History (string directory) {
    string[] files = Directory.GetFiles(directory);
    foreach (string filename in files) {
      Channel? channel = Load(filename);
      if (channel!=null) channels.Add(channel);
    }
  }
  
  Channel? Load (string filename) {
    StreamReader sr = new StreamReader(filename);
    
    ParseState state = ParseState.Metadata;
    string? line;
    int i = 0;
    IDictionary<string,string> metadata = new Dictionary<string,string>();
    IList<Sample>              samples  = new List<Sample>();
    while ((line = sr.ReadLine()) != null) {
      i++;
      switch (state) {
        case ParseState.Metadata:
          if (line.Length==0) {
            state = ParseState.Samples;
          } else {
            string[] mparts = line.Split(":");
            if (mparts.Length != 2) throw new Exception("Metadata parse error at "+filename+":"+i);
            metadata.Add(mparts[0], mparts[1]);
          }
          break;
        case ParseState.Samples:
          if (line.Length==0) continue;
          string[] sparts = line.Split(" ");
          if (sparts.Length != 2) throw new Exception("Sample parse error at "+filename+":"+i);
          samples.Add(new Sample(int.Parse(sparts[0]), double.Parse(sparts[1], CultureInfo.InvariantCulture)));
          break;
        default:
          throw new Exception("Error parsing '"+filename+"'");
      }
    }
    
    sr.Close();
    return new Channel(metadata, samples);
  }
  
  public ISet<Channel> GetChannels () {
    return channels;
  }
  
  public void Replay () {
    // find temporal boundaries
    int? tmin = null;
    int? tmax = null;
    foreach (Channel channel in channels) {
      int channel_min = channel.Samples[0].time;
      int channel_max = channel.Samples[channel.Samples.Count-1].time;
      
      if (tmin==null || channel_min<tmin) tmin = channel_min;
      if (tmax==null || channel_max<tmax) tmax = channel_max;
    }
    
    if (tmin==null || tmax==null) throw new Exception("Timeline is empty");
    
    // step through the timeline
    for (int t=(int)tmin ; t<=tmax ; t++) {
      foreach (Channel channel in channels) channel.Tick(t);
    }
  }
  
  public void PrettyPrint () {
    Console.WriteLine("History:");
    int channel_i = 0;
    foreach (Channel channel in channels) {
      channel_i++;
      Console.WriteLine("- Channel "+channel_i+":");
      Console.WriteLine("  - Metadata:");
      foreach (string key in channel.Metadata.Keys) {
        Console.WriteLine("    - '"+key+"' ↦ '"+channel.Metadata[key]+"'");
      }
      Console.WriteLine("  - Samples:");
      foreach (Sample sample in channel.Samples) {
        Console.WriteLine("    - At time "+sample.time+": "+sample.value);
      }
    }
  }
}
