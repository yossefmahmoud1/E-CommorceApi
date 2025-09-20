# 🛒 E-Commerce API

A **Production-Ready E-Commerce API** built with **ASP.NET Core** using **Onion Architecture** principles.  
This project demonstrates a scalable, maintainable, and modular design covering the full e-commerce lifecycle:  
**Products → Cart → Orders → Payments → Users**

---

## 🚀 Features

### 🛍️ Core Features
- **Product Catalog**: CRUD for products, brands, and categories with filtering, sorting, searching, and pagination.
- **Shopping Cart**: Persistent basket management powered by Redis.
- **Order Processing**: Complete lifecycle including order creation, delivery methods, and tracking.
- **Authentication & Authorization**: JWT authentication, address management, and role-based access.
- **Payment Integration**: Secure checkout and transaction handling.

### 🛠 Supporting Features
- Interactive **Swagger UI** for API documentation & testing.
- Centralized **Exception Handling Middleware**.
- **CORS Configuration** for cross-origin requests.
- Automatic **Database Seeding & Migrations**.
- **Dual DbContext Strategy**:
  - `StoreDbContext` → Business data
  - `StoreIdentityDbContext` → Identity & users

---

## 🏗️ Architecture

The project is structured using **Onion Architecture** combined with **CQRS** for scalability.

### 🔑 Applied Design Patterns:
- Repository Pattern  
- Unit of Work  
- Specification Pattern  

📌 Layers:
1. **Core** → Entities, Interfaces, Specifications  
2. **Application** → Business logic, CQRS handlers  
3. **Infrastructure** → Data access, repositories, Redis, Identity  
4. **API** → Controllers, DTOs, Swagger, Middleware  

---

## ⚙️ Tech Stack
- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQL Server**
- **Redis**
- **Swagger**
- **JWT Authentication**

---
### 🧅 Onion Architecture Overview
<img width="1006" height="758" alt="Architecture Overview" src="https://github.com/user-attachments/assets/9bfe662c-e2b8-412a-99d0-bbc018f60d8c" />

### ⚡ Project Workflow
<img width="1723" height="725" alt="Project Workflow" src="https://github.com/user-attachments/assets/814bf14e-d40e-471a-81ac-fd1f78ccee0e" />



## 🛠️ Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/yossefmahmoud1/E-CommorceApi.git
