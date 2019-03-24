using appWebAPIClient.Application;
using appWebAPIClient.Service.Services.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Globalization;
using System.Threading;
using Unity;

namespace ConsoleApplication
{
    class Program
    {        

        static void Main(string[] args)
        {
            string cpf = "05039162693";

            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
                        
            var container = new Microsoft.Practices.Unity.UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IClientAppService>();

            #region Salvar
            try
            {               

                //List<Phone> listPhones = new List<Phone>
                //{
                //    new Phone {ClientId = 3, Number = "1111"},
                //    new Phone {ClientId = 3, Number = "2222"},
                //    new Phone {ClientId = 3, Number = "3333"}
                //};

                //Client client = new Client(cpf, "Rua Nogueira de Paiva, 30 Casa 09", "Jean Tadeu Ferreira", "jeantf@gmail.com", MaritalStatus.Single, null);

                //service.Register(client);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion            

            try
            {
                var clients = service.GetAll();

                foreach(var c in clients)
                {
                    Console.WriteLine(c.Name +"\t" + c.Address);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
}
