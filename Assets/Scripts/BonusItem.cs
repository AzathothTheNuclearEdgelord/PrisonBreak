public class BonusItem : Item{
    public int points{ protected set; get; }

    public BonusItem(string name, float weight, int points) : base(name, weight){
        this.points = points;
    }
}
