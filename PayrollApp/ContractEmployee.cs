using System;

namespace PayrollApp
{
    /// <summary>
    /// Represents a contract employee paid per working day.
    /// </summary>
    public class ContractEmployee : Employee
    {
        private int WorkingDays;

        public ContractEmployee(int id, string name, decimal dailyRate, int workingDays)
            : base(id, name, dailyRate)
        {
            if (workingDays < 0 || workingDays > 31)
                throw new ArgumentException("Working days must be between 0 and 31.");

            Emp_Type = "Contract";
            WorkingDays = workingDays;
        }

        /// <inheritdoc/>
        public override decimal CalculateGross()
        {
            return BaseAmount * WorkingDays;
        }

        /// <inheritdoc/>
        public override decimal CalculateDeductions(decimal gross)
        {
            // Lower deductions for contract employees
            return gross * 0.05m;
        }
    }
}
