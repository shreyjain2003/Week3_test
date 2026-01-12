using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollApp
{
    /// <summary>
    /// Delegate representing salary processed notification.
    /// </summary>
    public delegate void SalaryProcessedHandler(PaySlip slip);

    /// <summary>
    /// Responsible for payroll calculation and reporting.
    /// </summary>
    public class PayrollProcessor
    {
        //private readonly List<Employee> employees;
        //private readonly List<PaySlip> paySlips = new();

        /// <summary>
        /// Multicast delegate for notifications.
        /// </summary>
        public SalaryProcessedHandler? SalaryProcessed;

        // public PayrollProcessor(List<Employee> employees)
        // {
        //     this.employees = employees;
        // }

        /// <summary>
        /// Processes payroll using polymorphism (no if/else).
        /// </summary>
        public void ProcessPayroll()
        {
            foreach (var emp in PayrollStore.Employees)
            {
                decimal gross = emp.CalculateGross();
                decimal deductions = emp.CalculateDeductions(gross);

                var slip = new PaySlip
                {
                    EmployeeId = emp.Emp_Id,
                    EmployeeName = emp.Emp_Name,
                    EmployeeType = emp.Emp_Type,
                    GrossSalary = gross,
                    Deductions = deductions,
                    NetSalary = gross - deductions
                };

                //paySlips.Add(slip);
                PayrollStore.PaySlips.Add(slip);


                // Invoke multicast delegate
                SalaryProcessed?.Invoke(slip);

                Console.WriteLine($"Processed: {emp.Emp_Name} | Gross: ₹{gross} | Net: ₹{slip.NetSalary}");
            }
        }

        /// <summary>
        /// Prints final payroll summary.
        /// </summary>
        public void PrintSummary()
        {
            Console.WriteLine("\n===== PAYROLL SUMMARY =====");

            // Console.WriteLine($"Total Employees: {paySlips.Count}");
            // Console.WriteLine($"Total Payout: ₹{paySlips.Sum(p => p.NetSalary)}");

            // var grouped = paySlips.GroupBy(p => p.EmployeeType);


            Console.WriteLine($"Total Employees: {PayrollStore.PaySlips.Count}");
            Console.WriteLine($"Total Payout: ₹{PayrollStore.PaySlips.Sum(p => p.NetSalary)}");
            
            var grouped = PayrollStore.PaySlips.GroupBy(p => p.EmployeeType);

            foreach (var group in grouped)
            {
                Console.WriteLine($"{group.Key} Count: {group.Count()}");
            }

            //var highest = paySlips.OrderByDescending(p => p.NetSalary).First();
            var highest = PayrollStore.PaySlips.OrderByDescending(p => p.NetSalary).First();

            Console.WriteLine($"Highest Salary: {highest.EmployeeName} (₹{highest.NetSalary})");
        }
    }
}
