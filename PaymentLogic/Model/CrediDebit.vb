Public Class CreditDebitCard
    Inherits ATenderType : Implements ITenderType

    Public Event PaymentCompleted(result As String) Implements ITenderType.PaymentCompleted

    Public Function ProcessPayment(transaction As Transaction) As Result Implements ITenderType.ProcessPayment
        Dim result As New Result()

        If transaction.PaymentAmount <> transaction.TranAmount Then
            result.ProcessResult = "FAILED"
            result.Reason = "AMOUNT_INVALID"

            Return result
            'transaction.result.result_list.Add("FAILED, AMOUNT_INVALID")
        ElseIf transaction.TranAmount > 500 Then
            result.ProcessResult = "FAILED"
            result.Reason = "DECLINE"

            Return result
        Else
            result.ProcessResult = "SUCCESS"
            result.Reason = "APPROVED"

            Return result
        End If
     
    End Function

End Class
