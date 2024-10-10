using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.PeerResolvers;
using System.ServiceModel.Web;
using System.Text;
using WCF_elso_sever.Models;
namespace WCF_elso_sever
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Eloado> GetEloado();
        [OperationContract]
        string GetEloadoName();
        [OperationContract]
        Zeneszam GetZeneszam();
        [OperationContract]
        CD GetCD();
        [OperationContract]
        string UjEloado(Eloado ujEloado);
        [OperationContract]
        string ModositEloado(Eloado eloado);
        [OperationContract]
        string TorolEloado(int id);
        [OperationContract]
        string UjZeneszam(Zeneszam ujszeneszam);
        [OperationContract]
        string ModositZeneszam(Zeneszam zeneszam);
        [OperationContract]
        string TorolZeneszam(int id2);
    }
}
