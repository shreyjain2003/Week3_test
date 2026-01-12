using System;

namespace PayrollApp
{
    /// <summary>
    /// Contains notification handlers for HR and Finance.
    /// </summary>
    public static class Notifications
    {
        /// <summary>
        /// HR notification callback.
        /// </summary>
        public static void NotifyHR(PaySlip slip)
        {
            Console.WriteLine($"[HR] Salary processed for {slip.EmployeeName} ({slip.EmployeeType})");
        }

        /// <summary>
        /// Finance notification callback.
        /// </summary>
        public static void NotifyFinance(PaySlip slip)
        {
            Console.WriteLine($"[Finance] Net Pay ₹{slip.NetSalary} credited for Employee ID {slip.EmployeeId}");
        }
    }
}
