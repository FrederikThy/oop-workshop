namespace Physical;

public class Sample {
  public int    time;
  public double value;
  
  public Sample (int time, double value) {
    this.time  = time;
    this.value = value;
  }
  
  public override string ToString () {
    return "sample("+time+"→"+value+")";
  }
}
