using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HTTPServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessorHTTPService.PaymentProcessorClient paymentSystem =
                new PaymentProcessorHTTPService.PaymentProcessorClient();

            Console.WriteLine("Processing 1 transaction .... ");

            PaymentProcessorHTTPService.PaymentTransaction tran1 =
                new PaymentProcessorHTTPService.PaymentTransaction()
                {
                    TransactionID = 1,
                    TransactionAmount = 50,
                    PaymentAmount = 50,
                    TenderType = 1
                };

            PaymentProcessorHTTPService.ProcessResult result =
                new PaymentProcessorHTTPService.ProcessResult();

            result = paymentSystem.Process(tran1);

            Console.WriteLine(String.Format("The result is {0} with reason of {1}", result.Result, result.Reason));

            Console.WriteLine("Processing batch transactions .... ");

            List<PaymentProcessorHTTPService.PaymentTransaction> transactions =
                new List<PaymentProcessorHTTPService.PaymentTransaction>();

            transactions.Add(new PaymentProcessorHTTPService.PaymentTransaction()
                {
                    TransactionID = 1,
                    TransactionAmount = 50,
                    PaymentAmount = 50,
                    TenderType = 1
                });
            transactions.Add(new PaymentProcessorHTTPService.PaymentTransaction()
            {
                TransactionID = 2,
                TransactionAmount = 20,
                PaymentAmount = 30,
                TenderType = 2
            });

            List<PaymentProcessorHTTPService.ProcessResult> results =
                new List<PaymentProcessorHTTPService.ProcessResult>();

            results = paymentSystem.ProcessBatch(transactions.ToArray())
                        .ToList<PaymentProcessorHTTPService.ProcessResult>();

            foreach(var res in results)
            {
                Console.WriteLine(String.Format("The result is {0} with reason of {1}", res.Result, res.Reason));
            }

            Console.ReadLine();
        }
    }
}
