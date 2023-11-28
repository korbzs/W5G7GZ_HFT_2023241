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
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // automatikusan generalodik
        public virtual int BookID { get; set; }

        [ForeignKey("Author")]
        [Required]
        public int AuthorID { get; set; }

        [ForeignKey("Publisher")]
        [Required]
        public int PublisherID { get; set; }
        public int Price { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }

        public Book(int authorID, int publisherID, int price, string title, string genre, string iSBN, DateTime publicationDate)
        {
            AuthorID = authorID;
            PublisherID = publisherID;
            Price = price;
            Title = title;
            Genre = genre;
            ISBN = iSBN;
            PublicationDate = publicationDate;
        }
        public Book(int bookID, int authorID, int publisherID, int price, string title, string genre, string iSBN, DateTime publicationDate)
        {
            BookID = bookID;
            AuthorID = authorID;
            PublisherID = publisherID;
            Price = price;
            Title = title;
            Genre = genre;
            ISBN = iSBN;
            PublicationDate = publicationDate;
        }
        public Book()
        {
        }

        public override string ToString()
        {
            return $"{BookID}\t{Title}\t{Author?.AuthorName}\t{Price}\t{Genre}\t{ISBN}\t{PublicationDate.Year}";
        }
    }
}
