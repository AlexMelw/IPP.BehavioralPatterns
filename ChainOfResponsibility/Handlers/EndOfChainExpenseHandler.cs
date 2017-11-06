namespace ChainOfResponsibilityAppliance.Handlers
{
    using System;
    using Enums;
    using Interfaces;

    class EndOfChainExpenseHandler : IExpenseHandler
    {
        private static readonly Lazy<EndOfChainExpenseHandler> LazyInstance =
            new Lazy<EndOfChainExpenseHandler>(() => new EndOfChainExpenseHandler(), true);

        public static EndOfChainExpenseHandler Default => LazyInstance.Value;

        #region CONSTRUCTORS

        private EndOfChainExpenseHandler() { }

        #endregion

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            return ApprovalResponse.Denied;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            throw new InvalidOperationException($"{nameof(EndOfChainExpenseHandler)} must be the end of the chain!");
        }
    }
}