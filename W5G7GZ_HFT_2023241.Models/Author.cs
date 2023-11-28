using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace W5G7GZ_HFT_2023241.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int AuthorID { get; set; }
        public virtual int AuthorID { get; set; }
        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

        public Author(int authorID, string authorName, DateTime birthDate, string nationality)
        {
            AuthorID = authorID;
            AuthorName = authorName;
            BirthDate = birthDate;
            Nationality = nationality;
        }
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public override string ToString()
        {
            return $"{AuthorID}\t{AuthorName}\t{BirthDate.Year}\t{Nationality}";
        }
    }

}
