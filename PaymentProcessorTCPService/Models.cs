using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PaymentProcessorTCPService.Model
{

    [DataContract]
    public class PaymentTransaction
    {
        [DataMember]
        public int TransactionID { get; set; }

        [DataMember]
        public double TransactionAmount { get; set; }

        [DataMember]
        public double PaymentAmount { get; set; }

        [DataMember]
        public int TenderType { get; set; }
    }

    [DataContract]
    public class ProcessResult
    {
        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public string Reason { get; set; }
    }
}