using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;

namespace RESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BogsController : ControllerBase
    {
        static List<Bog> books = new List<Bog>(){
            new Bog("Soulless", "Gail Carriger", 352, "123456789abcd"),
            new Bog("Harry Potter", "J.K. Rowling", 195, "dcba987654321"),
            new Bog("Changeless", "Gail Carriger", 354, "23456789abcde")
        };

        // GET: api/Bogs
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return books;
        }

        // GET: api/Bogs/5
        [HttpGet]
        [Route("{isbn13}")]
        public Bog Get(string isbn13)
        {
            return books.Find(b => b.Isbn13 == isbn13);
        }

        // POST: api/Bogs
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

        // PUT: api/Bogs/5
        [HttpPut]
        [Route("{isbn13}")]
        public string Put(string isbn13, [FromBody] Bog value)
        {
            if (isbn13 != value.Isbn13)
            {
                if (Get(value.Isbn13)!= null)
                {
                    return "Der findes allerede en bog med det nye isbn13";
                }
            }

            if (Get(isbn13)!= null)
            {
                Delete(isbn13);
                Post(value);
                return "bogen er blevet opdateret";
            }

            return "der findes ikke en bog med det nr";

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{isbn13}")]
        public string Delete(string isbn13)
        { 

            if (books.Remove(Get(isbn13)))
            {
                return "bogen er fjernet";
            }

            return "Bogen findes allerede ikke";
        }
    }
}
