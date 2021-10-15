using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using HTTPPaymentProcessor.Model;

namespace HTTPPaymentProcessor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPaymentProcessor
    {
        [OperationContract]
        ProcessResult Process(PaymentTransaction transaction);

        [OperationContract]
        List<ProcessResult> ProcessBatch(List<PaymentTransaction> transactions);   
    }


}
