using System;

namespace eCommerce.Application.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) 
            : base(message)
        {
        }
    }
}
