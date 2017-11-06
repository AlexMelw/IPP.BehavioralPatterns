namespace ChainOfResponsibilityAppliance
{
    using System;
    using Enums;
    using Handlers;
    using Helpers;
    using Interfaces;
    using Models;

    class Approval
    {
        static void Main()
        {
            #region Initialize ExpenseHandlers

            // Assuming that Antohi Ionel needs reimbursement for his antiplagiat system
            var antohiIonel = new ExpenseHandler(new Employee("Antohi Ionel [Teacher]", decimal.Zero));

            var ciorbaDumitru = new ExpenseHandler(new Employee(
                @"Ciorba Dumitru [Head of the Department of Software Engineering and Automatics]",
                1000M));

            var ionBalmus = new ExpenseHandler(new Employee(
                "Ion Balmus [Dean of the Faculty of Computers, Informatics and Microelectronics]",
                5000M));

            var viorelBostan = new ExpenseHandler(new Employee("Viorel Bostan [Rector of TUM]", 20000M));

            #endregion

            #region Build Handlers Chain

            antohiIonel.RegisterNext(ciorbaDumitru);
            ciorbaDumitru.RegisterNext(ionBalmus);
            ionBalmus.RegisterNext(viorelBostan);

            #endregion

            if (ConsoleInput.TryReadDecimal("Expense report amount:", out decimal expenseReportAmount))
            {
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);

                ApprovalResponse response = antohiIonel.Approve(expense);

                Console.WriteLine("The request was {0}.", response);
            }
        }
    }
}