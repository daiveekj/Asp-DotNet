using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.code;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        DBCalling db = new DBCalling();
        Parameters pR = new Parameters();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CountryNameDropDown();
                getMember();
            }
        }

        void CountryNameDropDown()
        {
            try
            {
                DataTable dt = db.GetCountryData("GetCountries", true);
                ddlCountry.DataSource = dt;
                ddlCountry.DataTextField = "countryname";
                ddlCountry.DataValueField = "countryid";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--select country--", "0"));
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CountryId = Convert.ToInt32(ddlCountry.SelectedIndex);

            DataTable dt = db.GetDataState("GetStates", CountryId);
            ddlStates.DataSource = dt;
            ddlStates.DataTextField = "statename";
            ddlStates.DataValueField = "stateid";
            ddlStates.DataBind();
            ddlStates.Items.Insert(0, new ListItem("--select State--", "0"));
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            pR.Name = txtName.Text;
            pR.Number = txtNumber.Text;
            pR.Email = txtEmail.Text;
            pR.AadhaarNo = txtAadhaar.Text;
            pR.DOJ = Convert.ToDateTime(txtDate.Text);
            pR.Country = ddlCountry.Text;
            pR.States = ddlStates.Text;
            pR.Floor = ddlFloor.Text;
            pR.Sharing = ddlSharing.Text;
            pR.Price = Convert.ToInt32(txtPrice.Text);

            if (btnsubmit.Text == "Submit")
            {
                pR.MemberId = 0;
                db.AddMemberDetails(pR);
            }
            else
            {
                pR.MemberId = Convert.ToInt32(ViewState["EmloyeeId"]);
                db.UpdateMemberDetails(pR);
            }
            PanelGrid.Visible = true;
            PanelRegister.Visible = false;
            getMember();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAadhaar.Text = string.Empty;
            txtDate.Text = string.Empty;
            ddlCountry.Text = "0";
            ddlStates.Text = "0";
            txtPrice.Text = string.Empty;
        }

        void FnBindGridviewColumns(DataTable dt)
        {
            try
            {
                int columnsCount = dt.Columns.Count;
                for (int i = 0; i < columnsCount; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.DataField = dt.Columns[i].ColumnName;
                    boundField.HeaderText = dt.Columns[i].ColumnName;
                    gvMember.Columns.Add(boundField);
                }
                ButtonField buttonField = new ButtonField();

                buttonField.ButtonType = ButtonType.Image;
                //buttonField.Text = "Edit";
                //buttonField.ControlStyle.BackColor = Color.LightGray;
                buttonField.ImageUrl = "~/assets/icons8-edit-35.png";
                buttonField.ControlStyle.Height = 40;
                buttonField.ControlStyle.Width = 40;
                buttonField.CommandName = "upd";
                gvMember.Columns.Add(buttonField);

                buttonField = new ButtonField();
                buttonField.ButtonType = ButtonType.Image;
               // buttonField.Text = "Delete";
                buttonField.ImageUrl = "~/assets/icons8-delete-35.png";
                buttonField.ControlStyle.Width = 40;
                buttonField.ControlStyle.Height = 40;
                //buttonField.ControlStyle.BackColor = Color.Red;
                buttonField.CommandName = "del";

                gvMember.Columns.Add(buttonField);


            }
            catch (Exception ex)
            { }
        }

        void getMember()
        {

            dt = db.GetData("GetAllDetails");
            if (dt != null && dt.Rows.Count > 0)
            {
                if (gvMember.Columns.Count == 0)
                {
                    FnBindGridviewColumns(dt);
                }
                gvMember.DataSource = dt;
                gvMember.DataBind();
                ViewState["dt1"] = dt;

            }
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {

            PanelGrid.Visible = false;
            PanelRegister.Visible = true;
            ClearContent();

        }

        void ClearContent()
        {
            txtName.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAadhaar.Text = string.Empty;
            txtDate.Text = string.Empty;
            CountryNameDropDown();
            ddlCountry.SelectedValue = "0";
            txtPrice.Text = string.Empty;
            DataTable dt = db.GetDataState("GetStates", Convert.ToInt32(ddlCountry.SelectedValue));
            ddlStates.DataSource = dt;
            ddlStates.DataTextField = "statename";
            ddlStates.DataValueField = "stateid";
            ddlStates.DataBind();
            ddlStates.SelectedValue = "0";
        }


        protected void gvMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "upd")
                {
                    PanelRegister.Visible = true;
                    PanelGrid.Visible = false;
                    btnsubmit.Text = "Update";
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    ViewState["EmloyeeId"] = gvMember.Rows[rowIndex].Cells[0].Text.ToString();
                    txtName.Text = gvMember.Rows[rowIndex].Cells[1].Text.ToString();
                    txtNumber.Text = gvMember.Rows[rowIndex].Cells[2].Text.ToString();
                    txtEmail.Text = gvMember.Rows[rowIndex].Cells[3].Text.ToString();
                    txtAadhaar.Text = gvMember.Rows[rowIndex].Cells[4].Text.ToString();
                    txtDate.Text = gvMember.Rows[rowIndex].Cells[5].Text.ToString();
                    ddlCountry.Text = gvMember.Rows[rowIndex].Cells[6].ToString();
                    ddlStates.Text = gvMember.Rows[rowIndex].Cells[7].ToString();
                    ddlFloor.Text = gvMember.Rows[rowIndex].Cells[8].Text.ToString();
                    ddlSharing.Text = gvMember.Rows[rowIndex].Cells[9].Text.ToString();
                    txtPrice.Text = gvMember.Rows[rowIndex].Cells[10].Text.ToString();
                }
                else if (e.CommandName == "del")
                {
                    ViewState["DEL"] = int.Parse(e.CommandArgument.ToString());
                    popupDelete.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvMember_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            
            
                StringBuilder csvContent = new StringBuilder();

                
                foreach (TableCell headerCell in gvMember.HeaderRow.Cells)
                {
                    csvContent.Append(headerCell.Text + ",");
                }
                csvContent.AppendLine();

                
                foreach (GridViewRow row in gvMember.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        csvContent.Append(cell.Text + ",");
                    }
                    csvContent.AppendLine();
                }

                
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridViewData.csv");
                Response.Charset = "";
                Response.ContentType = "text/csv";
                Response.Output.Write(csvContent.ToString());
                Response.Flush();
                Response.End();
            }
        



        protected void yespopup_Click1(object sender, EventArgs e)
        {
            int RowIndex = Convert.ToInt32(ViewState["DEL"]);
            int i = Convert.ToInt32(gvMember.Rows[RowIndex].Cells[0].Text);
            db.DeleteMember("DeleteMember", i);
            getMember();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
             Session["LoggedInUser"] = null;

            // Redirect to login page or any other page
             Response.Redirect("Login.aspx");
          

        }
    }
}