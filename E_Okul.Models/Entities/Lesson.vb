Imports System.ComponentModel.DataAnnotations
Imports E_Okul.Infrastructure
Public Class Lesson
    Implements IEntity
    <Key> Public Property Id As Integer
    Public Property LessonCode As String
    Public Property LessonName As String
    Public Property LessonClock As Integer
    Public Overridable Property Points As ICollection(Of Point)
End Class