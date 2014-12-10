using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using BusinessLogic.Delete;
using LevelsPro.App_Code;
using System.Configuration;
using System.IO;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class LevelEdit : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        private static string pageURL;
        private ILog log;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblmessage.Visible = false;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (Convert.ToInt32(Session["viewcheck"]) == 1)
            {
                lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.UpdateMessage;
                Session["viewcheck"] = 0;
                lblmessage.Visible = true;
            }
            else if (Convert.ToInt32(Session["viewcheck"]) == 2)
            {
                lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.SavedMessage;
                Session["viewcheck"] = 0;
                lblmessage.Visible = true;

            }

            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                
                if (Request.QueryString["levelid"] != null && Request.QueryString["levelid"].ToString() != "")
                {
                    ViewState["levelid"] = Request.QueryString["levelid"];
                }

                if (Request.QueryString["roleid"] != null && Request.QueryString["roleid"].ToString() != "")
                {
                    ViewState["roleid"] = Request.QueryString["roleid"];
                }


                if (Request.QueryString["roleid"] != null && Request.QueryString["roleid"].ToString() != "" && Request.QueryString["count"] != null && Request.QueryString["count"].ToString() != "")
                {
                    ViewState["count"] = Request.QueryString["count"];
                    imgbtnleft.Enabled = false;
                    imgbtnright.Enabled = false;
                    btnUpdate.Text = Resources.TestSiteResources.Add;


                }
                try
                {
                    LoadGames();


                    LoadData(Convert.ToInt32(ViewState["roleid"]), Convert.ToInt32(ViewState["levelid"]));
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        
        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (ViewState["roleid"] != null && ViewState["roleid"].ToString() != "")
            {
                Response.Redirect("LevelManagements.aspx?roleid=" + ViewState["roleid"].ToString(), false);
            }
        }

        #region game code and display
        protected void LoadGames()
        {
            LevelGameViewBLL dropdown = new LevelGameViewBLL();

            LevelGame _dropdown = new LevelGame();
            
            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlGame.DataTextField = "GameName";
            ddlGame.DataValueField = "GameID";

            ddlGame.DataSource = dropdown.ResultSet;
            ddlGame.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlGame.Items.Insert(0, li);
        }

        protected void LoadStatus_YOU_ARE_IN()
        {
            LevelGameDDLViewBLL dropdown = new LevelGameDDLViewBLL();
            LevelGame _dropdown = new LevelGame();
            _dropdown.GameID = Convert.ToInt32(ddlGame.SelectedValue);
            dropdown.Game = _dropdown;
      
            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlYouIn.DataTextField = "GameDropdownName";
            ddlYouIn.DataValueField = "GameDropdownID";

            DataSet dS = new DataSet();
            dS = dropdown.ResultSet;

            DataView dv = new DataView();
            dv = dS.Tables[0].DefaultView;

       

            DataTable dT = new DataTable();
            dT = dv.ToTable();
            if (dT != null && dT.Rows.Count > 0)
            {
                ddlYouIn.DataSource = dT;
                ddlYouIn.DataBind();

                ListItem li = new ListItem("Select", "0");
                ddlYouIn.Items.Insert(0, li);
            }
        }

        protected void LoadStatus_HEADING_TO()
        {
            LevelGameDDLViewBLL dropdown = new LevelGameDDLViewBLL();
            LevelGame _dropdown = new LevelGame();
            _dropdown.GameID = Convert.ToInt32(ddlGame.SelectedValue);
            dropdown.Game = _dropdown;
        
            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlHeadingTo.DataTextField = "GameDropdownName";
            ddlHeadingTo.DataValueField = "GameDropdownID";

            DataSet dS = new DataSet();
            dS = dropdown.ResultSet;

            DataView dv = new DataView();
            dv = dS.Tables[0].DefaultView;

        

            DataTable dT = new DataTable();
            dT = dv.ToTable();

            if(dT !=null && dT.Rows.Count>0)
            {
                ddlHeadingTo.DataSource = dT;
                ddlHeadingTo.DataBind();

                ListItem li = new ListItem("Select", "0");
                ddlHeadingTo.Items.Insert(0, li);
            }

          
        }
        #endregion
        protected void LoadData(int RoleID, int LevelID)
        {
            string path = ConfigurationSettings.AppSettings["RolePath"].ToString();
            string Thumbpath = ConfigurationSettings.AppSettings["RoleThumbPath"].ToString();

            TargetViewBLL Target = new TargetViewBLL();
            try
            {
                Target.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv = Target.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Role_ID=" + RoleID.ToString() + "AND Level_ID =" + LevelID.ToString();

            dv.Sort = "KPI_name";


            gvTarget.DataSource = dv.ToTable();
            gvTarget.DataBind();


            if (ViewState["levelid"] != null && ViewState["levelid"].ToString() != "")
            {

                LevelsViewBLL level = new LevelsViewBLL();
                Common.Roles role = new Roles();
                role.RoleID = Convert.ToInt32(ViewState["roleid"]);
                level.Role = role;
                try
                {
                    level.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataView dvlevel = level.ResultSet.Tables[0].DefaultView;

                dvlevel.RowFilter = "Role_ID=" + RoleID.ToString() + "AND Level_ID =" + LevelID.ToString();

                if (level.ResultSet != null && level.ResultSet.Tables.Count > 0 && level.ResultSet.Tables[0] != null && level.ResultSet.Tables[0].Rows.Count > 0)
                {
                  
                    lblTotallevel.Text = level.ResultSet.Tables[0].Rows.Count.ToString();
                }

             

                if (dvlevel.ToTable() != null && dvlevel.ToTable().Rows.Count > 0)
                {
                    txtBaseHours.Text = dvlevel.ToTable().Rows[0]["BaseHours"].ToString();
                    txtlevelPoints.Text = dvlevel.ToTable().Rows[0]["Points"].ToString();
                    txtLevelName.Text = dvlevel.ToTable().Rows[0]["Level_Name"].ToString();
                    lbllevel.Text = dvlevel.ToTable().Rows[0]["Level_Position"].ToString().Substring(6, dvlevel.ToTable().Rows[0]["Level_Position"].ToString().Length-6);
                    lblRoleName.Text = dvlevel.ToTable().Rows[0]["Role_Name"].ToString();
                    lblLevelName.Text = "Level " + lbllevel.Text;
                    if (dvlevel.ToTable().Rows[0]["Game"] != null && dvlevel.ToTable().Rows[0]["Game"].ToString() !="")
                    {
                        ddlGame.SelectedValue = dvlevel.ToTable().Rows[0]["Game"].ToString();
                        ddlGame_SelectedIndexChanged(null, null);

                        ddlYouIn.SelectedValue = dvlevel.ToTable().Rows[0]["CurrentlyIn"].ToString();
                        ddlHeadingTo.SelectedValue = dvlevel.ToTable().Rows[0]["Reach"].ToString(); 
                    }
                    else
                    {
                        ddlGame.SelectedValue = "0";
                        ddlGame_SelectedIndexChanged(null, null);
                        ddlYouIn.SelectedValue = "0";
                        ddlHeadingTo.SelectedValue = "0";

                    }

                    if (dvlevel.ToTable().Rows[0]["ImageName"].ToString() != null && dvlevel.ToTable().Rows.Count > 0 && dvlevel.ToTable().Rows[0]["ImageName"].ToString() != "")
                    {
                      
                        string imagepath = dvlevel.ToTable().Rows[0]["ImageName"].ToString();
                        ViewState["imagepath"] = imagepath;
                         ViewState["imagethumbpath"] =  dvlevel.ToTable().Rows[0]["ImageThumbnail"].ToString();
                        hplView.Visible = true;
                        rfvGraphic.ValidationGroup = "update";
                        hplView.NavigateUrl = path + imagepath;
                    }

                    //txtDimension_left.Text = dvlevel.ToTable().Rows[0]["Dimension_left"].ToString();
                    //txtDimension_top.Text = dvlevel.ToTable().Rows[0]["Dimension_top"].ToString(); 
                }
                else
                {
                    txtBaseHours.Text = "";
                    txtlevelPoints.Text = "";
                    txtLevelName.Text = "";
                    ddlYouIn.SelectedIndex = 0; 
                    ddlHeadingTo.SelectedIndex = 0;
                    ddlGame.SelectedIndex = 0;
                }

            }

            if (dv.ToTable() != null && dv.ToTable().Rows.Count > 0)
            {
                txtBaseHours.Text = dv.ToTable().Rows[0]["BaseHours"].ToString();
                txtlevelPoints.Text = dv.ToTable().Rows[0]["Points"].ToString();
                txtLevelName.Text = dv.ToTable().Rows[0]["Level_Name"].ToString();
                lbllevel.Text = dv.ToTable().Rows[0]["Level_Position"].ToString();
                lblRoleName.Text = dv.ToTable().Rows[0]["Role_Name"].ToString();
                lblLevelName.Text = "Level " + lbllevel.Text;
                if (dv.ToTable().Rows[0]["Game"] != null && dv.ToTable().Rows[0]["Game"].ToString() != "")
                {
                    ddlGame.SelectedValue = dv.ToTable().Rows[0]["Game"].ToString();
                    ddlGame_SelectedIndexChanged(null, null);

                    ddlYouIn.SelectedValue = dv.ToTable().Rows[0]["CurrentlyIn"].ToString(); 
                    ddlHeadingTo.SelectedValue = dv.ToTable().Rows[0]["Reach"].ToString();

                }
                else
                {
                    ddlGame.SelectedValue = "0";
                    ddlGame_SelectedIndexChanged(null, null);
                    ddlYouIn.SelectedValue = "0";
                    ddlHeadingTo.SelectedValue = "0";

                }

                if (dv.ToTable().Rows[0]["ImageName"].ToString() != null && dv.ToTable().Rows.Count > 0 && dv.ToTable().Rows[0]["ImageName"].ToString() != "")
                {
                    string imagepath = dv.ToTable().Rows[0]["ImageName"].ToString();
                    ViewState["imagepath"] = imagepath;
                    ViewState["imagethumbpath"] = dv.ToTable().Rows[0]["ImageThumbnail"].ToString();
                    hplView.Visible = true;
                    rfvGraphic.ValidationGroup = "update";
                    hplView.NavigateUrl = path + imagepath;
                }

               // txtDimension_left.Text = dv.ToTable().Rows[0]["Dimension_left"].ToString();
               // txtDimension_top.Text = dv.ToTable().Rows[0]["Dimension_top"].ToString();

                if (ViewState["levelid"] != null && ViewState["levelid"].ToString() != "")
                {

                    LevelsViewBLL level = new LevelsViewBLL();
                    Common.Roles role = new Roles();
                    role.RoleID = Convert.ToInt32(ViewState["roleid"]);
                    level.Role = role;
                    try
                    {
                        level.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    if (level.ResultSet != null && level.ResultSet.Tables.Count > 0 && level.ResultSet.Tables[0] != null && level.ResultSet.Tables[0].Rows.Count > 0)
                    {
                        
                        lblTotallevel.Text = level.ResultSet.Tables[0].Rows.Count.ToString();
                    }

                }


            }
            

        }

        protected void gvTarget_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dropdown = e.Row.FindControl("ddlKPI") as DropDownList;
                if (dropdown != null)
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


                    dropdown.DataTextField = "KPI_name";
                    dropdown.DataValueField = "KPI_ID";

                    DataView dv = kpi.ResultSet.Tables[0].DefaultView;

                    dv.RowFilter = "Active=1 AND TypeLevel='Level'";

                    dropdown.DataSource = dv.ToTable();
                    dropdown.DataBind();

                    ListItem li = new ListItem("Select", "0");
                    dropdown.Items.Insert(0, li);

                    Label KPIvalue = e.Row.FindControl("lblddlKPIValue") as Label;


                    dropdown.SelectedValue = KPIvalue.Text;
                }



            }
        }

        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".jpeg", ".jpg", ".bmp", ".png", ".gif" };
            if (strArr.Contains(extension))
                return true;
            return false;
        }


        public String SaveImageInFolder()
        {
            string path = Server.MapPath(ConfigurationSettings.AppSettings["RolePath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationSettings.AppSettings["RoleThumbPath"].ToString());
            if (fileQuizImage.HasFile)
            {
                string s = fileQuizImage.FileName;
                FileInfo fleInfo = new FileInfo(s);
                if (AllowedFile(fleInfo.Extension))
                {
                    string GuidOne = Guid.NewGuid().ToString();
                    string FileExtension = Path.GetExtension(fileQuizImage.FileName).ToLower();
                    fileQuizImage.SaveAs(path + GuidOne + FileExtension);
                    string ipath = string.Format("{0}{1}", GuidOne, FileExtension);

                    System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
                    System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                    thumbImage.Save(Thumbpath + GuidOne + FileExtension);
                    ViewState["thumbpathnew"] = string.Format("{0}{1}", GuidOne, FileExtension);


                   return ipath;
                }
                else
                    return "";
            }
            else
            {
                return "";
            }
        }


        #region update and add level
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(ConfigurationSettings.AppSettings["RolePath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationSettings.AppSettings["RoleThumbPath"].ToString());


            if (btnUpdate.Text == "Update" || btnUpdate.Text == "mettre à jour" || btnUpdate.Text == "actualizar")
            {
                

                if (ViewState["levelid"] != null && ViewState["levelid"].ToString() != "" && ddlGame.SelectedIndex > 0 && ddlHeadingTo.SelectedIndex > 0 && ddlYouIn.SelectedIndex > 0)
                {
                    lblmessage.Visible = true;
                    Level_LevelInfoUpdateBLL UpdateLevel = new Level_LevelInfoUpdateBLL();
                    Levels level = new Levels();
                    level.LevelID = Convert.ToInt32(ViewState["levelid"]);
                    level.BaseHours = Convert.ToInt32(txtBaseHours.Text.Trim());
                    level.Points = Convert.ToInt32(txtlevelPoints.Text.Trim());
                    level.LevelName = txtLevelName.Text.Trim();
                    
                    level.CurrentlyIn = ddlYouIn.SelectedValue;
                    level.Reach = ddlHeadingTo.SelectedValue;
                    level.Game = ddlGame.SelectedValue;
                    String imageID = SaveImageInFolder();
                    if (imageID != "")
                    {
                        ViewState["Image"] = imageID;
                        level.LevelImage = imageID;
                        level.LevelThumbnail = ViewState["thumbpathnew"].ToString();

                    }
                    else
                    {
                        level.LevelThumbnail = ViewState["imagethumbpath"].ToString();
                        level.LevelImage=ViewState["imagepath"].ToString();
                    }

                   // level.LevelImage =
                  //  level.LevelThumbnail =
                   // level.Dimension_top = Convert.ToInt32(txtDimension_top.Text);


                    UpdateLevel.Levels = level;
                    try
                    {
                        UpdateLevel.Invoke();                        
                        lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.UpdateMessage;
                     

                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.Level;
                       
                    }

                    //gvTarget Sort Logic
                    foreach (GridViewRow Row in gvTarget.Rows)
                    {
                        DropDownList kpidropdown = Row.FindControl("ddlKPI") as DropDownList;
                        TextBox valuetextbox = Row.FindControl("txtTargetValue") as TextBox;
                        TextBox pointstextbox = Row.FindControl("txtPoints") as TextBox;
                        Label targetidlabel = Row.FindControl("lblTargetID") as Label;

                        Level_TargetUpdateBLL UpdateLevelTarget = new Level_TargetUpdateBLL();
                        Target target = new Target();
                        target.KPIID = Convert.ToInt32(kpidropdown.SelectedValue);
                        if (valuetextbox.Text.Trim() != "")
                        {
                            target.TargetValue = Convert.ToInt32(valuetextbox.Text.Trim());
                        }
                        if (pointstextbox.Text.Trim() != "")
                        {
                            target.Points = Convert.ToInt32(pointstextbox.Text.Trim());
                        }
                        target.TargetID = Convert.ToInt32(targetidlabel.Text);

                        UpdateLevelTarget.Target = target;
                        try
                        {
                            UpdateLevelTarget.Invoke();
                             lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.UpdateMessage;                                     
                        }
                        catch (Exception ex)
                        {
                            ExceptionUtility.ExceptionLogString(ex, Session);
                            Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                            log.Debug(Session["ExpLogString"]);
                            lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.Level;
                           
                        }


                    }
                }
                else
                {

                    lblmessage.Text = "Provide Game ,you are in and Heading to values";
                }

                if (ViewState["Image"] != null)
                {
                    hplView.Visible = true;
                    hplView.NavigateUrl = path + ViewState["Image"].ToString();
                    if (!ViewState["levelid"].Equals("") || ViewState["levelid"] != null || !ViewState["roleid"].Equals("") || ViewState["roleid"] != null)
                    {
                        Session["viewcheck"] = 1;
                        Response.Redirect("LevelEdit.aspx?levelid=" + Convert.ToInt32(ViewState["levelid"]) + "&roleid=" + Convert.ToInt32(ViewState["roleid"]), false);
                    }
                    }
            }
            else if (ViewState["roleid"] != null && ViewState["roleid"].ToString() != "" && ViewState["count"] != null && ViewState["count"].ToString() != "")
                {
                    lblmessage.Visible = true;

                    if (txtLevelName.Text.Equals(""))
                    {
                        return;
                    }
                    else
                    {
                        if (ViewState["roleid"] != null && ViewState["roleid"].ToString() != "")
                        {
                            Levels level = new Levels();
                            level.LevelName = txtLevelName.Text.Trim();
                            level.RoleID = Convert.ToInt32(ViewState["roleid"]);

                            string levelposition = ViewState["count"].ToString();
                            level.LevelPosition = Convert.ToInt32(levelposition);


                            level.BaseHours = Convert.ToInt32(txtBaseHours.Text.Trim());
                            level.Points = Convert.ToInt32(txtlevelPoints.Text.Trim());

                           // level.Dimension_top = Convert.ToInt32(txtDimension_top.Text.Trim());
                           // level.Dimension_left = Convert.ToInt32(txtDimension_left.Text.Trim());
                            String imageID = SaveImageInFolder();
                            if (imageID != "")
                            {
                                ViewState["Image"] = imageID;
                                level.LevelImage = imageID;
                                level.LevelThumbnail = ViewState["thumbpathnew"].ToString();

                            }
                            else
                            {
                                level.LevelThumbnail = ViewState["imagethumbpath"].ToString();
                                level.LevelImage = ViewState["imagepath"].ToString();
                            }
                           
                            level.CurrentlyIn = ddlYouIn.SelectedValue;  
                            level.Reach = ddlHeadingTo.SelectedValue;
                            level.Game = ddlGame.SelectedValue;

                            LevelsInsertBLL insertLevel = new LevelsInsertBLL();
                            insertLevel.Levels = level;
                            try
                            {
                                int LevelID = insertLevel.Invoke();
                                ViewState["levelid"] = LevelID;
                                ViewState["count"] = null;
                                imgbtnright.Enabled = true;
                                imgbtnleft.Enabled = true;
                                if (ViewState["Image"] != null || !ViewState["Image"].Equals(""))
                                {
                                    hplView.Visible = true;
                                    hplView.NavigateUrl = path + ViewState["Image"].ToString();
                                }
                                lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.SavedMessage;//"Level has been saved successfully";                                
                                btnUpdate.Text = Resources.TestSiteResources.Update;
                                try
                                {
                                    LoadData(Convert.ToInt32(ViewState["roleid"]), LevelID);
                                }
                                catch (Exception exp)
                                {
                                    throw exp;
                                }

                                if (!txtTargetValue.Text.Trim().Equals("") || !txtPoints.Text.Trim().Equals(""))
                                {
                                    Target target = new Target();
                                    target.TargetValue = Convert.ToInt32(txtTargetValue.Text.Trim());
                                    target.RoleID = Convert.ToInt32(ViewState["roleid"]);
                                    target.LevelID = Convert.ToInt32(ViewState["levelid"]);
                                    target.KPIID = Convert.ToInt32(ddlKPI.SelectedValue);
                                    target.Points = Convert.ToInt32(txtPoints.Text.Trim());
                                    target.Description = "";

                                    TargetInsertBLL insertTarget = new TargetInsertBLL();
                                    insertTarget.Target = target;
                                    try
                                    {
                                        insertTarget.Invoke();


                                        pnlAddGoal.Visible = false;
                                        ddlKPI.SelectedIndex = 0;
                                        txtTargetValue.Text = "";
                                        txtPoints.Text = "";
                                        btnUpdate.Text = Resources.TestSiteResources.Update;
                                        LoadData(Convert.ToInt32(ViewState["roleid"]), Convert.ToInt32(ViewState["levelid"]));
                                    }
                                    catch (Exception ex)
                                    {
                                        ExceptionUtility.ExceptionLogString(ex, Session);
                                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                                        log.Debug(Session["ExpLogString"]);
                                        if (ex.Message.Contains("Duplicate"))
                                        {
                                            lblmessage.Text = Resources.TestSiteResources.TargetValue + ' ' + Resources.TestSiteResources.Already;
                                        }
                                        else
                                        {
                                            //show unsuceess
                                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.TargetValue;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }                            
                        }
                        if (!ViewState["levelid"].Equals("") || ViewState["levelid"] != null || !ViewState["roleid"].Equals("") || ViewState["roleid"] != null)
                        {
                            Session["viewcheck"] = 2;
                            Response.Redirect("LevelEdit.aspx?levelid=" + Convert.ToInt32(ViewState["levelid"]) + "&roleid=" + Convert.ToInt32(ViewState["roleid"]), false);
                        }
                    }
                   
                }
                else
                {
                    lblmessage.Visible = false;
                    Target target = new Target();
                    target.TargetValue = Convert.ToInt32(txtTargetValue.Text.Trim());
                    target.RoleID = Convert.ToInt32(ViewState["roleid"]);
                    target.LevelID = Convert.ToInt32(ViewState["levelid"]);
                    target.KPIID = Convert.ToInt32(ddlKPI.SelectedValue);
                    target.Points = Convert.ToInt32(txtPoints.Text.Trim());
                    target.Description = "";

                    TargetInsertBLL insertTarget = new TargetInsertBLL();
                    insertTarget.Target = target;
                    try
                    {
                        insertTarget.Invoke();

                        
                        pnlAddGoal.Visible = false;
                        ddlKPI.SelectedIndex = 0;
                        txtTargetValue.Text = "";
                        txtPoints.Text = "";
                        btnUpdate.Text = Resources.TestSiteResources.Update;
                        LoadData(Convert.ToInt32(ViewState["roleid"]), Convert.ToInt32(ViewState["levelid"]));
                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        if (ex.Message.Contains("Duplicate"))
                        {
                            
                        }
                        else
                        {
                            throw ex;
                        }
                        
                    }
                }
        }
        #endregion

        #region add goal to level
        protected void btnAddGoal_Click(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            pnlAddGoal.Visible = true;
            btnUpdate.Text = Resources.TestSiteResources.Add;


            KPIViewBLL kpi = new KPIViewBLL();
            try
            {
                kpi.Invoke();
            }
            catch (Exception ex)
            {
                ExceptionUtility.ExceptionLogString(ex, Session);
                Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                log.Debug(Session["ExpLogString"]);

                if (ex.Message.ToLower().Contains("duplicate"))
                { }
                else
                    throw ex;
            }
           
            ddlKPI.DataTextField = "KPI_name";
            ddlKPI.DataValueField = "KPI_ID";

            DataView dv = kpi.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1 AND TypeLevel='Level'";

            ddlKPI.DataSource = dv.ToTable();
            ddlKPI.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlKPI.Items.Insert(0, li);
        }
        #endregion

        #region delete goal
        protected void btnDeleteGoal_Click(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            foreach (GridViewRow Row in gvTarget.Rows)
            {
                CheckBox cbidelete = Row.FindControl("chkDelete") as CheckBox;
                Label targetidlabel = Row.FindControl("lblTargetID") as Label;

                if (cbidelete.Checked)
                {
                    level_TargetDeleteBLL deletetarget = new level_TargetDeleteBLL();
                    Target target = new Target();

                    target.TargetID = Convert.ToInt32(targetidlabel.Text);
                    deletetarget.Target = target;

                    try
                    {
                        deletetarget.Invoke();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
            try
            {
                LoadData(Convert.ToInt32(ViewState["roleid"]), Convert.ToInt32(ViewState["levelid"]));
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion

        #region rearrage level
        protected void imgbtnleft_Click(object sender, ImageClickEventArgs e)
        {
            lblmessage.Visible = false;
            int level_id = 0;
            int previouslevel_id = 0;
            
            if (ViewState["levelid"] != null && ViewState["levelid"].ToString() != "")
            {
                level_id = Convert.ToInt32(ViewState["levelid"]);

                LevelsViewBLL level = new LevelsViewBLL();
                Common.Roles role = new Roles();
                role.RoleID = Convert.ToInt32(ViewState["roleid"]);
                level.Role = role;
                try
                {
                    level.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (level.ResultSet != null && level.ResultSet.Tables.Count > 0 && level.ResultSet.Tables[0] != null && level.ResultSet.Tables[0].Rows.Count > 0)
                {
                    
                    for (int i = 1; i < level.ResultSet.Tables[0].Rows.Count; i++)
                    {
                        if (level_id == Convert.ToInt32(level.ResultSet.Tables[0].Rows[i]["Level_ID"]))
                        {
                            previouslevel_id = Convert.ToInt32(level.ResultSet.Tables[0].Rows[i - 1]["Level_ID"]);
                            try
                            {
                                LoadData(Convert.ToInt32(ViewState["roleid"]), previouslevel_id);
                            }
                            catch (Exception exp)
                            {
                                throw exp;
                            }
                            ViewState["levelid"] = previouslevel_id;
                        }
                    }
                }

            }
        }

        protected void imgbtnright_Click(object sender, ImageClickEventArgs e)
        {
            lblmessage.Visible = false;
            int level_id = 0;
            int nextlevel_id = 0;
          
          
            if (ViewState["levelid"] != null && ViewState["levelid"].ToString() != "")
            {
                level_id = Convert.ToInt32(ViewState["levelid"]);

                LevelsViewBLL level = new LevelsViewBLL();
                Common.Roles role = new Roles();
                role.RoleID = Convert.ToInt32(ViewState["roleid"]);
                level.Role = role;
                try
                {
                    level.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (level.ResultSet != null && level.ResultSet.Tables.Count > 0 && level.ResultSet.Tables[0] != null && level.ResultSet.Tables[0].Rows.Count > 0)
                {
                 
                    for (int i = 0; i < level.ResultSet.Tables[0].Rows.Count; i++)
                    {
                        if (level_id == Convert.ToInt32(level.ResultSet.Tables[0].Rows[i]["Level_ID"]))
                        {
                            if ( i+1 < level.ResultSet.Tables[0].Rows.Count)
                            {
                                nextlevel_id = Convert.ToInt32(level.ResultSet.Tables[0].Rows[i + 1]["Level_ID"]);
                                try
                                {
                                    LoadData(Convert.ToInt32(ViewState["roleid"]), nextlevel_id);
                                }
                                catch (Exception exp)
                                {
                                    throw exp;
                                }
                                ViewState["levelid"] = nextlevel_id;
                            }
                        }
                    }
                }

            }
        }
        #endregion

        protected void ddlGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGame.SelectedIndex > 0)
            {
                LoadStatus_YOU_ARE_IN();
                LoadStatus_HEADING_TO();
            }
        }

        protected void ImgCancel_Click(object sender, ImageClickEventArgs e)
        {
            lblmessage.Visible = false;
            pnlAddGoal.Visible = false;
            
            ddlKPI.SelectedValue = "0";
            txtTargetValue.Text = "";
            txtPoints.Text = "";
            btnUpdate.Text = "Update";
        }


    }
}