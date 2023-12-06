using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W5G7GZ_HFT_2023241.Logic.Interfaces;
using W5G7GZ_HFT_2023241.Logic.Logic;
using W5G7GZ_HFT_2023241.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W5G7GZ_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NonCrudFieldController : ControllerBase
    {
        IBookLogic logic;

        public NonCrudFieldController(IBookLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> BookCountPerPublisher()
        {
            return this.logic.BookCountPerPublisher();
        }
        [HttpGet]
        public IEnumerable<string> AuthorsWithMultipleBooks()
        {
            return this.logic.AuthorsWithMultipleBooks();
        }
        [HttpGet]
        public List<Book> BooksByGenre(string genre)
        {
            return this.logic.BooksByGenre(genre);
        }
        [HttpGet]
        public int PriceOfAllBooks()
        {
            return this.logic.PriceOfAllBooks();
        }
        [HttpGet]
        public List<Author> AuthorsBornInDecade(int year)
        {
            return this.logic.AuthorsBornInDecade(year);
        }
    }
}
