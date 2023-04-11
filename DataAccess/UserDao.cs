using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Commun.Cache;

namespace DataAccess
{
    public class UserDao:ConnectionToSql
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from usuarios where usuario COLLATE Latin1_General_CS_AS =@user and contraseña COLLATE Latin1_General_CS_AS =@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.FirstName = reader.GetString(1);
                            UserLoginCache.LastName = reader.GetString(2);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Area = reader.GetString(6);
                            UserLoginCache.Id = reader.GetInt32(0);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        //Entradas Almacén Materia Prima
        public DataTable ver_CatalogoMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();
            using(var connection = GetConnection())
            {
                connection.Open();
                using(var command= new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT *FROM catalogoMP";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable ver_CatalogoProveedores()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT *FROM CatalogoProveedores";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable mostrar_Costo(string idProducto)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT *FROM catalogoMP WHERE idProducto='@idProducto'";
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    
                    if (leer.HasRows)
                    {
                        AppCache.costoActual = leer.GetDouble(0);
                    }
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable ver_NumEtiqueta()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP 1 (idEtiqueta+1) as idEtiqueta FROM almacenMateriaPrima ORDER BY idEtiqueta DESC ";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable ver_Datos()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select TOP 500 idPrimario,idEtiqueta,fechaRegistro,idUsuario,idProducto,ROUND(tara,2) as tara,ROUND(pesoBruto,2)as pesoBruto,ROUND(pesoNeto,2)as pesoNeto,costo,idStatus,idProveedor,idTraspaso from almacenMateriaPrima ";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable ver_Datos(int i)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idPrimario,idEtiqueta,fechaRegistro,idUsuario,idProducto,ROUND(tara,2) as tara,ROUND(pesoBruto,2)as pesoBruto,ROUND(pesoNeto,2)as pesoNeto,costo,idStatus,idProveedor,idTraspaso from almacenMateriaPrimaSeguimiento ORDER BY idEtiqueta DESC ";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public void insertarEntradas(int idEtiqueta,int idUsuario,string idProducto,double tara,double pesoBruto,double pesoNeto,double costo,int idStatus,int idProveedor,int idTraspaso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO almacenMateriaPrima VALUES(@idEtiqueta,GETDATE(),@idUsuario,@idProducto,@tara,@pesoBruto,@pesoNeto,@costo,@idStatus,@idProveedor,@idTraspaso)" +
                        "INSERT INTO almacenMateriaPrimaSeguimiento VALUES(@idEtiqueta,GETDATE(),@idUsuario,@idProducto,@tara,@pesoBruto,@pesoNeto,@costo,@idStatus,@idProveedor,@idTraspaso)";
                    command.Parameters.AddWithValue("@idEtiqueta",idEtiqueta);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    command.Parameters.AddWithValue("@tara", tara);
                    command.Parameters.AddWithValue("@pesoBruto", pesoBruto);
                    command.Parameters.AddWithValue("@pesoNeto", pesoNeto);
                    command.Parameters.AddWithValue("@costo", costo);
                    command.Parameters.AddWithValue("@idStatus", idStatus);
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }           
        }
        //Entradas Almacén Materia Prima

        //Salidas Almaacén Materia Prima
        public DataTable ver_CatalogoTraspaso()
        {
            DataTable table = new DataTable();
            SqlDataReader leer;
            using(var connection= GetConnection())
            {
                connection.Open();
                using(var command= new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT *FROM catalogoTraspasos";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public void insertarSalidas(int idEtiqueta, int idUsuario, string idProducto, double tara, double pesoBruto, double pesoNeto, double costo, int idStatus, int idProveedor, int idTraspaso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO almacenMateriaPrima VALUES(@idEtiqueta,GETDATE(),@idUsuario,@idProducto,@tara,@pesoBruto,@pesoNeto,@costo,@idStatus,@idProveedor,@idTraspaso)" +
                        "UPDATE almacenMateriaPrimaSeguimiento SET idStatus=@idStatus,idTraspaso=@idTraspaso where idEtiqueta=@idEtiqueta";
                    command.Parameters.AddWithValue("@idEtiqueta", idEtiqueta);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    command.Parameters.AddWithValue("@tara", tara);
                    command.Parameters.AddWithValue("@pesoBruto", pesoBruto);
                    command.Parameters.AddWithValue("@pesoNeto", pesoNeto);
                    command.Parameters.AddWithValue("@costo", costo);
                    command.Parameters.AddWithValue("@idStatus", idStatus);
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Configuración Almacén Materia Prima
        public void deshacerMoviemientoEntradas(int idEtiqueta)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM almacenMateriaPrima where idEtiqueta=@idEtiqueta " +
                        "DELETE FROM almacenMateriaPrimaSeguimiento where idEtiqueta=@idEtiqueta";
                    command.Parameters.AddWithValue("@idEtiqueta", idEtiqueta);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void deshacerMoviemientoSalidas(int idEtiqueta, int idStatusOG,int idStatus,int idTraspaso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM almacenMateriaPrima where idEtiqueta=@idEtiqueta and idStatus=@idStatusOG " +
                        "UPDATE almacenMateriaPrimaSeguimiento SET idStatus=@idStatus,idTraspaso=@idTraspaso where idStatus=@idStatusOG";
                    command.Parameters.AddWithValue("@idEtiqueta", idEtiqueta);
                    command.Parameters.AddWithValue("@idStatusOG", idStatusOG);
                    command.Parameters.AddWithValue("@idStatus", idStatus);
                    command.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Config Catalogo Materia Prima
        public void agregarMateria(string id, string desc, double costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO catalogoMP VALUES(@id,@desc,@costo)";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@costo", costo);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void actualizarMateria(string idOG,string id, string desc, double costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE catalogoMP SET idProducto=@id,producto=@desc,costo=@costo WHERE idProducto=@idOG";
                    command.Parameters.AddWithValue("@idOG", idOG);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.Parameters.AddWithValue("@costo", costo);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void borrarMaterial(string id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM catalogoMP WHERE idProducto=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        //Config Catalogo Usuarios
        public DataTable verUsuarios()
        {
            DataTable table = new DataTable();
            SqlDataReader leer;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT *FROM usuarios";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public void agregarUsuario(string nombre, string apellido,string usuario, string contraseña,string cargo, string area,string correo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO usuarios VALUES(@nombre,@apellido,@usuario,@contraseña,@cargo,@area,@correo)";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    command.Parameters.AddWithValue("@cargo", cargo);
                    command.Parameters.AddWithValue("@area", area);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void actualizarUsuario(int id,string nombre, string apellido, string usuario, string contraseña, string cargo, string area, string correo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE usuarios SET nombre=@nombre,apellido=@apellido,usuario=@usuario,contraseña=@nombre,cargo=@cargo,area=@area,correoE=@correo WHERE idUsuario=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    command.Parameters.AddWithValue("@cargo", cargo);
                    command.Parameters.AddWithValue("@area", area);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void borrarUsuario(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM usuarios WHERE idUsuario=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        //Config Catalogo Proveedores
        public void agregarProveedor(string desc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO catalogoProveedores VALUES(@desc)";
                    command.Parameters.AddWithValue("@desc", desc);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void actualizarProveedor(int id,string desc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE catalogoProveedores SET proveedor=@desc WHERE idProveedor=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@desc", desc);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void borrarProveedor(string id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM catalogoProveedores WHERE idProveedor=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
