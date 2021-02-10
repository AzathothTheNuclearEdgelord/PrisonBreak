public abstract class Item{
    // Properties
    public string name{ get; private set; }
    public float weight{ get; private set; }
    // public int itemId{ get; private set; }


    // Constructor
    public Item(string name, float weight){
        this.name = name;
        this.weight = weight;
        // itemId = int
    }

    // Example of polymorphism
    //
    // public Item(float weight){
    //    name = "Unnamed";
    //    this.weight = weight;
    // }
}