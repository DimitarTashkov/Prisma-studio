# 📸 Prisma Studio Management System

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)

**Prisma Studio** is a comprehensive desktop management solution developed as a custom software project for a creative photography business. It unifies two critical workflows—**service scheduling** and **e-commerce sales**—into a single, robust Windows Forms application.

Unlike generic booking tools, Prisma Studio features a custom algorithm for real-time slot calculation and a strict **N-Tier Architecture** to ensure scalability and maintainability.

---

## 🚀 Key Features

### 🛒 Integrated E-Commerce (Shop)

- **Dynamic Inventory:** Browse cameras, lenses, and accessories with real-time stock tracking.
- **Shopping Cart:** In-memory cart system allowing users to add/remove items and view live total calculations.
- **Order Processing:** Seamless checkout experience with automated database updates.

### 📅 Smart Booking System

- **Intelligent Slot Calculation:** A custom algorithm automatically calculates available time slots based on the specific duration of the chosen service (e.g., 60 min vs 120 min sessions) and checks against existing reservations in the SQL database.
- **Conflict Prevention:** Logic to strictly prevent double-booking or overlapping sessions.
- **Service Catalog:** Visual catalog of services with duration and pricing details.

### 🛡️ Role-Based Access Control (RBAC)

- **Client Portal:** User-friendly interface for booking appointments and purchasing gear.
- **Admin Dashboard:** Powerful tools for business owners to:
  - **Manage Products:** CRUD operations with image upload handling.
  - **Manage Services:** Set duration, price, and descriptions.
  - **Process Requests:** Visual dashboard to **Confirm/Decline** photo sessions and mark orders as **Completed**.
  - **User Management:** View and manage registered accounts.

---

## 📸 Screenshots & Previews

<details>
<summary>Click to view the application screenshots</summary>
<br>

<div align="center">

| | |
|:---:|:---:|
| **Home Page**<br><img src="images/home%20form.png" width="400"/> | **Shop Interface**<br><img src="images/shop%20form.png" width="400"/> |
| **Session Booking**<br><img src="images/book%20session%20form.png" width="400"/> | **Shopping Cart**<br><img src="images/cart%20from.png" width="400"/> |
| **User Profile**<br><img src="images/profie%20form.png" width="400"/> | **User Management (Admin)**<br><img src="images/users%20form.png" width="400"/> |
| **Product Management (Admin)**<br><img src="images/manageproducts%20form.png" width="400"/> | **Login Screen**<br><img src="images/login%20form.png" width="400"/> |
| **Register Screen**<br><img src="images/register%20form.png" width="400"/> | **Contact Us**<br><img src="images/contact%20us%20form.png" width="400"/> |

<br>
<b>Database Relationship Diagram</b><br>
<img src="images/db%20diagram.png" width="800"/>

</div>
</details>

---

## 🏗️ Architecture & Tech Stack

The project is built using **C#** and **.NET (Windows Forms)**, adhering to clean code principles to avoid "spaghetti code" in the UI layer.

- **Design Pattern:** Service Layer Pattern with Dependency Injection (via a custom `ServiceLocator`).
- **Data Access:** Entity Framework Core (**Code First** approach).
- **Database:** Microsoft SQL Server (LocalDB).
- **Security:** Password hashing (SHA256) and session management via `AuthorizationHelper`.

### Project Structure
```text
Prisma Studio
│
├── Data            # DbContext and Migrations
├── Models          # Database Entities (User, Product, Order, etc.)
├── Services        # Business Logic (ShopService, SessionService, etc.)
├── Forms           # UI Layer (Windows Forms)
└── Utilities       # Helpers for Validation, Auth, and UI Effects
```
## 🛠️ Getting Started
## Prerequisites
Visual Studio 2022

.NET Desktop Development workload

MS SQL Server (LocalDB)

## Installation
Clone the repository:

Bash
git clone [https://github.com/DimitarTashkov/Prisma-studio.git](https://github.com/DimitarTashkov/Prisma-studio.git)
Open the solution: Open Prisma studio.sln in Visual Studio.

Restore Packages: Right-click on the solution -> Restore NuGet Packages.

Database Setup: Since this project uses EF Core Code First, you need to apply migrations to create the local database. Open the Package Manager Console (View -> Other Windows -> Package Manager Console) and run:

PowerShell
Update-Database
Run the Application: Press F5 or click Start.

First Run (Admin Access): The application includes a Seeding logic (SeedAdmin.cs). On the first run, if the database is empty, an Admin account will be created automatically.

Username: "foulcoast" (or check SeedAdmin.cs)

Password: "mitko123" (or check SeedAdmin.cs)
