using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_elso_sever.Models;
using WCF_elso_sever.Controllers;

namespace WCF_elso_sever
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        public CD GetCD()
        {
            CD cd = new CD()
            { 
                CdAz = 1,
                CdCim = "Certified Lover Boy",
                Kiado = "O&T arnot"
            };
            return cd;
        }

       public List<Eloado> GetEloado()
        {
            List<Eloado> eloado = new EloadoController().EloadokLista();
            return eloado;
        }

        public string UjEloado(Eloado ujEloado)
        {

            return new EloadoController().InsertEloado(ujEloado);
        }

        public string GetEloadoName()
        {
            Eloado eloado1 = new Eloado()
            {
                eloadoAz = 1,
                eloadoName = "Queen"
            };
            return eloado1.eloadoName;
        }

    

       

        string IService1.ModositEloado(Eloado eloado)
        {
            return new EloadoController().UpdateEloado(eloado);
        }

        public string TorolEloado(int id)
        {
            return new EloadoController().TorolEloado(id);
        }
        public List<Zeneszam> GetZeneszam()
        {
            List<Zeneszam> zeneszam = new EloadoController.ZeneszamController().ZeneszamokLista();
            return zeneszam;
        }
        public string UjZeneszam(Zeneszam ujZeneszam)
        {

            return new EloadoController.ZeneszamController().InsertZeneszam(ujZeneszam);
        }

        string IService1.ModositZeneszam(Zeneszam zeneszam)
        {
            return new EloadoController.ZeneszamController().UpdateZeneszam(zeneszam);
        }

        public string TorolZeneszam(int id2)
        {
            return new EloadoController.ZeneszamController().TorolZeneszam(id2);
        }
        Zeneszam IService1.GetZeneszam()
        {
            throw new NotImplementedException();
        }
    }
}