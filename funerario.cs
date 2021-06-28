using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tarea7
{
    class funerario : IObservador
    {
        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemanomina;Integrated Security=True");



        public void Actualizar()
        {
            if (descuentos.funerario > 0)
            {
                descuentos.salarioneto = descuentos.salarioneto - descuentos.funerario;
            }

        }

        public void agregarplanemple()
        {

            try
            {
            
                Console.WriteLine("Ingrese la cedula del empleado: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                int funerariox = 0;

                decimal salarioz;


                cone.Open();
                SqlCommand comando = new SqlCommand($"SELECT salario FROM EMPLEADO WHERE cedula ={cedula}", cone);

                SqlDataReader reader = comando.ExecuteReader();


             

                if (reader.Read())
                {
                    salarioz = Convert.ToDecimal(reader["salario"].ToString());
                    cone.Close();
                    cone.Open();

                    if (salarioz > 15000)
                    {
                        funerariox = Convert.ToInt32(salarioz * 3 / 100);

                        string query = $"UPDATE EMPLEADO SET funerario = {funerariox} WHERE cedula = {cedula}";
                        comando = new SqlCommand(query, cone);
                        comando.ExecuteNonQuery();


                        Console.WriteLine("---------     VALOR CALCULADO   ---------------");
                        Console.WriteLine("CEDULA: " + cedula);
                        Console.WriteLine("PORCENTAJE EXTRAIDO (3% DEL SALARIO):  " + funerariox);
                        Console.WriteLine("-----------------------------------------------");
                    }
                    else
                    {

                        Console.WriteLine("USTED NO APLICA PARA EL DESCUENTO DEL PLAN FUNERARIO");
                   

                    }


                }
                else
                {
                    Console.WriteLine("No se puede actualizar");

                }

                cone.Close();

            }
            catch (Exception hola)
            {
                Console.WriteLine(hola);

            }


        }

        public void cancelar()
        {

            try
            {

                Console.WriteLine("Ingrese la cedula del empleado: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                int funex;

                cone.Open();
                SqlCommand comando = new SqlCommand($"SELECT funerario FROM EMPLEADO WHERE cedula ={cedula}", cone);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    funex = Convert.ToInt32(reader["funerario"].ToString());
                    cone.Close();
                    cone.Open();


                    if (funex > 0)
                    {
                 
                        string query = $"UPDATE EMPLEADO SET funerario = {0} WHERE cedula = {cedula}";
                        comando = new SqlCommand(query, cone);
                        comando.ExecuteNonQuery();


                        Console.WriteLine("---------   PLAN ELIMINADO DEL EMPLEADO SASTIFACTORIAMENTE ---------------");
                        Console.WriteLine("CEDULA: " + cedula);
                        Console.WriteLine("-----------------------------------------------");



                    }
                    else
                    {
                        Console.WriteLine("NO SE PUEDE ELMININAR, YA QUE EL EMPLEADO NO TIENE EL PLAN");
                    }
                }
                else
                {
                    Console.WriteLine("No se puede actualizar");

                }

                cone.Close();

            }
            catch (Exception hola)
            {
                Console.WriteLine(hola);

            }





        }


    }
    }

