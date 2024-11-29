namespace Physical;

public class Room : Floor
{ 
    public int room;
    public int channel;

    public Room(int room, int floor, string building, int channel)
    {
        this.room = room;
        this.floor = floor;
        this.building = building;
        this.channel = channel;
    }
}