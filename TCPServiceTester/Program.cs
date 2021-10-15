using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TCPPaymentService.PaymentProcessorClient paymentService =
                new TCPPaymentService.PaymentProcessorClient();


            TCPPaymentService.PaymentTransaction tran1 =
                new TCPPaymentService.PaymentTransaction()
                {
                    TransactionID = 1,
                    TransactionAmount = 50,
                    PaymentAmount = 50,
                    TenderType = 1
                };

            TCPPaymentService.ProcessResult result =
                new TCPPaymentService.ProcessResult();

            result = paymentService.Process(tran1);

            Console.WriteLine(String.Format("The result is {0} with reason of {1}", result.Result, result.Reason));

            List<TCPPaymentService.PaymentTransaction> transactions =
                new List<TCPPaymentService.PaymentTransaction>();

            transactions.Add(new TCPPaymentService.PaymentTransaction()
            {
                TransactionID = 1,
                TransactionAmount = 50,
                PaymentAmount = 50,
                TenderType = 1
            });
            transactions.Add(new TCPPaymentService.PaymentTransaction()
            {
                TransactionID = 2,
                TransactionAmount = 20,
                PaymentAmount = 30,
                TenderType = 2
            });

            List<TCPPaymentService.ProcessResult> results =
                new List<TCPPaymentService.ProcessResult>();

            results = paymentService.ProcessBatch(transactions.ToArray())
                           .ToList<TCPPaymentService.ProcessResult>();

            foreach (var res in results)
            {
                Console.WriteLine(String.Format("The result is {0} with reason of {1}", res.Result, res.Reason));
            }

            paymentService.Close();

            Console.ReadLine();
        }
    }
}
