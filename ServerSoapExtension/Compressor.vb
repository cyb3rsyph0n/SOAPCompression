Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports MCSTextCompression

Public Class Compressor
    Inherits SoapExtension

#Region "Variables"
    Private networkStream As Stream
    Private newStream As Stream
#End Region

#Region "Initializers"
    Public Overloads Overrides Function GetInitializer(ByVal methodInfo As LogicalMethodInfo, ByVal attribute As SoapExtensionAttribute) As Object
        'RETURN A NULL VALUE NOTHING DOESNT WORK FOR SOME REASON
        Return System.DBNull.Value
    End Function
    Public Overloads Overrides Function GetInitializer(ByVal WebServiceType As Type) As Object
        'RETURN A NULL VALUE NOTHING DOESNT WORK FOR SOME REASON
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
        'GET A HANDLE TO THE NETWORK STREAM AND REMEMBER IT
        networkStream = stream
        newStream = New MemoryStream()

        'RETURN A NEW TEMPORARY STREAM WE CAN WORK WITH
        Return newStream
    End Function
#End Region

#Region "Private Methods"
    Public Sub AfterSerialize(ByVal message As SoapMessage)
        'MOVE THE STREAM TO THE BEGINING (SOMETIMES WE START OUT AT THE END)
        newStream.Position = 0

        'COMPRESS THE STREAM TO THE NETWORK STREAM
        Comp(newStream, networkStream)
    End Sub
    Public Sub BeforeDeserialize(ByVal message As SoapMessage)
        'SIMPLY COPY THE DATA ACCROSS BECAUSE WE ARE NOT COMPRESSING THE REQUESTS ONLY THE RESPONSES
        Copy(networkStream, newStream)

        'RESET THE STREAMS POSITION SO ASP CAN HANDLE IT FROM HERE
        newStream.Position = 0
    End Sub
    Sub Copy(ByVal fromStream As Stream, ByVal toStream As Stream)
        Dim Input As New StreamReader(fromStream)
        Dim Output As New StreamWriter(toStream)

        'SIMPLY READ FROM ONE STREAM TO THE OTHER AND COPY THE DATA ACCROSS
        Output.WriteLine(Input.ReadToEnd())
        Output.Flush()
    End Sub
    Sub Comp(ByVal fromStream As Stream, ByVal toStream As Stream)
        Dim Input As New StreamReader(fromStream)
        Dim Output As New StreamWriter(toStream)
        Dim tmpHolder As String
        Dim tmpCompressed As String

        'GET THE UNCOMPRESSED VERSION OF THE DATA
        tmpHolder = Input.ReadToEnd

        'COMPRESS THE STRING USING MCSTEXTCOMPRESSION LIBRARY
        tmpCompressed = MCSTextCompression.TextCompressor.Compress(tmpHolder)
        Output.WriteLine(tmpCompressed)
        Output.Flush()
    End Sub
#End Region

End Class

<AttributeUsage(AttributeTargets.Method)> _
Public Class CompressorExtensionAttribute
    Inherits SoapExtensionAttribute

    Public Overrides ReadOnly Property ExtensionType() As Type
        Get
            Return GetType(Compressor)
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

