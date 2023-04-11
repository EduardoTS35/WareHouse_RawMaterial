using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

        public DataTable ver_CatalogoMP()
        {
            DataTable table = userDao.ver_CatalogoMP();
            return table;
        }

        public DataTable ver_CatalogoProveedores()
        {
            DataTable table = userDao.ver_CatalogoProveedores();
            return table;
        }
        public DataTable mostrar_Costo(string idProducto)
        {
            DataTable table = userDao.mostrar_Costo(idProducto);
            return table;
        }
        public DataTable ver_NumEtiqueta()
        {
            DataTable table = userDao.ver_NumEtiqueta();
            return table;
        }
        public DataTable ver_Datos()
        {
            DataTable table = userDao.ver_Datos();
            return table;
        }
        public DataTable ver_Datos(int i)
        {
            DataTable table = userDao.ver_Datos(i);
            return table;
        }

        public void insertarEntradas(int idEtiqueta, int idUsuario, string idProducto, double tara, double pesoBruto, double pesoNeto, double costo, int idStatus, int idProveedor,int idTraspaso)
        {
            userDao.insertarEntradas(idEtiqueta, idUsuario, idProducto, tara, pesoBruto, pesoNeto, costo, idStatus, idProveedor,idTraspaso);
        }
        public void insertarSalidas(int idEtiqueta, int idUsuario, string idProducto, double tara, double pesoBruto, double pesoNeto, double costo, int idStatus, int idProveedor, int idTraspaso)
        {
            userDao.insertarSalidas(idEtiqueta, idUsuario, idProducto, tara, pesoBruto, pesoNeto, costo, idStatus, idProveedor, idTraspaso);
        }
        public DataTable ver_CatalogoTraspaso()
        {
            DataTable table = userDao.ver_CatalogoTraspaso();
            return table;
        }
        public void deshacerMoviemientoEntradas(int idEtiqueta)
        {
            userDao.deshacerMoviemientoEntradas(idEtiqueta);
        }
        public void deshacerMoviemientoSalidas(int idEtiqueta, int idStatusOG, int idStatus, int idTraspaso)
        {
            userDao.deshacerMoviemientoSalidas(idEtiqueta, idStatusOG,idStatus,idTraspaso);
        }
        public void agregarMateria(string id, string desc, double costo)
        {
            userDao.agregarMateria(id, desc, costo);
        }
        public void actualizarMateria(string idOG, string id, string desc, double costo)
        {
            userDao.actualizarMateria(idOG, id, desc, costo);
        }
        public void borrarMaterial(string id)
        {
            userDao.borrarMaterial(id);
        }
        public DataTable verUsuarios()
        {
            DataTable table = userDao.verUsuarios();
            return table;
        }
        public void agregarUsuario(string nombre, string apellido, string usuario, string contraseña, string cargo, string area, string correo)
        {
            userDao.agregarUsuario(nombre, apellido, usuario, contraseña, cargo, area, correo);
        }
        public void actualizarUsuario(string id, string nombre, string apellido, string usuario, string contraseña, string cargo, string area, string correo)
        {
            userDao.actualizarUsuario(Convert.ToInt32(id),nombre,apellido, usuario, contraseña, cargo, area, correo);
        }
        public void borrarUsuario(string id)
        {
            userDao.borrarUsuario(Convert.ToInt32(id));
        }
        public void agregarProveedor(string desc)
        {
            userDao.agregarProveedor(desc);
        }
        public void actualizarProveedor(int id, string desc)
        {
            userDao.actualizarProveedor(id, desc);
        }
        public void borrarProveedor(string id)
        {
            userDao.borrarProveedor(id);
        }
    }
}
