using Core.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Persistence.Infrastructure.EventHandlers
{
    public class ProductCreatedHandler : INotificationHandler<ProductCreatedDomainEvent>
    {
        private readonly ILogger<ProductCreatedHandler> _logger;

        public ProductCreatedHandler(ILogger<ProductCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("🔥 Product created event triggered: {Id}", notification.ProductId);

            // aquí puedes:
            // enviar email
            // publicar en bus
            // auditoría
            // etc

            return Task.CompletedTask;
        }
    }
}
