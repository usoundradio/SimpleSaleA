using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleSale.Models;

namespace SimpleSale.Controllers
{
    public class Default1Controller : ApiController
    {
        private readonly ICategoryRepository categoryRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public Default1Controller()
            : this(new CategoryRepository())
        {
        }

        public Default1Controller(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        private SimpleSaleContext db = new SimpleSaleContext();

        // GET api/Default1
        public IEnumerable<Category> GetCategories()
        {

            var game = categoryRepository.GetAll().Where(aa=>aa.UserId==User.Identity.Name);
        
            return game;
        }

        public Category Post(Category category)
        {
            return categoryRepository.Add(category);
        }

        public void PutCategory(int id, Category category)
        {
            category.Id = id;
            if (category.UserId == User.Identity.Name)
            {
                if (!categoryRepository.Update(category))
                {
                    //throw new HttpResponseException(HttpStatusCode.NotFound);
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
                }
            }
        }

        // GET api/Default1/5
        public Category GetCategory(int id)
        {

            Category category = categoryRepository.Get(id);


            if (category == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            if (category.UserId == User.Identity.Name)
            {
                return category;

            }
            return null;

        }

        public HttpResponseMessage DeleteCategory(int id, Category category)
        {
            categoryRepository.Delete(id);

           
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}