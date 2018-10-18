Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Configuration
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Text
Imports System.IO

Public Class saveimage

    'Private Sub saveimage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub
    ' ''' <summary>

    ' ''' Function to save an image to a SQL database

    ' ''' </summary>

    ' ''' <param name="imgName">Name of the image (Need path as well)

    ' ''' ex: C:\MyImage.gif

    ' ''' </param>

    ' ''' <param name="storedProc">Stored procedure to execute.

    ' ''' NOTE: I decided to make this a parameter so when using it

    ' ''' a stored proc doesnt have to be renamed to use this snippet

    ' ''' </param>

    ' ''' <returns>True if successful, False is failed</returns>

    ' ''' <remarks></remarks>

    'Public Function InsertImage(ByRef imgName As String, ByRef storedProc As String) As Boolean
    '    Try
    '        'First we need to make sure an image name was provided. If
    '        'none is provided we need to show a message to the user
    '        'and exit the function
    '        '    img.Image = Nothing
    '        If IsNothing(img) Then
    '            '  IsNothing()
    '            MessageBox.Show("Please provide an image to save.")
    '            Exit Function
    '        End If

    '        'FileInfo instance so we can get all the
    '        'information we need regarding the image
    '        Dim fInfo As New FileInfo(imgName)
    '        'Get the length of the image for the byte array
    '        'we create later in the function       
    '        Dim len As Long = fInfo.Length
    '        'This is the connections tring connecting to your database
    '        '** NOTE: This needs to be changed to YOUR connection string **
    '        Dim connString As String = My.Settings.cnnstring
    '        'Open a FileStream the length of the image being inserted
    '        Using stream As New FileStream(img., FileMode.Open)
    '            'Create a new byte array the size of the length of the file
    '            Dim imgData() As Byte = New Byte(Convert.ToInt32(len - 1)) {}
    '            'Read the byte array into the buffer
    '            stream.Read(imgData, 0, len)
    '            'Create our Sql connection
    '            Using con As New SqlConnection(connString)
    '                'Create the command object that will do
    '                'the database work
    '                Using cmd As New SqlCommand()
    '                    con.Open()
    '                    'Set the properties of ouor connection object
    '                    cmd.Connection = con
    '                    cmd.CommandType = CommandType.StoredProcedure
    '                    cmd.CommandText = storedProc
    '                    'Add the parameters for the stored procedure
    '                    cmd.Parameters.AddWithValue("@image_data", imgData)
    '                    cmd.Parameters.AddWithValue("@image_name", imgName)
    '                    'Execute the Stored Procedure
    '                    cmd.ExecuteNonQuery()
    '                    Return True
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As SqlException
    '        MessageBox.Show(ex.ToString)
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '        Return False
    '    End Try
    'End Function

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    InsertImage("C:\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\Bado_Office.jpg", "uspInsertImage")
    'End Sub
End Class