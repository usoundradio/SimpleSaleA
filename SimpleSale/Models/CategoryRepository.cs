using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace SimpleSale.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private SimpleSaleContext context = new SimpleSaleContext();

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.Include(a => a.Items);
        }

        public Category Get(int id)
        {
            IQueryable<Category> categories = context.Categories.Where(a => a.Id == id).Include(a => a.Items);
            return categories.FirstOrDefault();
        }


        public Category Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }
        public Reciept AddReciept(Reciept receipt)
        {
            context.Reciepts.Add(receipt);
            context.SaveChanges();
            return receipt;
        }
        public void Delete(int id)
        {
            Category category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public bool Update(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

     
    }

    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category Get(int id);

        Category Add(Category category);
        Reciept AddReciept(Reciept reciept);


        void Delete(int id);

        bool Update(Category category);

    }
}