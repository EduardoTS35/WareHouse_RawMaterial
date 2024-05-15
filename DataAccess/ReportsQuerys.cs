using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ReportsQuerys:ConnectionToSql
    {
        #region Inventario
        public DataTable ResumenInv()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @" SELECT a.idProducto, mp.producto, SUM(a.pesoBruto) AS pesoBruto, SUM(a.pesoNeto) AS pesoNeto, COUNT(*) AS pacas
        FROM     almacenMateriaPrimaSeguimiento AS a INNER JOIN
                          catalogoMP AS mp ON a.idProducto = mp.idProducto
        WHERE  (a.idStatus = 1)
        GROUP BY a.idProducto, mp.producto";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public DataTable DatallesInv()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"SELECT a.idPrimario, a.idEtiqueta, a.fechaRegistro, a.idUsuario, a.idProducto, a.tara, a.pesoBruto, a.pesoNeto, a.costo, a.idStatus, a.idProveedor, a.idTraspaso, c.producto
                FROM     almacenMateriaPrimaSeguimiento AS a INNER JOIN
                catalogoMP AS c ON a.idProducto = c.idProducto
                WHERE  (a.idStatus = 1)";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        #endregion
        #region Entradas
        public DataTable ResumenEntradas(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"SELECT a.idProducto, mp.producto, SUM(a.pesoBruto) AS pesoBruto, SUM(a.pesoNeto) AS pesoNeto, COUNT(*) AS pacas
FROM     almacenMateriaPrimaSeguimiento AS a INNER JOIN
                  catalogoMP AS mp ON a.idProducto = mp.idProducto
WHERE  (a.fechaRegistro BETWEEN @fechaInicial AND @fechaFinal) AND (a.idStatus = 1)
GROUP BY a.idProducto, mp.producto";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        cmd.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public DataTable DatallesEntradas(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"SELECT a.idPrimario, a.idEtiqueta, a.fechaRegistro, a.idUsuario, a.idProducto, a.tara, a.pesoBruto, a.pesoNeto, a.costo, a.idStatus, a.idProveedor, a.idTraspaso, c.producto, c.costo AS Expr2
FROM     almacenMateriaPrimaSeguimiento AS a INNER JOIN
                  catalogoMP AS c ON a.idProducto = c.idProducto
WHERE  (a.fechaRegistro BETWEEN @fechaInicial AND @fechaFinal) AND (a.idStatus = 1)";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        cmd.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        #endregion
        #region Salidas Proceso
        public DataTable ResumenSalidasProceso(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"SELECT a.idProducto, mp.producto, SUM(a.pesoBruto) AS pesoBruto, SUM(a.pesoNeto) AS pesoNeto, COUNT(*) AS pacas
FROM     almacenMateriaPrimaSeguimiento AS a INNER JOIN
                  catalogoMP AS mp ON a.idProducto = mp.idProducto
WHERE  (a.fechaRegistro BETWEEN @fechaInicial AND @fechaFinal) AND (a.idTraspaso >= 3)
GROUP BY a.idProducto, mp.producto";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        cmd.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public DataTable DatallesSalidasProceso(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"SELECT a.idPrimario, a.idEtiqueta, a.fechaRegistro, a.idUsuario, a.idProducto, a.tara, a.pesoBruto, a.pesoNeto, a.costo, a.idStatus, a.idProveedor, a.idTraspaso, c.producto, c.costo AS Expr2
FROM     almacenMateriaPrimaSeguimiento AS a INNER JOIN
                  catalogoMP AS mp ON a.idProducto = mp.idProducto
WHERE  (a.fechaRegistro BETWEEN @fechaInicial AND @fechaFinal) AND (a.idTraspaso >= 3)";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        cmd.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        #endregion
        #region Salidas Proveedores
        public DataTable ResumenSalidasProveedores(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"SELECT a.idProducto, mp.producto, SUM(a.pesoBruto) AS pesoBruto, SUM(a.pesoNeto) AS pesoNeto, COUNT(*) AS pacas
FROM     almacenMateriaPrima AS a INNER JOIN
                  catalogoMP AS mp ON a.idProducto = mp.idProducto
WHERE  (a.fechaRegistro BETWEEN @fechaInicial AND @fechaFinal) AND (a.idStatus = (2))
GROUP BY a.idProducto, mp.producto";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        cmd.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public DataTable DatallesSalidasProveedores(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string selectQuery = @"SELECT a.idPrimario, a.idEtiqueta, a.fechaRegistro, a.idUsuario, a.idProducto, a.tara, a.pesoBruto, a.pesoNeto, a.costo, a.idStatus, a.idProveedor, a.idTraspaso, c.producto, c.costo AS Expr2
FROM     almacenMateriaPrima AS a INNER JOIN
                  catalogoMP AS c ON a.idProducto = c.idProducto
WHERE  (a.fechaRegistro BETWEEN @fechaInicial AND @fechaFinal) AND (a.idStatus = (2))S
GROUP BY a.idProducto, mp.producto)";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        cmd.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                        cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        #endregion
    }
}
