using System;
using System.Collections.Generic;

namespace PayrollApp
{
    /// <summary>
    /// Application entry point.
    /// Uses hardcoded sample data as allowed by assignment.
    /// </summary>
    class Program
    {
        static void Main()
        {
            try
            {
                /// Hardcoded employee data (6 employees as required)
                var employees = new List<Employee>
                {
                    new FullTimeEmployee(1, "Shrey", 99000),
                    new FullTimeEmployee(2, "Tushar", 49000),
                    new ContractEmployee(3, "Apurav", 1100, 20),
                    new ContractEmployee(4, "Rajpreet", 2000, 25),
                    new FullTimeEmployee(5, "Sahaj", 46000),
                    new ContractEmployee(6, "Anshul", 1000, 29)
                };

                var process = new PayrollProcessor(employees);

                /// Subscribing multiple notification methods
                process.SalaryProcessed += Notifications.NotifyHR;
                process.SalaryProcessed += Notifications.NotifyFinance;

                process.ProcessPayroll();
                process.PrintSummary();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
