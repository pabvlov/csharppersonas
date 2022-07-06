﻿using form.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace form.Models.DAL
{
    public class PersonaDAL
    {
        static Conexion conexion = new Conexion();
        public List<Persona> get()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                using (SqlConnection con = new SqlConnection(conexion.GetConnectionString()))
                {

                    string sql = "select * from persona";
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Persona p = new Persona(reader["nombre"].ToString(), reader["apellido"].ToString());
                            p.Id = int.Parse(reader["id"].ToString());
                            personas.Add(p);
                        }
                        con.Close();
                    }
                }
            } catch(Exception e)
            {
                Persona p = new Persona(e.ToString(), "");
                personas.Add(p);
            }
               return personas;
        }

        public void agregar(Persona persona)
        {
            string sql = "insert into persona (nombre, apellido) values ('" + persona.nombre + "', '" + persona.apellido + "')";
            query(sql);
        }

        public void borrar(int id)
        {
            string sql = "DELETE FROM persona WHERE id=" + id + ";";
            query(sql);
        }

        public void modificar(int id, string nombre, string apellido)
        {
            string sql = "UPDATE persona SET nombre = '" + nombre + "', apellido = '" + apellido + "' WHERE id=" + id + ";";
            query(sql);
        }

        public void query(string sql)
        {
            using (SqlConnection con = new SqlConnection(conexion.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    int reader = command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
