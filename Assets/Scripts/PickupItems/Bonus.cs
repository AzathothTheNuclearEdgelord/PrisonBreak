public class Bonus : Pickup
{
    public int points;

    public override Item CreateItem(){
        return new BonusItem(itemName, weight, points);
    }
}
