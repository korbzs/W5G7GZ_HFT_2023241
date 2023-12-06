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
        public virtual int AuthorID { get; set; }
        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }
        public int BirthYear { get; set; }
        public string Nationality { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

        public Author(int authorID, string authorName, int birthYear, string nationality)
        {
            AuthorID = authorID;
            AuthorName = authorName;
            BirthYear = birthYear;
            Nationality = nationality;
        }
        public Author(string authorName, int birthYear, string nationality)
        {
            AuthorName = authorName;
            BirthYear = birthYear;
            Nationality = nationality;
        }
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public override string ToString()
        {
            return $"Author ID: {AuthorID}\tName: {AuthorName}\tBirthYear: {BirthYear}\tNationality: {Nationality}";
        }
    }

}
