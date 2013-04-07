Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports MCSTextCompression

Public Class DeCompressor
    Inherits SoapExtension

#Region "Variables"
    Private networkStream As Stream
    Private newStream As Stream
#End Region

#Region "Initializers"
    Public Overloads Overrides Function GetInitializer(ByVal methodInfo As LogicalMethodInfo, ByVal attribute As SoapExtensionAttribute) As Object
        'RETURN A NULL VALUE BECAUSE NOTHING DOESNT WORK
        Return System.DBNull.Value
    End Function
    Public Overloads Overrides Function GetInitializer(ByVal WebServiceType As Type) As Object
        'RETURN A NULL VALUE BECAUSE NOTHING DOESNT WORK
        Return System.DBNull.Value
    End Function
    Public Overrides Sub Initialize(ByVal initializer As Object)
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Sub ProcessMessage(ByVal message As SoapMessage)
        Select Case message.Stage
            Case SoapMessageStage.BeforeSerialize
            Case SoapMessageStage.AfterSerialize
                AfterSerialize(message)
            Case SoapMessageStage.BeforeDeserialize
                BeforeDeserialize(message)
            Case SoapMessageStage.AfterDeserialize
            Case Else
                Throw New Exception("invalid stage")
        End Select
    End Sub
    Public Overrides Function ChainStream(ByVal stream As Stream) As Stream
        networkStream = stream
        newStream = New MemoryStream()

        Return newStream
    End Function
#End Region

#Region "Private Methods"
    Public Sub AfterSerialize(ByVal message As SoapMessage)
        'MOVE THE STREAM TO THE BEGINING SINCE WE DONT ALWAYS START OUT THERE
        newStream.Position = 0

        'COPY THE STREAM STRAIGHT ACCROSS BECAUSE WE ARE NOT COMPRESSING THE REQUESTS ONLY THE RESPONSES
        Copy(newStream, networkStream)
    End Sub
    Public Sub BeforeDeserialize(ByVal message As SoapMessage)
        'DECOMPRESS THE INCOMING RESPONSE BECAUSE IT WAS COMPRESSED ON THE OTHERSIDE
        DeComp(networkStream, newStream)

        'RESET THE STREAM POSITION SO ASP CAN HANDLE THE REST FROM HERE
        newStream.Position = 0
    End Sub
    Sub Copy(ByVal fromStream As Stream, ByVal toStream As Stream)
        Dim Input As New StreamReader(fromStream)
        Dim Output As New StreamWriter(toStream)

        'COPY THE DATA FROM ONE STREAM TO THE OTHER STREAM
        Output.WriteLine(Input.ReadToEnd())
        Output.Flush()
    End Sub
    Sub DeComp(ByVal fromStream As Stream, ByVal toStream As Stream)
        Dim Input As New StreamReader(fromStream)
        Dim Output As New StreamWriter(toStream)
        Dim tmpHolder As String
        Dim tmpUncompressed As String

        'READ THE COMPRESSED DATA FROM THE STREAM TO A TMP VARIABLE
        tmpHolder = Input.ReadToEnd

        'DECOMPRESS THE DATA USING THE MCSTEXTCOMPRESSOR LIBRARY
        Try
            tmpUncompressed = MCSTextCompression.TextCompressor.DeCompress(tmpHolder)
        Catch
            'IF UNCOMPRESSION FAILS THEN JUST COPY THE DATA OVER AND HOPE FOR THE BEST
            tmpUncompressed = tmpHolder
        End Try

        'WRITE THE UNCOMPRESSED DATA TO THE STREAM FOR ASP TO PROCESS
        Output.WriteLine(tmpUncompressed)
        Output.Flush()
    End Sub
#End Region

End Class

<AttributeUsage(AttributeTargets.Method)> _
Public Class DeCompressorExtensionAttribute
    Inherits SoapExtensionAttribute

    Public Overrides ReadOnly Property ExtensionType() As Type
        Get
            Return GetType(DeCompressor)
        End Get
    End Property

    Public Overrides Property Priority() As Integer
        Get
            Return 1
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property

End Class