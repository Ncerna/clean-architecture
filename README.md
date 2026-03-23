# Clean Architecture .NET 10 and DDD

## 🚀 Description

This project demonstrates a **Clean Architecture** implementation using **.NET 10**, **CQRS**, **MediatR**, **UnitOfWork**, **EF Core**, **Value Objects**, **Domain Events**, and **optimistic concurrency (RowVersion)**.  

The goal is to provide a **professional-level project** suitable for interviews or enterprise applications.

---

## 🏗 Project Structure

```text
src/
├── MyApp.Domain
│   ├── Entities/
│   │   └── Product.cs
│   ├── ValueObjects/
│   │   └── Money.cs
│   ├── Aggregates/
│   │   └── ProductAggregate.cs
│   ├── Repositories/
│   │   └── IProductRepository.cs
│   ├── Exceptions/
│   │   └── DomainException.cs
│   ├── Events/
│   │   └── ProductCreatedDomainEvent.cs
│   └── DomainEntity.cs
├── MyApp.Application
│   ├── DTOs/
│   ├── Wrappers/
│   ├── Features/
│   ├── Mappings/
│   └── Interfaces/
├── MyApp.Infrastructure
│   ├── Persistence/
│   ├── Repositories/
│   └── UnitOfWork.cs
└── MyApp.Api
    ├── Controllers/
    ├── Middleware/
    └── Program.cs
