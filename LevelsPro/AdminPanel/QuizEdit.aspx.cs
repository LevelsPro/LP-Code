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
using MySql.Data.MySqlClient;
using BusinessLogic.Delete;
using LevelsPro.Util;
using log4net;
using System.Collections;
using Common.Utils;

namespace LevelsPro.AdminPanel
{

    public partial class QuizEdit : AuthorizedPage
    {
        private static string pageURL;
        protected static Hashtable fileMetadata;
        static DataSet dss;
        private ILog log;

        static QuizEdit()
        {
            fileMetadata = new Hashtable();
            fileMetadata.Add("folderPath", "QuizPath");
            fileMetadata.Add("thumbnailPath", "QuizThumbPath");

            string[] metadataKeys = { "folderPath", "thumbnailPath" };
            foreach (string key in metadataKeys)
            {
                string appKey = (string)fileMetadata[key];
                string settingValue = ConfigurationManager.AppSettings[appKey].ToString();
                fileMetadata[key] = HttpContext.Current.Server.MapPath(settingValue);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();

                try
                {
                    LoadKPI();

                    if (Request.QueryString["mess"] != null && Request.QueryString["mess"].ToString() != "")
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "Quiz info " + Resources.TestSiteResources.UpdateMessage;

                    }

                    if (Request.QueryString["quizid"] != null && Request.QueryString["quizid"].ToString() != "")
                    {
                        ViewState["quizid"] = Request.QueryString["quizid"];

                        LoadData(Convert.ToInt32(ViewState["quizid"]));
                    }
                    loadDataList();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            ExceptionUtility.CheckForErrorMessage(Session);
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            // Void Page_Load(System.Object, System.EventArgs)
            // Handle specific exception.
            if (exc is HttpUnhandledException || exc.TargetSite.Name.ToLower().Contains("page_load"))
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
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
                throw ex;
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
                throw ex;
            }

            ddlKPI_ID.DataTextField = "KPI_name";
            ddlKPI_ID.DataValueField = "KPI_ID";

            DataView dv = kpi.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1 AND TypeLevel='Level'";

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

                FileResources resource = FileResources.Instance;
                string imageId = resource.save(fuQuizImage, fileMetadata);
                if (!string.IsNullOrEmpty(imageId))
                {
                    quiz.QuizImage = imageId;
                    quiz.QuizImageThumbnail = imageId;
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

                MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                scon.Open();
                MySqlTransaction sqlTrans = scon.BeginTransaction();
                quiz.sqlTransaction = sqlTrans;
                try
                {

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
                                ExceptionUtility.ExceptionLogString(ex, Session);
                                Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                                log.Debug(Session["ExpLogString"]);
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

                            //Response.Redirect("QuizManagement.aspx",false);
                        }
                        catch (Exception ex)
                        {
                            ExceptionUtility.ExceptionLogString(ex, Session);
                            Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                            log.Debug(Session["ExpLogString"]);
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

                    QuizLevelsDeleteBLL del = new QuizLevelsDeleteBLL();
                    QuizLevelsInsertBLL qLevels = new QuizLevelsInsertBLL();

                    del.Quiz = quiz;
                    del.Invoke();

                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {
                        if (dss.Tables[0].Rows[i]["Allow"].ToString() == "yes")
                        {
                            quiz.RoleID = Convert.ToInt32(dss.Tables[0].Rows[i]["Role_ID"].ToString());
                            quiz.LevelID = Convert.ToInt32(dss.Tables[0].Rows[i]["Level_ID"].ToString());
                            qLevels.Quiz = quiz;
                            qLevels.Invoke();
                        }

                    }
                    sqlTrans.Commit();

                    if (btnAddQuiz.Text == "Update" || btnAddQuiz.Text == "mettre à jour" || btnAddQuiz.Text == "actualizar")
                    {
                        LoadData(int.Parse(quiz.QuizID.ToString()));
                        lblmessage.Visible = true;
                        lblmessage.Text = "Quiz info " + Resources.TestSiteResources.UpdateMessage;
                        Response.Redirect("QuizEdit.aspx?mess=1" + "&quizid=" + ViewState["quizid"].ToString(), false);

                    }
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "Quiz info " + ' ' + Resources.TestSiteResources.SavedMessage;
                        Response.Redirect("QuizManagement.aspx");
                    }

                }
                catch (Exception ex)
                {
                    ExceptionUtility.ExceptionLogString(ex, Session);
                    Session["ExpLogString"] += " Aditional Info : Transaction Rolledback";
                    log.Debug(Session["ExpLogString"]);
                    sqlTrans.Rollback();
                }
                finally
                {


                    sqlTrans.Dispose();
                    scon.Close();
                }
            }

        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizManagement.aspx");
        }

        protected void btnAddImage_Click(object sender, EventArgs e)
        {

        }

        protected void dlLevels_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            DataList dlLevels = sender as DataList;
            Button btnLevel = dlLevels.Items[e.Item.ItemIndex].FindControl("btnLevels") as Button;

            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {

                if (dss.Tables[0].Rows[i]["Level_ID"].ToString() == e.CommandArgument.ToString().Trim())
                {
                    if (btnLevel.CssClass == "lvl-green")
                    {
                        dss.Tables[0].Rows[i]["Allow"] = null;
                        btnLevel.CssClass = "lvl-white";
                    }
                    else
                    {
                        dss.Tables[0].Rows[i]["Allow"] = "yes";
                        btnLevel.CssClass = "lvl-green";
                    }
                    break;
                }

            }

        }

        protected void dlRoles_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataList dlLevels = e.Item.FindControl("dlLevels") as DataList;
                Literal ltRoleID = e.Item.FindControl("ltRoleID") as Literal;


                DataView dv = dss.Tables[0].DefaultView;
                dv.RowFilter = "Role_ID=" + Convert.ToInt32(ltRoleID.Text.Trim());
                dlLevels.DataSource = dv.ToTable();
                dlLevels.DataBind();


                foreach (DataListItem item in dlLevels.Items)
                {
                    Button btnLevel = item.FindControl("btnLevels") as Button;

                    if (dv.ToTable().Rows[item.ItemIndex]["Allow"].ToString().Trim() == "yes")
                    {
                        btnLevel.CssClass = "lvl-green";
                    }
                    else
                    {
                        btnLevel.CssClass = "lvl-white";

                    }

                }

            }
        }

        private void loadDataList()
        {
            try
            {
                QuizLevelsBLL Rolelevel = new QuizLevelsBLL();
                Quiz quiz = new Quiz();

                if (ViewState["quizid"] != null && ViewState["quizid"].ToString() != "")
                {
                    quiz.QuizID = Convert.ToInt32(ViewState["quizid"]);

                }
                else
                {
                    quiz.QuizID = -1;
                }
                Rolelevel.Quiz = quiz;
                Rolelevel.Invoke();
                dss = new DataSet();
                dss = Rolelevel.ResultSet;
                dlRoles.DataSource = Rolelevel.ResultSet.Tables[0].DefaultView.ToTable(true, "Role_ID", "Role_Name");
                dlRoles.DataBind();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}