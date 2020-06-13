namespace CleanCode.SwitchStatements
{
    //Open Closed Principle
    //Software must be Open for extension
    //Close for modification
    //Polymorfism instead of using Switch statements
    //Generate one generic customer class and their derivative ones
    //Set the switch logic inside each derivative class
    //moving Generate method to 'MonthlyUsage' class
    public class MonthlyStatement
    {
        public float CallCost { get; set; }
        public float SmsCost { get; set; }
        public float TotalCost { get; set; }
    }
}