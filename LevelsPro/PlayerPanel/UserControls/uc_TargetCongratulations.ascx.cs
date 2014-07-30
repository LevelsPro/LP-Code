using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Update;
using AjaxControlToolkit;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_TargetCongratulations : System.Web.UI.UserControl
    {
        public static String Name = "";
        public static int TargetID = 0;
        public static String KPIName = "";
        //public static String Role = "";
        public static String Bonus = "";

        public void LoadData(int targetid, String kpiName, String bonus1, String Target_Value)
        {
            Name = Session["displayname"].ToString();
            //Role = Session["rolename"].ToString();
            TargetID = targetid;
            //LevelID = levelID;
            KPIName = kpiName;
            Bonus = bonus1;

            lblName.Text = Name;
            //lblRole.Text = Role;
            lblBonus1.Text = Bonus;
            //lblTarget.Text = KPIName;
            string targettext = KPIName;
            targettext = targettext.Replace("X", Target_Value);
            lblTarget.Text = targettext;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblName.Text = Name;
            //lblRole.Text = Role;
            //lblBonus1.Text = Bonus;
            //lblLevel.Text = Level;
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                UserTargetAchievedUpdateBLL popup = new UserTargetAchievedUpdateBLL();
                Common.User user = new Common.User();

                user.UserID = Convert.ToInt32(Session["userid"]);
                user.TargetID = TargetID;
                //user.CurrentLevel = Convert.ToInt32(LevelID);
                popup.User = user;
                try
                {
                    popup.Invoke();
                }
                catch (Exception ex)
                {
                }

                Button lblScore = (Button)this.Parent.FindControl("lblScore");

                if (Session["U_Points"] != null && Session["U_Points"].ToString() != "")
                {
                    Session["U_Points"] = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(lblBonus1.Text.Trim())).ToString();
                }
                else
                {
                    Session["U_Points"] = lblBonus1.Text.Trim();
                }

                ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeTargetCongratsMessageDiv");
                mpe.Hide();
                Response.Redirect("PlayerHome.aspx", false);
            }
        }
    }
}