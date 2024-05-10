using BulkyBookWeb.Interfaces;

namespace BulkyBookWeb.Models
{
    public class view
    {
        public IEnumerable<Catagory> Catagories { get; set; }
        public string search { get; set; }
    }
}
