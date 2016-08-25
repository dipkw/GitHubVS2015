using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public Nullable<bool> active { get; set; }
        public string uname { get; set; }
    }
}
