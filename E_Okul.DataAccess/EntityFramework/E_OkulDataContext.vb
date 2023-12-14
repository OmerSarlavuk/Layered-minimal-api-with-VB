Imports E_Okul.Models
Imports Microsoft.EntityFrameworkCore

Public Class E_OkulDataContext
    Inherits DbContext

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        MyBase.OnConfiguring(optionsBuilder)
        optionsBuilder.UseSqlServer("Data Source = DESKTOP-R04PVQ3\SQLEXPRESS; Initial Catalog = EOkul; Trust Server Certificate = True; Integrated Security = True")
    End Sub

    Public Property Students As DbSet(Of Student)
    Public Property Points As DbSet(Of E_Okul.Models.Point)
    Public Property Lessons As DbSet(Of Lesson)
    Public Property Teachers As DbSet(Of Teacher)
    Public Property Branches As DbSet(Of Branch)
    Public Property Addresses As DbSet(Of Address)

End Class
