using System;

namespace PayrollApp
{
    /// <summary>
    /// Represents a full-time employee with fixed monthly salary.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(int id, string name, decimal monthlySalary)
            : base(id, name, monthlySalary)
        {
            Emp_Type = "Full-Time";
        }

        /// <inheritdoc/>
        public override decimal CalculateGross()
        {
            return BaseAmount;
        }

        /// <inheritdoc/>
        public override decimal CalculateDeductions(decimal gross)
        {
            // Higher deductions for full-time employees
            return gross * 0.20m;
        }
    }
}
