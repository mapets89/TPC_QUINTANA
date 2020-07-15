using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Microsoft.Win32;

namespace Negocio
{

    public class UsuarioNegocio
    {
        AccesoDB conexionDB = new AccesoDB();
        public void Agregar(Usuario usuario)
        {
            try
            {
                conexionDB.SetearSP("SP_AGREGAR_USUARIO");
                conexionDB.agregarParametro("@Nombre", usuario.nombre);
                conexionDB.agregarParametro("@Apellido", usuario.apellido);
                conexionDB.agregarParametro("@Dni", usuario.dni);
                conexionDB.agregarParametro("@Mail", usuario.email);
                conexionDB.agregarParametro("@Username", usuario.userName);
                conexionDB.agregarParametro("@Contraseña", usuario.password);
                conexionDB.agregarParametro("@Iddireccion", usuario.direccion.id);
                conexionDB.agregarParametro("@Tipo", usuario.privilegio);
                conexionDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDB.cerrarConexion();
            }
        }
        public int BuscarUsuario(Usuario usuario)
        {
            int id = 0;
            try
            {
                conexionDB.SetearSP("SP_BUSCAR_USUARIO");
                //conexionDB.setearQuery("EXEC SP_BUSCAR_DIRECCION");
                conexionDB.agregarParametro("@NombreUsuario", usuario.userName);
                conexionDB.agregarParametro("@Mail", usuario.email);
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    id = conexionDB.lector.GetInt32(0);
                    if (id != 0)
                    {
                        usuario.id = (int)conexionDB.lector["idUsuario"];
                        break;
                    }
                }
                return id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexionDB.cerrarConexion();
            }
        }
        public void DetalleUsuario(Usuario usuario)
        {
            try
            {
                conexionDB.setearQuery("EXEC SP_BUSCAR_USUARIO_COMPLETO @IdUsuario = "+usuario.id.ToString());
                //conexionDB.agregarParametro("@IdUsuario", 1);
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    usuario.id = conexionDB.lector.GetInt32(0);
                    usuario.privilegio = conexionDB.lector.GetInt32(1);
                    usuario.nombre = (string)conexionDB.lector["nombreUsuario"];
                    usuario.apellido = (string)conexionDB.lector["apellidoUsuario"];
                    usuario.dni = conexionDB.lector.GetInt32(4);
                    usuario.email = (string)conexionDB.lector["mailUsuario"];
                    usuario.userName = (string)conexionDB.lector["usernameUsuario"];
                    usuario.direccion.id = conexionDB.lector.GetInt32(7);
                    usuario.direccion.calle = (string)conexionDB.lector["calleDireccion"];
                    usuario.direccion.altura = (int)conexionDB.lector["alturaDireccion"];
                    usuario.password= (string)conexionDB.lector["passwordUsuario"];
                    usuario.direccion.localidad = (string)conexionDB.lector["localidadDireccion"];
                    usuario.direccion.provincia = (string)conexionDB.lector["provinciaDireccion"];
                    usuario.direccion.descripcion = (string)conexionDB.lector["descripcionDireccion"];

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDB.cerrarConexion();
            }
        }
        public void Modificar(Usuario usuario)
        {
            try
            {
                conexionDB.SetearSP("SP_MODIFICAR_USUARIO");
                conexionDB.agregarParametro("@Id", usuario.id);
                conexionDB.agregarParametro("@Nombre", usuario.nombre);
                conexionDB.agregarParametro("@Apellido", usuario.apellido);
                conexionDB.agregarParametro("@Dni", usuario.dni);
                conexionDB.agregarParametro("@Mail", usuario.email);
                conexionDB.agregarParametro("@Username", usuario.userName);
                conexionDB.agregarParametro("@Contraseña", usuario.password);
                conexionDB.agregarParametro("@Iddireccion", usuario.direccion.id);
                conexionDB.agregarParametro("@Tipo", usuario.privilegio);
                conexionDB.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDB.cerrarConexion();
            }
        }
        public List<Usuario> Listar()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();
            Usuario usuario;
            try
            {
                conexionDB.SetearSP("SP_LISTAR_USUARIOS");
                conexionDB.ejecutarLector();
                while (conexionDB.lector.Read())
                {
                    usuario = new Usuario();
                    usuario.id = conexionDB.lector.GetInt32(0);
                    usuario.privilegio = conexionDB.lector.GetInt32(1);
                    usuario.nombre = (string)conexionDB.lector["nombreUsuario"];
                    usuario.apellido = (string)conexionDB.lector["apellidoUsuario"];
                    usuario.dni = conexionDB.lector.GetInt32(4);
                    usuario.email = (string)conexionDB.lector["mailUsuario"];
                    usuario.userName = (string)conexionDB.lector["usernameUsuario"];
                    usuario.direccion.id = conexionDB.lector.GetInt32(7);
                    usuario.direccion.calle = (string)conexionDB.lector["calleDireccion"];
                    usuario.direccion.altura = (int)conexionDB.lector["alturaDireccion"];
                    usuario.password = (string)conexionDB.lector["passwordUsuario"];
                    usuario.direccion.localidad = (string)conexionDB.lector["localidadDireccion"];
                    usuario.direccion.provincia = (string)conexionDB.lector["provinciaDireccion"];
                    usuario.direccion.descripcion = (string)conexionDB.lector["descripcionDireccion"];
                    listadoUsuarios.Add(usuario);
                }
                return listadoUsuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDB.cerrarConexion();
            }
        }

    }
}
