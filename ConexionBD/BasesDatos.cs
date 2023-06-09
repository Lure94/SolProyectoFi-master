using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConexionBD
{
    public class BasesDatos
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AO87L5U\\LURESERVER;Initial Catalog = SegurosSA;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public string mensaje;

        public BasesDatos()
        {
            try
            {
                con.Open();
                mensaje = "Conexion exitosa";
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            con.Close();
        }

        public String Insertar(string nomb, string ced, int edad, char sexo, float sal)
        {
            try
            {
                con.Open();
                string cadena = "INSERT INTO Empleados(Nombre, Cedula, Edad, Sexo, Salario)" +
                    "VALUES('" + nomb + "','" + ced + "','" + edad + "','" + sexo + "','" + sal + "')";
                cmd = new SqlCommand(cadena, con);
                cmd.ExecuteNonQuery();
                mensaje = "Datos enviados a la base de datos";
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            con.Close();
            return mensaje;
        }
    }
}
