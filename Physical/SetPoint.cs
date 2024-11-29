namespace Physical;

public class SetPoint : Device
{
    public SetPoint(string type, string media, string unit,string modality)
    {
        this.type = type;
        this.media = media;
        this.unit = unit;
        this.modality = modality;
    }

    public double GetSetPoint()
    {
        double setpoint = 0;
        //Code that sets the setpoint to a value
        
        return setpoint;
    }
    
}