<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <main>
        <style>
            #CardsContainerSub {
                display: flex;
                justify-content: center;
                gap: 100px;
                border: 3px solid black;
                width: 100%;
            }

            .cards {
                height: 150px;
                width: 150px;
                border: 2px solid black;
                text-align: center;
            }

            .chart {
                height: 500px;
                width: 500px;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                transition: box-shadow 0.3s ease;
                background-color:aliceblue;
            }

            .chart:hover {
                 box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
             }

            #ChartContainer {
                display: flex;
                justify-content: center;
                width: 100%;
                gap: 30px;
                align-items: center;
                margin-top: 50px;
                
            }

            .logout {
                float: right;
            }

            
               body {
   background-color:gainsboro;
}
            
        </style>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
        <script src="https://www.gstatic.com/charts/loader.js"></script>

        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" BackColor="Red" CssClass="logout" />
        <br />
        <br />




        <style scoped>
            .card {
                background-color: #f8f8f8;
                border-radius: 8px;
                box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
                padding: 20px;
                transition: all 0.3s ease-in-out;
                font-family: 'Roboto', sans-serif;
                position: relative;
            }

                .card::before {
                    content: '';
                    position: absolute;
                    top: 0;
                    left: 0;
                    width: 100%;
                    height: 100%;
                  /*  background: linear-gradient(to bottom right, #ffb347, #ffcc33);*/
                    opacity: 0;
                    border-radius: 8px;
                    transition: opacity 0.3s ease-in-out;
                }

                .card:hover::before {
                    box-shadow: 0 8px 20px rgba(0, 0, 0, 0.4);
                    opacity: 0.3;
                }

                /*.card:hover {
                    transform: translateY(-5px);
                    box-shadow: 0 16px 40px rgba(0, 0, 0, 0.4);
                }*/
        </style>
        <div style="display: flex; align-items: center; justify-content: center; gap: 10px">
            <asp:Repeater runat="server" ID="repeater">
                <ItemTemplate>
                    <div class="card" style="height: 200px; width: 200px">
                        <h6><%# Eval("Title") %></h6>
                        <hr />
                        <p><%# Eval("Description") %></p>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>




        <div id="ChartContainer">
            <div class="chart">
                <asp:Literal ID="chart1" runat="server"></asp:Literal>
            </div>
            <div class="chart">
                <asp:Literal ID="chart2" runat="server"></asp:Literal>
            </div>
        </div>





         
    </main>

</asp:Content>
