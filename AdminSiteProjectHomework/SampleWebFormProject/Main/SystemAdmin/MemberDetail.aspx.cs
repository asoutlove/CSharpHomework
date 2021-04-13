using CoreProject.Helpers;
using CoreProject.Managers;
using CoreProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Main.SystemAdmin
{
    public partial class MemberDetail : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.IsUpdateMode())
            {
                Guid temp;
                Guid.TryParse(Request.QueryString["ID"], out temp);

                this.txtAccount.Enabled = false;
                this.txtAccount.BackColor = System.Drawing.Color.DarkGray;
                this.LoadAccount(temp);
            }
            else
            {

                this.txtPWD.Enabled = false;
                this.txtPWD.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        private bool IsUpdateMode()
        {
            string qsID = Request.QueryString["ID"];

            Guid temp;
            if (Guid.TryParse(qsID, out temp))
                return true;

            return false;
        }

        private void LoadAccount(Guid id)
        {
            var manager = new AccountManager();
            var model = manager.GetAccountViewModel(id);

            if (model == null)
                //修改點: MemberList.aspx-->MamberList.aspx
                Response.Redirect("~/SystemAdmin/MamberList.aspx");

            this.txtAccount.Text = model.Account;
            this.txtName.Text = model.Name;
            this.txtEmail.Text = model.Email;
            this.txtTitle.Text = model.Title;
            //修改點:加上Phone
            this.txtPhone.Text = model.Phone;
            this.rdblUserLevel.SelectedValue = model.UserLevel.ToString();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            var manager = new AccountManager();


            AccountViewModel model = null;

            if (this.IsUpdateMode())
            {
                string qsID = Request.QueryString["ID"];

                Guid temp;
                if (!Guid.TryParse(qsID, out temp))
                    return;

                //修改點:加上model= 傳入值 
                model = manager.GetAccountViewModel(temp);
            }
            else
            {
                model = new AccountViewModel();
            }


            if (this.IsUpdateMode())
            {
                //修改點:新增提示使用者:未驗證原密碼，不可更新成新密碼
                if (string.IsNullOrEmpty(this.txtPWD.Text) &&
                    !string.IsNullOrEmpty(this.txtNewPWD.Text))
                {
                    this.lblMsg.Text = "未驗證原密碼，不可更新新密碼";
                    return;
                }
                //修改點:使用者只填入原始密碼時的驗證 
                if (!string.IsNullOrEmpty(this.txtPWD.Text) &&
                    string.IsNullOrEmpty(this.txtNewPWD.Text))
                {

                    if (model.PWD != this.txtPWD.Text)
                    {
                        this.lblMsg.Text = "密碼驗證失敗";
                        return;
                    }
                    else
                    {
                        model.PWD = this.txtPWD.Text.Trim();
                    }
                }
                if (!string.IsNullOrEmpty(this.txtPWD.Text) &&
                    !string.IsNullOrEmpty(this.txtNewPWD.Text))
                {
                    //修改點:驗證新密碼不可和原密碼相同
                    if (model.PWD == this.txtNewPWD.Text)
                    {
                        this.lblMsg.Text = "新密碼不可為原始密碼";
                        return;
                    }
                    if (model.PWD == this.txtPWD.Text)
                    {
                        model.PWD = this.txtNewPWD.Text.Trim();
                    }
                    else
                    {
                        //修改點:單純調整提示內容 
                        this.lblMsg.Text = "密碼驗證失敗";
                        return;
                    }
                }
                

            }
            else
            {
                if (string.IsNullOrEmpty(this.txtNewPWD.Text))
                {
                    this.lblMsg.Text = "密碼不可以為空";
                    return;
                }

                if (manager.GetAccount(this.txtAccount.Text.Trim()) != null)
                {
                    this.lblMsg.Text = "帳號已重覆，請選擇其它帳號";
                    return;
                }

                model.Account = this.txtAccount.Text.Trim();
                model.PWD = this.txtNewPWD.Text.Trim();
            }

            model.Title = this.txtTitle.Text.Trim();
            model.Name = this.txtName.Text.Trim();
            model.Email = this.txtEmail.Text.Trim();
            model.Phone = this.txtPhone.Text.Trim();

            int userLever = 0;

            if (int.TryParse(this.rdblUserLevel.SelectedValue, out userLever))
            {
                try
                {
                    var item = (UserLevel)userLever;
                }
                catch
                {
                    throw;
                }

                model.UserLevel = userLever;
            }



            if (this.IsUpdateMode())
                //修改點: CreateAccountViewModel--> UpdateAccountViewModel
                manager.UpdateAccountViewModel(model);
            else
            {
                try
                {
                    manager.CreateAccountViewModel(model);
                }
                catch (Exception ex)
                {
                    this.lblMsg.Text = ex.ToString();
                    return;
                }
            }

            this.lblMsg.Text = "存檔成功";
        }
    }
}