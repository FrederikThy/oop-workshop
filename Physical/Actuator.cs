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

    public int SetTemperature(Sensor sensor,SetPoint setPoint)
    {
        int temperature = 0;
        return temperature;
    }
}