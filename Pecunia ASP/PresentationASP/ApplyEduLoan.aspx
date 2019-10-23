<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyEduLoan.aspx.cs" Inherits="PresentationASP.ApplyEduLoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Apply Educational Loan</h3>
            <table>
                
                <tr>
                    <td><asp:Label ID="customerIDLabel" runat="server" Text="Customer ID"></asp:Label></td>
                    <td><asp:TextBox ID="customerIDTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>

                    <td><asp:Label ID="courseLabel" runat="server" Text="Course "></asp:Label></td>
                    <td><asp:DropDownList ID="courseDropDown" runat="server">
                        <asp:ListItem Text="Undergraduate" Value="Undergraduate"></asp:ListItem>
                        <asp:ListItem Text="Masters" Value="Masters"></asp:ListItem>
                        <asp:ListItem Text="PHD" Value="PHD"></asp:ListItem>
                        <asp:ListItem Text="M.PHIL" Value="M.PHIL"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                    </asp:DropDownList></td  >
                    
                </tr>
                <tr>
                    <td><asp:Label ID="amountAppliedLabel" runat="server" Text="Amount Applied "></asp:Label></td>
                    <td><asp:TextBox ID="amountAppliedTextBox" runat="server" ReadOnly="False" ></asp:TextBox><br/></td>

                    <td><asp:Label ID="instituteNameLabel" runat="server" Text="Institute Name "></asp:Label></td>
                    <td><asp:TextBox ID="instituteNameTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="repaymentPeriodLabel" runat="server" Text="Repayment Period "></asp:Label></td>
                    <td><asp:TextBox ID="repaymentPeriodTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>

                    <td><asp:Label ID="studentIDLabel" runat="server" Text="StudentID "></asp:Label></td>
                    <td><asp:TextBox ID="studentIDTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr></tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="Back" runat="server" Text="BacK" OnClick="Back_Click" /></td>
                    <td><asp:Button ID="Submit" runat="server" Text="Submit" onclick="Submit_Click"/></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="customerListGridView" runat="server"></asp:GridView>
    </form>
</body>
</html>
