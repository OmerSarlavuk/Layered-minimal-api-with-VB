Imports System.Runtime.CompilerServices

Public Module AverageAccount
    <Extension()>
    Function AverageAccounts(dec As Decimal, ex1 As Byte, ex2 As Byte, per1 As Byte, per2 As Byte) As Decimal
        Return IIf(1, (((ex1 + ex2) / 2) * 7 / 10) + (((per1 + per2) / 2) * 3 / 10), 0)
    End Function
End Module