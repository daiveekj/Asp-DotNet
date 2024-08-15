<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMembers.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <main>

        <style>
            body {
                background margin: 0; /* Remove default margin */
                padding: 0; /* Remove default padding */
                background-image: linear-gradient(45deg, #333, #444, #555, #666);
            }



            .modalBackground {
                background-color: rgba(0, 0, 0, 0.8); /* Semi-transparent black background */
                backdrop-filter: blur(8px); /* Adds a blur effect */
                opacity: 1; /* Full opacity */
                position: fixed; /* Fixes the background position */
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                z-index: 999; /* Ensures the background is on top of other content */
            }

            /* Modal Popup */

            .modelPopup {
                background-color: #f0f0f0; /* Light gray background */
                border: 2px solid #333; /* Thin solid border */
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Adds a subtle shadow */
                padding: 20px; /* Increased padding for better spacing */
                width: 60%; /* Increased width */
                max-width: 500px; /* Maximum width */
                height: auto; /* Adjusts height based on content */
                max-height: 80vh; /* Maximum height relative to viewport */
                border-radius: 15px; /* Rounded corners */
                overflow-y: auto; /* Adds scrollbars when content overflows */
                position: fixed; /* Position modal relative to the viewport */
                top: 50%; /* Centers modal vertically */
                left: 50%; /* Centers modal horizontally */
                transform: translate(-50%, -50%); /* Centers modal perfectly */
                z-index: 1000; /* Ensures the modal is on top of the background */
            }

            #Pop {
                display: flex;
                justify-content: center;
                align-items: center;
            }

            #RegisterContainer{
                border:2px solid black;
                align-items:center;
                display:flex;
                justify-content:center;
                margin-right:40px;
            }
            #subContainer{
              
               
                border:2px solid red;
                display:flex;
                justify-content:center;
                align-items:center;
            }

        </style>

        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
        <br />
        <br />

        <center>

            <ajaxToolkit:ModalPopupExtender ID="popupDelete" runat="server" BackgroundCssClass="modalBackground" PopupControlID="panelPopUpId" CancelControlID="cancelpopup" TargetControlID="linkButton"></ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="panelPopUpId" runat="server" CssClass="modelPopup">
                <h1>Do you want to delete?</h1>
                <asp:Button ID="yespopup" runat="server" Text="yes" OnClick="yespopup_Click1" />
                <asp:Button ID="cancelpopup" runat="server" Text="cancel" />
            </asp:Panel>
            <asp:LinkButton ID="linkButton" runat="server"></asp:LinkButton>



        </center>


       
        <asp:Panel ID="PanelGrid" runat="server" Visible="true">
            <br />
            <div style="display: flex; gap: 10px; margin-bottom: 10px">

                <asp:Button ID="btnAddMember" Text="Add Member" runat="server" OnClick="btnAddMember_Click" BorderStyle="None" BackColor="Green" ForeColor="White" />
                <asp:Button ID="btnDownload" Text="Download" runat="server" OnClick="btnDownload_Click" BorderStyle="None" BackColor="Yellow" ForeColor="Black" />
            </div>

            <div style="display: flex; justify-content: center; align-items: center; text-align: center; margin-top: 30px">
                <asp:GridView runat="server" ID="gvMember" AutoGenerateColumns="False" HeaderStyle-BackColor="SeaGreen" CellPadding="3"
                    BackColor="White" BorderWidth="2px" BorderColor="White" Width="1200px" OnPageIndexChanging="gvMember_PageIndexChanging" OnRowCommand="gvMember_RowCommand" OnRowDataBound="gvMember_RowDataBound" CssClass="GridBorder" BorderStyle="Ridge" CellSpacing="1" GridLines="None">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </div>
        </asp:Panel>

       
        <style>
            
        </style>
        <asp:Panel ID="PanelRegister" runat="server" Visible="false">
            <center>
                <h2>Registration Form</h2>
               </center>
            <div id="RegisterContainer">
                <div id="subContainer">
                <table class="form-container">
                    <tr>
                        <td>Name</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" AutoComplete="off" Required="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexName" runat="server" ControlToValidate="txtname"
                                ValidationExpression="^[a-zA-Z\s]*$" ErrorMessage="Only letters and spaces are allowed"
                                Display="Dynamic" />
                        </td>
                    </tr>
                    <tr>
                        <td>Number</td>
                        <td>
                            <asp:TextBox ID="txtNumber" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regx" runat="server" ControlToValidate="txtNumber" ErrorMessage="*Enter valid Mobile Number"
                                ForeColor="Red" ValidationExpression="^[0][0-9]{10}|^[+91][0-9]{12}|[0-9]{10}"></asp:RegularExpressionValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" AutoComplete="off">
 
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="validateEmail"
                                runat="server" ErrorMessage="Invalid email."
                                ControlToValidate="txtEmail"
                                ValidationExpression="^[a-zA-Z][\w\.-]*@[\w\.-]+\.[a-zA-Z]+$" />
                        </td>
                    </tr>
                    <tr>
                        <td>Adhaar No</td>
                        <td>
                            <asp:TextBox ID="txtAadhaar" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAadhaar" ErrorMessage="*Enter valid Aadhaar Number"
                                ForeColor="Red" ValidationExpression="^[0][0-9]{10}|^[+91][0-9]{12}|[0-9]{12}"></asp:RegularExpressionValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>DOJ</td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" TextMode="Date" AutoCompleteType="Disabled" onkeydown="return false;"></asp:TextBox>
                            <asp:CompareValidator ID="compareValidatorBirthDate" runat="server" ControlToValidate="txtDate"
                                Operator="DataTypeCheck" Type="Date" ErrorMessage="*Please enter a valid birth date." />
                        </td>
                    </tr>
                    <tr>
                        <td>Country</td>
                        <td>
                            <asp:DropDownList ID="ddlCountry" runat="server" Width="150" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>

                    </tr>
                    <tr>
                        <td>State
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStates" runat="server" Width="150" AutoPostBack="true"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>Floor</td>
                        <td>
                            <asp:DropDownList ID="ddlFloor" runat="server">
                                <asp:ListItem Text="G Floor" Value="G Floor" Selected="True" />
                                <asp:ListItem Text="1st Floor" Value="1st Floor" />
                                <asp:ListItem Text="2nd Floor" Value="2nd Floor" />
                                <asp:ListItem Text="3nd Floor" Value="3rd Floor" />
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Sharing</td>
                        <td>
                            <asp:DropDownList ID="ddlSharing" runat="server">
                                <asp:ListItem Text="1 Sharing" Value="1 Sharing" Selected="True" />
                                <asp:ListItem Text="2 Sharing" Value="2 Sharing" />
                                <asp:ListItem Text="3 Sharing" Value="3 Sharing" />
                                <asp:ListItem Text="4 Sharing" Value="4 Sharing" />
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Price(in Rupees)</td>
                        <td>
                            <asp:TextBox ID="txtPrice" runat="server" AutoComplete="off"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="validatePrice" runat="server" ErrorMessage="invalid" CssClass="text-danger"
                                ControlToValidate="txtPrice" ValidationExpression="^\d+$" />
                        </td>
                    </tr>             
                  <tr id="button">
                        <td>
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                             <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
                    </div>
                </div>
        </asp:Panel>
    </main>
</asp:Content>
