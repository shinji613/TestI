using ClassDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// WebService 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService() {

        //如果使用設計的元件，請取消註解下列一行
        //InitializeComponent(); 
    }

    [WebMethod]
    public Employees GetByEmp(int employeeID) {
        return ClassDB.Employees.Get(employeeID);
    }

    [WebMethod]
    public Employees[] GetAllByEmp() {
        return ClassDB.Employees.GetAll();
    }

    [WebMethod]
    public void NewByEmp(string lastName, string firstName, string address) {
        ClassDB.Employees.New(lastName,  firstName,  address);
    }

    [WebMethod]
    public void UpdateByEmp(int employeeID, string lastName, string firstName, string address) {
        ClassDB.Employees.Update(employeeID, lastName, firstName, address);
    }

    [WebMethod]
    public void DeleteByEmp(int employeeID) {
        ClassDB.Employees.Delete(employeeID);
    }

}
