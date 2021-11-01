using Entities_POJOS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ExceptionManager
    {
        public string PATH = "";

        private static ExceptionManager instance;

        private static Dictionary<int, ApplicationMessage> messages = new Dictionary<int, ApplicationMessage>();

        private ExceptionManager()
        {
            LoadMessages();
            PATH = ConfigurationManager.AppSettings.Get("LOG_PATH");
        }

        public static ExceptionManager GetInstance()
        {
            if (instance == null)
                instance = new ExceptionManager();

            return instance;
        }

        public void Process(Exception ex)
        {

            var bex = new BussinessException();


            if (ex.GetType() == typeof(BussinessException))
            {
                bex = (BussinessException)ex;
                bex.ExceptionDetails = GetMessage(bex).Message;
            }
            else
            {
                bex = new BussinessException(0, ex);
            }

            ProcessBussinesException(bex);

        }

        private void ProcessBussinesException(BussinessException bex)
        {
            //2021022009            
            var today = DateTime.Now.ToString("yyyyMMdd_HH");
            var logName = PATH + today + "_" + "log.txt";

            var message = bex.ExceptionDetails + "\n" + bex.StackTrace + "\n";

            //if (bex.InnerException!=null)
            //    message += bex.InnerException.Message + "\n" + bex.InnerException.StackTrace;

            using (StreamWriter w = File.AppendText(logName))
            {
                Log(message, w);
            }

            bex.AppMessage = GetMessage(bex);

            throw bex;

        }

        public ApplicationMessage GetMessage(BussinessException bex)
        {

            var appMessage = new ApplicationMessage
            {
                Message = "Message not found!"
            };

            if (messages.ContainsKey(bex.ExceptionId))
                appMessage = messages[bex.ExceptionId];

            return appMessage;

        }

        private void LoadMessages()
        {
            messages.Add(0, new ApplicationMessage { Id = 0, Message = "Error en el sistema." });

            //Cliente
            messages.Add(1, new ApplicationMessage { Id = 1, Message = "Error. No se pudo crear el cliente correctamente." });
            messages.Add(2, new ApplicationMessage { Id = 2, Message = "Error. No se pudo listar los clientes correctamente." });
            messages.Add(3, new ApplicationMessage { Id = 3, Message = "Error. No se pudo actualizar el cliente correctamente." });
            messages.Add(4, new ApplicationMessage { Id = 4, Message = "Error. No se pudo encontrar el cliente." });
            messages.Add(5, new ApplicationMessage { Id = 5, Message = "Error. No se pudo eliminar el cliente correctamente." });

            //Direccion
            messages.Add(6, new ApplicationMessage { Id = 6, Message = "Error. No se pudo crear la dirección correctamente." });
            messages.Add(7, new ApplicationMessage { Id = 7, Message = "Error. No se pudo listar las direcciones correctamente." });
            messages.Add(8, new ApplicationMessage { Id = 8, Message = "Error. No se pudo actualizar la dirección correctamente." });
            messages.Add(9, new ApplicationMessage { Id = 9, Message = "Error. No se pudo encontrar la dirección." });
            messages.Add(10, new ApplicationMessage { Id = 10, Message = "Error. No se pudo eliminar la dirección correctamente." });

            //Creditos
            messages.Add(11, new ApplicationMessage { Id = 11, Message = "Error. No se pudo crear el crédito correctamente." });
            messages.Add(12, new ApplicationMessage { Id = 12, Message = "Error. No se pudo listar los creditos correctamente." });
            messages.Add(13, new ApplicationMessage { Id = 13, Message = "Error. No se pudo actualizar el crédito correctamente." });
            messages.Add(14, new ApplicationMessage { Id = 14, Message = "Error. No se pudo encontrar el crédito." });
            messages.Add(15, new ApplicationMessage { Id = 15, Message = "Error. No se pudo eliminar el crédito correctamente." });

            //Cuentas
            messages.Add(16, new ApplicationMessage { Id = 16, Message = "Error. No se pudo crear la cuenta correctamente." });
            messages.Add(17, new ApplicationMessage { Id = 17, Message = "Error. No se pudo listar las cuentas correctamente." });
            messages.Add(18, new ApplicationMessage { Id = 18, Message = "Error. No se pudo actualizar la cuenta correctamente." });
            messages.Add(19, new ApplicationMessage { Id = 19, Message = "Error. No se pudo encontrar la cuenta." });
            messages.Add(20, new ApplicationMessage { Id = 20, Message = "Error. No se pudo eliminar el crédito correctamente." }); 


            messages.Add(21, new ApplicationMessage { Id = 21, Message = "Error. El cliente tiene que ser mayor de edad." }); 
            messages.Add(22, new ApplicationMessage { Id = 22, Message = "Error. No puede depositar montos menores a 10$." });
            messages.Add(23, new ApplicationMessage { Id = 23, Message = "Error. La tasa de los créditos no podrá ser mayor al 10%." });
            messages.Add(24, new ApplicationMessage { Id = 24, Message = "Error. La información de la provincia es invalido." });

        }

        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
