public class BonusItem : Item{
    public int points{ get; private set; }

    public BonusItem(string name, float weight, int points) : base(name, weight){
        this.points = points;
    }
}
