Imports System.Runtime.CompilerServices

Public Module PointStatus
    <Extension()>
    Function StatusCheck(str As String, dec As Decimal) As String
        Return IIf(dec < 50, "Kaldı", "Geçti")
    End Function

End Module
