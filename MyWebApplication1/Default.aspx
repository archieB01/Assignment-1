<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temperature Conversion and Number Sorting</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Temperature Conversion</h2>
            Celsius to Fahrenheit:<asp:TextBox ID="celsiusInput" runat="server"></asp:TextBox>
            <asp:Label ID="lblResult1" runat="server" Text="Result" Width="120"></asp:Label>
            <asp:Button ID="btnCelsiusToFahrenheit" runat="server" Text="Convert to Fahrenheit" OnClick="ConvertCelsiusToFahrenheit" />
            <br /><br />

            Fahrenheit to Celsius:<asp:TextBox ID="fahrenheitInput" runat="server"></asp:TextBox>
            <asp:Label ID="lblResult2" runat="server" Text="Result" Width="120"></asp:Label>
            <asp:Button ID="btnFahrenheitToCelsius" runat="server" Text="Convert to Celsius" OnClick="ConvertFahrenheitToCelsius" />
            <br /><br />

            <h2>Sort Numbers</h2>
            Enter numbers (use comma to seperate numbers):<asp:TextBox ID="numberInput" runat="server"></asp:TextBox>
            <asp:Label ID="lblResult3" runat="server" Text="Result" Width="120"></asp:Label>
            <asp:Button ID="btnSortNumbers" runat="server" Text="Sort Numbers" OnClick="SortNumbers" />
        </div>
    </form>
</body>
</html>
