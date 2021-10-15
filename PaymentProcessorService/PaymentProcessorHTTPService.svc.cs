using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PaymentProcessorService.Model;

namespace PaymentProcessorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PaymentProcessorHTTPService : IPaymentProcessor
    {

        public Model.ProcessResult Process(Model.PaymentTransaction transaction)
        {
            ProcessResult result = new ProcessResult() { Result = "SUCCESS", Reason = "APPROVED" };

            return result;
        }

        public List<Model.ProcessResult> ProcessBatch(List<Model.PaymentTransaction> transactions)
        {
            List<Model.ProcessResult> results = new List<ProcessResult>();
            results.Add(new ProcessResult() { Result = "SUCCESS", Reason = "APPROVED" });
            results.Add(new ProcessResult() { Result = "FAILED", Reason = "DECLINED" });

            return results;
        }
    }
}
