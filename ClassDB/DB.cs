using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB {
    /// <summary>員工</summary>
    public partial class Employees{

        public static Employees Get(int employeeID) {
            northwindDataContext nw = new northwindDataContext();

            return nw.Employees.FirstOrDefault(a => a.EmployeeID == employeeID);
        }
    }

    /// <summary>訂單</summary>
    public partial class Orders {

        public static Orders Get(int orderID) {
            northwindDataContext nw = new northwindDataContext();

            return nw.Orders.FirstOrDefault(a => a.OrderID == orderID);
        }
    }

    /// <summary>顧客</summary>
    public partial class Customers {

        public static Customers Get(string customerID) {
            northwindDataContext nw = new northwindDataContext();

            return nw.Customers.FirstOrDefault(a => a.CustomerID == customerID);
        }
    }
}
