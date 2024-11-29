namespace Physical;

public class Actuator : Device
{
    public Actuator(string type, string media, string unit,string modality)
    {
        this.type = type;
        this.media = media;
        this.unit = unit;
        this.modality = modality;
    }

    public void SetTemperature(Sensor sensor,SetPoint setPoint,ISet<Channel> channels)
    {
        List<double> sensorSamples = new List<double>();
        List<double> setPointSamples = new List<double>();

        for (int i = 0; i < 30; i++)
        {
            setPointSamples.Add(setPoint.GetSetPoint(channels,i));
            sensorSamples.Add(sensor.TempSensor(channels,i));
        }
            
        
        for (int i = 0; i < 30; i++)
            if (sensorSamples[i] > setPointSamples[i])
            {
                Console.WriteLine("Skru ned");
            }
            else if (sensorSamples[i] < setPointSamples[i])
            {
                Console.WriteLine("Skru op");
            }
            else
            {
                Console.WriteLine("Perfekt!");
            }
    }
}