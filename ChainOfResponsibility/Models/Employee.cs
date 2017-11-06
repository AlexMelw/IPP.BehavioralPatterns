namespace ChainOfResponsibilityAppliance.Models
{
    using Enums;
    using Interfaces;

    public class Employee : IExpenseApprover
    {
        private readonly decimal _approvalLimit;

        public string Name { get; }

        #region CONSTRUCTORS

        public Employee(string name, decimal approvalLimit)
        {
            Name = name;
            _approvalLimit = approvalLimit;
        }

        #endregion

        public ApprovalResponse ApproveExpense(IExpenseReport expenseReport)
        {
            return expenseReport.Total > _approvalLimit
                ? ApprovalResponse.BeyondApprovalLimit
                : ApprovalResponse.Approved;
        }
    }
}