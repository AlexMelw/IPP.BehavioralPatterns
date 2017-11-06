namespace ChainOfResponsibilityAppliance.Interfaces
{
    using Enums;

    public interface IExpenseApprover
    {
        ApprovalResponse ApproveExpense(IExpenseReport expenseReport);
    }
}