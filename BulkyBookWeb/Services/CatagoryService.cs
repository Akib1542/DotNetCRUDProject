using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Services
{
    public class CatagoryService : ICatagory
    {
        private readonly IBulky<Catagory, int, Catagory> catRepo;

        public CatagoryService(IBulky<Catagory, int, Catagory> catRepo)
        {
            this.catRepo = catRepo;
        }

        public async Task<Catagory> CreateCatagoryAsync(Catagory catagory)
        {
            var data = await catRepo.Create(catagory);
            return data;
        }

       

        public async Task<view> GetAllCatagories(string search)
        {
            var data = new view();
            data.Catagories = await catRepo.GetAll();
            data.search = search;
            return data;

        }

        public async Task<bool> DeleteCatagoryAsync(int catagoryId)
        {
            return await catRepo.Delete(catagoryId);
        }
            public async Task<Catagory> GetCatagoryAsync(int catagoryId)
        {
            var data = await catRepo.Read(catagoryId);
            return data;
        }


        public async Task<Catagory> UpdateCatagoryAsync(Catagory catagory)
        {
            var data =  await catRepo.Update(catagory); 
            return data;
        }

        public async Task<List<Catagory>> GetCatBySearch(string search)
        {
            var data = await catRepo.GetAll();
            var datas = new List<Catagory>();
            if(search == null)
            {
                return data;
            }
            for(int i=0;i<data.Count;i++)
            {
                if (data[i].Name.Contains(search))
                {
                    datas.Add(data[i]);
                }
            }

            return datas;
        }
    }
}
