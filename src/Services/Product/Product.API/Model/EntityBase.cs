using System;

namespace Product.API.Model
{
    public class EntityBase<T>
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string DocType
        {
            get { return typeof(T).Name.ToLower(); }
        }
    }
}
