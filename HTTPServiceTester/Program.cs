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
            HTTPPaymentProcessor.PaymentProcessorClient paymentService =
                new HTTPPaymentProcessor.PaymentProcessorClient();

            /*
                1,550,550,1
                2,450,450,3
                3,350,400,2
                4,500,500,4
            */
       
            HTTPPaymentProcessor.PaymentTransaction tran1 =
                new HTTPPaymentProcessor.PaymentTransaction()
                {
                    TransactionID = 1,
                    TransactionAmount = 550,
                    PaymentAmount = 550,
                    TenderType = 5
                };

            HTTPPaymentProcessor.ProcessResult result =
                new HTTPPaymentProcessor.ProcessResult();

            result = paymentService.Process(tran1);

            Console.WriteLine(String.Format("The result is {0} with reason of {1}", result.Result, result.Reason));

            List<HTTPPaymentProcessor.PaymentTransaction> transactions =
                new List<HTTPPaymentProcessor.PaymentTransaction>();

            transactions.Add(new HTTPPaymentProcessor.PaymentTransaction()
            {
                TransactionID = 1,
                TransactionAmount = 350,
                PaymentAmount = 450,
                TenderType = 2
            });
            transactions.Add(new HTTPPaymentProcessor.PaymentTransaction()
            {
                TransactionID = 2,
                TransactionAmount = 10000,
                PaymentAmount = 10000,
                TenderType = 3
            });

            List<HTTPPaymentProcessor.ProcessResult> results =
                new List<HTTPPaymentProcessor.ProcessResult>();

            results = paymentService.ProcessBatch(transactions.ToArray())
                           .ToList<HTTPPaymentProcessor.ProcessResult>();

            foreach (var res in results)
            {
                Console.WriteLine(String.Format("The result is {0} with reason of {1}", res.Result, res.Reason));
            }

            paymentService.Close();

            Console.ReadLine();


        }
    }
}
