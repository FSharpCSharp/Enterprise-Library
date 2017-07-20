<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ValidationHOL.Web._Default" %>

<%@ Register assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet" namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="First Name" />
                </td>
                <td>
                    <asp:TextBox ID="FirstNameTextBox" runat="server" />
                    <cc1:PropertyProxyValidator ID="FirstNameValidator" runat="server" 
                        ControlToValidate="FirstNameTextBox" PropertyName="FirstName" 
                        SourceTypeName="ValidationHOL.BusinessLogic.Customer, ValidationHOL.BusinessLogic">
                    </cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Last Name" />
                </td>
                <td>
                    <asp:TextBox ID="LastNameTextBox" runat="server" />
                    <cc1:PropertyProxyValidator ID="LastNameValidator" runat="server" 
                        ControlToValidate="LastNameTextBox" PropertyName="LastName" 
                        SourceTypeName="ValidationHOL.BusinessLogic.Customer, ValidationHOL.BusinessLogic">
                    </cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="SSN" />
                </td>
                <td>
                    <asp:TextBox ID="SSNTextBox" runat="server" />
                    <cc1:PropertyProxyValidator ID="SSNValidator" runat="server" PropertyName="SSN" 
                        SourceTypeName="ValidationHOL.BusinessLogic.Customer, ValidationHOL.BusinessLogic" ControlToValidate="SSNTextBox">
                    </cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Street Address" />
                </td>
                <td>
                    <asp:TextBox ID="StreetAddressTextBox" runat="server" />
                    <cc1:PropertyProxyValidator ID="StreetAddressValidator" runat="server" 
                        PropertyName="StreetAddress" 
                        SourceTypeName="ValidationHOL.BusinessLogic.Address, ValidationHOL.BusinessLogic" ControlToValidate="StreetAddressTextBox">
                    </cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="City" />
                </td>
                <td>
                    <asp:TextBox ID="CityTextBox" runat="server" />
                    <cc1:PropertyProxyValidator ID="CityValidator" runat="server" 
                        PropertyName="City" 
                        SourceTypeName="ValidationHOL.BusinessLogic.Address, ValidationHOL.BusinessLogic" ControlToValidate="CityTextBox">
                    </cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="State" />
                </td>
                <td>
                    <asp:DropDownList ID="StateDropDownList" runat="server">
                        <asp:ListItem>AL</asp:ListItem>
                        <asp:ListItem>AK</asp:ListItem>
                        <asp:ListItem>AZ</asp:ListItem>
                        <asp:ListItem>AR</asp:ListItem>
                        <asp:ListItem>CA</asp:ListItem>
                        <asp:ListItem>CO</asp:ListItem>
                        <asp:ListItem>CT</asp:ListItem>
                        <asp:ListItem>DE</asp:ListItem>
                        <asp:ListItem>FL</asp:ListItem>
                        <asp:ListItem>GA</asp:ListItem>
                        <asp:ListItem>HI</asp:ListItem>
                        <asp:ListItem>ID</asp:ListItem>
                        <asp:ListItem>IL</asp:ListItem>
                        <asp:ListItem>IN</asp:ListItem>
                        <asp:ListItem>IA</asp:ListItem>
                        <asp:ListItem>KS</asp:ListItem>
                        <asp:ListItem>KY</asp:ListItem>
                        <asp:ListItem>LA</asp:ListItem>
                        <asp:ListItem>ME</asp:ListItem>
                        <asp:ListItem>MD</asp:ListItem>
                        <asp:ListItem>MA</asp:ListItem>
                        <asp:ListItem>MI</asp:ListItem>
                        <asp:ListItem>MN</asp:ListItem>
                        <asp:ListItem>MS</asp:ListItem>
                        <asp:ListItem>MO</asp:ListItem>
                        <asp:ListItem>MT</asp:ListItem>
                        <asp:ListItem>NE</asp:ListItem>
                        <asp:ListItem>NV</asp:ListItem>
                        <asp:ListItem>NH</asp:ListItem>
                        <asp:ListItem>NJ</asp:ListItem>
                        <asp:ListItem>NM</asp:ListItem>
                        <asp:ListItem>NY</asp:ListItem>
                        <asp:ListItem>NC</asp:ListItem>
                        <asp:ListItem>ND</asp:ListItem>
                        <asp:ListItem>OH</asp:ListItem>
                        <asp:ListItem>OK</asp:ListItem>
                        <asp:ListItem>OR</asp:ListItem>
                        <asp:ListItem>PA</asp:ListItem>
                        <asp:ListItem>RI</asp:ListItem>
                        <asp:ListItem>SC</asp:ListItem>
                        <asp:ListItem>SD</asp:ListItem>
                        <asp:ListItem>TN</asp:ListItem>
                        <asp:ListItem>TX</asp:ListItem>
                        <asp:ListItem>UT</asp:ListItem>
                        <asp:ListItem>VT</asp:ListItem>
                        <asp:ListItem>VA</asp:ListItem>
                        <asp:ListItem>WA</asp:ListItem>
                        <asp:ListItem>WV</asp:ListItem>
                        <asp:ListItem>WI</asp:ListItem>
                        <asp:ListItem>WY</asp:ListItem>
                    </asp:DropDownList>
                    <cc1:PropertyProxyValidator ID="StateValidator" runat="server" 
                        PropertyName="State" 
                        SourceTypeName="ValidationHOL.BusinessLogic.Address, ValidationHOL.BusinessLogic" ControlToValidate="StateDropDownList">
                    </cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Zip Code" />
                </td>
                <td>
                    <asp:TextBox ID="ZipCodeTextBox" runat="server" />
                    <cc1:PropertyProxyValidator ID="ZipCodeValidator" runat="server" 
                        PropertyName="ZipCode" 
                        SourceTypeName="ValidationHOL.BusinessLogic.Address, ValidationHOL.BusinessLogic" ControlToValidate="ZipCodeTextBox">
                    </cc1:PropertyProxyValidator>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Do work" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
