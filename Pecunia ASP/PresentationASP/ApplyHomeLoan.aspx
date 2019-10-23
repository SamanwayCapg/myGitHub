<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyHomeLoan.aspx.cs" Inherits="PresentationASP.ApplyHomeLoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Apply Home Loan</h4>
            <table >
                <tr>
                    <td ><asp:Label ID="loanIDLabel" runat="server" Text="Loan ID" ></asp:Label></td>
                    <td><asp:TextBox ID="loanIDTextBox" runat="server" ReadOnly="False" ForeColor="#CC99FF"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="customerIDLabel" runat="server" Text="Customer ID" ></asp:Label></td>
                    <td><asp:TextBox ID="customerIDTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td  ><asp:Label ID="amountAppliedLabel" runat="server" Text="Amount Applied " ></asp:Label></td>
                    <td ><asp:TextBox ID="amountAppliedTextBox" runat="server" ReadOnly="False" ></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="interestRateLabel" runat="server" Text="Interest Rate " > </asp:Label></td>
                    <td><asp:TextBox ID="interestRateTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="EMI_AmountLabel" runat="server" Text="EMI Amount " ></asp:Label></td>
                    <td><asp:TextBox ID="EMI_AmountTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="repaymentPeriodLabel" runat="server" Text="Repayment Period " ></asp:Label></td>
                    <td><asp:TextBox ID="repaymentPeriodTextBox" runat="server" ReadOnly="False" ForeColor="#CCFFFF"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="dateOfApplicationLabel" runat="server" Text="Date Of Application " ></asp:Label></td>
                    <td><asp:TextBox ID="dateOfApplicationTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="statusLabel" runat="server" Text="Status " ></asp:Label></td>
                    <td><asp:TextBox ID="statusTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="occupationLabel" runat="server" Text="Occupation" ></asp:Label></td>
                    <td><asp:TextBox ID="occupationTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="grossIncomeLabel" runat="server" Text="Gross Income " ></asp:Label></td>
                    <td><asp:TextBox ID="grossIncomeTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td ><asp:Label ID="salaryDeductionsLabel" runat="server" Text="Salary Deductions " ></asp:Label></td>
                    <td><asp:TextBox ID="salaryDeductionsTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
                </tr>
                 <tr>
                    <td ><asp:Label ID="serviceYearsLabel" runat="server" Text="Service Years " ></asp:Label></td>
                    <td><asp:TextBox ID="serviceYearsTextBox" runat="server" ReadOnly="False"></asp:TextBox><br/></td>
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
