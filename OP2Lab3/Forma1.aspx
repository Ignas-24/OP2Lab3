<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="OP2Lab3.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leidiniai</title>
    <link rel="stylesheet" runat="server" href="~/Code/StyleSheet1.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 1600px">
            <asp:Label ID="Label9" runat="server" Text="Pasirinkite leidinių failą"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Pasirinkite prenumeratorių failą"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Įsikelti duomenis" />
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <asp:Table ID="Table3" runat="server">
            </asp:Table>
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
            <asp:Label ID="Label5" runat="server" Text="Pasirinkite leidinį"></asp:Label>
            &nbsp;
            <asp:Label ID="Label6" runat="server" Text="Pasirinkite mėnesį"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ieškoti prenumeratorių" />
            <asp:Table ID="Table5" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>

