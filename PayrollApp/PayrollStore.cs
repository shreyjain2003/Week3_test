using System.Collections.Generic;

namespace PayrollApp
{
    /// <summary>
    /// Central in-memory storage for payroll data.
    /// Acts like a temporary database.
    /// </summary>
    public static class PayrollStore
    {
        public static List<Employee> Employees = new();
        public static List<PaySlip> PaySlips = new();
        public static List<string> NotificationLogs = new();
    }
}
