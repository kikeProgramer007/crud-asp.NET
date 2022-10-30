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
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        void cargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load", con);
            cmd.CommandType = CommandType.StoredProcedure;//es de tipo proc almacenado
            con.Open();//abrir conexion
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvUsuarios.DataSource = dt;
            gvUsuarios.DataBind();
            con.Close();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/CRUD.aspx?op=C");
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/CRUD.aspx?id="+id+ "&op=R");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/pages/CRUD.aspx?id=" + id + "&op=D");
        }
    }
}