using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tarea7
{
    class cooperativa : IObservador
    {
        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemanomina;Integrated Security=True");


        public void Actualizar()
        {
            if (descuentos.cooperativa > 0)
            {
                descuentos.salarioneto = descuentos.salarioneto - descuentos.cooperativa;
            }

        }

        public void agregarplanemple()
        {
        
            try { 

            Console.WriteLine("Ingrese la cedula del empleado: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            int cooperativax = 0;

            decimal salarioz;


            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT salario FROM EMPLEADO WHERE cedula ={cedula}", cone);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                salarioz = Convert.ToDecimal(reader["salario"].ToString());
                cone.Close();
                cone.Open();
              
                cooperativax = Convert.ToInt32(salarioz * 5 / 100);

                string query = $"UPDATE EMPLEADO SET cooperativa = {cooperativax} WHERE cedula = {cedula}";
                comando = new SqlCommand(query, cone);
                comando.ExecuteNonQuery();


                Console.WriteLine("---------     VALOR CALCULADO   ---------------");
                Console.WriteLine("CEDULA: " + cedula);
                Console.WriteLine("PORCENTAJE EXTRAIDO (5% DEL SALARIO):  " + cooperativax);
                Console.WriteLine("-----------------------------------------------");
            }
            else
            {
                Console.WriteLine("No se puede actualizar");

            }

            cone.Close();

            }
            catch(Exception hola)
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

                int copex;


                cone.Open();
                SqlCommand comando = new SqlCommand($"SELECT cooperativa FROM EMPLEADO WHERE cedula ={cedula}", cone);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    copex =  Convert.ToInt32(reader["cooperativa"].ToString());
                    cone.Close();
                    cone.Open();


                    if (copex>0) {


                        string query = $"UPDATE EMPLEADO SET cooperativa = {0} WHERE cedula = {cedula}";
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
