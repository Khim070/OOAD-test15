using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productlib
{
    public class ProductResponse : IKeyIdentity
    {
        public string? Id { get; set; }
        public string Code { get; set; } = default!;
        public string? Name { get; set; }
        public string? Category { get; set; }
    }
}
