using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Common;
using System.IO;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using BusinessLogic.Update;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class QuizEdit : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            if (!IsPostBack)
            {
                LoadKPI();

                if (Request.QueryString["quizid"] != null && Request.QueryString["quizid"].ToString() != "")
                {
                    ViewState["quizid"] = Request.QueryString["quizid"];
                    
                    LoadData(Convert.ToInt32(ViewState["quizid"]));
                }
            }
        }
        #region show quiz for edit
        private void LoadData(int QuizID)
        {
            string path = ConfigurationManager.AppSettings["QuizPath"].ToString();
            QuizViewBLL quizview = new QuizViewBLL();
            Quiz _quiz = new Quiz();
            _quiz.Where = " WHERE QuizID = " + QuizID.ToString();
            quizview.Quiz = _quiz;
            try
            {
                quizview.Invoke();
            }
            catch (Exception ex)
            {
            }

            if (quizview.ResultSet != null && quizview.ResultSet.Tables.Count > 0 && quizview.ResultSet.Tables[0] != null && quizview.ResultSet.Tables[0].Rows.Count > 0)
            {
                txtQuizName.Text = quizview.ResultSet.Tables[0].Rows[0]["QuizName"].ToString();
                txtNoOfQuestions.Text = quizview.ResultSet.Tables[0].Rows[0]["NoOfQuestions"].ToString();
                txtTimePerQuestion.Text = quizview.ResultSet.Tables[0].Rows[0]["TimePerQuestion"].ToString();
                txtNoOfTimesPerDay.Text = quizview.ResultSet.Tables[0].Rows[0]["TimesPlayablePerDay"].ToString();
                txtTimeBeforePointDeduction.Text = quizview.ResultSet.Tables[0].Rows[0]["TimeBeforePointsDeduction"].ToString();
                txtPointsPerQuestion.Text = quizview.ResultSet.Tables[0].Rows[0]["PointsPerQuestion"].ToString();
                ddlKPI_ID.SelectedValue = quizview.ResultSet.Tables[0].Rows[0]["KPI_ID"].ToString();
               


                hdImage.Value = path + quizview.ResultSet.Tables[0].Rows[0]["QuizImage"].ToString();

                ViewState["QuizImage"] = quizview.ResultSet.Tables[0].Rows[0]["QuizImage"].ToString();
                ViewState["QuizImageThumbnail"] = quizview.ResultSet.Tables[0].Rows[0]["QuizImageThumbnail"].ToString();

                btnAddQuiz.Text = Resources.TestSiteResources.Update;
            }
        }
        #endregion
        protected void LoadKPI()
        {
            KPIViewBLL kpi = new KPIViewBLL();
            try
            {
                kpi.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlKPI_ID.DataTextField = "KPI_name";
            ddlKPI_ID.DataValueField = "KPI_ID";

            DataView dv = kpi.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1";

            ddlKPI_ID.DataSource = dv.ToTable();
            ddlKPI_ID.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlKPI_ID.Items.Insert(0, li);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        #region add and update quiz
        protected void btnAddQuiz_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["QuizPath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationManager.AppSettings["QuizThumbPath"].ToString());
            if (txtQuizName.Text.Equals(""))
            {
                
                return;
            }
            else
            {

                Quiz quiz = new Quiz();


                quiz.QuizName = txtQuizName.Text.Trim();
                if (txtNoOfQuestions.Text.Trim() != "")
                {
                    quiz.NoOfQuestions = Convert.ToInt32(txtNoOfQuestions.Text.Trim());
                }

                if (txtTimePerQuestion.Text.Trim() != "")
                {
                    quiz.TimePerQuestion = Convert.ToInt32(txtTimePerQuestion.Text.Trim());
                }

                if (txtNoOfTimesPerDay.Text.Trim() != "")
                {
                    quiz.TimesPlayablePerDay = Convert.ToInt32(txtNoOfTimesPerDay.Text.Trim());
                }

                if (txtPointsPerQuestion.Text.Trim() != "")
                {
                    quiz.PointsPerQuestion = Convert.ToInt32(txtPointsPerQuestion.Text.Trim());
                }

                if (txtTimeBeforePointDeduction.Text.Trim() != "")
                {
                    quiz.TimeBeforePointsDeduction = Convert.ToInt32(txtTimeBeforePointDeduction.Text.Trim());
                }

                if (ddlKPI_ID.SelectedIndex > 0)
                {
                    quiz.KPIID = Convert.ToInt32(ddlKPI_ID.SelectedValue);
                }


                if (fuQuizImage.HasFile)
                {
                    string s = fuQuizImage.FileName;
                    FileInfo fleInfo = new FileInfo(s);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        string GuidOne = Guid.NewGuid().ToString();
                        string FileExtension = Path.GetExtension(fuQuizImage.FileName).ToLower();
                        fuQuizImage.SaveAs(path + GuidOne + FileExtension);

                        quiz.QuizImage = string.Format("{0}{1}", GuidOne, FileExtension);

                        System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
                        System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                        thumbImage.Save(Thumbpath + GuidOne + FileExtension);

                        quiz.QuizImageThumbnail = string.Format("{0}{1}", GuidOne, FileExtension);
                    }
                }
                else
                {
                    if (ViewState["QuizImage"] != null && ViewState["QuizImage"].ToString() != "")
                    {
                        quiz.QuizImage = ViewState["QuizImage"].ToString();
                    }
                    if (ViewState["QuizImageThumbnail"] != null && ViewState["QuizImageThumbnail"].ToString() != "")
                    {
                        quiz.QuizImageThumbnail = ViewState["QuizImageThumbnail"].ToString();
                    }

                }

                if (btnAddQuiz.Text == "Update" || btnAddQuiz.Text == "mettre à jour" || btnAddQuiz.Text == "actualizar")
                {
                    if (ViewState["quizid"] != null && ViewState["quizid"].ToString() != "")
                    {
                        quiz.QuizID = Convert.ToInt32(ViewState["quizid"]);
                        lblmessage.Visible = true;

                        QuizUpdateBLL updategame = new QuizUpdateBLL();
                        updategame.Quiz = quiz;
                        lblmessage.Visible = true;
                        try
                        {
                            updategame.Invoke();
                            lblmessage.Text = Resources.TestSiteResources.GameName + ' ' + Resources.TestSiteResources.UpdateMessage;
                            LoadData(Convert.ToInt32(ViewState["quizid"]));
                           
                        }
                        catch (Exception ex)
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.GameName;
                        }
                    }
                }
                else
                {

                    lblmessage.Visible = true;
                    QuizInsertBLL insertquiz = new QuizInsertBLL();
                    insertquiz.Quiz = quiz;
                    try
                    {
                        insertquiz.Invoke();
                        
                        Response.Redirect("QuizManagement.aspx",false);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.GameName + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            //show unsuceess
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.GameName;
                        }
                    }
                }
            }
                        
        }
        #endregion
        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".jpeg", ".jpg", ".bmp", ".png", ".gif" };
            if (strArr.Contains(extension))
                return true;
            return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {            
            Response.Redirect("QuizManagement.aspx");
        }

        protected void btnAddImage_Click(object sender, EventArgs e)
        {

        }
    }
}