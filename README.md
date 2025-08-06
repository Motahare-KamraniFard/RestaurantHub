# 🍽️ RestaurantHub

RestaurantHub is a simple C# console application that simulates a restaurant ordering system. It allows users to place food orders and choose between different service types: Online Ordering, Courier Delivery, or Dine-In with a Table Reservation.

This project is a great example of **Object-Oriented Programming (OOP)** principles in action, including **abstraction**, **encapsulation**, **inheritance**, and **polymorphism**.

---

## 🚀 Features

- User can input a list of food items to order.
- Select a service type:
  - Online Ordering
  - Courier Delivery
  - Dine-In with Reservation
- Modular and extendable design using interfaces and classes.

---

## 🧠 Object-Oriented Design Breakdown

### ✅ Interfaces

- `IOrder` — Abstracts the ordering mechanism.
- `IDelivery` — Abstracts different delivery methods.
- `IReservation` — Abstracts reservation handling.

These interfaces allow the system to remain **flexible and extensible** by enabling new types of services or behaviors to be added without modifying existing code.

---

### 🏗️ Classes and Responsibilities

| Class            | Responsibility |
|------------------|----------------|
| `CustomOrder`    | Implements `IOrder` to handle a user's custom food order. |
| `OnlineOrdering` | Implements `IDelivery` for online ordering functionality. |
| `CourierDelivery`| Implements `IDelivery` for courier-based delivery. |
| `DineInService`  | Implements `IDelivery` for dine-in service (internal handling). |
| `TableReservation` | Implements `IReservation` to handle dine-in table reservations. |
| `Restaurant`     | Orchestrates the whole process by combining order, delivery, and (optionally) reservation components. |

---

## 🔄 Flow of the Program

1. The user is prompted to input food items.
2. The user selects a service type (1, 2, or 3).
3. Based on the selection:
   - An appropriate `IDelivery` implementation is selected.
   - If it's dine-in, a `TableReservation` is also created.
4. A `CustomOrder` object is instantiated with the selected items.
5. All components are passed to a `Restaurant` object.
6. The `Restaurant.ProcessOrder()` method coordinates the flow:
   - Orders the food.
   - Reserves a table (if applicable).
   - Delivers the food via the chosen method.

---

## 🧱 OOP Concepts in Use

| Concept        | Example |
|----------------|---------|
| **Abstraction** | Interfaces (`IOrder`, `IDelivery`, `IReservation`) abstract the general behavior. |
| **Encapsulation** | Each class encapsulates its own data and behavior (e.g., `CustomOrder` has a private list of items). |
| **Polymorphism** | Multiple classes implement the same interface and can be used interchangeably. |
| **Composition** | The `Restaurant` class is composed of other components to delegate responsibilities. |

---

## 🛠️ How to Run

Make sure you have [.NET SDK](https://dotnet.microsoft.com/download) installed.

```bash
dotnet build
dotnet run
```

---

## 📌 Future Improvements

- Input validation and error handling
- Persistent order history
- GUI or web version
- Localization support

---

## 📃 License

This project is for educational purposes and demonstrates basic OOP practices in C#.
