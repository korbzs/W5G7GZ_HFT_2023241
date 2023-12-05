using System;
using System.Collections.Generic;
using System.Linq;

namespace W5G7GZ_HFT_2023241.Logic.Logic
{
    public class GenresForAuthorsClass
    {
        public string AuthorName { get; set; }
        public List<string> Genres { get; set; }

        public override bool Equals(object obj)
        {
            GenresForAuthorsClass other = obj as GenresForAuthorsClass;
            return other != null && other.AuthorName == AuthorName && other.Genres.SequenceEqual(Genres);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(AuthorName,Genres);
        }
    }
}