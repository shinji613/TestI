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
            div_EmpEdit.Visible = true;
        } else {
            div_EmpInfo.Visible = true;

            GridView_Emp.DataSource = WP.GetAllByEmp();
            GridView_Emp.DataBind();
        }
    }

    #endregion

    #region 員工資訊

    protected void GridView_Emp_PageIndexChanging(object sender, GridViewPageEventArgs e) {
        GridView view = (GridView)sender;

        if (view == null) return;

        view.PageIndex = e.NewPageIndex;
        view.DataSource = WP.GetAllByEmp();
        view.DataBind();
    }

    protected void GridView_Emp_RowCommand(object sender, GridViewCommandEventArgs e) {
        GridView view = (GridView)sender;

        if (view == null) return;

        try {
            int index = Convert.ToInt32(e.CommandArgument);

            view.SelectedIndex = index;

            int employeeID = int.Parse(view.DataKeys[index]["EmployeeID"].ToString());

            if (e.CommandName == "Edi") {
                DetailsView_Edit.DataSource = new WebAPI.Employees[] { WP.GetByEmp(employeeID) };
                DetailsView_Edit.DataBind();

                SetUI(view);
            } else if (e.CommandName == "Del") {             
                WP.DeleteByEmp(employeeID);

                Response.Write("<script>alert('刪除員工成功')</script>");

                SetUI();
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
        try {
            WP.NewByEmp(((TextBox)DetailsView_New.Rows[0].Cells[1].Controls[0]).Text,
                        ((TextBox)DetailsView_New.Rows[1].Cells[1].Controls[0]).Text,
                        ((TextBox)DetailsView_New.Rows[2].Cells[1].Controls[0]).Text
                       );

            Response.Write("<script>alert('新增員工成功')</script>");

            SetUI();
        } catch (Exception ex) {
            Response.Write("<script>alert('新增員工失敗，錯誤原因：" + ex.Message + "')</script>");

            return;
        }
    }

    #endregion

    #region 異動員工

    protected void Button_Edit_Click(object sender, EventArgs e) {
        try {
            WP.UpdateByEmp(int.Parse(DetailsView_Edit.DataKey["EmployeeID"].ToString()),
                           ((TextBox)DetailsView_Edit.Rows[1].Cells[1].Controls[0]).Text,
                           ((TextBox)DetailsView_Edit.Rows[2].Cells[1].Controls[0]).Text,
                           ((TextBox)DetailsView_Edit.Rows[3].Cells[1].Controls[0]).Text
                          );

            Response.Write("<script>alert('異動員工成功')</script>");

            SetUI();
        } catch (Exception ex) {
            Response.Write("<script>alert('異動員工失敗，錯誤原因：" + ex.Message + "')</script>");

            return;
        }
    }

    #endregion

    #region 返回員工資訊

    protected void Button_Back_Click(object sender, EventArgs e) {
        SetUI();
    }

    #endregion


}