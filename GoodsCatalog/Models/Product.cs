using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsCatalog.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Measure { get; set; }
        public DateTime Expire { get; set; }
        public string Delivery { get; set; }
    }
}
