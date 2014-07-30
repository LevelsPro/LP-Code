using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Update;
using System.Web.UI.HtmlControls;
using BusinessLogic.Select;
using System.Data;
using LevelsPro.App_Code;

namespace LevelsPro.PlayerPanel
{
    public partial class QuizResult : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
               if (Request.QueryString["check"] != null && Request.QueryString["check"].ToString() != "")
                {
                    ViewState["quizid"] = Request.QueryString["check"].ToString();
                }
                
               
                LoadData();

            }
        }
        protected void LoadData()
        {
            ltlName.Text = Session["displayname"].ToString() + Resources.TestSiteResources.QuizResults;
            PlayerQuizViewBLL Quiz_Selection = new PlayerQuizViewBLL();
            //Quiz_Selection.Quiz = _quiz;
            try
            {
                Quiz_Selection.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = Quiz_Selection.ResultSet.Tables[2].DefaultView;
            dv.RowFilter = "UserID = " + Convert.ToInt32(Session["userid"]) +" AND QuizID= " + Convert.ToInt32(ViewState["quizid"]);
            DataTable dtQuiz = dv.ToTable();
            lblTotal.Text = "0";
            for (int i = 0; i < dtQuiz.Rows.Count; i++)
            {
                lblTotal.Text = (Convert.ToInt32(lblTotal.Text) + Convert.ToInt32(dtQuiz.Rows[i]["PointsAchieved"])).ToString();
            
            }

            dlResult.DataSource = dtQuiz;
            dlResult.DataBind();
        }
        protected void btnHome_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("PlayerHome.aspx");
        }

        protected void btnLogout_Click(object sender, System.EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            Common.User user = new Common.User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void dlResult_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblCorrect = e.Item.FindControl("lblCorrect") as Label;
            if (lblCorrect.Text.ToLower() == "1")
            {
                HtmlGenericControl span = (HtmlGenericControl)e.Item.FindControl("clstrip");
                span.Attributes["class"] = "qr-item qr-green";

            }
            else
            {
                HtmlGenericControl span = (HtmlGenericControl)e.Item.FindControl("clstrip");
                span.Attributes["class"] = "qr-item qr-red";
            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizSelection.aspx");
        }
    }
}