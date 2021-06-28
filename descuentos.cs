using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea7
{
    class descuentos
    {
        public static int salario { get; set; }
        public static int salarioneto { get; set; }
        public static int cooperativa{ get; set; }
        public static int farmacia { get; set; }
        public static int funerario { get; set; }

        

        public List<IObservador> plan = new List<IObservador>();

        public void agregarplan(IObservador observador)
        {
            plan.Add(observador);
        }

        public void quitarplan(IObservador observador)
        {
            plan.Remove(observador);
        }

        public void Notificar()
        {
            foreach (var elemento in plan)
            {
                elemento.Actualizar();
            }
        }

        public void descontar(decimal salariox, int cooperativax, int farmaciax, int funerariox)
        {
            salario =Convert.ToInt32(salariox);
            salarioneto = salario;
            cooperativa = cooperativax;
            farmacia    = farmaciax;
            funerario   = funerariox;
           
            Notificar();
        }


    }
}
