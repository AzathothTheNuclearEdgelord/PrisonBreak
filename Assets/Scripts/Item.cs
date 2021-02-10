public abstract class Item{
    // Properties
    public string name{ get; private set; }
    public float weight{ get; private set; }


    // Constructor
    public Item(string name, float weight){
        this.name = name;
        this.weight = weight;
    }

    // Example of polymorphism
    //
    // public Item(float weight){
    //    name = "Unnamed";
    //    this.weight = weight;
    // }
}