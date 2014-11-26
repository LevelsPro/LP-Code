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
using BusinessLogic.Delete;
using LevelsPro.App_Code;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;

namespace LevelsPro.AdminPanel
{
    public partial class ContestEdit : AuthorizedPage
    {
        int CountTextBoxes = 0;
        private TextBox[] dynamicTextBoxes;

        protected override void OnInit(EventArgs e)
        {
            dynamicTextBoxes = (TextBox[])Session["dynamicTextBoxes"];

            if ((dynamicTextBoxes != null) && (dynamicTextBoxes.Length > 0)) 
            {
                for (var i = 0; i < dynamicTextBoxes.Length; i++)
                {
                    var counts = Convert.ToInt32(Session["NumberPositions"]) + i; 
                    CreateControls(0, 0, "", counts);
                }                
            }

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            if (!IsPostBack)
            {
                LoadKPI();
                LoadStore();
                LoadRoles();

                if (Request.QueryString["contestid"] != null && Request.QueryString["contestid"].ToString() != "")
                {
                    ViewState["contestid"] = Request.QueryString["contestid"];

                    LoadData(Convert.ToInt32(ViewState["contestid"]));
                }
                else
                {
                    this.Title = Resources.TestSiteResources.CreateAContest;
                    lblHeading.Text = Resources.TestSiteResources.CreateAContest;
                    LoadAwardDropDown(ddl1Place);
                    LoadAwardDropDown(ddl2Place);
                    LoadAwardDropDown(ddl3Place);
                    btnLeaderBoard.Enabled = false;
                }
            }
            else 
            {
                dynamicTextBoxes = (TextBox[])Session["dynamicTextBoxes"];
            }
        }

        #region show contest for edit
        private void LoadData(int ContestID)
        {            
            ContestViewBLL contestview = new ContestViewBLL();
            
            Contest _contest = new Contest();
            _contest.Where = " WHERE a.ContestID = " + ContestID.ToString();
            contestview.Contest = _contest;
            try
            {
                contestview.Invoke();
            }
            catch (Exception ex)
            {
            }

            if (contestview.ResultSet != null && contestview.ResultSet.Tables.Count > 0 && contestview.ResultSet.Tables[0] != null && contestview.ResultSet.Tables[0].Rows.Count > 0)
            {
                txtContestName.Text = contestview.ResultSet.Tables[0].Rows[0]["ContestName"].ToString();
                txtFromDate.Text = Convert.ToDateTime(contestview.ResultSet.Tables[0].Rows[0]["FromDate"].ToString()).ToString("MM/dd/yyyy");
                txtToDate.Text = Convert.ToDateTime(contestview.ResultSet.Tables[0].Rows[0]["ToDate"].ToString()).ToString("MM/dd/yyyy");                
                ddlKPI_ID.SelectedValue = contestview.ResultSet.Tables[0].Rows[0]["KPI_ID"].ToString();
                ddlStore_ID.SelectedValue = contestview.ResultSet.Tables[0].Rows[0]["Site_ID"].ToString();
                ddlRoles_ID.SelectedValue = contestview.ResultSet.Tables[0].Rows[0]["Role_ID"].ToString();

                LoadAwards(Convert.ToInt32(ViewState["contestid"]));

                btnAddContest.Text = Resources.TestSiteResources.Update;
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

            dv.RowFilter = "TypeContest='Contest'";

            ddlKPI_ID.DataSource = dv.ToTable();
            ddlKPI_ID.DataBind();

            ListItem li = new ListItem("KPI Value", "0");
            ddlKPI_ID.Items.Insert(0, li);
        }

        protected void LoadStore()
        {
            Site_DropDownBLL site = new Site_DropDownBLL();
            try
            {
                site.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlStore_ID.DataTextField = "site_name";
            ddlStore_ID.DataValueField = "site_ID";

            DataView dv = site.ResultSet.Tables[0].DefaultView;

            ddlStore_ID.DataSource = dv.ToTable();
            ddlStore_ID.DataBind();

            ListItem li = new ListItem("Select Store", "0");
            ddlStore_ID.Items.Insert(0, li);
        }

        protected void LoadRoles()
        {
            RolesViewBLL roles = new RolesViewBLL();
            try
            {
                roles.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlRoles_ID.DataTextField = "Role_name";
            ddlRoles_ID.DataValueField = "Role_ID";

            DataView dv = roles.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1";

            ddlRoles_ID.DataSource = dv.ToTable();
            ddlRoles_ID.DataBind();

            ListItem li = new ListItem("All Roles", "0");
            ddlRoles_ID.Items.Insert(0, li);
        }

        protected void LoadAwardDropDown(DropDownList ddlAward)
        {
            AwardViewBLL awards = new AwardViewBLL();
            try
            {
                awards.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlAward.DataTextField = "Award_Name";
            ddlAward.DataValueField = "Award_ID";            

            DataView dv = awards.ResultSet.Tables[0].DefaultView;

            ddlAward.DataSource = dv.ToTable();
            ddlAward.DataBind();            

            ListItem li = new ListItem("No Award", "0");
            ddlAward.Items.Insert(0, li);            
        }

        protected void LoadAwards(int ContestID)
        {
            ContestPositionViewBLL contestpositions = new ContestPositionViewBLL();
            Contest _contest = new Contest();
            _contest.Where = " WHERE ContestID = " + ContestID.ToString();
            contestpositions.ContestPosition = _contest;
            try
            {
                contestpositions.Invoke();
            }
            catch (Exception ex)
            {
            }
            if (contestpositions.ResultSet != null && contestpositions.ResultSet.Tables.Count > 0 && contestpositions.ResultSet.Tables[0] != null && contestpositions.ResultSet.Tables[0].Rows.Count > 0)
            {
                var awardid = 0;
                var position = 0;
                var value = "";

                for (var i = 0; i < contestpositions.ResultSet.Tables[0].Rows.Count; i++)
                {
                    var pos = Convert.ToInt32(contestpositions.ResultSet.Tables[0].Rows[i]["Position"].ToString());
                    switch (pos)
                    {
                        case 0:
                            txt1Place.Text = contestpositions.ResultSet.Tables[0].Rows[i]["Points"].ToString();
                            LoadAwardDropDown(ddl1Place);
                            ddl1Place.SelectedValue = contestpositions.ResultSet.Tables[0].Rows[i]["Award_ID"].ToString();
                            hf1Place.Value = pos.ToString();
                            break;
                        case 1:
                            txt2Place.Text = contestpositions.ResultSet.Tables[0].Rows[i]["Points"].ToString();
                            LoadAwardDropDown(ddl2Place);
                            ddl2Place.SelectedValue = contestpositions.ResultSet.Tables[0].Rows[i]["Award_ID"].ToString();
                            hf2Place.Value = pos.ToString();
                            break;
                        case 2:
                            txt3Place.Text = contestpositions.ResultSet.Tables[0].Rows[i]["Points"].ToString();
                            LoadAwardDropDown(ddl3Place);
                            ddl3Place.SelectedValue = contestpositions.ResultSet.Tables[0].Rows[i]["Award_ID"].ToString();
                            hf3Place.Value = pos.ToString();
                            break;
                        default:
                            CountTextBoxes++; 
                            break;
                    }
                    
                }

                if (contestpositions.ResultSet.Tables[0].Rows.Count > 3) 
                {
                    dynamicTextBoxes = new TextBox[CountTextBoxes];

                    //CountTextBoxes = 0;

                    for (var i = 3; i < contestpositions.ResultSet.Tables[0].Rows.Count; i++)
                    {
                        awardid = Convert.ToInt32(contestpositions.ResultSet.Tables[0].Rows[i]["Award_ID"].ToString());
                        position = Convert.ToInt32(contestpositions.ResultSet.Tables[0].Rows[i]["Position"].ToString());
                        value = contestpositions.ResultSet.Tables[0].Rows[i]["Points"].ToString();

                        CountTextBoxes++;

                        CreateControls(awardid, position, value, (contestpositions.ResultSet.Tables[0].Rows.Count - 3));
                    }
                    Session["dynamicTextBoxes"] = dynamicTextBoxes;
                }                
            }
        }        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        
        #region add and update contest
        protected void btnAddContest_Click(object sender, EventArgs e)
        {            
            if (txtContestName.Text.Equals(""))
            {
                return;
            }
            else
            {

                Contest contest = new Contest();

                contest.ContestName = txtContestName.Text.Trim();
                if (txtFromDate.Text.Trim() != "")
                {
                    contest.FromDate = txtFromDate.Text.Trim();
                }

                if (txtToDate.Text.Trim() != "")
                {
                    contest.ToDate = txtToDate.Text.Trim();
                }

                if (ddlKPI_ID.SelectedIndex > 0)
                {
                    contest.KPIID = Convert.ToInt32(ddlKPI_ID.SelectedValue);
                }

                if (ddlStore_ID.SelectedIndex > 0)
                {
                    contest.SiteID = Convert.ToInt32(ddlStore_ID.SelectedValue);
                }

                contest.RoleID = Convert.ToInt32(ddlRoles_ID.SelectedValue);

                MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                scon.Open();
                MySqlTransaction sqlTrans = scon.BeginTransaction();
                contest.sqlTransaction = sqlTrans;

                try
                {
                    if (btnAddContest.Text == "Update" || btnAddContest.Text == "mettre à jour" || btnAddContest.Text == "actualizar")
                    {
                        if (ViewState["contestid"] != null && ViewState["contestid"].ToString() != "")
                        {
                            contest.ContestID = Convert.ToInt32(ViewState["contestid"]);
                            lblmessage.Visible = true;

                            ContestUpdateBLL updategame = new ContestUpdateBLL();
                            updategame.Contest = contest;
                            lblmessage.Visible = true;
                            try
                            {
                                updategame.Invoke();
                                //lblmessage.Text = Resources.TestSiteResources.GameName + ' ' + Resources.TestSiteResources.UpdateMessage;
                                //LoadData(Convert.ToInt32(ViewState["contestid"]));

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
                        ContestInsertBLL insertcontest = new ContestInsertBLL();
                        insertcontest.Contest = contest;
                        try
                        {
                            insertcontest.Invoke();
                            //LoadData(Convert.ToInt32(ViewState["contestid"]));
                            //Response.Redirect("ContestManagement.aspx",false);
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
                    ContestPositionDeleteBLL del = new ContestPositionDeleteBLL();
                    ContestPositionInsertBLL qPositions = new ContestPositionInsertBLL();

                    del.ContestPosition = contest;
                    del.Invoke();

                    for (int i = 0; i < 3; i++)
                    {
                        switch (i) {
                            case 0:
                                contest.AwardID = Convert.ToInt32(ddl1Place.SelectedValue);
                                contest.Points = Convert.ToInt32(txt1Place.Text);
                                contest.Position = Convert.ToInt32(hf1Place.Value);
                                qPositions.ContestPosition = contest;
                                qPositions.Invoke();
                                break;
                            case 1:
                                contest.AwardID = Convert.ToInt32(ddl2Place.SelectedValue);
                                contest.Points = Convert.ToInt32(txt2Place.Text);
                                contest.Position = Convert.ToInt32(hf2Place.Value);
                                qPositions.ContestPosition = contest;
                                qPositions.Invoke();
                                break;
                            case 2:
                                contest.AwardID = Convert.ToInt32(ddl3Place.SelectedValue);
                                contest.Points = Convert.ToInt32(txt3Place.Text);
                                contest.Position = Convert.ToInt32(hf3Place.Value);
                                qPositions.ContestPosition = contest;
                                qPositions.Invoke();
                                break;
                        }
                    }
                    sqlTrans.Commit();

                    if (btnAddContest.Text == "Update" || btnAddContest.Text == "mettre à jour" || btnAddContest.Text == "actualizar")
                    {
                        LoadData(Convert.ToInt32(ViewState["contestid"]));
                        lblmessage.Visible = true;
                        lblmessage.Text = "Contest info " + Resources.TestSiteResources.UpdateMessage;
                        Response.Redirect("ContestEdit.aspx?contestid=" + ViewState["contestid"].ToString(), false);

                    }
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "Contest info " + ' ' + Resources.TestSiteResources.SavedMessage;
                        Response.Redirect("ContestManagement.aspx", false);
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
        #endregion        

        #region add award
        protected void btnAddPlace_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            HtmlGenericControl flwrapper = (HtmlGenericControl)content.FindControl("flWrapper");

            int count = ControlsCount;

            var Controls = 0;
            foreach (Control c in flwrapper.Controls)
            {
                if (c is TextBox)
                    Controls++;
            }            

            Session["NumberPositions"] = Controls;

            if (Controls == 3)
            {
                dynamicTextBoxes = new TextBox[1];
            }
            else
            {
                dynamicTextBoxes = new TextBox[Controls - 2];
            }

            CreateControls(0, 0, "", Convert.ToInt32(Session["NumberPositions"]));

            Session["dynamicTextBoxes"] = dynamicTextBoxes;
        }
        protected void btnRemovePlace_Click(object sender, EventArgs e)
        {
            
        }
        #endregion        

        protected void btnCancel_Click(object sender, EventArgs e)
        {            
            Response.Redirect("ContestManagement.aspx");
        }

        protected void ddlKPI_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAwardDropDown(ddl1Place);
            LoadAwardDropDown(ddl2Place);
            LoadAwardDropDown(ddl3Place);
        }

        private void CreateControls(int awardid, int position, string value, int counter)
        {
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            HtmlGenericControl flwrapper = (HtmlGenericControl)content.FindControl("flWrapper");
            
            #region TextBox
            //div strip
            HtmlGenericControl _strip = new HtmlGenericControl();
            _strip.Attributes.Add("class", "strip");
            _strip.TagName = "div";

            HtmlGenericControl _editfull = new HtmlGenericControl();
            _editfull.Attributes.Add("class", "edit-full tl");

            _strip.Controls.Add(_editfull);

            Label lblPlace = new Label();
            lblPlace.ID = "lbl" + (counter + 1) + "Place";
            lblPlace.CssClass = "edit-left20";
            lblPlace.Text = ToOrdinal(counter+1) + " " + Resources.TestSiteResources.Place;

            _editfull.Controls.Add(lblPlace);

            TextBox txtPlace = new TextBox();
            txtPlace.ID = "txt" + (counter + 1) + "Place";
            txtPlace.CssClass = "txtPoints edit-left20 qq-admin";
            txtPlace.MaxLength = 5;
            txtPlace.ValidationGroup = "Insertion";
            txtPlace.AutoCompleteType = AutoCompleteType.Disabled;
            txtPlace.Attributes.Add("onfocus", "disableautocompletion(this.id);");
            if (position != 0)
                txtPlace.Text = position.ToString();
            //dynamicTextBoxes[counter - counter] = txtPlace;

            _editfull.Controls.Add(txtPlace);

            Label lblPoints = new Label();
            lblPoints.ID = "lbl" + (counter + 1) + "Poinst";
            lblPoints.CssClass = "lblPoints edit-left20";
            lblPoints.Text = Resources.TestSiteResources.Points;

            _editfull.Controls.Add(lblPoints);

            RequiredFieldValidator rfvPlace = new RequiredFieldValidator();
            rfvPlace.ID = "rfv" + (counter + 1) + "Place";
            rfvPlace.ErrorMessage = "Provide " + (counter + 1) + "Place";
            rfvPlace.ControlToValidate = "txt" + (counter + 1) + "Place";
            rfvPlace.Display = ValidatorDisplay.Dynamic;
            rfvPlace.SetFocusOnError = true;
            rfvPlace.ValidationGroup = "Insertion";
            rfvPlace.Text = " * ";

            _editfull.Controls.Add(rfvPlace);

            DropDownList ddlPlace = new DropDownList();
            ddlPlace.ID = "ddl" + (counter + 1) + "Place";
            ddlPlace.CssClass = "ddlPoints edit-left20 combo-fw";
            ddlPlace.ValidationGroup = "Insertion";            
            LoadAwardDropDown(ddlPlace);
            if (awardid != 0)
                ddl3Place.SelectedValue = awardid.ToString();

            _editfull.Controls.Add(ddlPlace);

            HiddenField hfPlace = new HiddenField();
            hfPlace.ID = "hf" + (counter + 1) + "Place";
            if (position != 0)
            {
                hfPlace.Value = position.ToString();
            }
            else 
            {
                hfPlace.Value = (counter + 1).ToString();
            }            

            _editfull.Controls.Add(hfPlace);

            HtmlGenericControl _clear = new HtmlGenericControl();
            _clear.Attributes.Add("class", "clear");
            _clear.TagName = "div";

            _strip.Controls.Add(_clear);
            
            flwrapper.Controls.AddAt(flwrapper.Controls.Count, _strip);
            
            //controls = controls + _strip.Controls.Count + 1;
            #endregion

        }

        public string ToOrdinal(int number)
        {
            if (number < 0) return number.ToString();
            long rem = number % 100;
            if (rem >= 11 && rem <= 13) return number.ToString() + "th";
            switch (number % 10)
            {
                case 1:
                    return number.ToString() + "st";
                case 2:
                    return number.ToString() + "nd";
                case 3:
                    return number.ToString() + "rd";
                default:
                    return number.ToString() + "th";
            }
        }

        private int ControlsCount
        {
            get
            {
                object o = ViewState["ControlCount"];
                if (o != null)
                    return (int)o;

                return 0;
            }
            set
            {
                ViewState["ControlCount"] = value;
            }
        }

        protected void btnLeaderBoard_Click(object sender, EventArgs e)
        {
            if (ViewState["contestid"] != null) 
            {
                int ContestID = Convert.ToInt32(ViewState["contestid"].ToString());
                Session["ContestID"] = ContestID;
                Response.Redirect("ContestDetails.aspx");
            }            
        }
    }    
}