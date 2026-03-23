using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Events;
public record ProductCreatedDomainEvent(Guid ProductId);
