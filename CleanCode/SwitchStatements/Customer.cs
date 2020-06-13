namespace CleanCode.SwitchStatements
{
    //Replace the switch statements with polymorfism dispatch
    public abstract class Customer
    {
        public abstract MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage);
    }
}