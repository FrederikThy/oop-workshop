namespace Physical;

public class SetPoint : Device
{
    public SetPoint(string type, string media, string unit,string modality, Room room, int deviceChannel)
    {
        this.type = type;
        this.media = media;
        this.unit = unit;
        this.modality = modality;
        this.room = room;
        this.deviceChannel = deviceChannel;
    }
    
    public double GetSetPoint(ISet<Channel> channels, int i)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == deviceChannel && type == "Setpoint")
            {
                return channel.Samples[i].value;
            }
            else if (modality != "Temperature")
            {
                return 0.0;
            }
        }
        return 0.0;
    }
    
}