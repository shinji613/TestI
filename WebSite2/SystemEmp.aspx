<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SystemEmp.aspx.cs" Inherits="SystemEmp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="div_EmpInfo" runat="server" >

    <h2>員工資訊 <asp:button ID="Button_Add" runat="server" text="新增員工" OnClick="Button_Add_Click" />  </h2> 

    <asp:GridView ID="GridView_Emp" 
                  runat="server" 
                  DataKeyNames="EmployeeID" 
                  AutoGenerateColumns="false"
                  AllowPaging="true"
                  PageSize="20"
                  OnRowCommand="GridView_Emp_RowCommand"
                  OnSelectedIndexChanging="GridView_Emp_SelectedIndexChanging" >
        <Columns>
            <asp:ButtonField CommandName="Edi" ButtonType="Button" Text="編輯" />
            <asp:ButtonField CommandName="Del" ButtonType="Button" Text="刪除" />
            <asp:BoundField DataField="EmployeeID" HeaderText="員工編號" />
            <asp:BoundField DataField="LastName" HeaderText="LastName"  />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName"  />
            <asp:BoundField DataField="Address" HeaderText="住家地址"  />
        </Columns>
    </asp:GridView>

    </div>

    <div id="div_EmpNew" runat="server" >
        <h2>新增員工資料</h2>
        <asp:DetailsView ID="DetailsView_New" 
                         runat="server" 
                         DataKeyNames="EmployeeID"
                         AutoGenerateRows="false"
                         DefaultMode="Insert" >
            <Fields>
               <asp:BoundField DataField="EmployeeID" HeaderText="員工編號" />
               <asp:BoundField DataField="LastName" HeaderText="LastName"  />
               <asp:BoundField DataField="FirstName" HeaderText="FirstName"  />
               <asp:BoundField DataField="Address" HeaderText="住家地址"  />
            </Fields>
        </asp:DetailsView>

        <asp:Button ID="Button_New" runat="server" Text="新增員工資料" OnClick="Button_New_Click" />

    </div>

    <div id="div_EmpEdit" runat="server" >
         <h2>異動員工資料</h2>
          <asp:DetailsView ID="DetailsView_Edit" 
                           runat="server" 
                           DataKeyNames="EmployeeID"
                           AutoGenerateRows="false"
                           DefaultMode="Edit" >
            <Fields>
               <asp:BoundField DataField="EmployeeID" HeaderText="員工編號" ReadOnly="true" />
               <asp:BoundField DataField="LastName" HeaderText="LastName"  />
               <asp:BoundField DataField="FirstName" HeaderText="FirstName"  />
               <asp:BoundField DataField="Address" HeaderText="住家地址"  />
            </Fields>
        </asp:DetailsView>

        <asp:Button ID="Button_Edit" runat="server" Text="異動員工資料" OnClick="Button_Edit_Click" />
    </div>

</asp:Content>

