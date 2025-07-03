# EF-Best-Practices-SmartApi (.NET 8 Web API with EF Core Best Practices)

A real-world .NET 8 Web API project that demonstrates **smart usage of Entity Framework Core**, avoiding common pitfalls and improving performance through best practices.

---

## ✅ Key EF Core Best Practices Used

- **Efficient filtering**: Avoid loading all data using `.Where(...)`
- **Avoiding N+1 queries**: Use `.Include(...)` for eager loading
- **Pagination**: Retrieve only a subset of data using `.Skip()` and `.Take()`
- **No tracking for read-only**: Use `.AsNoTracking()` to improve query performance
- **Indexing**: Speed up filtering on email using `.HasIndex(...)` (EF Core 7/8 compatible)

---

## 🧠 Indexing in EF Core 7/8+

> EF Core 7 and 8 no longer support `.HasDatabaseName()` or `.HasName()` for manually naming indexes.

In this project, we define an index on the `Email` column like this:

modelBuilder.Entity<User>()
    .HasIndex(u => u.Email);

```csharp


EF-Best-Practices-SmartApi/
│
├── EF-Best-Practices-SmartApi.sln
├── README.md
│
├── EF-Best-Practices-SmartApi/
│   ├── Controllers/
│   │   └── UserController.cs
│   ├── Services/
│   │   ├── Interfaces/
│   │   │   └── IUserService.cs
│   │   └── UserService.cs
│   ├── Models/
│   │   ├── User.cs
│   │   └── Order.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Program.cs
│   └── EF-Best-Practices-SmartApi.csproj

