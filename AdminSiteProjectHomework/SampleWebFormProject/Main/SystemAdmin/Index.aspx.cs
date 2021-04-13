using CoreProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main.SystemAdmin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            //修改點:!LoginHelper-->LoginHelper;  傳入值位置互換;增加登入失敗時的通知
            if (LoginHelper.TryLogin(this.txtAccount.Text, this.txtPWD.Text))
            {
                Response.Redirect("~/SystemAdmin/MainPage.aspx");
            }
            else
            {
                lbmsgNot.Text = "登入失敗";
            }
        }
    }
}