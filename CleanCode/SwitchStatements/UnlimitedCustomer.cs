namespace CleanCode.SwitchStatements
{
    public class UnlimitedCustomer : Customer
    {
        public override MonthlyStatement GenerateStatement(MonthlyUsage monthlyUsage)
        {
            var statement = new MonthlyStatement();
            statement.TotalCost = 54.9f;
            return statement;
        }
    }
}