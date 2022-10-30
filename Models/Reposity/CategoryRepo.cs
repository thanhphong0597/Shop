using DoAn.Entities;
using DoAn.Models.Interfaces;
using DoAn.Models.ViewModels;
using DoAn.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace DoAn.Models.Reposity
{
    public class CategoryRepo : ICategory
    {
        private readonly Context Db;
        public CategoryRepo(Context Db)
        {
            this.Db = Db;
        }

        //httpget

        public async Task<IEnumerable<CategoryItem>> GetCategories()
        {
            var data = await (from c in Db.Categories
                              select new CategoryItem
                              {
                                  Id = c.CategoryID,
                                  Name = c.Name,
                                  Slug = c.Slug
                              }).ToListAsync();
            foreach (var i in data)
            {
                var q = await (from g in Db.GenericShoes
                               where g.Category_ID == i.Id
                               select new GenericItem
                               {
                                   Name = g.Name,
                                   Slug = g.Slug,
                                   GenericID = g.GenericShoesID
                               }).ToListAsync();
                i.GenericShoeses = q;
            }
            return data;
        }

        //httpget{id}
        public async Task<CategoryItem> GetCategory(int id)
        {
            var data = await (from c in Db.Categories
                              where c.CategoryID == id
                              select new CategoryItem
                              {
                                  Id = c.CategoryID,
                                  Name = c.Name,
                                  Slug = c.Slug
                              }).FirstOrDefaultAsync();
            var q = await (from g in Db.GenericShoes
                           where g.Category_ID==data.Id
                            select new GenericItem
                                        {
                                            Name=g.Name,
                                            GenericID=g.GenericShoesID,
                                            Slug=g.Slug
                                        }).ToListAsync();
            data.GenericShoeses = q;
            return data;
        }

        public async Task<Category> AddCategory(Category cat)
        {
            var result = await Db.Categories.AddAsync(cat);  
            await Db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteCategory(int id)
        {
            var result = await Db.Categories.FirstOrDefaultAsync(e => e.CategoryID == id);
            if (result != null)
            {
                Db.Categories.Remove(result);
                await Db.SaveChangesAsync();
            }
        }

        public async Task<Category> UpdateCategory(Category cat)
        {
            var data = await Db.Categories.FirstOrDefaultAsync(e => e.CategoryID == cat.CategoryID);
            if(data!= null)
            {
                data.Name = cat.Name;
                data.Slug = cat.Slug;
            }
            await Db.SaveChangesAsync();
            return data;
        }
    }
}
