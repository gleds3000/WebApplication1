using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace WebApplication1
{
    
    public partial class log : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //string ssqltable = "geral";

           
            if (!Page.IsPostBack)
            {
               // string Area = "";

                populaDDL();
               // populaGrid();
            }

         
    
        }
        public void populaDDL()
        {
            string ssqlconnectionstring = "Data Source=(localdb)\\Projects;Initial Catalog=webdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            string sqlstr = "select Grupo_now_name , count(Grupo_now_name) as Total from GERAL Where Request_status = 'Fechado' group by Grupo_now_name";
            SqlConnection Conexao = new SqlConnection(ssqlconnectionstring);
            SqlDataAdapter Comando = new SqlDataAdapter(sqlstr, Conexao);
            DataSet ds = new DataSet();
            Conexao.Open();
            Comando.Fill(ds);
            DataView fonte = new DataView(ds.Tables[0]);
            Ddl1Grupoarea.DataTextField = "Grupo_now_name";
            Ddl1Grupoarea.DataValueField = "Grupo_now_name";
            Ddl1Grupoarea.DataSource = fonte;
            Ddl1Grupoarea.DataBind();

            Conexao.Close();
          
        }
        public void populaGrid()
        {
            string ssqlconnectionstring = "Data Source=(localdb)\\Projects;Initial Catalog=webdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            string sqlstr = "select Grupo_now_name AS Grupo , count(Grupo_now_name) as Total from GERAL Where Request_status = 'Fechado' and Grupo_now_name = '" + Ddl1Grupoarea.SelectedItem.Value + "' group by Grupo_now_name";
            SqlConnection Conexao = new SqlConnection(ssqlconnectionstring);
            SqlDataAdapter Comando = new SqlDataAdapter(sqlstr, Conexao);

            DataSet ds = new DataSet();
            Conexao.Open();
            Comando.Fill(ds);

            DataView fonte = new DataView(ds.Tables[0]);

            //  System.Web.UI.DataVisualization.Charting.Chart Chart1 = new Chart();

             Chart1.DataSource = fonte;

            Chart1.Series[0].XValueMember= "Grupo";
            Chart1.Series[0].YValueMembers = "Total";

            Chart1.DataBind();
            
            //GridView2.Caption = "teste";
            //GridView2.DataSource = fonte;
            //GridView2.DataBind();

            Conexao.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Ddl1Grupoarea.SelectedItem.Text != "")
            {
                populaGrid();
            }
            

        }
    }
}