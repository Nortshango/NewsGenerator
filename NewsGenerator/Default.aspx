<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsGenerator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" BorderColor="DarkGray" BackColor="LightGray" CssClass="Panel">
           <div class="CSSTableGenerator">
            <table>
                <tr><td colspan="4">News Generator Beta v0.15</td><td style="width:500px">Output</td></tr>
                <tr>
                    <td><b>Liga:</b></td>
                    <td colspan="3"><asp:DropDownList ID="dropdown_liga" runat="server" DataTextField="Name"></asp:DropDownList></td>
                    
                    <td rowspan="13">
                        <asp:TextBox ID="txtbox_output" runat="server" TextMode="MultiLine" ReadOnly="false" Height="449px" Width="497px" TabIndex="20" ValidateRequestMode="Disabled"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><b>Gegner:</b></td>
                    <td colspan="3">
                        Database<br />
                        <asp:CheckBox ID="chk_opponentfromdatabase" runat="server" Checked="true" OnCheckedChanged="chk_opponentfromdatabase_CheckedChanged" AutoPostBack="true" /><asp:DropDownList ID="dropdown_gegner" runat="server" DataTextField="Name"></asp:DropDownList>
                     <br /> Manuell<br />   <asp:CheckBox ID="chk_opponentfromtextbox" runat="server" OnCheckedChanged="chk_opponentfromtextbox_CheckedChanged" AutoPostBack="true" /><asp:TextBox ID="txt_gegner" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><b>Spieler:</b></td>
                    <td>1vs1</td><td>Wins</td><td>Losses</td>
                    </tr>
                <tr>
                    <td></td>
                    <td>
                        1&nbsp;<asp:DropDownList ID="dropdown_spieler_1v1_1" runat="server" DataTextField="Name"></asp:DropDownList>&nbsp;[Held<asp:CheckBox ID="chk_held1" runat="server" OnCheckedChanged="chk_held1_CheckedChanged" AutoPostBack="true" />]&nbsp;[Noob<asp:CheckBox ID="chk_noob1" runat="server" OnCheckedChanged="chk_noob1_CheckedChanged" AutoPostBack="true" />]<br />
                        2&nbsp;<asp:DropDownList ID="dropdown_spieler_1v1_2" runat="server" DataTextField="Name"></asp:DropDownList>&nbsp;[Held<asp:CheckBox ID="chk_held2" runat="server" OnCheckedChanged="chk_held2_CheckedChanged" AutoPostBack="true" />]&nbsp;[Noob<asp:CheckBox ID="chk_noob2" runat="server" OnCheckedChanged="chk_noob2_CheckedChanged" AutoPostBack="true" />]<br />
                        3&nbsp;<asp:DropDownList ID="dropdown_spieler_1v1_3" runat="server" DataTextField="Name"></asp:DropDownList>&nbsp;[Held<asp:CheckBox ID="chk_held3" runat="server" OnCheckedChanged="chk_held3_CheckedChanged" AutoPostBack="true" />]&nbsp;[Noob<asp:CheckBox ID="chk_noob3" runat="server" OnCheckedChanged="chk_noob3_CheckedChanged" AutoPostBack="true" />]<br />
                        4&nbsp;<asp:DropDownList ID="dropdown_spieler_1v1_4" runat="server" DataTextField="Name"></asp:DropDownList>&nbsp;[Held<asp:CheckBox ID="chk_held4" runat="server" OnCheckedChanged="chk_held4_CheckedChanged" AutoPostBack="true" />]&nbsp;[Noob<asp:CheckBox ID="chk_noob4" runat="server" OnCheckedChanged="chk_noob4_CheckedChanged" AutoPostBack="true" />]</td>
                    <td><asp:DropDownList ID="dropdown_wins_1v1_1" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_wins_1v1_2" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_wins_1v1_3" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_wins_1v1_4" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                    </td>
                        <td><asp:DropDownList ID="dropdown_losses_1v1_1" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_losses_1v1_2" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_losses_1v1_3" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                        <asp:DropDownList ID="dropdown_losses_1v1_4" runat="server" DataTextField="Wins"></asp:DropDownList><br />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>2vs2</td><td>Wins</td><td>Losses</td>
                    </tr>
                <tr>
                    <td style="text-align:right; font-size:15px;"></td>
                    <td>1&nbsp;<asp:DropDownList ID="dropdown_spieler_2v2_1" runat="server" DataTextField="Name"></asp:DropDownList>&nbsp;[Held<asp:CheckBox ID="chk_held5" runat="server" OnCheckedChanged="chk_held5_CheckedChanged" AutoPostBack="true"/>]&nbsp;[Noob<asp:CheckBox ID="chk_noob5" runat="server" OnCheckedChanged="chk_noob5_CheckedChanged" AutoPostBack="true" />]<br />
                        &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="dropdown_spieler_2v2_2" runat="server" DataTextField="Name"></asp:DropDownList>&nbsp;[Held<asp:CheckBox ID="chk_held6" runat="server" OnCheckedChanged="chk_held6_CheckedChanged" AutoPostBack="true" />]&nbsp;[Noob<asp:CheckBox ID="chk_noob6" runat="server" OnCheckedChanged="chk_noob6_CheckedChanged" AutoPostBack="true" />]
                    </td>
                    <td><asp:DropDownList ID="dropdown_wins_2v2_1" runat="server" DataTextField="Wins"></asp:DropDownList>
                    </td>
                    <td><asp:DropDownList ID="dropdown_losses_2v2_1" runat="server" DataTextField="Wins"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"><b>Textbausteine:</b></td>
                </tr>
                <tr>
                     <td><asp:CheckBox ID="chk_intro" runat="server" Text="intro" /></td>
                        <td colspan="3"><asp:DropDownList ID="dropdown_intro" runat="server" DataTextField="Shorttext"></asp:DropDownList></td>
                   
                </tr>
                <tr>
                        <td><asp:CheckBox ID="chk_mannered" runat="server" Text="mannered" /></td>
                        <td colspan="3"><asp:DropDownList ID="dropdown_mannered" runat="server" DataTextField="Shorttext"></asp:DropDownList></td>
                    
                </tr>
                <tr>
                     <td><asp:CheckBox ID="chk_unmannered" runat="server" Text="unmannered"/></td>
                        <td colspan="3"><asp:DropDownList ID="dropdown_unmannered" runat="server" DataTextField="Shorttext"></asp:DropDownList></td>
                   
                </tr>
                <tr>
                     <td><asp:CheckBox ID="chk_toolate" runat="server" Text="zu spät" /></td>
                        <td colspan="3"><asp:DropDownList ID="dropdown_toolate" runat="server" DataTextField="Shorttext"></asp:DropDownList></td>
                   
                </tr>
                <tr>
                     <td><asp:CheckBox ID="chk_thank" runat="server" Text="Dank" /></td>
                        <td colspan="3"><asp:DropDownList ID="dropdown_thank" runat="server" DataTextField="Shorttext"></asp:DropDownList></td>
                   
                </tr>
                <tr><td style="width:100px">Persönlicher Kommentar des Autors</td>
                    <td colspan="3">
                        Dein Name:<br /><asp:TextBox ID="txt_Autor" runat="server"></asp:TextBox><br />
                        Dein Kommentar:<br />
                        <asp:TextBox ID="txt_Kommentar" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                </tr>
            </table></div><br />
            <asp:Button ID="btn_genNews" runat="server" Text="News generieren" OnClick="btn_genNews_Click" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
