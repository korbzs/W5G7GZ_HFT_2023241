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
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int PublisherID { get; set; }
        public virtual int PublisherID { get; set; }
        [MaxLength(100)]
        [Required]
        public string PublisherName { get; set; }
        public string Headquarters { get; set; }
        public int FoundatitonYear { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

        public Publisher(int publisherID, string publisherName, string headquarters, int foundatitonYear)
        {
            PublisherID = publisherID;
            PublisherName = publisherName;
            Headquarters = headquarters;
            FoundatitonYear = foundatitonYear;
        }

        public Publisher(string publisherName, string headquarters, int foundatitonYear)
        {
            PublisherName = publisherName;
            Headquarters = headquarters;
            FoundatitonYear = foundatitonYear;
        }

        public Publisher()
        {
            this.Books = new HashSet<Book>();
        }
        public override string ToString()
        {
            return $"{PublisherID}\t{PublisherName}\t{Headquarters}\t{FoundatitonYear}";
        }
    }
}