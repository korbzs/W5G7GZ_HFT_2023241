using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W5G7GZ_HFT_2023241.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }

        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }
    }

}
