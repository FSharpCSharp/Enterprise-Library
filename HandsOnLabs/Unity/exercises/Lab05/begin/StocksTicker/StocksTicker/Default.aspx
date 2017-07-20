<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="StocksTicker._Default" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simulated Stocks ticker</title>
    <link rel="stylesheet" type="text/css" href="web.css" />
    <meta http-equiv="refresh" content="30"/>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="SubscribeSymbolButton">
        <div>
            <asp:Label ID="StockSymbolLabel" runat="server" Text="Symbol" />
            <asp:TextBox ID="StockSymbolText" runat="server" />
            <asp:RegularExpressionValidator ID="ValidStockSymbolValidator" runat="server" ValidationExpression="^[a-zA-Z]+$"
                Display="Dynamic" ControlToValidate="StockSymbolText" EnableClientScript="false"
                Enabled="true" ErrorMessage="Not a valid stock symbol" />
            <asp:RequiredFieldValidator ID="RequiredStockSymbolValidator" runat="server" Display="Dynamic"
                ControlToValidate="StockSymbolText" EnableClientScript="false" Enabled="true"
                ErrorMessage="Cannot be empty" />
            <asp:Button ID="SubscribeSymbolButton" runat="server" Text="Subscribe" OnClick="SubscribeSymbolButton_Click"
                CausesValidation="true" />
            <br />
            <br />
            <asp:GridView ID="StockQuotesGridView" runat="server" AutoGenerateColumns="False"
                OnRowDataBound="StockQuotesGridView_OnRowDataBound" CellPadding="5">
                <Columns>
                    <asp:BoundField HeaderText="Symbol" DataField="Symbol" />
                    <asp:BoundField HeaderText="Volume" DataField="Volume" DataFormatString="{0:N0}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Last" DataField="Last" DataFormatString="{0:N4}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Change">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ChangeLabel" runat="server" Text='<%# Bind("Change", "{0:N2}") %>'
                                ForeColor="Green" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Change %">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="PercentChangeLabel" runat="server" Text='<%# Bind("PercentChange", "{0:P}") %>'
                                ForeColor="Green" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Update" DataField="LastUpdate" DataFormatString="{0:T}" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="StatusLabel" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
