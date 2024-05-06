using Microsoft.Data.SqlClient;
using System.Data;


namespace Proyecto.Presentacion.Models
{
    public class RepositorioVendedor : IVendedor
    {
        private string cadena;
        public RepositorioVendedor()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }
        //--
        public IEnumerable<Distrito> listadoDistrito()
        {
            List<Distrito> aDistritos = new List<Distrito>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADODISTRITOS", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aDistritos.Add(new Distrito()
                {
                    ide_dis = int.Parse(dr[0].ToString()),
                    nom_dis = dr[1].ToString()
                });
            }
            cn.Close();
            return aDistritos;
        }

        public IEnumerable<Vendedor> listadoVendedor()
        {
            List<Vendedor> aVendedor = new List<Vendedor>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADOVENDEDORES", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aVendedor.Add(new Vendedor()
                {
                    ide_ven = int.Parse(dr[0].ToString()),
                    nom_ven = dr[1].ToString(),
                    sue_ven = double.Parse(dr[2].ToString()),
                    fec_ing = DateTime.Parse(dr[3].ToString()),
                    nom_dis = dr[4].ToString()
                });
            }
            cn.Close();
            return aVendedor;
        }

        public IEnumerable<VendedorO> listadoVendedorO()
        {
            List<VendedorO> aVendedores = new List<VendedorO>();
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LISTADOVENDEDORES_O", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                aVendedores.Add(new VendedorO()
                {
                    ide_ven = int.Parse(dr[0].ToString()),
                    nom_ven = dr[1].ToString(),
                    ape_ven = dr[2].ToString(),
                    sue_ven = double.Parse(dr[3].ToString()),
                    fec_ing = DateTime.Parse(dr[4].ToString()),
                    ide_dis = int.Parse(dr[5].ToString())
                });
            }
            cn.Close();
            return aVendedores;
        }

        public string modificaVendedor(VendedorO objV)
        {
            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_VENDEDOR", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure; ;
                //parametros
                cmd.Parameters.AddWithValue("@ide", objV.ide_ven);
                cmd.Parameters.AddWithValue("@nom", objV.nom_ven);
                cmd.Parameters.AddWithValue("@ape", objV.ape_ven);
                cmd.Parameters.AddWithValue("@sue", objV.sue_ven);
                cmd.Parameters.AddWithValue("@fec", objV.fec_ing);
                cmd.Parameters.AddWithValue("@dis", objV.ide_dis);
                int n = cmd.ExecuteNonQuery();
                mensaje = n.ToString() + " Vendedor Actualizado";
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar" + ex.Message;
            }
            cn.Close();
            return mensaje;
        }

        public string nuevoVendedor(VendedorO objV)
        {

            string mensaje = "";
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_MERGE_VENDEDOR", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //parametros
                cmd.Parameters.AddWithValue("@ide", objV.ide_ven);
                cmd.Parameters.AddWithValue("@nom", objV.nom_ven);
                cmd.Parameters.AddWithValue("@ape", objV.ape_ven);
                cmd.Parameters.AddWithValue("@sue", objV.sue_ven);
                cmd.Parameters.AddWithValue("@fec", objV.fec_ing);
                cmd.Parameters.AddWithValue("@dis", objV.ide_dis);
                int n = cmd.ExecuteNonQuery();
                mensaje = n.ToString() + " Vendedor Registrado";
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar" + ex.Message;
            }
            cn.Close();
            return mensaje;
        }
    }
}
