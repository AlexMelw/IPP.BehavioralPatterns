namespace ChainOfResponsibilityAppliance
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Enums;
    using Handlers;
    using Helpers;
    using Interfaces;
    using Models;

    // Chain of Responsibility + Adapter + Null Object Pattern + Singleton

    class Approval
    {
        static void Main()
        {
            #region Initialize ExpenseHandlers

            // Assuming that Antohi Ionel needs reimbursement for his antiplagiat system
            var antohiIonel = new ExpenseHandler(new UniversityEmployee(
                "Antohi Ionel [Teacher]", decimal.Zero));

            var ciorbaDumitru = new ExpenseHandler(new UniversityEmployee(
                @"Ciorba Dumitru [Head of the Department of Software Engineering and Automatics]",
                5_000M));

            var ionBalmus = new ExpenseHandler(new UniversityEmployee(
                "Ion Balmus [Dean of the Faculty of Computers, Informatics and Microelectronics]",
                2_000M));

            var viorelBostan = new ExpenseHandler(new UniversityEmployee(
                "Viorel Bostan [Rector of TUM]", 100_000M));

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