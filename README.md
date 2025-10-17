# Restaurant Manager (C# Desktop)

A Windows desktop application built in **C# / .NET** for end-to-end restaurant operations: **order management**, **menu control**, **table & billing**, and **staff coordination**. Designed for small to mid-size restaurants that need a fast, reliable, offline-friendly back-office and front-of-house app.

---

## ✨ Features

- **Orders & Tables**
  - Create, edit, and track dine-in, takeout, or delivery orders
  - Table assignment, merge/split, real-time order status
  - Discounts, notes (no-onion, extra-spicy), and refunds
- **Menu Management**
  - CRUD for categories, items, sizes, modifiers, combos
  - Price, cost, and availability toggles (e.g., “86 Salmon”)
  - Import/export menu as CSV/JSON
- **Billing & Payments**
  - Sub-totals, taxes, service charges, tips
  - Split bills (by item or amount), receipts (print/PDF)
- **Staff & Roles**
  - Users, roles (Admin/Manager/Cashier/Waiter/Kitchen), permissions
  - Shift tracking (clock-in/out), activity logs
- **Reports & Insights**
  - Daily sales, best-sellers, category trends, staff performance
  - Export to CSV/XLSX/PDF
- **Kitchen Display (optional)**
  - Simple **KDS** view by status (Queued / In-Progress / Done)

---

## 🧱 Tech Stack

- **C# / .NET 6+** (Works with .NET Framework 4.8+ too)
- **UI:** WinForms *or* WPF
- **Database:** SQLite (default, file-based) or SQL Server / LocalDB
- **ORM/Access:** Entity Framework Core *or* ADO.NET
- **Reporting:** RDLC or PDF library (e.g., iText7)
- **Printing:** Native Windows printing or POS thermal printer (ESC/POS)

> Start with **SQLite** locally and switch to **SQL Server** in production.

---

## 📁 Solution Structure (example)

