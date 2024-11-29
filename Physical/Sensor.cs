namespace Physical;

public class Sensor : Device
{
    public Sensor(string type, string media, string unit,string modality, Room room)
    {
        this.type = type;
        this.media = media;
        this.unit = unit;
        this.modality = modality;
        this.room = room;
    }

    public void LightSensor(Room room, ISet<Channel> channels)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == room.channel && type == "light")
            {
                foreach (Sample sample in channel.Samples)
                {
                    Console.WriteLine(sample.value);
                }
            }
            else
            {
                Console.WriteLine("This sensor is not a light sensor");
                break;
            }
        }
    }

    public void TempSensor(Room room, ISet<Channel> channels)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == room.channel && type == "Temp")
            {
                foreach (Sample sample in channel.Samples)
                {
                    Console.WriteLine(sample.value);
                }
            }
            else
            {
                Console.WriteLine("This sensor is not a temperature sensor");
                break;
            }
        }
    }

    public void OccupancySensor(Room room,ISet<Channel> channels)
    {
        int channel_i = 0;
        foreach (Channel channel in channels)
        {
            channel_i++;
            if (channel_i == room.channel && type == "Occupancy")
            {
                foreach (Sample sample in channel.Samples)
                {
                    Console.WriteLine(sample.value);
                }
            }
            else
            {
                Console.WriteLine("This sensor is not an occupancy sensor");
                break;
            }
        }
    }

    public void ElectricitySensor(Room room)
    {
        Console.WriteLine("ElectricitySensor");
    }
    
}