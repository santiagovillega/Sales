namespace Sales.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string  Description { get; set; }
        public Decimal Price { get; set; }
        public bool IsAvalaible { get; set; }
        public DateTime PublishOn { get; set; }

        public override string ToString()
        {
            return this.Description ;
        }
    }
}
