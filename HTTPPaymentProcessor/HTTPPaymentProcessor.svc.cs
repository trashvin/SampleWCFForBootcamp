using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using HTTPPaymentProcessor.Model;

using PaymentLogic;

namespace HTTPPaymentProcessor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class HTTPPaymentProcessor : IPaymentProcessor
    {

        public Model.ProcessResult Process(Model.PaymentTransaction transaction)
        {
            PaymentLogic.ProcessTender processor = new ProcessTender();
            PaymentLogic.Result result = new Result();
            result = processor.Process(
                transaction.TransactionID,
                transaction.TransactionAmount,
                transaction.PaymentAmount,
                transaction.TenderType
            );

            ProcessResult httpResult = new ProcessResult() 
            { 
                Result = result.ProcessResult, 
                Reason = result.Reason
            };

            return httpResult;
        }

        public List<Model.ProcessResult> ProcessBatch(List<Model.PaymentTransaction> transactions)
        {
            PaymentLogic.ProcessTender processor = new ProcessTender();
            PaymentLogic.Result result = new Result();
            List<Model.ProcessResult> results = new List<ProcessResult>();

            foreach(var transaction in transactions)
            {
                result = processor.Process(
                    transaction.TransactionID,
                    transaction.TransactionAmount,
                    transaction.PaymentAmount,
                    transaction.TenderType
                );

                results.Add(new ProcessResult()
                {
                    Result = result.ProcessResult,
                    Reason = result.Reason
                });
            }

            return results;
        }
    }
}
