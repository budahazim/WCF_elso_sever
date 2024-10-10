using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_elso_kliens.ServiceReference1;

namespace WCF_elso_kliens
{
    internal class Program
    {
        static ServiceReference1.Service1Client client;
        static void Main(string[] args)
        {
            client = new ServiceReference1.Service1Client();
            Eloado eloado = client.GetEloado();
            CD cd = client.GetCD();
            Console.WriteLine(cd.CdCim);
            Console.WriteLine(eloado.eloadoName);
            Console.ReadKey();
        }
    }
}
