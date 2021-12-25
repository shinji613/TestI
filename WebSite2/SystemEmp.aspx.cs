using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SystemEmp : System.Web.UI.Page {
    public WebProcess WP {
        get {
             WebProcess wp = new WebProcess();

            return wp;
        } 
    }


    protected void Page_Load(object sender, EventArgs e) {
        if (IsPostBack) return;

        SetUI();
    }

    #region UI

    private void ReSetUI() {
        div_EmpInfo.Visible = false;
        div_EmpNew.Visible = false;
        div_EmpEdit.Visible = false;
    }

    public void SetUI(WebControl control = null) {
        ReSetUI();

        if(control != null && control.ID == "Button_Add") {
            DetailsView_New.DataSource =  new WebAPI.Employees[] { new WebAPI.Employees() };
            DetailsView_New.DataBind();

            div_EmpNew.Visible = true;
        } else if (control != null && control.ID == "GridView_Emp") {
            DetailsView_Edit.DataBind();

            div_EmpEdit.Visible = true;
        } else {
            div_EmpInfo.Visible = true;

            GridView_Emp.DataSource = WP.GetAllByEmp();
            GridView_Emp.DataBind();
        }
    }

    #endregion

    #region 員工資訊

    protected void GridView_Emp_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
        GridView view = (GridView)sender;

        if (view == null) return;

        view.PageIndex = e.NewSelectedIndex;
        view.DataBind();
    }

    protected void GridView_Emp_RowCommand(object sender, GridViewCommandEventArgs e) {
        GridView view = (GridView)sender;

        if (view == null) return;

        try {
            int index = Convert.ToInt32(e.CommandArgument);

            view.SelectedIndex = index;

            if (e.CommandName == "Edi") {
                SetUI(view);
            } else if (e.CommandName == "Del") {
                int employeeID = int.Parse(view.DataKeys[index]["EmployeeID"].ToString());

                WP.DeleteByEmp(employeeID);
            }

        } catch (Exception ex) {
            Response.Write("<script>alert('" + ex.Message + "')</script>");

            return;
        }
    }

    #endregion

    #region 新增員工

    protected void Button_Add_Click(object sender, EventArgs e) {
        SetUI(Button_Add);
    }

    protected void Button_New_Click(object sender, EventArgs e) {

    }

    #endregion

    #region 異動員工

    protected void Button_Edit_Click(object sender, EventArgs e) {

    }

    #endregion


}