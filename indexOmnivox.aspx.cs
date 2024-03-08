using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Practice3
{
    public partial class indexOmnivox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrer_Click(object sender, EventArgs e)
        {
            String num = txtNumero.Text.Trim();
            String mdp = txtMot2passe.Text.Trim();

            SqlConnection mycon = new SqlConnection();
            mycon.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBOmnivox;Integrated Security=True";

            SqlCommand mycmd = new SqlCommand();
            mycmd.Connection = mycon;
            string sql = "SELECT Nom FROM Membres ";

            sql += "WHERE Numero = '" + num + "' AND ";
            sql += "MotDePasse = '" + mdp + "'";

            mycmd.CommandText = sql;

            mycon.Open();

            SqlDataReader myRder = mycmd.ExecuteReader();


            if (myRder.Read())
            {
                Session["nom"] = myRder["Nom"];
                mycon.Close();
                Response.Redirect("AcceuilOmnivox.aspx");
            }
            else
            {
                mycon.Close();
                lblErreur.Text = "Numero ou mot de passe invalide";
                txtMot2passe.Text = "";
                txtMot2passe.Focus();
            }
        }
    }
}