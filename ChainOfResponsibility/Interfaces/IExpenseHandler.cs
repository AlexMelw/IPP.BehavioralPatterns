namespace ChainOfResponsibilityAppliance.Interfaces
{
    using Enums;

    interface IExpenseHandler
    {
        ApprovalResponse Approve(IExpenseReport expenseReport);
        void RegisterNext(IExpenseHandler next);
    }
}