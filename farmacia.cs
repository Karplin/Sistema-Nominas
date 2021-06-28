using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tarea7
{
    class farmacia : IObservador
    {
        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemanomina;Integrated Security=True");


        public void Actualizar()
        {
            if (descuentos.farmacia > 0)
            {
                descuentos.salarioneto = descuentos.salarioneto - descuentos.farmacia;
            }

        }

        public void agregarplanemple()
        {
            

            Console.WriteLine("Ingrese la cedula del empleado: ");
            int cedula = Convert.ToInt32(Console.ReadLine());

            bool validarfarma;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT validarfarma FROM EMPLEADO WHERE cedula ={cedula}", cone);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                validarfarma = Convert.ToBoolean(reader["validarfarma"].ToString());

                cone.Close();
                cone.Open();

                if (validarfarma == false)
                {

                    string query = $"UPDATE EMPLEADO SET validarfarma = '1' WHERE cedula = {cedula}";
                    comando = new SqlCommand(query, cone);
                    comando.ExecuteNonQuery();

                    Console.WriteLine("EMPLEADO INSCRITO CORRECTAMENTE AL PLAN FARMACIA");
                }

                else
                {

                    Console.WriteLine("EL EMPLEADO YA TIENE UN PLAN FARMACIA");

                }

            }
            else
            {
                Console.WriteLine("No se puede actualizar");

            }

            cone.Close();
        }



        public void consumir()
        {
                bool validarfarmacia;

                Console.WriteLine("Ingrese la cedula del empleado: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el consumo del empleado: ");
                int farmaciax = Convert.ToInt32(Console.ReadLine());

    
                cone.Open();
                SqlCommand comando = new SqlCommand($"SELECT salario, farmacia, validarfarma FROM EMPLEADO WHERE cedula ={cedula}", cone);

                SqlDataReader reader = comando.ExecuteReader();


                if (reader.Read())
                {
                   decimal salarioy = Convert.ToDecimal(reader["salario"].ToString());
                   int farmaciaz = int.Parse(reader["farmacia"].ToString());
                   validarfarmacia = Convert.ToBoolean(reader["validarfarma"].ToString());
                 

                    cone.Close();
                    cone.Open();

                if(validarfarmacia==true){

                    if (farmaciax > salarioy)
                    {

                        Console.WriteLine("NO PUEDE CONSUMIR ESA CANTIDAD YA QUE ES MAYOR AL SALARIO, INTENTE DE NUEVO");

                    }
                    else
                    {

                        decimal total1 = farmaciax / 2;
                        decimal total2 = total1 + farmaciaz;


                        string query = $"UPDATE EMPLEADO SET farmacia = {total2} WHERE cedula = {cedula}";
                        comando = new SqlCommand(query, cone);
                        comando.ExecuteNonQuery();


                        Console.WriteLine("---------     VALOR CALCULADO   ---------------");
                        Console.WriteLine("CEDULA: " + cedula);
                        Console.WriteLine("PORCENTAJE EXTRAIDO (MITAD DEL MONTO):  " + total1);
                        Console.WriteLine("SU NUEVO MONTO ES :  " + total2);
                        Console.WriteLine("-----------------------------------------------");
                    }


                }

                else
                {
                    Console.WriteLine("ESTE EMPLEADO NO TIENE UN PLAN FARMACIA");

                }
             
            }


            else
            {
                Console.WriteLine("No se puede actualizar");

            }


            cone.Close();

         

        }

        public void verempleado()
        {

            Console.WriteLine("Ingrese la cedula del empleado: ");
            int cedulaemple = Convert.ToInt32(Console.ReadLine());

            int consultafarma = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT farmacia FROM EMPLEADO WHERE cedula ={cedulaemple}", cone);

            SqlDataReader reader = comando.ExecuteReader();


            if (reader.Read())
            {
                consultafarma = int.Parse(reader["farmacia"].ToString());
                cone.Close();
                cone.Open();

                Console.WriteLine("---------     CONSULTA DEL PLAN ---------------");
                Console.WriteLine("Cedula:  " + cedulaemple);
                Console.WriteLine("Su monto es: " + consultafarma);
                Console.WriteLine("-----------------------------------------");

            }
            else
            {
                Console.WriteLine("No se puede encontrar la cuenta, intente de nuevo");

            }




            cone.Close();


        }

        public void cancelar()
        {

             bool validarfarmacia;

                Console.WriteLine("Ingrese la cedula del empleado: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                cone.Open();
                SqlCommand comando = new SqlCommand($"SELECT farmacia, validarfarma FROM EMPLEADO WHERE cedula ={cedula}", cone);

                SqlDataReader reader = comando.ExecuteReader();


                if (reader.Read())
                {

                   validarfarmacia = Convert.ToBoolean(reader["validarfarma"].ToString());

                    cone.Close();
                    cone.Open();

                if(validarfarmacia==true){

                        string query = $"UPDATE EMPLEADO SET farmacia = {0}, validarfarma = {0} WHERE cedula = {cedula}";
                        comando = new SqlCommand(query, cone);
                        comando.ExecuteNonQuery();


                        Console.WriteLine("---------   PLAN ELIMINADO DEL EMPLEADO SASTIFACTORIAMENTE ---------------");
                        Console.WriteLine("CEDULA: " + cedula);
                        Console.WriteLine("-----------------------------------------------");
                }

                else
                {
                    Console.WriteLine("ESTE EMPLEADO NO TIENE UN PLAN FARMACIA");

                }
             
            }


            else
            {
                Console.WriteLine("No se puede actualizar");

            }


            cone.Close();





        }


    }
}
