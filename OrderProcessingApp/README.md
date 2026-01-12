# 📦 OrderProcessingApp – Online Order Processing & Status Notifications (C# .NET)

## 📖 Overview

**OrderProcessingApp** is a **console-based C# application** that simulates an **online order processing system** with order lifecycle management and real-time status notifications.

The project is designed to demonstrate **Object-Oriented Programming (OOPS)** concepts, **generic collections**, **delegates**, and **business rule validation**, all implemented **entirely in memory** as per assignment requirements.

---

## 🎯 Objectives

* Model real-world entities such as **Product**, **Customer**, **Order**, and **OrderItem**
* Implement **order status workflow** with strict validation rules
* Store orders, products, and status history using **generic collections**
* Use **delegates (multicast)** to notify multiple subscribers on status change
* Maintain a complete **order status history timeline**
* Print a **comprehensive order summary report**

---

## 🧠 Concepts Demonstrated

* ✅ Encapsulation
* ✅ Composition (Order has OrderItems)
* ✅ Polymorphism (where applicable)
* ✅ Delegates (Multicast Delegates)
* ✅ Generic Collections (`List<T>`, `Dictionary<TKey,TValue>`)
* ✅ Business Rule Validation
* ✅ Exception Handling
* ✅ Clean Separation of Concerns
* ✅ Professional XML Documentation (`///`)

---

## 🏗️ Project Structure

```
OrderProcessingApp
│
├── Program.cs
├── Product.cs
├── Customer.cs
├── OrderItem.cs
├── Order.cs
├── OrderStatus.cs
├── OrderStatusLog.cs
├── OrderService.cs
├── Notifications.cs
└── README.md
```

---

## 🧩 Key Components

### 🔹 Product

Represents an item available for purchase with ID, name, and price.

### 🔹 Customer

Stores basic customer information and owns one or more orders.

### 🔹 OrderItem

Represents a product-quantity pair inside an order.
Demonstrates **composition**.

### 🔹 Order

* Maintains order items
* Tracks current order status
* Records full status history
* Enforces valid state transitions

### 🔹 OrderService

* Manages order storage and updates
* Invokes delegate notifications on status change
* Handles reporting logic

### 🔹 Notifications

* Customer notification
* Logistics notification
  (Both are independent and subscribed via delegates)

---

## 🔁 Order Status Workflow

The system enforces the following valid transitions:

```
Created → Paid → Packed → Shipped → Delivered
```

### ❌ Invalid Transitions Prevented

* Shipping before payment
* Delivering before shipping
* Progressing a cancelled order

Clear error messages are printed for invalid attempts.

---

## 📦 Data Storage (In-Memory)

| Data           | Collection Used          | Reason                  |
| -------------- | ------------------------ | ----------------------- |
| Products       | `List<Product>`          | Sequential access       |
| Orders         | `Dictionary<int, Order>` | Fast lookup by Order ID |
| Order Items    | `List<OrderItem>`        | Composition             |
| Status History | `List<OrderStatusLog>`   | Timeline tracking       |

> ❗ No database, file system, or web APIs are used

---

## 🔔 Delegate-Based Notifications

### Delegate Signature

```csharp
public delegate void OrderStatusChangedHandler(Order order, OrderStatus newStatus);
```

### Subscribers

* **CustomerNotification** – informs customer of status change
* **LogisticsNotification** – triggers dispatch on `Shipped`

✔ Demonstrates **multicast delegates**
✔ No events used (as required)

---

## ▶️ How to Run the Project

### Prerequisites

* .NET SDK 6.0 or later
* Visual Studio Code

### Steps

```bash
dotnet new console -n OrderProcessingApp
cd OrderProcessingApp
dotnet run
```

Or run directly via **VS Code Run / Debug**.

---

## 📤 Sample Output (Excerpt)

```
Order 101 created successfully.
Order 102 created successfully.
[Customer] Order 101 is now Paid
[Customer] Order 101 is now Packed
[Customer] Order 101 is now Shipped
[Logistics] Dispatch initiated for Order 101
[Customer] Order 101 is now Delivered
Status Change Failed: Order must be packed before shipping.

===== ORDER REPORT =====

Order ID: 101, Customer: Shrey
Current Status: Delivered
Items:
- Laptop x1
- Mouse x2
Total: ₹91800
Status Timeline:
1/12/2026 11:48:18 AM: Created → Created
1/12/2026 11:48:18 AM: Created → Paid
1/12/2026 11:48:18 AM: Paid → Packed
1/12/2026 11:48:18 AM: Packed → Shipped
1/12/2026 11:48:18 AM: Shipped → Delivered

Order ID: 102, Customer: Tushar
Current Status: Created
Items:
- Keyboard x1
- Headset x1
Total: ₹7000
Status Timeline:
1/12/2026 11:48:18 AM: Created → Created
```

---

## ⚠️ Business Rules Implemented

* Cannot ship before order is packed
* Cannot deliver before order is shipped
* Cancelled orders cannot progress
* All status changes are logged
* Invalid transitions are safely handled using exceptions

---

## 🧪 Learning Outcomes

* Strong understanding of **order lifecycle modeling**
* Practical experience with **delegates for decoupled notifications**
* Effective use of **generic collections**
* Clean separation of business logic and reporting
* Real-world application of OOPS concepts

---

## 🔮 Future Enhancements

* Add menu-driven order creation
* Introduce discount & tax strategies
* Store notification history
* Replace delegates with events
* Scale to large datasets using optimized collections

---

## 👨‍💻 Author

**Shreyansh Jain**
B.Tech (Final Year)
Learning Focus: C# .NET, OOPS, Backend Development, System Design