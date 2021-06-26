using System;

namespace Product.API.Exceptions
{
    /// <summary>
    /// exception type for app exception
    /// </summary>
    public class ProductDomainException : Exception
    {
        public ProductDomainException()
        { }

        public ProductDomainException(string message)
            : base(message)
        { }

        public ProductDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
