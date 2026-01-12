# 📌 PayrollApp – Payroll & Salary Processing System (C# .NET)

## 📖 Overview

**PayrollApp** is a **console-based C# application** that simulates a real-world **payroll and salary processing system**.
The project is designed to demonstrate **Object-Oriented Programming (OOPS)** principles, **generic collections**, and **delegates** as part of an academic/learning assignment.

The application processes salaries for **Full-Time** and **Contract** employees using **runtime polymorphism**, generates payslips, sends notifications to multiple departments, and prints a complete payroll summary.

---

## 🎯 Objectives

* Design a **base Employee class** and derived employee types
* Calculate salaries using **polymorphism** (no if/else checks on type)
* Store data using **generic collections**
* Use **delegates** to notify multiple subscribers (HR & Finance)
* Print a detailed payroll report and summary
* Handle invalid data using validation and exception handling

---

## 🧠 Concepts Demonstrated

* ✅ Encapsulation
* ✅ Inheritance
* ✅ Runtime Polymorphism
* ✅ Delegates (Multicast Delegates)
* ✅ Generic Collections (`List<T>`)
* ✅ Single Responsibility Principle (SRP)
* ✅ Exception Handling
* ✅ Professional XML documentation (`///`)

---

## 🏗️ Project Structure

```
PayrollApp
│
├── Program.cs
├── Employee.cs
├── FullTimeEmployee.cs
├── ContractEmployee.cs
├── PaySlip.cs
├── PayrollProcessor.cs
├── Notifications.cs
└── README.md
```

---

## 🧩 Key Components

### 🔹 Employee (Abstract Base Class)

* Holds common employee details
* Declares abstract method `CalculateGross()`
* Implements virtual method `CalculateDeductions()`

### 🔹 FullTimeEmployee & ContractEmployee

* Override salary calculation logic
* Demonstrate **polymorphism**

### 🔹 PayrollProcessor

* Processes payroll for all employees
* Stores payslips in a generic collection
* Raises delegate notifications after salary processing

### 🔹 Delegates & Notifications

* `SalaryProcessedHandler` delegate
* Multiple subscribers:

  * HR Notification
  * Finance Notification

---

## 📦 Data Storage (In-Memory)

| Data      | Collection Used  | Reason                               |
| --------- | ---------------- | ------------------------------------ |
| Employees | `List<Employee>` | Sequential processing & polymorphism |
| Payslips  | `List<PaySlip>`  | Easy aggregation & reporting         |

> ❗ No database, file system, or external API is used (as per requirement)

---

## ▶️ How to Run the Project

### Prerequisites

* .NET SDK (6.0 or later)
* Visual Studio Code (recommended)

### Steps

```bash
dotnet new console -n PayrollApp
cd PayrollApp
dotnet run
```

Or simply run using **VS Code Run / Debug**.

---

## 📤 Sample Output (Excerpt)

```
[HR] Salary processed for Shrey (Full-Time)
[Finance] Net Pay ₹79200 credited for Employee ID 1
Processed: Shrey | Gross: ₹99000 | Net: ₹79200

===== PAYROLL SUMMARY =====
Total Employees: 6
Total Payout: ₹XXXXX
Full-Time Count: 3
Contract Count: 3
Highest Salary: Shrey (₹79200)
```

---

## ⚠️ Validation Rules Implemented

* Salary cannot be negative
* Working days must be between 0–31
* Delegate safely invoked using null-conditional operator (`?.`)
* Invalid input is handled using exceptions

---

## 🧪 Learning Outcomes

* Clear understanding of **polymorphism in real applications**
* Practical use of **delegates instead of hardcoding logic**
* Effective use of **generic collections**
* Clean separation of responsibilities between classes

---

## 🔮 Future Enhancements

* Add menu-driven input
* Export payslip to file (CSV / PDF)
* Add new employee types (Intern, Part-Time)
* Replace delegates with events
* Integrate database support

---

## 👨‍💻 Author

**Shreyansh Jain**
B.Tech (Final Year)
Learning Focus: C# .NET, OOPS, Data Structures, Backend Development