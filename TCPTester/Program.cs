using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTester
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPPaymentProcessor.PaymentProcessorClient paymentSystem =
                new TCPPaymentProcessor.PaymentProcessorClient();

            Console.WriteLine("Processing 1 transaction .... ");

            TCPPaymentProcessor.PaymentTransaction tran1 =
                new TCPPaymentProcessor.PaymentTransaction()
                {
                    TransactionID = 1,
                    TransactionAmount = 50,
                    PaymentAmount = 50,
                    TenderType = 1
                };

            TCPPaymentProcessor.ProcessResult result =
                new TCPPaymentProcessor.ProcessResult();

            result = paymentSystem.Process(tran1);

            Console.WriteLine(String.Format("The result is {0} with reason of {1}", result.Result, result.Reason));

            Console.WriteLine("Processing batch transactions .... ");

            List<TCPPaymentProcessor.PaymentTransaction> transactions =
                new List<TCPPaymentProcessor.PaymentTransaction>();

            transactions.Add(new TCPPaymentProcessor.PaymentTransaction()
            {
                TransactionID = 1,
                TransactionAmount = 50,
                PaymentAmount = 50,
                TenderType = 1
            });
            transactions.Add(new TCPPaymentProcessor.PaymentTransaction()
            {
                TransactionID = 2,
                TransactionAmount = 20,
                PaymentAmount = 30,
                TenderType = 2
            });

            List<TCPPaymentProcessor.ProcessResult> results =
                new List<TCPPaymentProcessor.ProcessResult>();

            results = paymentSystem.ProcessBatch(transactions.ToArray())
                        .ToList<TCPPaymentProcessor.ProcessResult>();

            foreach (var res in results)
            {
                Console.WriteLine(String.Format("The result is {0} with reason of {1}", res.Result, res.Reason));
            }

            Console.ReadLine();
        }
    }
}
