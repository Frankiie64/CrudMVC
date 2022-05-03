using CapaPresentacion.Models;
using System.Data.SqlClient;
using System.Data;

namespace CapaPresentacion.Data
{
    public class REPO_CONTACTO
    {
        public List<ContactoModel> listar()
        {
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand("SP_Listar", conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (var dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public ContactoModel listarByContact(int IdContacto)
        {
            var Contacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand("SP_ListarByContaco", conexion);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@IdContacto", IdContacto);

                using (var dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        Contacto.Nombre = dr["Nombre"].ToString();
                        Contacto.Telefono = dr["Telefono"].ToString();
                        Contacto.Correo = dr["Correo"].ToString();                        
                    }
                }
            }
            return Contacto;
        }

        public bool Guadar(ContactoModel contacto)
        {
            try
            {
                var Contacto = new ContactoModel();

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("SP_Guardar", conexion);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    sqlCommand.Parameters.AddWithValue("@Correo", contacto.Correo);

                    sqlCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
           
        }
        public bool Editar(ContactoModel contacto)
        {
            try
            {
                var Contacto = new ContactoModel();

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("SP_Actualizar", conexion);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@IdContacto", contacto.IdContacto);
                    sqlCommand.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    sqlCommand.Parameters.AddWithValue("@Correo", contacto.Correo);

                    sqlCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }
        public bool Eliminar(int IdContacto)
        {
            try
            {
                var Contacto = new ContactoModel();

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand sqlCommand = new SqlCommand("SP_Eliminar", conexion);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@IdContacto", IdContacto);              
                    sqlCommand.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }

        }
    }
}
