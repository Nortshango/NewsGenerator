using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsGenerator
{
    public partial class Default : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                initFields();
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
            dropdown_spieler_1v1_1.Items.FindByValue("GosuHaube").Selected = true;

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

            //TEXT
            dropdown_mannered.DataSource = db.GetText("mannered");
            dropdown_mannered.DataBind();

            dropdown_unmannered.DataSource = db.GetText("unmannered");
            dropdown_unmannered.DataBind();

        }

        protected void dropdown_mannered_SelectedIndexChanged(object sender, EventArgs e)
        {
           // lbl_dropdown_mannered.Text = dropdown_mannered.SelectedItem.
        }
    }
}