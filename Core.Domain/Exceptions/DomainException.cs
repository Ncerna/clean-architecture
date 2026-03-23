using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Exceptions;

    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }

