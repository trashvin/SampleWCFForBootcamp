using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using TCPPaymentProcessor.Model;
namespace TCPPaymentProcessor
{
    public class TCPPaymentProcessor : IPaymentProcessor
    {
        public Model.ProcessResult Process(Model.PaymentTransaction transaction)
        {
            ProcessResult result = new ProcessResult() { Result = "FAILED", Reason = "INVALID" };

            return result;
        }

        public List<Model.ProcessResult> ProcessBatch(List<Model.PaymentTransaction> transactions)
        {
            List<Model.ProcessResult> results = new List<ProcessResult>();
            results.Add(new ProcessResult() { Result = "SUCCESS", Reason = "APPROVED" });
            results.Add(new ProcessResult() { Result = "FAILED", Reason = "INVALID" });
            results.Add(new ProcessResult() { Result = "SUCCESS", Reason = "APPROVED" });

            return results;
        }
    }
}
