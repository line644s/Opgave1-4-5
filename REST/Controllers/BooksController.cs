using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        static List<Bog> books = new List<Bog>(){
            new Bog("Soulless", "Gail Carriger", 352, "123456789abcd"),
            new Bog("Harry Potter", "J.K. Rowling", 195, "dcba987654321"),
            new Bog("Changeless", "Gail Carriger", 354, "23456789abcde")
        };


        // GET: api/Books
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return books;
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("{isbn13}")]
        public Bog Get(string isbn13)
        {
            return books.Find(b => b.Isbn13 == isbn13);
        }

        // POST: api/Books
        [HttpPost]
        public string Post([FromBody] Bog value)
        {

            if (Get(value.Isbn13) != null)
            {
                return "Bogen findes allerede";
            }

            try
            {
                books.Add(value);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Bogen er blevet tilføjet";
        }

        // PUT: api/Books/5
        [HttpPut]
        [Route(("{isbn13}"))]
        public void Put(string isbn13, [FromBody] Bog value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route(("{isbn13}"))]
        public void Delete(string isbn13)
        {
            books.Remove(Get(isbn13));
        }
    }
}
