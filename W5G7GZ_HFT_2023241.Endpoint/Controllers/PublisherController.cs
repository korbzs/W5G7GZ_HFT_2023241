using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using W5G7GZ_HFT_2023241.Logic.Interfaces;
using W5G7GZ_HFT_2023241.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace W5G7GZ_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherLogic logic;

        public PublisherController(IPublisherLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<SeasonController>
        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<SeasonController>/5
        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<SeasonController>
        [HttpPost]
        public void Create([FromBody] Publisher value)
        {
            this.logic.Create(value);
        }

        // PUT api/<SeasonController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Publisher value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<SeasonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
