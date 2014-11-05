using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Insert;
using System.Drawing;
using BusinessLogic.Select;
using System.Data;
using AjaxControlToolkit;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic.Update;
using MySql.Data.MySqlClient;
using BusinessLogic;
namespace LevelsPro.UserControls
{
    public partial class uc_SecurityQuestions : System.Web.UI.UserControl
    {
        static string answer1 = "";
        static string answer2 = "";
        static  string answer3 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void LoadQuestions()
        {
            SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
            try
            {
                securityquestionsbll.Invoke();
            }
            catch (Exception)
            {
            } 
                ddlQuestion1.DataTextField = "Question_Text";
                ddlQuestion1.DataValueField = "Question_ID";
                ddlQuestion1.DataSource = securityquestionsbll.ResultSet;//dv.ToTable();
                ddlQuestion1.DataBind();


                ddlQuestion2.DataTextField = "Question_Text";
                ddlQuestion2.DataValueField = "Question_ID";


                ddlQuestion2.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                ddlQuestion2.DataBind();


                ddlQuestion3.DataTextField = "Question_Text";
                ddlQuestion3.DataValueField = "Question_ID";

                ddlQuestion3.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                ddlQuestion3.DataBind();

                this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                this.ddlQuestion1.SelectedIndex = 0;
                this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                this.ddlQuestion2.SelectedIndex = 0;
                this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                this.ddlQuestion3.SelectedIndex = 0;

            ////////////////////////////////////if Forget Password////////////////////////////
                if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
                {
                    CheckSecurityAnswersBLL checkuser = new CheckSecurityAnswersBLL();
                    Common.User user = new Common.User();

                    user.UserID = Convert.ToInt32(Session["useridForgot"]);

                    checkuser.User = user;
                   
                    try
                    {
                        checkuser.Invoke();

                    }
                    catch (Exception)
                    {

                    }
                    if (checkuser.ResultSet != null && checkuser.ResultSet.Tables.Count > 0 && checkuser.ResultSet.Tables[0] != null && checkuser.ResultSet.Tables[0].Rows.Count > 0)
                    {
                        Label1.Text = "Answer Security Questions";
                        Label2.Text = "Answer Selected Security Questions to Set Password";
                        ddlQuestion1.SelectedValue = checkuser.ResultSet.Tables[0].Rows[0]["Question_ID"].ToString();
                        ddlQuestion1.Enabled = false;
                        ddlQuestion1.Visible = true;
                        ddlQuestion2.SelectedValue = checkuser.ResultSet.Tables[0].Rows[1]["Question_ID"].ToString();
                        ddlQuestion2.Enabled = false;
                        ddlQuestion2.Visible = true;
                        ddlQuestion3.SelectedValue = checkuser.ResultSet.Tables[0].Rows[2]["Question_ID"].ToString();
                        ddlQuestion3.Visible = true;
                        ddlQuestion3.Enabled = false;

                        answer1 = checkuser.ResultSet.Tables[0].Rows[0]["Answer"].ToString(); ;
                        answer2 = checkuser.ResultSet.Tables[0].Rows[1]["Answer"].ToString(); ;
                        answer3 = checkuser.ResultSet.Tables[0].Rows[2]["Answer"].ToString(); ;
                    }

                    //Session["useridForgot"] = null;
                }
            //////////////////////////////////////////////////////////////////////////////
 
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
            if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
            {
               // DataSet dsCheck = new DataSet();

              //  dsCheck = LoadQuestionAnswers();


                //if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
               // {
                bool PasswordVerification1 = PasswordEncrypt.ValidatePassword(txtAnswer1.Text, answer1);
                bool PasswordVerification2 = PasswordEncrypt.ValidatePassword(txtAnswer2.Text, answer2);
                bool PasswordVerification3 = PasswordEncrypt.ValidatePassword(txtAnswer3.Text, answer3);

                    //if ((answer1 == txtAnswer1.Text) && (answer2 == txtAnswer2.Text) && (answer3 == txtAnswer3.Text))
                if ((PasswordVerification1 == true) && (PasswordVerification2 == true) && (PasswordVerification3 == true))
                    {
                        lblMeassage.Visible = false;
                        //if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
                        //{
                            //ModalPopupExtender mpe = this.Parent.FindControl("mpeAnswers") as ModalPopupExtender;
                            mpe.Hide();

                            //uc_SetPassword chk = this.Parent.FindControl("ucSetNewPassword") as uc_SetPassword;
                           // chk.LoadData(Convert.ToInt32(Session["useridForgot"]));
                            ModalPopupExtender mpeSetNewPass = this.Parent.FindControl("mpeSetNewPassword") as ModalPopupExtender;
                            mpeSetNewPass.Show();
                            answer1 = "";
                            answer2 = "";
                            answer3 = "";
                        //}
                    }
                    else
                    {
                        lblMeassage.Visible = true;
                        lblMeassage.ForeColor = Color.Red;
                        lblMeassage.Text = "Answers are not matched.";
                        //ModalPopupExtender mpe = this.Parent.FindControl("mpeAnswers") as ModalPopupExtender;
                        
                        txtAnswer1.Text = "";
                        txtAnswer2.Text = "";
                        txtAnswer3.Text = "";
                        mpe.Show();

                        //DataSet dsQuestions = new DataSet();
                        //dsQuestions = LoadQuestionAnswers();

                        //if (dsQuestions != null && dsQuestions.Tables.Count > 0 && dsQuestions.Tables[0] != null && dsQuestions.Tables[0].Rows.Count > 0)
                        //{
                        //    ddlQuestion1.SelectedValue = dsQuestions.Tables[0].Rows[0]["Question_ID"].ToString();
                        //    ddlQuestion1.Enabled = false;
                        //    ddlQuestion1.Visible = true;
                        //    ddlQuestion2.SelectedValue = dsQuestions.Tables[0].Rows[1]["Question_ID"].ToString();
                        //    ddlQuestion2.Enabled = false;
                        //    ddlQuestion2.Visible = true;
                        //    ddlQuestion3.SelectedValue = dsQuestions.Tables[0].Rows[2]["Question_ID"].ToString();
                        //    ddlQuestion3.Visible = true;
                        //    ddlQuestion3.Enabled = false;
                        //}
                        // divChangePwd.Visible = false;
                    }
               // }
            }
            else
            {

                //ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
                if (ddlQuestion1.SelectedValue == ddlQuestion2.SelectedValue || ddlQuestion2.SelectedValue == ddlQuestion3.SelectedValue || ddlQuestion3.SelectedValue == ddlQuestion1.SelectedValue || ddlQuestion1.SelectedIndex == 0 || ddlQuestion2.SelectedIndex == 0 || ddlQuestion3.SelectedIndex == 0)
                {
                    lblMeassage.Visible = true;
                    lblMeassage.Text = "select different questions.";
                    lblMeassage.ForeColor = Color.Red;
                    mpe.Show();
                    return;
                }
                else
                {
                    lblMeassage.Visible = false;
                }

                if (Session["userid"] != null)
                {
                    MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                    scon.Open();
                    MySqlTransaction sqlTrans = scon.BeginTransaction();
                    try
                    {
                        SecurityAnswerInsertBLL securityanswers = new SecurityAnswerInsertBLL();
                        UpdatePasswordBLL changepass = new UpdatePasswordBLL();
                        Common.User user = new Common.User();

                        user.UserPassword = Session["password"].ToString();
                        user.UserID = int.Parse(Session["userid"].ToString());
                        user.sqlTransaction = sqlTrans;
                        changepass.User = user;
                        changepass.Invoke();

                        ////////////////////Insert Security Questions////////////

                        user.Securitytype = 2;
                        user.QuestionID = Convert.ToInt32(ddlQuestion1.SelectedValue);
                        user.Answer = PasswordEncrypt.CreateHash(txtAnswer1.Text.Trim());
                        securityanswers.User = user;
                        securityanswers.Invoke();

                        user.QuestionID = Convert.ToInt32(ddlQuestion2.SelectedValue);
                        user.Answer = PasswordEncrypt.CreateHash(txtAnswer2.Text.Trim());
                        securityanswers.User = user;
                        securityanswers.Invoke();

                        user.QuestionID = Convert.ToInt32(ddlQuestion3.SelectedValue);
                        user.Answer = PasswordEncrypt.CreateHash(txtAnswer3.Text.Trim());
                        securityanswers.User = user;
                        securityanswers.Invoke();
                        /////////////////////////////////////////////////////////      
                        sqlTrans.Commit();
                    }
                    catch (Exception)
                    {
                        sqlTrans.Rollback();
                        // lblMeassage.Visible = true;
                        //lblMeassage.Text = "Cannot add information.";

                    }
                    finally
                    {
                        sqlTrans.Dispose();
                        scon.Close();
                    }
                }

                btnCancel_Click(null, null);
            }
        }     

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            //ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
            //mpe.Hide();
            Response.Redirect("~/Index.aspx");            
        }

        protected void ddlQuestion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuestion1.SelectedIndex > 0)
            {
                Session["Q1"] = ddlQuestion1.SelectedValue;

                SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
                try
                {
                    securityquestionsbll.Invoke();
                }
                catch (Exception)
                {
                }


                if (Convert.ToInt32(Session["Q2"]) > 0 && Convert.ToInt32(Session["Q3"]) > 0)
                {
                  //  int idcheck = Convert.ToInt32(ddlQuestion1.SelectedValue);

                    ddlQuestion2.DataTextField = "Question_Text";
                    ddlQuestion2.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals("") && Session["Q3"] != null && !Session["Q3"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"]) + "AND Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    }
                        ddlQuestion2.DataSource = dv2.ToTable();
                        ddlQuestion2.DataBind();
                        this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                        this.ddlQuestion2.SelectedIndex = 0;
                        ddlQuestion2.SelectedValue = Session["Q2"].ToString();
                    

                }
                else if (Convert.ToInt32(Session["Q2"]) > 0)
                {
                    ddlQuestion2.DataTextField = "Question_Text";
                    ddlQuestion2.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"]);
                    }
                        ddlQuestion2.DataSource = dv2.ToTable();
                        ddlQuestion2.DataBind();
                        this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                        this.ddlQuestion2.SelectedIndex = 0;
                        ddlQuestion2.SelectedValue = Session["Q2"].ToString();
                    
                }
                else
                {

                    ddlQuestion2.DataTextField = "Question_Text";
                    ddlQuestion2.DataValueField = "Question_ID";

                    DataView dv = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals(""))
                    {
                        dv.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"]);
                    }
                    ddlQuestion2.DataSource = dv.ToTable();// dv.ToTable();
                    // ddlQuestion2.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                    ddlQuestion2.DataBind();

                    this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion2.SelectedIndex = 0;

                }

                if (Convert.ToInt32(Session["Q3"]) > 0 && Convert.ToInt32(Session["Q2"]) > 0)
                {

                    //int idcheck = Convert.ToInt32(ddlQuestion3.SelectedValue);

                    ddlQuestion3.DataTextField = "Question_Text";
                    ddlQuestion3.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals("") && Session["Q2"] != null && !Session["Q2"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"]) + "AND Question_ID <>" + Convert.ToInt32(Session["Q2"]);
                    }
                        ddlQuestion3.DataSource = dv2.ToTable();
                        ddlQuestion3.DataBind();
                        this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                        this.ddlQuestion3.SelectedIndex = 0;
                        ddlQuestion3.SelectedValue = Session["Q3"].ToString();
                    
                }
                else if (Convert.ToInt32(Session["Q3"]) > 0)
                {
                    ddlQuestion3.DataTextField = "Question_Text";
                    ddlQuestion3.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"]);
                    }
                    ddlQuestion3.DataSource = dv2.ToTable();
                    ddlQuestion3.DataBind();
                    this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion3.SelectedIndex = 0;
                    ddlQuestion3.SelectedValue = Session["Q3"].ToString();
                }
                else
                {
                    ddlQuestion3.DataTextField = "Question_Text";
                    ddlQuestion3.DataValueField = "Question_ID";


                    DataView dv1 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals(""))
                    {
                        dv1.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"].ToString());
                    }
                    ddlQuestion3.DataSource = dv1.ToTable();
                    //ddlQuestion3.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                    ddlQuestion3.DataBind();
                    this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion3.SelectedIndex = 0;
                }

            }

            else
            {

                SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
                try
                {
                    securityquestionsbll.Invoke();
                }
                catch (Exception)
                {
                }

                ddlQuestion1.DataTextField = "Question_Text";
                ddlQuestion1.DataValueField = "Question_ID";


                DataView dv1 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                //dv1.RowFilter = "Question_ID <>" + Convert.ToInt32(ddlQuestion3.SelectedValue) + " AND Question_ID <>" + Convert.ToInt32(ddlQuestion1.SelectedValue);
                ddlQuestion1.DataSource = dv1.ToTable();
                //ddlQuestion3.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                ddlQuestion1.DataBind();
                this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                this.ddlQuestion1.SelectedIndex = 0;
            }

            ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
            mpe.Show();
        }

        protected void ddlQuestion2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlQuestion2.SelectedIndex > 0 && Convert.ToInt32(Session["Q1"]) > 0)
            {
                Session["Q2"] = ddlQuestion2.SelectedValue;
                SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
                try
                {
                    securityquestionsbll.Invoke();
                }
                catch (Exception)
                {
                }


                if (Convert.ToInt32(Session["Q1"]) > 0 && Convert.ToInt32(Session["Q3"]) > 0)
                {
                   //int idcheck = Convert.ToInt32(ddlQuestion1.SelectedValue);

                    ddlQuestion1.DataTextField = "Question_Text";
                    ddlQuestion1.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q2"] != null && !Session["Q2"].Equals("") && Session["Q3"] != null && !Session["Q3"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q2"]) + "AND Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    }
                    ddlQuestion1.DataSource = dv2.ToTable();
                    ddlQuestion1.DataBind();
                    this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion1.SelectedIndex = 0;

                    ddlQuestion1.SelectedValue = Session["Q1"].ToString();

                    //ddlQuestion1.DataTextField = "Question_Text";
                    //ddlQuestion1.DataValueField = "Question_ID";

                    //DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    //dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(ddlQuestion2.SelectedValue);

                    //ddlQuestion1.DataSource = dv2.ToTable();
                    //ddlQuestion1.DataBind();
                    //ddlQuestion1.SelectedValue = idcheck.ToString();

                }
                else if (Convert.ToInt32(Session["Q1"]) > 0)
                {
                    ddlQuestion1.DataTextField = "Question_Text";
                    ddlQuestion1.DataValueField = "Question_ID";

                    DataView dv = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q2"] != null && !Session["Q2"].Equals(""))
                    {
                        dv.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q2"]);
                    }
                    ddlQuestion1.DataSource = dv.ToTable();
                    ddlQuestion1.DataBind();
                    this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion1.SelectedIndex = 0;
                    ddlQuestion1.SelectedValue = Session["Q1"].ToString();


                }
                else
                {

                    ddlQuestion1.DataTextField = "Question_Text";
                    ddlQuestion1.DataValueField = "Question_ID";

                    DataView dv = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    dv.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q2"].ToString());
                    ddlQuestion1.DataSource = dv.ToTable();// dv.ToTable();
                    // ddlQuestion2.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                    ddlQuestion1.DataBind();

                    this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion1.SelectedIndex = 0;

                }

                if (Convert.ToInt32(Session["Q3"]) > 0 && Convert.ToInt32(Session["Q1"]) > 0)
                {

                    //int idcheck = Convert.ToInt32(ddlQuestion3.SelectedValue);
                    ddlQuestion3.DataTextField = "Question_Text";
                    ddlQuestion3.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals("") && Session["Q2"] != null && !Session["Q2"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"]) + "AND Question_ID <>" + Convert.ToInt32(Session["Q2"]);
                    }
                    ddlQuestion3.DataSource = dv2.ToTable();
                    ddlQuestion3.DataBind();
                    this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion3.SelectedIndex = 0;
                    ddlQuestion3.SelectedValue = Session["Q3"].ToString();


                    //ddlQuestion3.DataTextField = "Question_Text";
                    //ddlQuestion3.DataValueField = "Question_ID";

                    //DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    //dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(ddlQuestion2.SelectedValue) + " AND Question_ID <>" + Convert.ToInt32(ddlQuestion1.SelectedValue);
                    //ddlQuestion3.DataSource = dv2.ToTable();
                    //ddlQuestion3.DataBind();
                    //ddlQuestion3.SelectedValue = idcheck.ToString();
                }
                else if (Convert.ToInt32(Session["Q3"]) > 0)
                {

                    ddlQuestion3.DataTextField = "Question_Text";
                    ddlQuestion3.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals("") && Session["Q2"] != null && !Session["Q2"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q2"]);
                    }
                    ddlQuestion3.DataSource = dv2.ToTable();
                    ddlQuestion3.DataBind();
                    this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion3.SelectedIndex = 0;
                    ddlQuestion3.SelectedValue = Session["Q3"].ToString();


                }
                else
                {
                    ddlQuestion3.DataTextField = "Question_Text";
                    ddlQuestion3.DataValueField = "Question_ID";


                    DataView dv1 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    dv1.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q2"]) + "AND Question_ID <>" + Convert.ToInt32(Session["Q1"]);
                    ddlQuestion3.DataSource = dv1.ToTable();
                    //ddlQuestion3.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                    ddlQuestion3.DataBind();
                    this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion3.SelectedIndex = 0;
                }

            }
            else
            {

                SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
                try
                {
                    securityquestionsbll.Invoke();
                }
                catch (Exception)
                {
                }

                ddlQuestion2.DataTextField = "Question_Text";
                ddlQuestion2.DataValueField = "Question_ID";


                DataView dv1 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                //dv1.RowFilter = "Question_ID <>" + Convert.ToInt32(ddlQuestion3.SelectedValue) + " AND Question_ID <>" + Convert.ToInt32(ddlQuestion1.SelectedValue);
                ddlQuestion2.DataSource = dv1.ToTable();
                //ddlQuestion3.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                ddlQuestion2.DataBind();
                this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                this.ddlQuestion2.SelectedIndex = 0;
            }
            ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
            mpe.Show();

        }

        protected void ddlQuestion3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuestion3.SelectedIndex > 0 && Convert.ToInt32(Session["Q1"]) > 0 && Convert.ToInt32(Session["Q2"]) > 0)
            {
                Session["Q3"] = ddlQuestion3.SelectedValue;
                SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
                try
                {
                    securityquestionsbll.Invoke();
                }
                catch (Exception)
                {
                }

                if (Convert.ToInt32(Session["Q1"]) > 0 && Convert.ToInt32(Session["Q2"]) > 0)
                {
                   // int idcheck = Convert.ToInt32(ddlQuestion1.SelectedValue);

                    ddlQuestion1.DataTextField = "Question_Text";
                    ddlQuestion1.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q2"] != null && !Session["Q2"].Equals("") && Session["Q3"] != null && !Session["Q3"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q2"]) + "AND Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    }
                    ddlQuestion1.DataSource = dv2.ToTable();
                    ddlQuestion1.DataBind();
                    this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion1.SelectedIndex = 0;
                    ddlQuestion1.SelectedValue = Session["Q1"].ToString();


                    //ddlQuestion1.DataTextField = "Question_Text";
                    //ddlQuestion1.DataValueField = "Question_ID";

                    //DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    //dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(ddlQuestion2.SelectedValue) + " AND Question_ID <>" + Convert.ToInt32(ddlQuestion3.SelectedValue);
                    //ddlQuestion1.DataSource = dv2.ToTable();
                    //ddlQuestion1.DataBind();
                    //ddlQuestion1.SelectedValue = idcheck.ToString();

                }
                else if (Convert.ToInt32(Session["Q1"]) > 0)
                {
                    ddlQuestion1.DataTextField = "Question_Text";
                    ddlQuestion1.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if ( Session["Q3"] != null && !Session["Q3"].Equals(""))
                    {
                        dv2.RowFilter ="Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    }
                    ddlQuestion1.DataSource = dv2.ToTable();
                    ddlQuestion1.DataBind();
                    this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion1.SelectedIndex = 0;
                    ddlQuestion1.SelectedValue = Session["Q1"].ToString();

                }
                else
                {

                    ddlQuestion1.DataTextField = "Question_Text";
                    ddlQuestion1.DataValueField = "Question_ID";

                    DataView dv = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    dv.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    ddlQuestion1.DataSource = dv.ToTable();// dv.ToTable();
                    // ddlQuestion2.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                    ddlQuestion1.DataBind();

                    this.ddlQuestion1.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion1.SelectedIndex = 0;

                }

                if (Convert.ToInt32(Session["Q2"]) > 0 && Convert.ToInt32(Session["Q1"]) > 0)
                {

                   // int idcheck = Convert.ToInt32(ddlQuestion2.SelectedValue);


                    ddlQuestion2.DataTextField = "Question_Text";
                    ddlQuestion2.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q1"] != null && !Session["Q1"].Equals("") && Session["Q3"] != null && !Session["Q3"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q1"]) + "AND Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    }
                    ddlQuestion2.DataSource = dv2.ToTable();
                    ddlQuestion2.DataBind();
                    this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion2.SelectedIndex = 0;
                    ddlQuestion2.SelectedValue = Session["Q2"].ToString();


                    //ddlQuestion2.DataTextField = "Question_Text";
                    //ddlQuestion2.DataValueField = "Question_ID";

                    //DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    //dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(ddlQuestion3.SelectedValue) + " AND Question_ID <>" + Convert.ToInt32(ddlQuestion1.SelectedValue);
                    //ddlQuestion2.DataSource = dv2.ToTable();
                    //ddlQuestion2.DataBind();
                    //ddlQuestion2.SelectedValue = idcheck.ToString();
                }
                else if (Convert.ToInt32(Session["Q2"]) > 0)
                {
                    ddlQuestion2.DataTextField = "Question_Text";
                    ddlQuestion2.DataValueField = "Question_ID";

                    DataView dv2 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    if (Session["Q3"] != null && !Session["Q3"].Equals(""))
                    {
                        dv2.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    }
                    ddlQuestion2.DataSource = dv2.ToTable();
                    ddlQuestion2.DataBind();
                    this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion2.SelectedIndex = 0;
                    ddlQuestion2.SelectedValue = Session["Q2"].ToString();
                }
                else
                {
                    ddlQuestion2.DataTextField = "Question_Text";
                    ddlQuestion2.DataValueField = "Question_ID";


                    DataView dv1 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
                    dv1.RowFilter = "Question_ID <>" + Convert.ToInt32(Session["Q3"]);
                    ddlQuestion2.DataSource = dv1.ToTable();
                    //ddlQuestion3.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                    ddlQuestion2.DataBind();
                    this.ddlQuestion2.Items.Insert(0, "--Select Question--");
                    this.ddlQuestion2.SelectedIndex = 0;
                }

            }
            else
            {

                SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
                try
                {
                    securityquestionsbll.Invoke();
                }
                catch (Exception)
                {
                }


                ddlQuestion3.DataTextField = "Question_Text";
                ddlQuestion3.DataValueField = "Question_ID";

                DataView dv1 = securityquestionsbll.ResultSet.Tables[0].DefaultView;
               // dv1.RowFilter = "Question_ID <>" + Convert.ToInt32(ddlQuestion2.SelectedValue) + " AND Question_ID <>" + Convert.ToInt32(ddlQuestion1.SelectedValue);
                ddlQuestion3.DataSource = dv1.ToTable();
                //ddlQuestion3.DataSource = securityquestionsbll.ResultSet;// dv.ToTable();
                ddlQuestion3.DataBind();
                this.ddlQuestion3.Items.Insert(0, "--Select Question--");
                this.ddlQuestion3.SelectedIndex = 0;
            }
            ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
            mpe.Show();

        }       
    }
}