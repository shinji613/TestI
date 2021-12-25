using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
    }

    protected void Button_Query_Click(object sender, EventArgs e) {
        string customerID = Text_CustomerID.Text;

        try {
            if(string.IsNullOrEmpty(customerID)) {
                throw new Exception("請輸入顧客編號");
            }

            GridView_Order.DataBind();
        } catch (Exception ex) {
            Response.Write("<script>alert('" + ex.Message + "')</script>");

            return;
        }
    }

    protected void DataSource_Order_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) {
        e.InputParameters["customerID"] = Text_CustomerID.Text;
    }
}