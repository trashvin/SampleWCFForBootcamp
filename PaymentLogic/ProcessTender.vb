Public Class ProcessTender
    Public Function Process(ByVal tranID As Integer, ByVal tranAmount As Double, ByVal paymentAmount As Double, ByVal tenderType As Integer) As Result
        Dim transaction As New Transaction()

        transaction.TranID = tranID
        transaction.TranAmount = tranAmount
        transaction.PaymentAmount = paymentAmount
        transaction.TenderType = tenderType

        Return ProcessTransaction(transaction)

    End Function
    Private Function ProcessTransaction(ByVal tran As Transaction) As Result

        Select Case tran.TenderType
            Case 1
                Return ProcessCash(tran)
            Case 2
                Return ProcessCheck(tran)
            Case 3
                Return ProcessCreditDebt(tran)
            Case Else
                Dim res As New Result()
                res.ProcessResult = "FAILED"
                res.Reason = "INVALID"
                Return res
        End Select


    End Function

    Function ProcessCash(ByVal tran As Transaction) As Result
        Dim cashProcess As New Cash()

        Return cashProcess.ProcessPayment(tran)
    End Function

    Function ProcessCheck(ByVal tran As Transaction) As Result
        Dim checkProcess As New Check()
        Return checkProcess.ProcessPayment(tran)

    End Function

    Function ProcessCreditDebt(ByVal tran As Transaction) As Result
        Dim creditProcess As New CreditDebitCard()
        Return creditProcess.ProcessPayment(tran)
    End Function
End Class
