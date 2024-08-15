using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebApplication1.code;

namespace WebApplication1
{
    public partial class _Default : Page
    {

        DataSet ds = new DataSet();
        Charts cs = new Charts();
        DBCalling db = new DBCalling();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ds = cs.GetChartData("Charts", true);
                DataTable dt = ds.Tables[0];
                chart1.Text = BarChart(dt, 0);
                DataTable dt2 = ds.Tables[1];
                chart2.Text = PieChart(dt2, 1);
                Cards();

                //  barchart1.Text =BarChart(dt, 1);
            }

        }

        public string BarChart(DataTable dt, int count)
        {
            string Value1 = "";
            string Value2 = "";
            string chart = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    Value1 += ",";
                    Value2 += ",";

                }
                Value1 += "'" + dt.Rows[i][0].ToString() + "'";
                Value2 += "'" + dt.Rows[i][1].ToString() + "'";

            }
            chart = "<canvas id=\"barchart" + count + "\" style=\"width:100%;max-width:600px\"></canvas>\r\n\r\n<script>\r\nvar xValues = [" + Value1 + "];\r\nvar yValues = [" + Value2 + "];\r\nvar barColors = [\"red\", \"green\",\"blue\",\"orange\",\"brown\"];\r\n\r\nnew Chart(\"barchart" + count + "\", {\r\n  type: \"bar\",\r\n  data: {\r\n    labels: xValues,\r\n    datasets: [{\r\n      backgroundColor: barColors,\r\n      data: yValues\r\n    }]\r\n  },\r\n  options: {\r\n    legend: {display: false},\r\n    title: {\r\n      display: true,\r\n      text: \"People Staying according to floor\"\r\n    }\r\n  }\r\n});\r\n</script>";
            // chart = "<div\r\nid=\"barchart"+count+"\" style=\"width:100%; max-width:600px; height:500px;\">\r\n</div>\r\n\r\n<script>\r\ngoogle.charts.load('current', {'packages':['corechart']});\r\ngoogle.charts.setOnLoadCallback(drawChart);\r\n\r\nfunction drawChart() {\r\n\r\n// Set Data\r\nconst data = google.visualization.arrayToDataTable([\r\n  ['Contry', 'Mhl'],\r\n  ['Italy',54.8],\r\n  ['France',48.6],\r\n  ['Spain',44.4],\r\n  ['USA',23.9],\r\n  ['Argentina',14.5]\r\n]);\r\n\r\n// Set Options\r\nconst options = {\r\n  title:'World Wide Wine Production'\r\n};\r\n\r\n// Draw\r\nconst chart = new google.visualization.PieChart(document.getElementById('myChart'));\r\nchart.draw(data, options);\r\n\r\n}\r\n</script>";
            return chart;
        }

        public string PieChart(DataTable dt, int count)
        {
            string Value1 = "";
            string Value2 = "";
            string Chart = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    Value1 += ",";
                    Value2 += ",";
                }

                Value1 += "'" + dt.Rows[i][0].ToString() + "'";
                Value2 += "'" + dt.Rows[i][1].ToString() + "'";

            }
            // Chart = "<canvas id =\"barchart" + count + "\" style=\"width:100%;max-width:600px\"></canvas>\r\n\r\n<script>\r\nvar xValues = [" + Value1 + "];\r\nvar yValues = [" + Value2 + "];\r\nvar barColors = [\"red\", \"green\",\"blue\",\"orange\",\"brown\"];\r\n\r\nnew Chart(\"barchart" + count + "\", {\r\n  type: \"bar\",\r\n  data: {\r\n    labels: xValues,\r\n    datasets: [{\r\n      backgroundColor: barColors,\r\n      data: yValues\r\n    }]\r\n  },\r\n  options: {\r\n    legend: {display: false},\r\n    title: {\r\n      display: true,\r\n      text: \"World Wine Production 2018\"\r\n    }\r\n  }\r\n});\r\n</script>";

            Chart = "<canvas id=\"piechart" + count + "\" style=\"width:100%;max-width:600px\"></canvas>\r\n\r\n<script>\r\nvar xValues = [" + Value1 + "];\r\nvar yValues = [" + Value2 + "];\r\nvar barColors = [\r\n  \"#b91d47\",\r\n  \"#00aba9\",\r\n  \"#2b5797\",\r\n  \"#e8c3b9\",\r\n  \"#1e7145\"\r\n];\r\n\r\nnew Chart(\"piechart" + count + "\", {\r\n  type: \"pie\",\r\n  data: {\r\n    labels: xValues,\r\n    datasets: [{\r\n      backgroundColor: barColors,\r\n      data: yValues\r\n    }]\r\n  },\r\n  options: {\r\n    title: {\r\n      display: true,\r\n      text: \"Number Of People according to Room Sharing\"\r\n    }\r\n  }\r\n});\r\n</script>";
            return Chart;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUser"] = null;

           
            Response.Redirect("Login.aspx");
        }

        void Cards()
        {
            DataSet ds = db.CardData("CARDS", true);


            //DataTable dt1 = ds.Tables[0];


            //string floorN1 = dt1.Rows[0][0].ToString();
            //string floor1 = dt1.Rows[0][1].ToString();
            
            //string floorN2 = dt1.Rows[1][0].ToString();
            //string floor2 = dt1.Rows[1][1].ToString();

            //string floorN3 = dt1.Rows[2][0].ToString();
            //string floor3 = dt1.Rows[2][1].ToString();

            //string floorN4 = dt1.Rows[3][0].ToString();
            //string floor4 = dt1.Rows[3][1].ToString();

          



            DataTable dt2 = ds.Tables[1];
            string num = "";
            if(dt2.Rows[0][0].ToString() == null)
            {
                num="0";
            }
            else
            {
                num=dt2.Rows[0][0].ToString();
            }


            DataTable dt3 = ds.Tables[2];
            string price = "";
            if(dt3.Rows[0][0].ToString() == null)
            {
                price = "0";
            }
            else
            {
               price= dt3.Rows[0][0].ToString();
            }


            DataTable dt4 = ds.Tables[3];

            string sharingN1 = "";
            string NoOfPeople1 ="";

    
            if (dt4.Rows.Count <= 0)
            {
                sharingN1="1";
                NoOfPeople1="0";
            }
            else
            {
                sharingN1=dt4.Rows[0][0].ToString();
                NoOfPeople1 = dt4.Rows[0][1].ToString();
            }
            
            string sharingN2 = "";
            string NoOfPeople2 = "";
            if (dt4.Rows.Count <= 0)
            {
                sharingN2 = "2";
                NoOfPeople2 = "0";
            }
            else
            {
                sharingN2 = dt4.Rows[1][0].ToString();
                NoOfPeople2 = dt4.Rows[1][1].ToString();
            }

            string sharingN3 = "";
            string NoOfPeople3 = "";
            if (dt4.Rows.Count <= 0)
            {
                sharingN3 = "3";
                NoOfPeople3 = "0";
            }
            else
            {
                sharingN3 = dt4.Rows[2][0].ToString();
                NoOfPeople3 = dt4.Rows[2][1].ToString();
            }

            string sharingN4 = "";
            string NoOfPeople4 = "";
            if (dt4.Rows.Count <= 0)
            {
                sharingN4 = "4";
                NoOfPeople4 = "0";
            }
            else
            {
                sharingN4 = dt4.Rows[3][0].ToString();
                NoOfPeople4 = dt4.Rows[3][1].ToString();

            }

            List<Parameters> card = new List<Parameters>
             {
                // new Parameters { Title = "Number Of People in a Floor", Description = $"{floorN4} : {floor4} <br/> {floorN1} : {floor1} <br/> {floorN2} : {floor2} <br/> {floorN3} : {floor3}"},
                 new Parameters { Title = "Total Number Of People", Description = $"{num}/40" },
                 new Parameters { Title = "Total Amount Received(in Rupees)",Description= $"{price}/302000" },
                 new Parameters { Title = "Sharing Details", Description = $"{sharingN1} : {NoOfPeople1}/4 <br/> {sharingN2} : {NoOfPeople2}/8 <br/> {sharingN3} : {NoOfPeople3}/12 <br/> {sharingN4} : {NoOfPeople4}/16" },
             };

            repeater.DataSource = card;
            repeater.DataBind();
        }
    }
}