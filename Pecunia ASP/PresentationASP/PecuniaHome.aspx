<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PecuniaHome.aspx.cs" Inherits="PresentationASP.PecuniaHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <asp:Menu runat="server" ID="menu" Orientation="Vertical" StaticMenuItemStyle-HorizontalPadding=""> 
                <Items>
                    <asp:MenuItem Text="Loan" Value="Products" NavigateUrl="~/Loans.aspx"></asp:MenuItem>
                    
                </Items>
            </asp:Menu>

        </div>
    </form>
</body>
</html>
