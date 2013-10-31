using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsGenerator
{
    public partial class Default : System.Web.UI.Page
    {

        public int wins = 0;
        public int losses = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                initFields();
                txt_gegner.Enabled = false;
            }
        }

        private void initFields()
        {
            DBUtil db = new DBUtil();

            dropdown_liga.DataSource = db.GetLeague();
            dropdown_liga.DataBind();

            dropdown_gegner.DataSource = db.GetOpponent();
            dropdown_gegner.DataBind();
            
            //PLAYER
            dropdown_spieler_1v1_1.DataSource = db.GetPlayer();
            dropdown_spieler_1v1_1.DataBind();
            dropdown_spieler_1v1_1.Items.FindByText("GosuHaube").Selected = true;

            dropdown_spieler_1v1_2.DataSource = db.GetPlayer();
            dropdown_spieler_1v1_2.DataBind();
            dropdown_spieler_1v1_2.Items.FindByValue("DarK").Selected = true;

            dropdown_spieler_1v1_3.DataSource = db.GetPlayer();
            dropdown_spieler_1v1_3.DataBind();
            dropdown_spieler_1v1_3.Items.FindByValue("Oggogg").Selected = true;

            dropdown_spieler_1v1_4.DataSource = db.GetPlayer();
            dropdown_spieler_1v1_4.DataBind();
            dropdown_spieler_1v1_4.Items.FindByValue("Nantis").Selected = true;

            dropdown_spieler_2v2_1.DataSource = db.GetPlayer();
            dropdown_spieler_2v2_1.DataBind();
            dropdown_spieler_2v2_1.Items.FindByValue("Melkor").Selected = true;

            dropdown_spieler_2v2_2.DataSource = db.GetPlayer();
            dropdown_spieler_2v2_2.DataBind();
            dropdown_spieler_2v2_2.Items.FindByValue("GosuHaube").Selected = true;
            
            //WINS
            dropdown_wins_1v1_1.DataSource = db.GetWins();
            dropdown_wins_1v1_1.DataBind();
            dropdown_wins_1v1_2.DataSource = db.GetWins();
            dropdown_wins_1v1_2.DataBind();
            dropdown_wins_1v1_3.DataSource = db.GetWins();
            dropdown_wins_1v1_3.DataBind();
            dropdown_wins_1v1_4.DataSource = db.GetWins();
            dropdown_wins_1v1_4.DataBind();

            dropdown_wins_2v2_1.DataSource = db.GetWins();
            dropdown_wins_2v2_1.DataBind();

            //LOSSES
            dropdown_losses_1v1_1.DataSource = db.GetWins();
            dropdown_losses_1v1_1.DataBind();
            dropdown_losses_1v1_2.DataSource = db.GetWins();
            dropdown_losses_1v1_2.DataBind();
            dropdown_losses_1v1_3.DataSource = db.GetWins();
            dropdown_losses_1v1_3.DataBind();
            dropdown_losses_1v1_4.DataSource = db.GetWins();
            dropdown_losses_1v1_4.DataBind();

            dropdown_losses_2v2_1.DataSource = db.GetWins();
            dropdown_losses_2v2_1.DataBind();

            //TEXT
            dropdown_intro.DataSource = db.GetText("intro");
            dropdown_intro.DataValueField = db.GetText("intro").Tables[0].Columns[2].ToString();
            dropdown_intro.DataBind();

            dropdown_toolate.DataSource = db.GetText("toolate");
            dropdown_toolate.DataValueField = db.GetText("toolate").Tables[0].Columns[2].ToString();            
            dropdown_toolate.DataBind();

            dropdown_mannered.DataSource = db.GetText("mannered");
            dropdown_mannered.DataValueField = db.GetText("mannered").Tables[0].Columns[2].ToString();
            dropdown_mannered.DataBind();

            dropdown_unmannered.DataSource = db.GetText("unmannered");
            dropdown_unmannered.DataValueField = db.GetText("unmannered").Tables[0].Columns[2].ToString();
            dropdown_unmannered.DataBind();

            dropdown_thank.DataSource = db.GetText("thank");
            dropdown_thank.DataValueField = db.GetText("thank").Tables[0].Columns[2].ToString();
            dropdown_thank.DataBind();
        }

        protected void btn_genNews_Click(object sender, EventArgs e)
        {
            DBUtil db = new DBUtil();
            StringBuilder s = new StringBuilder();

            checkResult();



            //INTRO

            s.Append("<p style='font-size:14px;font-weight:bold'>");
            s.Append(dropdown_liga.SelectedItem.Text);
            s.Append(" versus ");
            if (chk_opponentfromdatabase.Checked)
            {
                s.Append(dropdown_gegner.SelectedItem.Text);
            }
            if (chk_opponentfromtextbox.Checked) {
                s.Append(txtbox_output.Text);
            }
            s.Append(": "); 

            if (chk_intro.Checked) {
                s.Append(dropdown_intro.SelectedItem.Value);
            }
            s.Append("</p><br />");
            

            //ERG
            //s.Append("<table style='width: 95%;'><tr><td style='width: 50%;'>");
            s.Append("<table style='border: 1px solid #b9b9b9; width: 100%; height: 0px;' frame='box' rules='none' border='1' cellpadding='1' cellspacing='0'>");

            s.Append("<tr style='height: 30px;background-color:lightgray;font-variant:small-caps;font-weight:bold;'><td style='text-align: center;'>");
            s.Append("WSB vs ");
            if (chk_opponentfromdatabase.Checked)
            {
                s.Append(dropdown_gegner.SelectedItem.Text);
            }
            else
            {
                s.Append(txtbox_output.Text);
            }
            s.Append("</td><td></td>");
            if (losses > wins)
            {
                s.Append("<td style='background-color:Crimson;text-align: center;'>");
            }
            if (wins > losses)
            {
                s.Append("<td style='background-color:limeGreen;text-align: center;'>");
            }
            if (losses == wins)
            {
                s.Append("<td style='background-color:darkgray;text-align: center;'>");
            }
            s.Append(wins);
            s.Append(":");
            s.Append(losses);
            s.Append("</td></tr>");
            
            s.Append("<tr style='height: 30px;'><td style='text-align: center;'>");
            
            s.Append(dropdown_spieler_1v1_1.SelectedItem.Text);
            if (chk_held1.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/xzxib6fu.png' height='20' width='20' />");
            }
            if (chk_noob1.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/opbgw8ui.png' height='20' width='20' />");
            }
            s.Append("</td><td style='text-align:center;'><img height='20px' width='20px' src='images/ranking/");
            DataSet ds = db.GetRace(dropdown_spieler_1v1_1.SelectedItem.Text);
            DataRow dr = ds.Tables[0].Rows[0];
            s.Append(dr["Race"]);
            s.Append(".png' /></td><td style='text-align: center;'>");
            s.Append(dropdown_wins_1v1_1.SelectedItem.Text);
            s.Append(":");
            s.Append(dropdown_losses_1v1_1.SelectedItem.Text);
            s.Append("</td></tr>");
            s.Append("<tr style='height: 30px;background-color: #eaeaea;'><td style='text-align: center;'>");
            
            s.Append(dropdown_spieler_1v1_2.SelectedItem.Value);
            if (chk_held2.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/xzxib6fu.png' height='20' width='20' />");
            }
            if (chk_noob2.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/opbgw8ui.png' height='20' width='20' />");
            }
            s.Append("</td><td style='text-align:center;'><img height='20px' width='20px' src='images/ranking/");
            ds = db.GetRace(dropdown_spieler_1v1_2.SelectedItem.Text);
            dr = ds.Tables[0].Rows[0];
            s.Append(dr["Race"]);
            s.Append(".png' /></td><td style='text-align: center;'>");
            s.Append(dropdown_wins_1v1_2.SelectedItem.Text);
            s.Append(":");
            s.Append(dropdown_losses_1v1_2.SelectedItem.Text);
            s.Append("</td></tr>");
            s.Append("<tr style='height: 30px;'><td style='text-align: center;'>");
            
            s.Append(dropdown_spieler_1v1_3.SelectedItem.Value);
            if (chk_held3.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/xzxib6fu.png' height='20' width='20' />");
            }
            if (chk_noob3.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/opbgw8ui.png' height='20' width='20' />");
            }
            s.Append("</td><td style='text-align:center;'><img height='20px' width='20px' src='images/ranking/");
            ds = db.GetRace(dropdown_spieler_1v1_3.SelectedItem.Text);
            dr = ds.Tables[0].Rows[0];
            s.Append(dr["Race"]);
            s.Append(".png' /></td><td style='text-align: center;'>");
            s.Append(dropdown_wins_1v1_3.SelectedItem.Text);
            s.Append(":");
            s.Append(dropdown_losses_1v1_3.SelectedItem.Text);
            s.Append("</td></tr>");
            s.Append("<tr style='height: 30px;background-color: #eaeaea;'><td style='text-align: center;'>");
            
            s.Append(dropdown_spieler_1v1_4.SelectedItem.Value);
            if (chk_held4.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/xzxib6fu.png' height='20' width='20' />");
            }
            if (chk_noob4.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/opbgw8ui.png' height='20' width='20' />");
            }
            s.Append("</td><td style='text-align:center;'><img height='20px' width='20px' src='images/ranking/");
            ds = db.GetRace(dropdown_spieler_1v1_4.SelectedItem.Text);
            dr = ds.Tables[0].Rows[0];
            s.Append(dr["Race"]);
            s.Append(".png' /></td><td style='text-align: center;'>");
            s.Append(dropdown_wins_1v1_4.SelectedItem.Text);
            s.Append(":");
            s.Append(dropdown_losses_1v1_4.SelectedItem.Text);
            s.Append("</td></tr>");
            s.Append("<tr style='height: 30px;'><td style='text-align: center;'>");
            
            s.Append(dropdown_spieler_2v2_1.SelectedItem.Value);
            if (chk_held5.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/xzxib6fu.png' height='20' width='20' />");
            }
            if (chk_noob5.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/opbgw8ui.png' height='20' width='20' />");
            }
            s.Append(" & ");
            s.Append(dropdown_spieler_2v2_2.SelectedItem.Value);
            if (chk_held6.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/xzxib6fu.png' height='20' width='20' />");
            }
            if (chk_noob6.Checked)
            {
                s.Append("<img src='http://s1.directupload.net/images/131031/opbgw8ui.png' height='20' width='20' />");
            }
            s.Append("</td><td style='text-align:center;'>");
            s.Append("<img height='20px' width='20px' src='images/ranking/");
            ds = db.GetRace(dropdown_spieler_2v2_1.SelectedItem.Text);
            dr = ds.Tables[0].Rows[0];
            s.Append(dr["Race"]);
            s.Append(".png' />");
            s.Append("<img height='20px' width='20px' src='images/ranking/");
            ds = db.GetRace(dropdown_spieler_2v2_2.SelectedItem.Text);
            dr = ds.Tables[0].Rows[0];
            s.Append(dr["Race"]);
            s.Append(".png' />");
            s.Append("</td><td style='text-align: center;'>");
            s.Append(dropdown_wins_2v2_1.SelectedItem.Text);
            s.Append(":");
            s.Append(dropdown_losses_2v2_1.SelectedItem.Text);
            s.Append("</td></tr>");

            s.Append("</table>");
            //s.Append("</td><td style='padding:10px;'>");

            if (chk_held1.Checked || chk_held2.Checked || chk_held3.Checked || chk_held4.Checked || chk_held5.Checked || chk_held6.Checked)
            {
                s.Append("<p style='font-size:smaller;'>*<img src='http://s1.directupload.net/images/131031/opbgw8ui.png' height='15' width='15' />Noob des Tages, *<img src='http://s1.directupload.net/images/131031/xzxib6fu.png' height='10' width='10' />Held des Tages<br /></p>");
            }
            //s.Append("</td></tr></table><br />");
            //TEXT B

            if (chk_mannered.Checked || chk_unmannered.Checked || chk_toolate.Checked) {
                s.Append("<br />");
            }

            if (chk_toolate.Checked)
            {
                s.Append(dropdown_toolate.SelectedItem.Value);
            }

            if (chk_mannered.Checked)
            {
                s.Append(dropdown_mannered.SelectedItem.Value);
            }

            if (chk_unmannered.Checked)
            {
                s.Append(dropdown_unmannered.SelectedItem.Value);
            }
            if (chk_thank.Checked)
            {
                s.Append(dropdown_thank.SelectedItem.Value);
            }


            //KOMMENTAR
            if (txt_Kommentar.Text != "")
            {
                s.Append("<br /><br /><p style='font-size:small; font-style: italic;'>Kommentar");
            }
            if (txt_Autor.Text != "") {
                s.Append(" von ");
                s.Append(txt_Autor.Text);
            }
            s.Append(":</p>");
            if (txt_Kommentar.Text != "")
            {
                s.Append("<p style='padding:10px; width:95%; border:1px dashed black; background-color:lightgray; color:black;'>");
                s.Append(txt_Kommentar.Text);
                s.Append("</p>");
            }
            s.Append("{jcomments on}");
            txtbox_output.Text = s.ToString();
                 
        }

        private void checkResult()
        {
            if (Int32.Parse(dropdown_wins_1v1_1.SelectedItem.Text) == 2)
            {
                wins++;
            }
            if (Int32.Parse(dropdown_losses_1v1_1.SelectedItem.Text) == 2)
            {
                losses++;
            }
            if (Int32.Parse(dropdown_wins_1v1_2.SelectedItem.Text) == 2)
            {
                wins++;
            }
            if (Int32.Parse(dropdown_losses_1v1_2.SelectedItem.Text) == 2)
            {
                losses++;
            }
            if (Int32.Parse(dropdown_wins_1v1_3.SelectedItem.Text) == 2)
            {
                wins++;
            }
            if (Int32.Parse(dropdown_losses_1v1_3.SelectedItem.Text) == 2)
            {
                losses++;
            }
            if (Int32.Parse(dropdown_wins_1v1_4.SelectedItem.Text) == 2)
            {
                wins++;
            }
            if (Int32.Parse(dropdown_losses_1v1_4.SelectedItem.Text) == 2)
            {
                losses++;
            }
            if (Int32.Parse(dropdown_wins_2v2_1.SelectedItem.Text) == 2)
            {
                wins++;
            }
            if (Int32.Parse(dropdown_losses_2v2_1.SelectedItem.Text) == 2)
            {
                losses++;
            }
        }



        protected void chk_opponentfromdatabase_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_opponentfromtextbox.Checked == false)
            {
                chk_opponentfromtextbox.Checked = true;
                //dropdown_gegner.Enabled = false;

            }
            else
            {
                chk_opponentfromtextbox.Checked = false;
                txt_gegner.Enabled = false;
                //dropdown_gegner.Enabled = true;
            }
        }

        protected void chk_opponentfromtextbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_opponentfromdatabase.Checked == false)
            {
                chk_opponentfromdatabase.Checked = true;
                //dropdown_gegner.Enabled = true;
            }
            else
            {
                chk_opponentfromdatabase.Checked = false;
                //dropdown_gegner.Enabled = false;
                txt_gegner.Enabled = true;
            }
        }

        protected void chk_held1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_held1.Checked == true)
            {
                chk_noob1.Enabled = false;
                chk_held2.Enabled = false;
                chk_held3.Enabled = false;
                chk_held4.Enabled = false;
                chk_held5.Enabled = false;
                chk_held6.Enabled = false;
            }
            else {
                chk_noob1.Enabled = true;
                chk_held2.Enabled = true;
                chk_held3.Enabled = true;
                chk_held4.Enabled = true;
                chk_held5.Enabled = true;
                chk_held6.Enabled = true;
            }
        }

        protected void chk_held2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_held2.Checked == true)
            {
                chk_noob2.Enabled = false;
                chk_held1.Enabled = false;
                chk_held3.Enabled = false;
                chk_held4.Enabled = false;
                chk_held5.Enabled = false;
                chk_held6.Enabled = false;
            }
            else
            {
                chk_noob2.Enabled = true;
                chk_held1.Enabled = true;
                chk_held3.Enabled = true;
                chk_held4.Enabled = true;
                chk_held5.Enabled = true;
                chk_held6.Enabled = true;
            }
        }

        protected void chk_held3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_held3.Checked == true)
            {
                chk_noob3.Enabled = false;
                chk_held2.Enabled = false;
                chk_held1.Enabled = false;
                chk_held4.Enabled = false;
                chk_held5.Enabled = false;
                chk_held6.Enabled = false;
            }
            else
            {
                chk_noob3.Enabled = true;
                chk_held2.Enabled = true;
                chk_held1.Enabled = true;
                chk_held4.Enabled = true;
                chk_held5.Enabled = true;
                chk_held6.Enabled = true;
            }
        }

        protected void chk_held4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_held4.Checked == true)
            {
                chk_noob4.Enabled = false;
                chk_held2.Enabled = false;
                chk_held3.Enabled = false;
                chk_held1.Enabled = false;
                chk_held5.Enabled = false;
                chk_held6.Enabled = false;
            }
            else
            {
                chk_noob4.Enabled = true;
                chk_held2.Enabled = true;
                chk_held3.Enabled = true;
                chk_held1.Enabled = true;
                chk_held5.Enabled = true;
                chk_held6.Enabled = true;
            }
        }

        protected void chk_held5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_held5.Checked == true)
            {
                chk_noob5.Enabled = false;
                chk_held2.Enabled = false;
                chk_held3.Enabled = false;
                chk_held4.Enabled = false;
                chk_held1.Enabled = false;
                chk_held6.Enabled = false;
            }
            else
            {
                chk_noob5.Enabled = true;
                chk_held2.Enabled = true;
                chk_held3.Enabled = true;
                chk_held4.Enabled = true;
                chk_held1.Enabled = true;
                chk_held6.Enabled = true;
            }
        }

        protected void chk_held6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_held6.Checked == true)
            {
                chk_noob6.Enabled = false;
                chk_held2.Enabled = false;
                chk_held3.Enabled = false;
                chk_held4.Enabled = false;
                chk_held5.Enabled = false;
                chk_held1.Enabled = false;
            }
            else
            {
                chk_noob6.Enabled = true;
                chk_held2.Enabled = true;
                chk_held3.Enabled = true;
                chk_held4.Enabled = true;
                chk_held5.Enabled = true;
                chk_held1.Enabled = true;
            }
        }

        protected void chk_noob1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_noob1.Checked == true)
            {
                chk_held1.Enabled = false;
                chk_noob2.Enabled = false;
                chk_noob3.Enabled = false;
                chk_noob4.Enabled = false;
                chk_noob5.Enabled = false;
                chk_noob6.Enabled = false;
            }
            else
            {
                chk_held1.Enabled = true;
                chk_noob2.Enabled = true;
                chk_noob3.Enabled = true;
                chk_noob4.Enabled = true;
                chk_noob5.Enabled = true;
                chk_noob6.Enabled = true;
            }
        }

        protected void chk_noob2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_noob2.Checked == true)
            {
                chk_held2.Enabled = false;
                chk_noob1.Enabled = false;
                chk_noob3.Enabled = false;
                chk_noob4.Enabled = false;
                chk_noob5.Enabled = false;
                chk_noob6.Enabled = false;
            }
            else
            {
                chk_held2.Enabled = true;
                chk_noob1.Enabled = true;
                chk_noob3.Enabled = true;
                chk_noob4.Enabled = true;
                chk_noob5.Enabled = true;
                chk_noob6.Enabled = true;
            }
        }

        protected void chk_noob3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_noob3.Checked == true)
            {
                chk_held3.Enabled = false;
                chk_noob2.Enabled = false;
                chk_noob1.Enabled = false;
                chk_noob4.Enabled = false;
                chk_noob5.Enabled = false;
                chk_noob6.Enabled = false;
            }
            else
            {
                chk_held3.Enabled = true;
                chk_noob2.Enabled = true;
                chk_noob1.Enabled = true;
                chk_noob4.Enabled = true;
                chk_noob5.Enabled = true;
                chk_noob6.Enabled = true;
            }
        }

        protected void chk_noob4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_noob4.Checked == true)
            {
                chk_held4.Enabled = false;
                chk_noob2.Enabled = false;
                chk_noob3.Enabled = false;
                chk_noob1.Enabled = false;
                chk_noob5.Enabled = false;
                chk_noob6.Enabled = false;
            }
            else
            {
                chk_held4.Enabled = true;
                chk_noob2.Enabled = true;
                chk_noob3.Enabled = true;
                chk_noob1.Enabled = true;
                chk_noob5.Enabled = true;
                chk_noob6.Enabled = true;
            }
        }

        protected void chk_noob5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_noob5.Checked == true)
            {
                chk_held5.Enabled = false;
                chk_noob2.Enabled = false;
                chk_noob3.Enabled = false;
                chk_noob4.Enabled = false;
                chk_noob1.Enabled = false;
                chk_noob6.Enabled = false;
            }
            else
            {
                chk_held5.Enabled = true;
                chk_noob2.Enabled = true;
                chk_noob3.Enabled = true;
                chk_noob4.Enabled = true;
                chk_noob1.Enabled = true;
                chk_noob6.Enabled = true;
            }
        }

        protected void chk_noob6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_noob6.Checked == true)
            {
                chk_held6.Enabled = false;
                chk_noob2.Enabled = false;
                chk_noob3.Enabled = false;
                chk_noob4.Enabled = false;
                chk_noob5.Enabled = false;
                chk_noob1.Enabled = false;
            }
            else
            {
                chk_held6.Enabled = true;
                chk_noob2.Enabled = true;
                chk_noob3.Enabled = true;
                chk_noob4.Enabled = true;
                chk_noob5.Enabled = true;
                chk_noob1.Enabled = true;
            }
        }
        /*
        protected void chk_mannered_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mannered.Checked)
            {
                chk_unmannered.Enabled = false;
                dropdown_unmannered.Enabled = false;
            }
            else
            {
                chk_unmannered.Enabled = true;
                dropdown_unmannered.Enabled = true;
            }
        }

        protected void chk_unmannered_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_unmannered.Checked)
            {
                chk_mannered.Enabled = false;
                dropdown_mannered.Enabled = false;
            }
            else {
                chk_mannered.Enabled = true;
                dropdown_mannered.Enabled = true;
            }
        }*/


    }
}