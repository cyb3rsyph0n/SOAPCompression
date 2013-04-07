Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data

<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class DemoService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function GetABFD(ByVal ExecCmd As String) As DataSet

        Using tmpConnection As New SqlConnection("Data Source=10.4.1.150;Initial Catalog=mcs_fs;User Id=sa;Password=mcsnow;")
            'Using tmpAdapter As New SqlDataAdapter("mcs_getinspectionswipvendorid 45, 0, '07/24/08 23:59:59'", tmpConnection)
            Using tmpAdapter As New SqlDataAdapter(ExecCmd, tmpConnection)
                Using tmpDataset As New DataSet()
                    tmpConnection.Open()
                    tmpAdapter.Fill(tmpDataset)

                    Return tmpDataset
                End Using
            End Using
        End Using

    End Function

End Class