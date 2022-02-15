using System.Collections.Generic;

namespace eCommerce.Request.Dtos.Common
{
    public class CollectionResponse<TResponse>
    {
        public IEnumerable<TResponse> Items { get; set; }

        public int Total { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}
