using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDB {
    public class constant {
        public static int 配號初始值 = 1;
    }

    /// <summary>員工</summary>
    public partial class Employees {

        public static Employees Get(int employeeID) {
            northwindDataContext nw = new northwindDataContext();

            return nw.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
        }

        private static int GetMaxSerial() {
            northwindDataContext nw = new northwindDataContext();

            return nw.Employees.ToArray().Length != 0 ?
                  nw.Employees.Max(e => e.EmployeeID) + 1 : constant.配號初始值;
        }

        public static void New() {
            northwindDataContext nw = new northwindDataContext();

            Employees emp = new Employees();

            int serial = GetMaxSerial();

            emp.EmployeeID = serial;
            emp.LastName = "LastName" + serial;
            emp.FirstName = "FirstName" + serial;
            emp.Address = "Address" + serial;

            nw.Employees.InsertOnSubmit(emp);
            nw.SubmitChanges();
        }

        public static void Update(int employeeID, string address) {
            northwindDataContext nw = new northwindDataContext();

            Employees emp = nw.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

            if (emp == null) return;

            emp.Address = address;

            nw.SubmitChanges();
        }

        public static void Delete(int employeeID) {
            northwindDataContext nw = new northwindDataContext();

            Employees emp = nw.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

            if (emp == null) return;

            nw.Employees.DeleteOnSubmit(emp);

            nw.SubmitChanges();
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

