using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SimpleSale.Models;

namespace SimpleSale.Controllers
{
    public class RecieptController : ApiController
    {
          private readonly ICategoryRepository categoryRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public RecieptController()
            : this(new CategoryRepository())
        {
        }

        public RecieptController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        private SimpleSaleContext db = new SimpleSaleContext();

        // GET api/Reciept
        public IEnumerable<Reciept> GetReciepts()
        {
            return db.Reciepts.AsEnumerable();
        }

        // GET api/Reciept/5
        public Reciept GetReciept(int id)
        {
            Reciept reciept = db.Reciepts.Find(id);
            if (reciept == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return reciept;
        }

        // PUT api/Reciept/5
        public HttpResponseMessage PutReciept(int id, Reciept reciept)
        {
            if (ModelState.IsValid && id == reciept.Id)
            {
                db.Entry(reciept).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public Reciept Post(Reciept reciept)
        {
            return categoryRepository.AddReciept(reciept);
        }

        // DELETE api/Reciept/5
        public HttpResponseMessage DeleteReciept(int id)
        {
            Reciept reciept = db.Reciepts.Find(id);
            if (reciept == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Reciepts.Remove(reciept);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, reciept);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}