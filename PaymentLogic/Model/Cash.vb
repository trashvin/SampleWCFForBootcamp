Public Class Cash
    Inherits ATenderType : Implements ITenderType

    Public Event PaymentCompleted(result As String) Implements ITenderType.PaymentCompleted

    Public Function ProcessPayment(transaction As Transaction) As Result Implements ITenderType.ProcessPayment
        Dim result As New Result()
        If transaction.PaymentAmount >= transaction.TranAmount Then
            result.ProcessResult = "SUCCESS"
            result.Reason = "APPROVED"

            Return result
        Else
            result.ProcessResult = "FAILED"
            result.Reason = "DECLINE"

            Return result
        End If
    End Function
End Class
