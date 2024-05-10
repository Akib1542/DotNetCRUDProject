using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Repo
{
    public class CatagoryRepo : IBulky<Catagory, int , Catagory>
    {
        private readonly ApplicationDbContext _db;

        public CatagoryRepo(ApplicationDbContext _db) 
        {
            this._db = _db;
        }

        public async Task<Catagory> Create(Catagory type)
        {
            _db.Catagories.Add(type);
            if (_db.SaveChanges() != 0) return await Task.FromResult(type);
            return null;

        }

        public async Task<bool> Delete(int type)
        {
            try
            {
                _db.Catagories.Remove(_db.Catagories.Find(type));
                _db.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<List<Catagory>> GetAll()
        {
            return await _db.Catagories.ToListAsync();
        }

        public async Task<Catagory> Read(int id)
        {
            return await _db.Catagories.FindAsync(id);
        }

        public async Task<Catagory> Update(Catagory type)
        {
            try
            {
                _db.Catagories.Update(type);
                _db.SaveChanges();
                return await Task.FromResult(type);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
