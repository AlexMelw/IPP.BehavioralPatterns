namespace ChainOfResponsibilityAppliance.Handlers
{
    using Enums;
    using Interfaces;



    class ExpenseHandler : IExpenseHandler
    {
        private readonly IExpenseApprover _approver;
        private IExpenseHandler _next;

        #region CONSTRUCTORS

        public ExpenseHandler(IExpenseApprover expenseApprover)
        {
            _approver = expenseApprover;

            // Null object pattern
            _next = EndOfChainExpenseHandler.Default;
        }

        #endregion

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            ApprovalResponse response = _approver.ApproveExpense(expenseReport);

            if (response == ApprovalResponse.BeyondApprovalLimit)
            {
                return _next.Approve(expenseReport);
            }

            return response;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            _next = next;
        }
    }
}