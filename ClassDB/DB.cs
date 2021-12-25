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

        public static Employees[] GetAll() {
            northwindDataContext nw = new northwindDataContext();

            return nw.Employees.ToArray();
        }

        private static int GetMaxSerial() {
            northwindDataContext nw = new northwindDataContext();

            return nw.Employees.ToArray().Length != 0 ?
                  nw.Employees.Max(e => e.EmployeeID) + 1 : constant.配號初始值;
        }

        public static void New(string lastName, string firstName, string address) {
            northwindDataContext nw = new northwindDataContext();

            Employees emp = new Employees();

            int serial = GetMaxSerial();

            emp.EmployeeID = serial;
            emp.LastName = lastName;
            emp.FirstName = firstName;
            emp.Address = address;

            nw.Employees.InsertOnSubmit(emp);
            nw.SubmitChanges();           
        }

        public static void Update(int employeeID, string lastName, string firstName, string address) {
            northwindDataContext nw = new northwindDataContext();

            Employees emp = nw.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);

            if (emp == null) return;

            emp.LastName = lastName;
            emp.FirstName = firstName;
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

        private Employees _getEmp;

        public Employees GetEmp {
            get {
                if (_getEmp == null) {
                    if (!EmployeeID.HasValue) return null;

                    _getEmp = Employees.Get(EmployeeID.Value);
                }

                return _getEmp;
            }
        }

        public string EmpName {
            get {
                if (GetEmp == null) return null;

                return GetEmp.FirstName + GetEmp.LastName;
            }
        }

        private Customers _getCustomer;

        public Customers GetCustomer {
            get {
                if (_getCustomer == null) {
                    if (string.IsNullOrEmpty(CustomerID)) return null;

                    _getCustomer = Customers.Get(CustomerID);
                }

                return _getCustomer;
            }
        }

        public string CustomerName {
            get {
                if (GetCustomer == null) return null;

                return GetCustomer.ContactName;
            }
        }

        public static Orders Get(int orderID) {
            northwindDataContext nw = new northwindDataContext();

            return nw.Orders.FirstOrDefault(o => o.OrderID == orderID);
        }

        public static Orders[] FindByCustomer(string customerID) {
            northwindDataContext nw = new northwindDataContext();

            return nw.Orders.Where(o => o.CustomerID == customerID).ToArray();
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

