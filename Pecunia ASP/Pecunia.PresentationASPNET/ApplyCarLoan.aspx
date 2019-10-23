<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyCarLoan.aspx.cs" Inherits="PresentationASP.ApplyCarLoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Apply Car Loan</h4>
            <table>
                
                <tr>
                    <td><asp:Label ID="customerIDLabel" runat="server" Text="Customer ID"></asp:Label></td>
                    <td><asp:TextBox ID="customerIDTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>

                    <td><asp:Label ID="grossIncomeLabel" runat="server" Text="Gross Income "></asp:Label></td>
                    <td><asp:TextBox ID="grossIncomeTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="salaryDeductionsLabel" runat="server" Text="Salary Deductions "></asp:Label></td>
                    <td><asp:TextBox ID="salaryDeductionsTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>

                    <td><asp:Label ID="vehicleLabel" runat="server" Text="Vehicle "></asp:Label></td>
                    <td><asp:TextBox ID="vehicleTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="amountAppliedLabel" runat="server" Text="Amount Applied "></asp:Label></td>
                    <td><asp:TextBox ID="amountAppliedTextBox" runat="server" ReadOnly="False" ></asp:TextBox><br/></td>

                    <td><asp:Label ID="repaymentPeriodLabel" runat="server" Text="Repayment Period "></asp:Label></td>
                    <td><asp:TextBox ID="repaymentPeriodTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="occupationLabel" runat="server" Text="Occupation"></asp:Label></td>
                    <td><asp:TextBox ID="occupationTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>  
                </tr>
               <tr>
                   <td><asp:Button ID="Back" runat="server" Text="Back" onclick="Back_Click"/></td>
                    <td><asp:Button ID="Submit" runat="server" Text="Submit" onclick="Submit_Click"/></td>
               </tr>
            </table>
        </div>
    </form>
</body>
</html>
