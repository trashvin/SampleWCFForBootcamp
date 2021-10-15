using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessorTCPService.Model;
namespace PaymentProcessorTCPService
{
    public class PaymentProcessorTCPService : IPaymentProcessor
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
