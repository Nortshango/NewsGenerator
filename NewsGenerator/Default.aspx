<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsGenerator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <h1>News Generator v0.002</h1>
            <table>
                <tr>
                    <td style="width:100px;">Liga:</td>
                    <td><asp:DropDownList ID="dropdown_liga" runat="server" DataTextField="Name"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width:100px;">Gegner:</td>
                    <td><asp:DropDownList ID="dropdown_gegner" runat="server" DataTextField="Name"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width:100px;">Spieler:</td>
                    <td>1vs1</td><td>Wins</td>
                    </tr>
                <tr>
                    <td style="text-align:right;">1<br />2<br />3<br />4</td>
                    <td><asp:DropDownList ID="dropdown_spieler_1v1_1" runat="server" DataTextField="Name"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_spieler_1v1_2" runat="server" DataTextField="Name"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_spieler_1v1_3" runat="server" DataTextField="Name"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_spieler_1v1_4" runat="server" DataTextField="Name"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="dropdown_wins_1v1_1" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_wins_1v1_2" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_wins_1v1_3" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_wins_1v1_4" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>2vs2</td><td>Wins</td>
                    </tr>
                <tr>
                    <td style="text-align:right;">1</td>
                    <td><asp:DropDownList ID="dropdown_spieler_2v2_1" runat="server" DataTextField="Name"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_spieler_2v2_2" runat="server" DataTextField="Name"></asp:DropDownList>
                    </td>
                    <td><asp:DropDownList ID="dropdown_wins_2v2_1" runat="server" DataTextField="Wins"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Textbausteine:</td>
                </tr>
                <tr>
                        <td><asp:CheckBox ID="chk_mannered" runat="server" Text="mannered" /></td>
                        <td><asp:DropDownList ID="dropdown_mannered" runat="server" DataTextField="Shorttext"></asp:DropDownList></td>
                </tr>
                <tr>
                     <td><asp:CheckBox ID="chk_unmannered" runat="server" Text="unmannered" /></td>
                        <td><asp:DropDownList ID="dropdown_unmannered" runat="server" DataTextField="Shorttext"></asp:DropDownList></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
