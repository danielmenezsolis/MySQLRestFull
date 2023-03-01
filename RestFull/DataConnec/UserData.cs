using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using RestFull.Model;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace RestFull.DataConnec
{
    public class UserData
    {
        [HttpGet]
        [Route("Get")]
        public List<Usuarios> Listar()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            using var connection = new MySqlConnection(Connection.urlConn);
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM Usuario;", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Usuarios user = new Usuarios();
                user.IdUsuario = (int)reader.GetValue(0);
                user.DocumentoIdentidad = (string)reader.GetValue(1);
                user.Nombres = (string)reader.GetValue(2);
                user.Telefono = (string)reader.GetValue(3);
                user.Correo = (string)reader.GetValue(4);
                user.Ciudad = (string)reader.GetValue(5);
                user.FechaRegistro = (DateTime)reader.GetValue(6);
                usuarios.Add(user);
            }
            connection.Close();

            return usuarios;
        }

        [HttpGet]
        [Route("Getid")]
        public List<Usuarios> Listar(int id)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            using var connection = new MySqlConnection(Connection.urlConn);
            connection.Open();

            var query = "SELECT * FROM Usuario";
            query += String.Format(" WHERE IdUsuario = {0};",  id);

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Usuarios user = new Usuarios();
                user.IdUsuario = (int)reader.GetValue(0);
                user.DocumentoIdentidad = (string)reader.GetValue(1);
                user.Nombres = (string)reader.GetValue(2);
                user.Telefono = (string)reader.GetValue(3);
                user.Correo = (string)reader.GetValue(4);
                user.Ciudad = (string)reader.GetValue(5);
                user.FechaRegistro = (DateTime)reader.GetValue(6);
                usuarios.Add(user);
            }
            connection.Close();

            return usuarios;
        }


        [HttpPost]
        [Route("Post")]
        public dynamic Insertar(Usuarios usuario)
        {
            using var connection = new MySqlConnection(Connection.urlConn);
            connection.Open();

            var query = "INSERT INTO Usuario (DocumentoIdentidad,Nombres,Telefono,Correo,Ciudad)";
            query += String.Format("VALUES ('{0}', '{1}', '{2}','{3}','{4}');", usuario.DocumentoIdentidad, usuario.Nombres, usuario.Telefono, usuario.Correo, usuario.Ciudad);

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            return HttpStatusCode.OK;

        }


        [HttpPut]
        [Route("Put")]
        public dynamic Actualizar(Usuarios usuario)
        {
            using var connection = new MySqlConnection(Connection.urlConn);
            connection.Open();

            var query = "UPDATE  Usuario";
            query += String.Format(" SET DocumentoIdentidad = '{0}', Nombres ='{1}', Telefono= '{2}', Correo = '{3}', Ciudad = '{4}' ", usuario.DocumentoIdentidad, usuario.Nombres, usuario.Telefono, usuario.Correo, usuario.Ciudad);
            query += String.Format("WHERE  IdUsuario = {0};", usuario.IdUsuario);

            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            return HttpStatusCode.OK;

        }

    }
}
