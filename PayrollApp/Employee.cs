using System;

namespace PayrollApp
{
    /// <summary>
    /// Abstract base class representing a generic employee.
    /// Demonstrates encapsulation and runtime polymorphism.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>Unique employee identifier.</summary>
        public int Emp_Id { get; }

        /// <summary>Employee full name.</summary>
        public string Emp_Name { get; }

        /// <summary>Type of employee (Full-Time / Contract).</summary>
        public string Emp_Type { get; protected set; }

        /// <summary>Base salary or rate.</summary>
        protected decimal BaseAmount;

        /// <summary>
        /// Initializes common employee properties.
        /// </summary>
        protected Employee(int id, string name, decimal baseAmount)
        {
            if (baseAmount < 0)
                throw new ArgumentException("Salary cannot be negative.");

            Emp_Id = id;
            Emp_Name = name;
            BaseAmount = baseAmount;
        }

        /// <summary>
        /// Calculates gross salary.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract decimal CalculateGross();

        /// <summary>
        /// Calculates deductions (tax, insurance, etc.).
        /// Can be overridden if rules change.
        /// </summary>
        public virtual decimal CalculateDeductions(decimal gross)
        {
            return gross * 0.10m; // Default 10% deduction
        }
    }
}
