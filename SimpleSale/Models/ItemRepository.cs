using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SimpleSale.Models;

namespace SimpleSale
{
    public class ItemRepository : IItemRepository
    {
        private SimpleSaleContext context = new SimpleSaleContext();

        public IQueryable<Item> All
        {
            get { return context.Items; }
        }

        public IQueryable<Item> AllIncluding(params Expression<Func<Item, object>>[] includeProperties)
        {
            IQueryable<Item> query = context.Items;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Item Find(int id)
        {
            IQueryable<Item> items = context.Items.Where(a => a.Id == id).Include(a => a.Category);
            return items.FirstOrDefault();
        }

        public Item Add(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            Item item = context.Items.FirstOrDefault(a => a.Id == id);
            context.Items.Remove(item);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

    public interface IItemRepository : IDisposable
    {
        IQueryable<Item> All { get; }

        IQueryable<Item> AllIncluding(params Expression<Func<Item, object>>[] includeProperties);

        Item Find(int id);

        void Delete(int id);

        Item Add(Item item);
    }
}