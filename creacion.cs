using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace tarea7
{
    class creacion
    {

        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemanomina;Integrated Security=True");
        SqlCommand comando;

        public void crearemple()
        {
            try {

            int cedula;
            string nombre;
            string cargo;
            decimal salario;
            int cooperativax = 0;
            int farmaciax    = 0;
            int funerariox   = 0;


            int afp;
            int sfs;


            Console.WriteLine("Ingrese la cedula");
            cedula = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el cargo");
            cargo = Console.ReadLine();
            Console.WriteLine("Ingrese el salario");
            salario = Convert.ToInt32(Console.ReadLine());

            double salariox = Convert.ToDouble(salario);

            afp = Convert.ToInt32(salariox * 2.87 / 100);
            sfs = Convert.ToInt32(salariox * 3.04 / 100);


            decimal totalsalario = Convert.ToDecimal(salariox);

            cone.Open();
            comando = new SqlCommand($"INSERT INTO empleado VALUES('{cedula}','{nombre}','{cargo}','{totalsalario}','{afp}','{sfs}','{cooperativax}','{farmaciax}','{funerariox}','0')", cone);
            comando.ExecuteNonQuery();
            cone.Close();

                Console.WriteLine("EMPLEADO CREADO!");
            }

            catch(Exception hola)
            
            {
                Console.WriteLine(hola);
                Console.ReadKey();
             
            }

        }

    }
}
