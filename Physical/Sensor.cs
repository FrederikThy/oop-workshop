namespace Physical;

public class Sensor : Device
{
    public Sensor(string type, string media, string unit,string modality, Room room, int deviceChannel)
    {
        this.type = type;
        this.media = media;
        this.unit = unit;
        this.modality = modality;
        this.room = room;
        this.deviceChannel = deviceChannel;
    }

    public void LightSensor(Room room, ISet<Channel> channels)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == deviceChannel && type == "Sensor")
            {
                foreach (Sample sample in channel.Samples)
                {
                    Console.WriteLine(sample.value);
                }
            }
            else if (modality != "Light")
            {
                Console.WriteLine("This sensor is not a temperature sensor");
                break;
            }
        }
    }

    public void OccupancySensor(Room room, ISet<Channel> channels)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == deviceChannel && type == "Sensor")
            {
                foreach (Sample sample in channel.Samples)
                {
                    Console.WriteLine(sample.value);
                }
            }
            else if (modality != "Occupancy")
            {
                Console.WriteLine("This sensor is not a temperature sensor");
                break;
            }
        }
    }

    public void ElectricitySensor(Room room, ISet<Channel> channels)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == deviceChannel && type == "Sensor")
            {
                foreach (Sample sample in channel.Samples)
                {
                    Console.WriteLine(sample.value);
                }
            }
            else if (modality != "Electricity")
            {
                Console.WriteLine("This sensor is not a temperature sensor");
                break;
            }
        }
    }
    public double TempSensor(ISet<Channel> channels, int i)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == deviceChannel && type == "Sensor")
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