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

            return nw.Orders.FirstOrDefault(o => o.OrderID == orderID);
        }

        private static int GetMaxSerial() {
            northwindDataContext nw = new northwindDataContext();

            return nw.Orders.ToArray().Length != 0 ?
                  nw.Orders.Max(o => o.OrderID) + 1 : constant.配號初始值;
        }

        public static void New(int employeeID, string customerID, string shipName) {
            northwindDataContext nw = new northwindDataContext();

            Orders order = new Orders();

            int serial = GetMaxSerial();

            order.OrderID = serial;
            order.EmployeeID = employeeID;
            order.CustomerID = customerID;
            order.ShipName = shipName;
            order.OrderDate = DateTime.Now;

            nw.Orders.InsertOnSubmit(order);
            nw.SubmitChanges();
        }

        public static void Update(int orderID, string shipName) {
            northwindDataContext nw = new northwindDataContext();

            Orders order = nw.Orders.FirstOrDefault(o => o.OrderID == orderID);

            if (order == null) return;

            order.ShipName = shipName;

            nw.SubmitChanges();
        }

        public static void Delete(int orderID) {
            northwindDataContext nw = new northwindDataContext();

            Orders order = nw.Orders.FirstOrDefault(o => o.OrderID == orderID);

            if (order == null) return;

            nw.Orders.DeleteOnSubmit(order);

            nw.SubmitChanges();
        }
    }

    /// <summary>顧客</summary>
    public partial class Customers {

        public static Customers Get(string customerID) {
            northwindDataContext nw = new northwindDataContext();

            return nw.Customers.FirstOrDefault(c => c.CustomerID == customerID);
        }

        public static void New(string contactName, string address, string phone) { 
            northwindDataContext nw = new northwindDataContext();

            Customers customer = new Customers();

            string guid = Guid.NewGuid().ToString().Substring(0,8);

            customer.CustomerID = guid;
            customer.ContactName = contactName;
            customer.Address = address;
            customer.Phone = phone;

            nw.Customers.InsertOnSubmit(customer);
            nw.SubmitChanges();
        }

        public static void Update(string customerID, string contactName, string address, string phone) {
            northwindDataContext nw = new northwindDataContext();

            Customers customer = nw.Customers.FirstOrDefault(o => o.CustomerID == customerID);

            if (customer == null) return;

            customer.ContactName = contactName;
            customer.Address = address;
            customer.Phone = phone;

            nw.SubmitChanges();
        }

        public static void Delete(string customerID) {
            northwindDataContext nw = new northwindDataContext();

            Customers customer = nw.Customers.FirstOrDefault(o => o.CustomerID == customerID);

            if (customer == null) return;

            nw.Customers.DeleteOnSubmit(customer);

            nw.SubmitChanges();
        }
    }
}

