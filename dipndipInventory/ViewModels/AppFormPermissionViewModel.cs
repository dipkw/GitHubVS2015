using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class AppFormPermissionViewModel
    {
        public int role_id { get; set; }
        public int form_id { get; set; }
        public string form_desc { get; set; }
        public bool create_permission { get; set; }
        public bool read_permission { get; set; }
        public bool update_permission { get; set; }
        public bool delete_permission { get; set; }
        public int row_index { get; set; }
    }
}
