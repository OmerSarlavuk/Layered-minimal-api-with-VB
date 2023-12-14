Imports System.Text.Json.Serialization
Imports E_Okul.Infrastructure

Public Class AddressPutDto
    Implements IDto
    Public Property Id As Integer
    Public Property AddressInformation As String
    Public Property City As String
    <JsonIgnore>
    Public Property StudentId As Integer
End Class
