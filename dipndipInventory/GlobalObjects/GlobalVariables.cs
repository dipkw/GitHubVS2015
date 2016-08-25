using dipndipInventory.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.GlobalObjects
{
    public class GlobalVariables1
    {
        public static string MESSAGE_TITLE = "dipndip";
        public static bool update_customer = false;
        public static string DATE_FORMAT = "dd/MM/yyyy";
        public static ck_users ActiveUser = new ck_users();
        public static long selected_stock_id = 0;
    }
}
