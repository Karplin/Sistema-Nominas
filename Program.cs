using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace tarea7
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemanomina;Integrated Security=True");
            SqlDataAdapter sda;
            DataSet dts;
            DataTable dtt;

            creacion crearx = new creacion();
           

            //PATRON OBSERVER
            descuentos  descuento    = new descuentos(); //Sujeto 
            cooperativa co     = new cooperativa(); // Observadoras
            farmacia    fa     = new farmacia();
            funerario   fu     = new funerario();
        
            
            int opcion1 = 0;

            try
            {
                do
                {
                    Console.WriteLine("**********************");
                    Console.WriteLine("  SISTEMA DE NOMINAS  ");
                    Console.WriteLine("**********************");
                    Console.WriteLine("");
                    Console.WriteLine("Seleccione una aplicacion \n" +
                        "\n1.CREACION DE EMPLEADOS" +
                        "\n2.CALCULO - NOMINA" +
                        "\n3.REGISTRO CONSUMO - FARMACIA" +
                        "\n4.INSCRIPCION /CANCELACION - PLANES" +
                        "\n5.Salir\n"
                        );

                    int principal = 0;
                    principal = Convert.ToInt32(Console.ReadLine());

                    switch (principal)
                    {
                        //-----------------------------CREACION DE EMPLEADOS--------------------
                        case 1:
                            crearx.crearemple();
                            break;

                     //-----------------------------CALCULO DE LA NOMINA--------------------

                        case 2:

                            DataTable lista()
                            {
                                try
                                {
                                    string tabla = "empleado";
                                    string sql = "SELECT * FROM " + tabla;
                                    cone.Open();

                                    sda = new SqlDataAdapter(sql, cone);
                                    dts = new DataSet();
                                    sda.Fill(dts, tabla);
                                    dtt = dts.Tables[tabla];

                                }
                                catch (Exception e)
                                {

                                    throw e;
                                }
                                finally
                                {

                                    cone.Close();
                                }
                                return dtt;

                            }
                         
                                foreach (DataRow item in lista().Rows)
                            {
                                    int salarioneto;
                                    decimal salariobruto = Convert.ToDecimal(item["salario"].ToString());
                                    int afp = Convert.ToInt32(item["afp"].ToString());
                                    int sfs = Convert.ToInt32(item["sfs"].ToString());
                                    int cooperativa = Convert.ToInt32(item["cooperativa"].ToString());
                                    int farmacia = Convert.ToInt32(item["farmacia"].ToString());
                                    int funerario = Convert.ToInt32(item["funerario"].ToString());
                                    descuento.descontar(salariobruto, cooperativa, farmacia, funerario);
                                    int salary = Convert.ToInt32(salariobruto);


                                    salary = descuentos.salarioneto;
                                    salarioneto = salary - afp - sfs ;

                                    Console.WriteLine("");
                                    Console.WriteLine("----------DATOS DEL EMPLEADO------------");
                                    Console.WriteLine("Nombre: " + item["nombre"].ToString());
                                    Console.WriteLine("Salario Bruto: " + descuentos.salario);
                                    Console.WriteLine("AFP: " + afp);
                                    Console.WriteLine("SFS: " + sfs);
                                    Console.WriteLine("Cooperativa: " + descuentos.cooperativa);
                                    Console.WriteLine("Farmacia: " + descuentos.farmacia);
                                    Console.WriteLine("Funerario: " + descuentos.funerario);
                                    Console.WriteLine("Salario Neto: " + salarioneto);
                                    Console.WriteLine("----------------------------------------");



                                }

                            break;
                        //----------------------------- REGISTRO DE CONSUMO  -  FARMACIA --------------------
                        case 3:

                            Console.Clear();
                            Console.WriteLine("***********************************************");
                            Console.WriteLine(" REGISTRO DE CONSUMO  -  FARMACIA ");
                            Console.WriteLine("***********************************************");
                            Console.WriteLine("");
                            Console.WriteLine("Seleccione una opción\n" +
                                "\n1.Agregar Consumo" +
                                "\n2.Ver Empleado" +
                                "\n3.Salir\n"
                                );
                            int optionfamarcia = 0;
                            optionfamarcia = Convert.ToInt32(Console.ReadLine());

                            switch (optionfamarcia)
                            {
                                case 1:
                                    fa.consumir();
                                    break;

                                case 2:
                                    fa.verempleado();
                                    break;

                                case 3:
                                    break;

                            }

                            break;

                  
                        //----------------------------- INSCRIPCION / CANCELACION DE PLANES + PATRON OBSERVER --------------------
                        case 4:

                            Console.Clear();
                            Console.WriteLine("***********************************************");
                            Console.WriteLine("  INSCRIPCION / CANCELACION DE PLANES ");
                            Console.WriteLine("***********************************************");
                            Console.WriteLine("");
                            Console.WriteLine("Seleccione una opción\n" +
                                "\n1.Cooperativa" +
                                "\n2.Farmacia" +
                                "\n3.Plan Funerario" +
                                "\n4.Salir\n"
                                );

                            int optionincri = 0;
                            optionincri = Convert.ToInt32(Console.ReadLine());

                            switch (optionincri)
                            {
                                //-----------------------------COOPERATIVA--------------------
                                case 1:
                                    Console.WriteLine("Seleccione una opción\n" +
                                     "\n1.Inscribir" +
                                     "\n2.Cancelar" +
                                     "\n3.Salir"
                                      );

                                    int optionco = 0;
                                    optionco = Convert.ToInt32(Console.ReadLine());

                                    switch (optionco)
                                    {
                                        case 1:
                                            co.agregarplanemple();
                                            descuento.agregarplan(co);
                                        
                                            break;
                                            
                                        case 2:
                                            co.cancelar();
                                            descuento.quitarplan(co);
                                            break;

                                        case 3:
                                            break;

                                    }
                                  
                                    break;
                                //-----------------------------FARMACIA--------------------
                                case 2:

                                    Console.WriteLine("Seleccione una opción\n" +
                                     "\n1.Inscribir" +
                                     "\n2.Cancelar" +
                                     "\n3.Salir"
                                      );

                                    int optionfa = 0;
                                    optionfa = Convert.ToInt32(Console.ReadLine());

                                    switch (optionfa)
                                    {
                                        case 1:
                                            fa.agregarplanemple();
                                            descuento.agregarplan(fa);
                                            break;

                                        case 2:
                                            fa.cancelar();
                                            descuento.quitarplan(fa);
                                            break;

                                        case 3:
                                            break;

                                    }
                                    break;
                                //----------------------------PLAN FUNERARIO--------------------
                                case 3:

                                    Console.WriteLine("Seleccione una opción\n" +
                                    "\n1.Inscribir" +
                                    "\n2.Cancelar" +
                                    "\n3.Salir"
                                     );

                                    int optionfune = 0;
                                    optionfune = Convert.ToInt32(Console.ReadLine());

                                    switch (optionfune)
                                    {
                                        case 1:
                                            fu.agregarplanemple();
                                            descuento.agregarplan(fu);
                                            break;

                                        case 2:
                                            fu.cancelar();
                                            descuento.quitarplan(fu);
                                            break;

                                        case 3:
                                            break;
                                    }
                                    break;

                                case 4:
                                    break;
                            }


                            break;

                        case 5:
                            Environment.Exit(0);
                            break;

                    }



                    Console.WriteLine("Quieres volver al menu principal? Pulse 1, de lo contrario otro numero ");
                    opcion1 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.ReadKey();

                } while (opcion1 == 1);


            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                Console.ReadKey();
            }

        }
    }
}
