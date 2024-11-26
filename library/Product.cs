using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productlib
{
    public class Product : IKeyIdentity
    {
        public string? Id { get; set; }
        public string Code { get; set; } = default!;
        public string? Name { get; set; }
        public Category Category { get; set; } = Category.None;
        public DateTime? Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
