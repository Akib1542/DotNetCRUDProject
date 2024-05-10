using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace BulkyBookWeb.Interfaces
{
    public interface ICatagory
    {
        Task<view> GetAllCatagories(string search);

        Task<Catagory> CreateCatagoryAsync(Catagory catagory);
        
          Task<Catagory> GetCatagoryAsync(int catagoryId);
         Task<Catagory>UpdateCatagoryAsync(Catagory catagory);

         Task<bool>DeleteCatagoryAsync(int catagoryId);

         Task<List<Catagory> >GetCatBySearch(string search);
    }
}
