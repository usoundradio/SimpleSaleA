using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleSale.Models;

namespace SimpleSale.Controllers
{
    public class ItemsController : ApiController
    {
        private readonly IItemRepository productsRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public ItemsController()
            : this(new ItemRepository())
        {
        }

        public ItemsController(IItemRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        private SimpleSaleContext db = new SimpleSaleContext();

        // GET api/Items
        public IEnumerable<Item> GetCategories()
        {
            var urls = db.Items.Include(a => a.Category).ToList();
            return urls;
        }

        public Item Post(Item item)
        {
            return productsRepository.Add(item);
        }

        // GET api/Default1/5
        public Item GetItem(int id)
        {
            Item product = productsRepository.Find(id);
            if (product == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return product;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            productsRepository.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}