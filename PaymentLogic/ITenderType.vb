Public Interface ITenderType

    Event PaymentCompleted(ByVal result As String)
    Function ProcessPayment(ByVal transaction As Transaction) As Result

End Interface
