<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       
    <h2>訂單查詢</h2>

    <table>
        <tr>
            <th>顧客編號</th>
            <td><asp:TextBox ID="Text_CustomerID" runat="server" /></td>
        </tr>   
    </table> 

    <br />

    <asp:Button ID="Button_Query" runat="server" Text="查詢訂單" OnClick="Button_Query_Click" />
    
    <br />
    
    <h2>訂單資訊</h2>

    <asp:GridView ID="GridView_Order" 
                  runat="server" 
                  DataSourceID="DataSource_Order"
                  DataKeyNames="OrderID,CustomerID" 
                  AutoGenerateColumns="false"  >
        <Columns>
            <asp:BoundField DataField="CustomerName" HeaderText="顧客" />
            <asp:BoundField DataField="EmpName" HeaderText="服務員工"  />
            <asp:BoundField DataField="OrderID" HeaderText="訂單編號"  />
            <asp:BoundField DataField="OrderDate" HeaderText="訂單日期"  />
            <asp:BoundField DataField="ShipName" HeaderText="消費店家"  />
        </Columns>
    </asp:GridView>
    
    
    <asp:ObjectDataSource ID="DataSource_Order" 
                          runat="server" 
                          TypeName="ClassDB.Orders,ClassDB"
                          SelectMethod="FindByCustomer"
                          OnSelecting="DataSource_Order_Selecting" >
        <SelectParameters>
            <asp:Parameter Name="customerID" DbType="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    
</asp:Content>

