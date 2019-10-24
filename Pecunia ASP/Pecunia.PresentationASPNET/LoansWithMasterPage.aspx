<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoansWithMasterPage.aspx.cs" Inherits="Pecunia.PresentationASPNET.LoansWithMasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
            <div class="left-box">
                <table class="myMenu">
                    <tr><td>
                    <asp:Menu runat="server" ID="applyLoanMenu" Orientation="Vertical" StaticMenuItemStyle-HorizontalPadding="" ItemWrap="true" DynamicVerticalOffset="10"> 
                    <Items >
                        <asp:MenuItem Text="Apply Home Loan" Value="applyHomeLoan" NavigateUrl="~/ApplyHomeLoan.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Apply Car Loan" Value="applyCarLoan" NavigateUrl="~/ApplyCarLoan.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Apply Edu Loan" Value="applyEduLoan" NavigateUrl="~/ApplyEduLoan.aspx"></asp:MenuItem>
                    </Items>    
                    </asp:Menu>
                    </td></tr>
                </table>
            </div>
        
            <div class="right-box" >
                <table border="1" class="table_header" >
                    <tr>
                        <td><asp:Label ID="Label1" runat="server" Text="Loan Details"></asp:Label></td>
                    </tr>
                </table>
                <table border="1" class="table_content">
                <tbody>
                <tr>
                    <td><asp:Label ID="loanIDLabel" runat="server" Text="Loan ID"></asp:Label></td>
                    <td><asp:TextBox ID="loanIDTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="dateOfApplicationLabel" runat="server" Text="Date Of Application "></asp:Label></td>
                    <td><asp:TextBox ID="dateOfApplicationTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="occupationLabel" runat="server" Text="Occupation"></asp:Label></td>
                    <td><asp:TextBox ID="occupationTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="customerIDLabel" runat="server" Text="Customer ID"></asp:Label></td>
                    <td><asp:TextBox ID="customerIDTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="statusLabel" runat="server" Text="Status "></asp:Label></td>
                    <td><asp:TextBox ID="statusTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="grossIncomeLabel" runat="server" Text="Gross Income "></asp:Label></td>
                    <td><asp:TextBox ID="grossIncomeTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="amountAppliedLabel" runat="server" Text="Amount Applied "></asp:Label></td>
                    <td><asp:TextBox ID="amountAppliedTextBox" runat="server" ReadOnly="True" ></asp:TextBox><br/></td>

                    <td><asp:Label ID="courseLabel" runat="server" Text="Course "></asp:Label></td>
                    <td><asp:TextBox ID="courseTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="salaryDeductionsLabel" runat="server" Text="Salary Deductions "></asp:Label></td>
                    <td><asp:TextBox ID="salaryDeductionsTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="interestRateLabel" runat="server" Text="Interest Rate "></asp:Label></td>
                    <td><asp:TextBox ID="interestRateTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="instituteNameLabel" runat="server" Text="Institute Name "></asp:Label></td>
                    <td><asp:TextBox ID="instituteNameTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="vehicleLabel" runat="server" Text="Vehicle "></asp:Label></td>
                    <td><asp:TextBox ID="vehicleTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="EMI_AmountLabel" runat="server" Text="EMI Amount "></asp:Label></td>
                    <td><asp:TextBox ID="EMI_AmountTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="studentIDLabel" runat="server" Text="StudentID "></asp:Label></td>
                    <td><asp:TextBox ID="studentIDTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="serviceYearsLabel" runat="server" Text="Service Years "></asp:Label></td>
                    <td><asp:TextBox ID="serviceYearsTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>
                </tr>
                <tr>
                    <td><asp:Label ID="repaymentPeriodLabel" runat="server" Text="Repayment Period "></asp:Label></td>
                    <td><asp:TextBox ID="repaymentPeriodTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>

                    <td><asp:Label ID="repaymentHolidayLabel" runat="server" Text="Repayment Holiday "></asp:Label></td>
                    <td><asp:TextBox ID="repaymentHolidayTextBox" runat="server" ReadOnly="True"></asp:TextBox><br/></td>
                </tr>
                </tbody>
            </table>

            <table class="table_header">
                <tr><td>
                <asp:Label ID="searchLoan" runat="server" Text="Search Loan"></asp:Label>
                
                <asp:DropDownList ID="selectID" runat="server">
                    <asp:ListItem Text="by Customer ID" Value="1"></asp:ListItem>
                    <asp:ListItem Text="by Loan ID" Value="2"></asp:ListItem>
                </asp:DropDownList>
                
                <asp:DropDownList ID="selectLoanType" runat="server">
                    <asp:ListItem Text="Home Loan" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Car Loan" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Edu Loan" Value="2"></asp:ListItem>
                </asp:DropDownList>
                
                <asp:TextBox ID="IDTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
                </td></tr>
            </table>
        </div>
        </div>
</asp:Content>
