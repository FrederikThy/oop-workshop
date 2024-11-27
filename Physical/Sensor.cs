namespace Physical;

public class Sensor : Device
{
    public Sensor(string type, string media, string unit,string modality)
    {
        this.type = type;
        this.media = media;
        this.unit = unit;
        this.modality = modality;
    }
    
    
}