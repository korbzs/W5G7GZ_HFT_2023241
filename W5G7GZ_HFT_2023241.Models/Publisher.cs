using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5G7GZ_HFT_2023241.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherID { get; set; }

        public string PublisherName { get; set; }
        public string Headquarters { get; set; }
        public int FoundatitonYear { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }
    }
}2