using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumno" in both code and config file together.
    [ServiceContract]
    public interface IAlumno   //Contrato 
    {
        [OperationContract]
        ML.Result Add(ML.Alumno alumno);  //Firma de metodos

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL.Result GetAll();
    }
}
