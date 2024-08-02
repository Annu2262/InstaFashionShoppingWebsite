<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditSubCategory.aspx.cs" Inherits="InstaFashionShopping.EditSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container ">
        <br />
        <br />
        <div class="form-horizontal ">
            <h2>Edit Sub-Category</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label " runat="server" Text="Enter Sub-Category ID"></asp:Label>
                <div class="col-md-3 ">

                    <asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtID_TextChanged" ></asp:TextBox> 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass="text-danger " ErrorMessage="*Please Enter CategoryId" ControlToValidate="txtID" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" CssClass="col-md-2 control-label " runat="server" Text="Select Category Name"></asp:Label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlMainCategory" CssClass="form-control" runat="server">
                   </asp:DropDownList></div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" CssClass="col-md-2 control-label " runat="server" Text="Enter Sub-Category"></asp:Label>
                <div class="col-md-3 ">

                    <asp:TextBox ID="txtSubCategory" CssClass="form-control" runat="server" AutoPostBack="true" ></asp:TextBox> 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger " ErrorMessage="*Please Enter Sub-Category" ControlToValidate="txtSubCategory" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
                    
            <div class="form-group">
                <div class="col-md-2 "></div>
                <div class="col-md-4 ">
                    <asp:Button ID="btnUpdateSubCategory" runat="server" Text="Update" BackColor="Blue" Font-Bold="False" Font-Size="12pt" ForeColor="White" Height="38px" Width="85px" border-radius="5px" OnClick="btnUpdateSubCategory_Click" />
                    <br />
                </div>
            </div>
        </div>
        <h1>Sub-Category</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading">All Sub-Category</div>
            <div class="col-md-12">
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
