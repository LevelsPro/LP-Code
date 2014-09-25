using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using BusinessLogic.Insert;
using Common;
using BusinessLogic.Delete;
using System.Data;
using LevelsPro.App_Code;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using LevelsPro.Util;

namespace LevelsPro.AdminPanel
{
    public partial class QuestionManagement : AuthorizedPage
    {
        private static string pageURL;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                try
                {
                    if (Request.QueryString["quizid"] != null && Request.QueryString["quizid"].ToString() != "")
                    {
                        ViewState["quizid"] = Request.QueryString["quizid"];
                        LoadQuestions(Convert.ToInt32(ViewState["quizid"]));
                        //LoadRoles();
                    }
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        private void LoadSites()
        {
            Site_DropDownBLL selectddlSite = new Site_DropDownBLL();
            try
            {
                selectddlSite.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlRole.DataTextField = "site_name";
            ddlRole.DataValueField = "site_id";

            DataView dv = selectddlSite.ResultSet.Tables[0].DefaultView;

            ddlRole.DataSource = dv.ToTable();
            ddlRole.DataBind();

            ListItem liFilter = new ListItem("Select All Location", "0");
            ddlRole.Items.Insert(0, liFilter);
           
        }
        protected void LoadLevels(int RoleID)
        {
            LevelsViewBLL level = new LevelsViewBLL();
            Common.Roles role = new Roles();
            role.RoleID = RoleID;
            level.Role = role;
            try
            {
                level.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            ddlLevel.DataTextField = "Level_Name";
            ddlLevel.DataValueField = "Level_ID";


            ddlLevel.DataSource = level.ResultSet;
            ddlLevel.DataBind();

            ListItem liFilter = new ListItem("Select Level", "0");
            ddlLevel.Items.Insert(0, liFilter);

        }
        protected void LoadRoles()
        {
            RolesViewBLL role = new RolesViewBLL();
            try
            {
                role.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlRole.DataTextField = "Role_Name";
            ddlRole.DataValueField = "Role_ID";

            DataView dv = role.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1";

            ddlRole.DataSource = dv.ToTable();
            ddlRole.DataBind();

            ListItem liFilter = new ListItem("Select Role", "0");
            ddlRole.Items.Insert(0, liFilter);
        }
        #region show all question
        protected void LoadQuestions(int QuizID)
        {
            QuizQuestionsViewBLL questionview = new QuizQuestionsViewBLL();
            Quiz _quiz = new Quiz();

            
            if (ViewState["roleid"] != null && ViewState["roleid"].ToString() != "")
            {
               _quiz.Status = 1;
                _quiz.Where = " WHERE QuizID=" + QuizID.ToString() + " AND tblQuestionLevels.RoleID=" + Convert.ToInt32(ViewState["roleid"]) + " AND LevelID=" + Convert.ToInt32(ViewState["levelid"]) ;
            }
            else if (ViewState["siteid"] != null && ViewState["siteid"].ToString() != "")
            {
                _quiz.Status = 0;
                _quiz.Where = " WHERE QuizID= " + QuizID.ToString() + " AND SiteID=" + Convert.ToInt32(ViewState["siteid"]) ;
            
            }
            else
            {
                _quiz.Status = 0;
                _quiz.Where = " WHERE QuizID= " + QuizID.ToString();
            }

            questionview.Quiz = _quiz;
            try
            {
                questionview.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (questionview.ResultSet.Tables[0] != null && questionview.ResultSet.Tables[0].Rows.Count > 0)
            {
                dlQuestions.DataSource = questionview.ResultSet.Tables[0];
                dlQuestions.DataBind();
            }
            else
            {
                dlQuestions.DataSource = null;
                dlQuestions.DataBind();
            }

        }

        #endregion
        protected void dlQuestions_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditQuestion")
            {
                if (ViewState["quizid"] != null && ViewState["quizid"].ToString() != "")
                {
                    Response.Redirect("QuestionEdit.aspx?questionid=" + e.CommandArgument.ToString() + "&quizid=" + ViewState["quizid"].ToString(), false);
                }
            }
            else if (e.CommandName == "DeleteQuestion")
            {
                QuestionDeleteBLL questiondelete = new QuestionDeleteBLL();
                Quiz _quiz = new Quiz();
                _quiz.QuestionID = Convert.ToInt32(e.CommandArgument);
                questiondelete.Quiz = _quiz;
                try
                {
                    questiondelete.Invoke();
                    LoadQuestions(Convert.ToInt32(ViewState["quizid"]));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

               
            }
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (ViewState["quizid"] != null && ViewState["quizid"].ToString() != "")
            {
                Response.Redirect("QuestionEdit.aspx?quizid=" + ViewState["quizid"].ToString(), false);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRole.SelectedIndex > 0)
                {
                    if (Convert.ToInt32(ViewState["roleid"]) == 1)
                    {
                        ViewState["siteid"] = null;
                        ViewState["roleid"] = ddlRole.SelectedValue;
                        LoadLevels(Convert.ToInt32(ViewState["roleid"]));
                        // LoadQuestions(Convert.ToInt32(ViewState["quizid"]));
                    }
                    else if (Convert.ToInt32(ViewState["siteid"]) == 1 || Convert.ToInt32(ViewState["check"]) == 1)
                    {
                        ViewState["roleid"] = null;
                        ViewState["siteid"] = ddlRole.SelectedValue;
                        LoadQuestions(Convert.ToInt32(ViewState["quizid"]));
                    }
                }
                else if (ddlRole.SelectedIndex == 0 && Convert.ToInt32(ViewState["check"]) == 1)
                {
                    ViewState["roleid"] = null;
                    ViewState["siteid"] = ddlRole.SelectedValue;
                    LoadQuestions(Convert.ToInt32(ViewState["quizid"]));

                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            
             
        }

        public static DataTable exceldata(string filePath)
        {
            OleDbConnection cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + "; Extended Properties=Excel 12.0;");

            OleDbCommand oconn = new OleDbCommand("select * from [Sheet1$]", cnn);
            cnn.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
            DataTable dt = new DataTable();
            adp.Fill(dt); 
            return dt;

        }

        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".xls", ".xlsx"};
            if (strArr.Contains(extension))
                return true;
            return false;
        }

        protected void btnBulkInsert_Click(object sender, EventArgs e)
        {
            string FilePath = "";
            if (fpBulk.HasFile)
            {
                string s = fpBulk.FileName;
                s = Convert.ToString(System.DateTime.Now.Ticks) + "." + s;
                FilePath = Server.MapPath(@"~\APIExcelSheet");

                FileInfo fleInfo = new FileInfo(s);
                if (AllowedFile(fleInfo.Extension))
                {
                    string GuidOne = Guid.NewGuid().ToString();
                    string FileExtension = Path.GetExtension(fpBulk.FileName).ToLower();
                    fpBulk.SaveAs(FilePath + s);
                    
                }

                DataSet dsBulk = new DataSet();

                DataTable dtBulk = exceldata(FilePath + s);

                dsBulk.Tables.Add(dtBulk);

                BulkInsertQuizQuestionsBLL BulkInsert = new BulkInsertQuizQuestionsBLL();
                BulkInsert.Invoke(dsBulk, FilePath);

                if (BulkInsert.BulkResult.Equals("Successfull"))
                {
                    //success
                }
                else
                {
                    //not success
                }
                
            }
        }

        protected void ddlFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFilterBy.SelectedIndex > 0)
                {
                    if (ddlFilterBy.SelectedValue == "1")
                    {
                        ViewState["check"] = null;
                        ViewState["siteid"] = null;
                        ViewState["roleid"] = 1;
                        LoadRoles();
                    }
                    else if (ddlFilterBy.SelectedValue == "2")
                    {
                        ddlLevel.Items.Clear();

                        ViewState["roleid"] = null;
                        ViewState["siteid"] = 1;
                        ViewState["check"] = 1;
                        LoadSites();
                        ddlRole_SelectedIndexChanged(null, null);
                    }

                }
                else if (ddlFilterBy.SelectedIndex == 0)
                {
                    ddlRole.Items.Clear();
                    ddlLevel.Items.Clear();

                    ViewState["roleid"] = null;
                    ViewState["siteid"] = null;
                    ViewState["check"] = null;
                    LoadQuestions(Convert.ToInt32(ViewState["quizid"]));

                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRole.SelectedIndex > 0)
                {
                    ViewState["levelid"] = ddlLevel.SelectedValue;
                    LoadQuestions(Convert.ToInt32(ViewState["quizid"]));

                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}