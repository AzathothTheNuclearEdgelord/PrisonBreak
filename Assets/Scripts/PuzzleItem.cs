public class PuzzleItem : Item{
    public string riddle{ get; private set; }
    public string answer{ get; private set; }
    public bool solved{ get; private set; }
    
    public PuzzleItem(string name, float weight, string riddle, string answer) : base(name, weight){
        this.answer = answer;
        this.riddle = riddle;
        solved = false;
    }

    public bool SolvesRiddle(string input){
         solved = (input == answer);
         return solved;
    }
    
}
