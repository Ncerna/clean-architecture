using MediatR;

namespace Core.Domain.Events;
public record ProductCreatedDomainEvent(Guid ProductId) : INotification;
