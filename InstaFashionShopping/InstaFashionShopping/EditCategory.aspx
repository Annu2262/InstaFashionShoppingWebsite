<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="InstaFashionShopping.EditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <br />
        <br />
        <div class="form-horizontal ">
            <h2>Edit Brand</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label " runat="server" Text="Enter Category ID"></asp:Label>
                <div class="col-md-3 ">

                    <asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true"  ontextchanged="txtID_TextChanged"></asp:TextBox> 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass="text-danger " ErrorMessage="*Please Enter CategoryId" ControlToValidate="txtID" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" CssClass="col-md-2 control-label " runat="server" Text="Category Name"></asp:Label>
                <div class="col-md-3 ">
                    <asp:TextBox ID="txtUpdateCatName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger " ErrorMessage="*Please Enter CategoryName" ControlToValidate="txtUpdateCatName" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
                    
            <div class="form-group">
                <div class="col-md-2 "></div>
                <div class="col-md-4 ">
                    <asp:Button ID="btnUpdateCategory" runat="server" Text="Update" BackColor="Blue" Font-Bold="False" Font-Size="12pt" ForeColor="White" Height="38px" Width="85px" border-radius="5px" OnClick="btnUpdateCategory_Click"/>
                    <br />
                </div>
            </div>
        </div>
        <h1>Category</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading">All Categories</div>
            <div class="col-md-12">
                <h4 class="alert-info text-center"> All Categories</h4>
                <br />
                 <asp:TextBox ID="txtFilterGrid1Record" style="border:2px solid blue" CssClass="form-control" runat="server" placeholder="Search Brand...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                <hr />
                   <div class="table table-responsive">
                       <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" EmptyDataText="Record not found...">
                       </asp:GridView>
                   </div>
                </div>
        </div>
        <hr />
    </div>
                    
         

 <script type="text/javascript">
     function Search_Gridview(strKey) {
         var strData = strKey.value.toLowerCase().split(" ");
         var tblData = document.getElementById("<%=GridView1.ClientID %>");
         var rowData;
         for (var i = 1; i < tblData.rows.length; i++) {
             rowData = tblData.rows[i].innerHTML;
             var styleDisplay = 'none';
             for (var j = 0; j < strData.length; j++) {
                 if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                     styleDisplay = '';
                 else {
                     styleDisplay = 'none';
                     break;
                 }
             }
             tblData.rows[i].style.display = styleDisplay;
         }
     }  
        </script>

</asp:Content>
