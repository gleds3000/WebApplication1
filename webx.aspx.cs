using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
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
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string FilePath = Server.MapPath(FolderPath + FileName);
                FileUpload1.SaveAs(FilePath);
                Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
            }
        }

        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            string ssqltable = "geral";
            try
            {
                //string conStr = "";
                //switch (Extension)
                //{
                //    case ".xls": //Excel 97-03
                //        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                //        break;
                //    case ".xlsx": //Excel 07
                //        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                //        break;
                //    //case ".xlsx"://excel 11 
                //    //    conStr =  Extended Properties=Excel 11.0
                //}
                //conStr = String.Format(conStr, FilePath, isHDR);
                // OleDbConnection oledbconn = new OleDbConnection(conStr);
                //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + FilePath +
                ";extended properties=" + "\"excel 8.0;hdr=Yes;\"";
                //string ssqlconnectionstring = "Data Source=SAYYED;Initial Catalog=SyncDB;Integrated Security=True";
                // string ssqlconnectionstring = "Server=(localdb)\\v11.0;Integrated Security=true;Initial Catalog=dashdb;";
                //string ssqlconnectionstring = "Server=np:\\.\pipe\LOCALDB#BA747AD2\tsql\query; Integrated Security=true;Initial Catalog=dashdb;  ";
                //string ssqlconnectionstring = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=dashdb.mdf;Integrated Security=True;";
                //string ssqlconnectionstring = "Data Source=np:\\.\\pipe\\LOCALDB#BA747AD2\\tsql\\query;Initial Catalog=C:\\USERS\\SVP3278\\DOCUMENTS\\DASHDB.MDF;Integrated Security=True;";
                //string ssqlconnectionstring = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=webdb.mdf;Integrated Security=True;";
                //string ssqlconnectionstring = "Data Source=(LocalDB)\\v11;Initial Catalog=webdb;Integrated Security=True";
                //string ssqlconnectionstring = "Data Source=(LocalDB)\v11.0;AttachDbFileName=.\\webdb.mdf;Initial Catalog=webdb;Integrated Security=True;MultipleActiveResultSets=True";
                // Data Source=(localdb)\Projects;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False
                string ssqlconnectionstring = "Data Source=(localdb)\\Projects;Initial Catalog=webdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
                //execute a query to erase any previous data from our destination table
                string sclearsql = "delete from prova"; //+ ssqltable;
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                // sqlconn.Close();
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                //  sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);

                OleDbCommand oledbcmd = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                oledbcmd.Connection = oledbconn;

                oledbconn.Open();
                //controle de nome da 1 planilha 
                DataTable dtExcelSchema;
                dtExcelSchema = oledbconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                oledbconn.Close();

                oledbconn.Open();
                //Read Data from First Sheet
                // connExcel.Open();
                oledbcmd.CommandText = "SELECT Ref_num,	Type_symbol,	Soma_horas_totais,	Soma_Horas_Util,	Grupo_now_name,	Request_Category,	RequestOpen_date,	Request_urgency,	Request_Severity,	External_system_ticket,	Request_status,	Request_close_date,	Assignee_now_last_name From [" + SheetName + "]";
                //Response.Write("Noma da planilha" + SheetName);
                oda.SelectCommand = oledbcmd;
                oda.Fill(dt);
                // oledbconn.Close();


                // OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                // oda.SelectCommand = oledbcmd;
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                bulkcopy.DestinationTableName = ssqltable;
              //  Label1.Text = "chegou no BULK";
                //Response.Write("Copiando");
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close();

                Label1.Text = "Foi com sucesso.";
                //Bind Data to GridView
                GridView1.Caption = Path.GetFileName(FilePath);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                oledbconn.Close();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                //handle exception
                //throw new teste("Algo com problema.", ex);
                Console.WriteLine("{0} pegamos uma falha.", ex);
                Response.Write(ex);
            }
        }

 
     protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string FolderPath = ConfigurationManager.AppSettings["FolderPath"] ;
        string FileName = GridView1.Caption;
        string Extension = Path.GetExtension(FileName);
        string FilePath = Server.MapPath(FolderPath + FileName);

        Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);  
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();  
    }
   private void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
{
    using (SqlConnection dbConnection = new SqlConnection("Data Source=LocalDB;Initial Catalog=Dashboard;Integrated Security=True"))
        {
          dbConnection.Open();
          using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
            {
                s.DestinationTableName = "DashGeral";

                foreach (var column in csvFileData.Columns)
                s.ColumnMappings.Add(column.ToString(), column.ToString());

                s.WriteToServer(csvFileData);
             }
         }
  }


  }  
}