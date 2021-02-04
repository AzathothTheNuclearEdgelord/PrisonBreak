public class AccessItem : Item{
    public int doorId{ get; private set; }

    public AccessItem(string name, float weight, int doorId) : base(name, weight){
        this.doorId = doorId;
    }

    public bool OpensDoor(int id){
        return doorId == id;
    }

}
