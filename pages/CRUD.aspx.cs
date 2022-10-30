using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//necesario para conexion
using System.Configuration;//necesario para conexion
using System.Data;//Necesario en conexion

namespace CRUD.pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //optener el id
            if (!Page.IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    Response.Write(sID);
                    cargarDatos();
                    tbDate.TextMode = TextBoxMode.DateTime ;
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch(sOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "Ingresar nuevo usuario";
                            this.btnCreate.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de usuario";
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar usuario";
                            this.btnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar usuario";
                            this.btnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void cargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int,0).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbNombre.Text = row[1].ToString();
            tbEdad.Text = row[2].ToString();
            tbEmail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            tbDate.Text = d.ToString("dd/MM/yyyy");
            con.Close();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();//ejecutar procedimiento almacenado
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();//ejecutar procedimiento almacenado
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();//ejecutar procedimiento almacenado
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}