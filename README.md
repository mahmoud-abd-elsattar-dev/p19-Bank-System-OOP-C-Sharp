# 🏦 Bank Management System — C# OOP with 3-Layer Architecture

A fully object-oriented C# console application for managing bank clients, users, and transactions — built with a clean 3-layer architecture (Data Layer, Business Layer, Console) and SQL Server as the database backend.

---

## 📖 Overview

This is a C# OOP Bank Management System designed with a professional 3-layer architecture that separates data access, business logic, and presentation concerns. It replaces the previous file-based storage with a **SQL Server database**, making it a closer representation of real-world enterprise application design. A `Bank.drawio` diagram is included to visualize the database structure.

---

## ✨ Features

- **Login System**: Secure authentication with username and password
- **Role-Based Permissions**: Bitwise permission flags control access per feature per user
- **Client Management**: Full CRUD operations (Add, Delete, Update, Find, List)
- **User Management**: Full CRUD operations for system users
- **Transactions**: Deposit, Withdraw, Transfer between accounts, and Total Balance reporting
- **Transfer Log**: All transfer transactions recorded in the database
- **Login Log**: All login events recorded with timestamp
- **Currency Management**: View and manage currencies with exchange rates
- **Logout**: Return to login screen without exiting

---

## 🛠️ Tech Stack

| Component | Technology |
|---|---|
| Language | C# (.NET) |
| Architecture | 3-Layer (Data / Business / Console) |
| Database | SQL Server |
| Data Access | ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`) |
| DB Diagram | Draw.io (`Bank.drawio`) |
| IDE | Visual Studio 2022+ |

---

## 🎮 How to Use

1. Run the application — a **Login Screen** appears first.
2. Enter your username and password to authenticate.
3. Choose an option from the **Main Menu** (options visible based on your permissions):
   - `1` Show Client List
   - `2` Add New Client
   - `3` Delete Client
   - `4` Update Client Info
   - `5` Find Client
   - `6` Transactions
   - `7` Manage Users
   - `8` Logout
4. If you select **Transactions**, a sub-menu appears:
   - `1` Deposit
   - `2` Withdraw
   - `3` Transfer
   - `4` Total Balances
   - `5` Transfer Log
   - `6` Back to Main Menu
5. If you select **Manage Users**, a sub-menu appears:
   - `1` List Users
   - `2` Add New User
   - `3` Delete User
   - `4` Update User
   - `5` Find User
   - `6` Back to Main Menu
6. Press any key to return to the previous menu after each action.

---

## 🏗️ Project Structure

```
p19-Bank-System-OOP-C-Sharp/
│
├── Bank-Data-Layer/        # ADO.NET classes for direct DB communication
│   ├── clsClientData.cs
│   ├── clsUserData.cs
│   └── ...
│
├── Bank-Business-Layer/    # Business logic classes
│   ├── clsClient.cs
│   ├── clsUser.cs
│   ├── clsCurrency.cs
│   └── ...
│
├── Bank-Console/           # Console UI and screen classes
│   ├── Program.cs
│   └── Screens/
│
├── Bank.drawio             # Database diagram
├── BankDb.bak              # SQL Server database backup
├── Bank-Console.slnx       # Visual Studio solution file
└── README.md
```

---

## 🧠 Concepts Used

- **3-Layer Architecture** — Strict separation of Data Layer, Business Layer, and Presentation Layer
- **OOP** — Full class-based design with encapsulation across all layers
- **ADO.NET** — Direct SQL Server communication using `SqlConnection`, `SqlCommand`, `SqlDataReader`
- **SQL Server** — Relational database replacing file-based storage
- **Stored Procedures / SQL Queries** — Data operations handled via parameterized queries
- **Enums** — Permission flags and menu options
- **Bitwise Operations** — Assigning and checking user permissions
- **Static Methods** — Used in business and data layer classes for CRUD operations
- **Global State** — `CurrentUser` shared across screens for session management
- **Database Diagram** — `Bank.drawio` documents the database schema visually

---

## 🔑 Key Classes

| Class | Layer | Description |
|---|---|---|
| `clsClientData` | Data Layer | Handles all SQL queries for client records |
| `clsUserData` | Data Layer | Handles all SQL queries for user records |
| `clsCurrencyData` | Data Layer | Handles all SQL queries for currency records |
| `clsClient` | Business Layer | Client business logic and CRUD operations |
| `clsUser` | Business Layer | User business logic, authentication, and permissions |
| `clsCurrency` | Business Layer | Currency business logic and exchange operations |

---

## ⚙️ Requirements

- **IDE**: Visual Studio 2022 or later
- **Language**: C# (.NET)
- **Database**: SQL Server (restore `BankDb.bak` to set up the database)
- **OS**: Windows

---

## 🚀 Getting Started

1. Clone the repository.
2. Open `Bank-Console.slnx` in Visual Studio.
3. Restore `BankDb.bak` to your SQL Server instance.
4. Update the connection string in the Data Layer to match your SQL Server setup.
5. Build and run the project.

---

## 📄 License

This project is open source and free to use for educational purposes.

---

## 👤 Author

👤 **Mahmoud Abd El-Sattar**  
📧 mahmoud.abdelsattar.dev@gmail.com  
💼 [linkedin.com/in/mahmoud-abd-el-sattar](https://www.linkedin.com/in/mahmoud-abd-el-sattar-1b227522a)
