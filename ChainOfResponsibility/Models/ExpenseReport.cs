namespace ChainOfResponsibilityAppliance.Models
{
    using Interfaces;

    public class ExpenseReport : IExpenseReport
    {
        #region CONSTRUCTORS

        public ExpenseReport(decimal total)
        {
            Total = total;
        }

        #endregion

        public decimal Total { get; }
    }
}