using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLogic.Select;
using Common;
using System.IO;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using LevelsPro.App_Code;
using System.Data;
using MySql.Data.MySqlClient;
using BusinessLogic.Delete;
using LevelsPro.Util;
namespace LevelsPro.AdminPanel
{
    public partial class QuestionEdit : AuthorizedPage
    {
        static DataSet dss; 
        private static string pageURL;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            lblMessage.Visible = false;
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                try
                {
                    if (Request.QueryString["mess"] != null && Request.QueryString["mess"].ToString() != "")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Question info " + Resources.TestSiteResources.UpdateMessage;

                    }
                    LoadCategory();
                    LoadSites();

                    if (Request.QueryString["quizid"] != null && Request.QueryString["quizid"].ToString() != "")
                    {
                        ViewState["quizid"] = Request.QueryString["quizid"];
                    }

                    if (Request.QueryString["questionid"] != null && Request.QueryString["questionid"].ToString() != "")
                    {
                        ViewState["questionid"] = Request.QueryString["questionid"];
                        LoadData(Convert.ToInt32(ViewState["questionid"]));
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }


        #region show question for edit
        private void LoadData(int QuestionID)
        {
            string path = ConfigurationManager.AppSettings["QuestionPath"].ToString();
            QuizQuestionsViewBLL quizview = new QuizQuestionsViewBLL();
            Quiz _quiz = new Quiz();
            _quiz.Status = 0;
            _quiz.Where = " WHERE QuestionID = " + QuestionID.ToString();
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
                txtQuestion.Text = quizview.ResultSet.Tables[0].Rows[0]["QuestionText"].ToString();
                txtExplanation.Text = quizview.ResultSet.Tables[0].Rows[0]["QuestionExplanation"].ToString();
                txtCorrectAnswer.Text = quizview.ResultSet.Tables[0].Rows[0]["CorrectAnswer"].ToString();
                txtAnswer1.Text = quizview.ResultSet.Tables[0].Rows[0]["Answer1"].ToString();
                txtAnswer2.Text = quizview.ResultSet.Tables[0].Rows[0]["Answer2"].ToString();
                txtAnswer3.Text = quizview.ResultSet.Tables[0].Rows[0]["Answer3"].ToString();
                txtShort.Text = quizview.ResultSet.Tables[0].Rows[0]["ShortQuestion"].ToString();
                ddlCategory.SelectedValue = quizview.ResultSet.Tables[0].Rows[0]["Category"].ToString();
                ViewState["ddlCatg"] = quizview.ResultSet.Tables[0].Rows[0]["Category"].ToString();
                ddlLocation.SelectedValue = quizview.ResultSet.Tables[0].Rows[0]["SiteID"].ToString();

                hdImage.Value = path + quizview.ResultSet.Tables[0].Rows[0]["QuestionImage"].ToString();

                ViewState["QuestionImage"] = quizview.ResultSet.Tables[0].Rows[0]["QuestionImage"].ToString();
                ViewState["QuestionImageThumbnail"] = quizview.ResultSet.Tables[0].Rows[0]["QuestionImageThumbnail"].ToString();

                btnAddQuestion.Text = Resources.TestSiteResources.Update;

                
            }
        }
        #endregion
        protected void LoadCategory()
        {
            CategoryViewBLL catg = new CategoryViewBLL();
            Quiz quiz = new Quiz();
            try
            {
                catg.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dvCategory = catg.ResultSet.Tables[0].DefaultView;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataSource = dvCategory.ToTable();
            ddlCategory.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlCategory.Items.Insert(0, li);


            
        }

        private void LoadSites()
        {
            Site_DropDownBLL Site = new Site_DropDownBLL();
            try
            {
                Site.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlLocation.DataTextField = "site_name";
            ddlLocation.DataValueField = "site_id";
            ddlLocation.DataSource = Site.ResultSet;
            ddlLocation.DataBind();
            this.ddlLocation.Items.Insert(0, new ListItem("Select All", "0"));
            this.ddlLocation.SelectedIndex = 0;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (ViewState["quizid"] != null && ViewState["quizid"].ToString() != "")
            {
                Response.Redirect("QuestionManagement.aspx?quizid=" + ViewState["quizid"].ToString(), false);
            }
        }

        #region add and update question
        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["QuestionPath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationManager.AppSettings["QuestionThumbPath"].ToString());

            if (txtQuestion.Text.Equals(""))
            {
               
                return;
            }
            else
            {

                Quiz quiz = new Quiz();
                quiz.Question = txtQuestion.Text.Trim();
                quiz.Explanation = txtExplanation.Text.Trim();
                quiz.Correct = txtCorrectAnswer.Text.Trim();
                quiz.Answer1 = txtAnswer1.Text.Trim();
                quiz.Answer2 = txtAnswer2.Text.Trim();
                quiz.Answer3 = txtAnswer3.Text.Trim();
                quiz.Answer4 = txtCorrectAnswer.Text.Trim();
                quiz.ShortQuestion = txtShort.Text.Trim();

                if (ddlCategory.SelectedIndex > 0)
                {
                    quiz.Category = Convert.ToInt32(ddlCategory.SelectedValue);
                }             
                quiz.SiteID = Convert.ToInt32(ddlLocation.SelectedValue);

                if (fuQuestionImage.HasFile)
                {
                    string s = fuQuestionImage.FileName;
                    FileInfo fleInfo = new FileInfo(s);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        string GuidOne = Guid.NewGuid().ToString();
                        string FileExtension = Path.GetExtension(fuQuestionImage.FileName).ToLower();
                        fuQuestionImage.SaveAs(path + GuidOne + FileExtension);

                        quiz.QuestionImage = string.Format("{0}{1}", GuidOne, FileExtension);

                        System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
                        System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                        thumbImage.Save(Thumbpath + GuidOne + FileExtension);

                        quiz.QuestionImageThumbnail = string.Format("{0}{1}", GuidOne, FileExtension);
                    }
                }
                else
                {
                    if (ViewState["QuestionImage"] != null && ViewState["QuestionImage"].ToString() != "")
                    {
                        quiz.QuestionImage = ViewState["QuestionImage"].ToString();
                    }
                    if (ViewState["QuestionImageThumbnail"] != null && ViewState["QuestionImageThumbnail"].ToString() != "")
                    {
                        quiz.QuestionImageThumbnail = ViewState["QuestionImageThumbnail"].ToString();
                    }

                }




                if (ViewState["quizid"] != null && ViewState["quizid"].ToString() != "")
                {
                    quiz.QuizID = Convert.ToInt32(ViewState["quizid"]);
                    

                    MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                    scon.Open();
                    MySqlTransaction sqlTrans = scon.BeginTransaction();
                    quiz.sqlTransaction = sqlTrans;
                    try
                    {
                        if (btnAddQuestion.Text == "Update" || btnAddQuestion.Text == "mettre à jour" || btnAddQuestion.Text == "actualizar")
                        {
                            if (ViewState["questionid"] != null && ViewState["questionid"].ToString() != "")
                            {
                                QuestionsUpdateBLL updategame = new QuestionsUpdateBLL();
                                quiz.QuestionID = Convert.ToInt32(ViewState["questionid"]);
                                
                                updategame.Quiz = quiz;
                                updategame.Invoke();                                  
                            }
                        }
                        else
                        {
                            QuestionsInsertBLL insertquiz = new QuestionsInsertBLL();
                           
                            insertquiz.Quiz = quiz;
                            insertquiz.Invoke();
                        }

                     QuestionLevelDeleteBLL del = new QuestionLevelDeleteBLL();
                     QuestionLevelsInsertBLL qLevels = new QuestionLevelsInsertBLL();
                     
                        del.Quiz = quiz;
                         del.Invoke();
                     
                     for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                     {
                         if (dss.Tables[0].Rows[i]["Allow"].ToString()=="yes")
                         {
                            quiz.RoleID = Convert.ToInt32(dss.Tables[0].Rows[i]["Role_ID"].ToString());
                            quiz.LevelID = Convert.ToInt32(dss.Tables[0].Rows[i]["Level_ID"].ToString());
                            qLevels.Quiz = quiz;
                            qLevels.Invoke();
                         }

                     }
                     sqlTrans.Commit();
                   
                     if (btnAddQuestion.Text == "Update" || btnAddQuestion.Text == "mettre à jour" || btnAddQuestion.Text == "actualizar")
                     {
                         LoadData(int.Parse(quiz.QuestionID.ToString()));
                         lblMessage.Visible = true;
                         lblMessage.Text = "Question info " + Resources.TestSiteResources.UpdateMessage;
                         Response.Redirect("QuestionEdit.aspx?mess=1" + "&questionid=" + ViewState["questionid"].ToString() + "&quizid=" + ViewState["quizid"].ToString(), false);                         
                     }
                     else
                     {
                         lblMessage.Visible = true;
                         lblMessage.Text = "Question info " + ' ' + Resources.TestSiteResources.SavedMessage;
                         Response.Redirect("QuestionManagement.aspx?quizid=" + ViewState["quizid"].ToString(), false);
                     }
                     
                    }
                    catch (Exception )
                    {
                        sqlTrans.Rollback();
                    }
                    finally
                    {
                        
                        
                        sqlTrans.Dispose();
                        scon.Close();
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

        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (ViewState["quizid"] != null && ViewState["quizid"].ToString() != "")
            {
                Response.Redirect("QuestionManagement.aspx?quizid=" + ViewState["quizid"].ToString(), false);
            }
        }

        private void loadDataList()
        {
            try
            {
                RolesLevelsViewBLL Rolelevel = new RolesLevelsViewBLL();
                Quiz quiz = new Quiz();

                if (ViewState["questionid"] != null && ViewState["questionid"].ToString() != "")
                {
                    quiz.QuestionID = Convert.ToInt32(ViewState["questionid"]);

                }
                else
                {
                    quiz.QuestionID = -1;
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

        


        protected void gvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            mpeManualScore.Show();
            if (gvCategory.SelectedIndex != -1)
            {
                txtCategory.Text = gvCategory.SelectedRow.Cells[2].Text.Trim();
                btnSave.Text = Resources.TestSiteResources.Update;
            }
            mpeManualScore.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            mpeManualScore.Show();
            if (txtCategory.Text.Equals(""))
            {
                
                return;
            }
            else
            {
                lblcatgmess.Visible = true;
                Quiz quiz = new Quiz();
                quiz.CategoryName = txtCategory.Text.Trim();
                if (btnSave.Text == "Update" || btnSave.Text == "mettre à jour" || btnSave.Text == "actualizar")
                {
                    CategoryUpdateBLL catgUp = new CategoryUpdateBLL();
                    quiz.Category = Convert.ToInt32(gvCategory.SelectedDataKey[0]);
                    catgUp.Quiz = quiz;
                    try
                    {
                        catgUp.Invoke();
                        lblcatgmess.Text = "Category name updated successfully";
                        
                    }
                    catch (Exception ex)
                    {
                        lblcatgmess.Text = "Category name not updated successfully";
                       
                    }
                }
                else
                {
                    CategoryInsertBLL catgIn = new CategoryInsertBLL();
                    catgIn.Quiz = quiz;
                    try
                    {
                        catgIn.Invoke();
                        lblcatgmess.Text = "Category name Added successfully";
                        
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblcatgmess.Text = "Category name Alreadt exists";
                           
                        }
                        else
                        {
                            lblcatgmess.Text = "Category name not Added successfully";
                            
                        }
                    }
                }

                btnSave.Text = Resources.TestSiteResources.Save;
                txtCategory.Text = "";
                LoadCategoryPop();

            }
            mpeManualScore.Show();
        }

        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            lblcatgmess.Visible = false;
            LoadCategory();
            if (ViewState["ddlCatg"] != null)
            {
                ddlCategory.SelectedValue = ViewState["ddlCatg"].ToString();
            }
            btnSave.Text = Resources.TestSiteResources.Save;
            mpeManualScore.Hide();
           
        }
        protected void LoadCategoryPop()
        {

            CategoryViewBLL catg = new CategoryViewBLL();
            Quiz quiz = new Quiz();
            try
            {
                catg.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dvCategory = catg.ResultSet.Tables[0].DefaultView;
            gvCategory.DataSource = dvCategory.ToTable();
            gvCategory.DataBind();
        
        
        }

        protected void btnCategoryEdit_Click(object sender, EventArgs e)
        {
            mpeManualScore.Show();
            LoadCategoryPop();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex > 0)
            {
                ViewState["ddlCatg"] = ddlCategory.SelectedValue;
            }
        }
    }
}