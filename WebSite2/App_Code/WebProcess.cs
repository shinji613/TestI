using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI;

/// <summary>
/// WebProcess 的摘要描述
/// </summary>
public class WebProcess {
    private WebService _ws;

    public WebService WS {
        get { return _ws; }
        set { _ws = value; }
    }

    public WebProcess() {
        WS = new WebService();
    }

    public Employees GetByEmp(int employeeID) {
        return WS.GetByEmp(employeeID);
    }

    public Employees[] GetAllByEmp() {
        return WS.GetAllByEmp();
    }

    public void NewByEmp(string lastName, string firstName, string address) {
        WS.NewByEmp(lastName, firstName, address);
    }

    public void UpdateByEmp(int employeeID, string lastName, string firstName, string address) {
        WS.UpdateByEmp(employeeID, lastName, firstName, address);
    }

    public void DeleteByEmp(int employeeID) {
        WS.DeleteByEmp(employeeID);
    }

}