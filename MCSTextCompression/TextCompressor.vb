Imports ICSharpCode.SharpZipLib.GZip
Imports System.IO
Imports System.Text

Public Class TextCompressor

    Public Shared Function DeCompress(ByVal CompressedData As String) As String
        Dim tmpReturn As New StringBuilder()
        Dim tmpBytes As Byte() = System.Convert.FromBase64String(CompressedData)

        Using tmpMemoryStream As New MemoryStream(tmpBytes)
            Using tmpStream As New GZipInputStream(tmpMemoryStream)

                Dim tmpBuffer(4096) As Byte
                'READ AS LONG AS THE STREAM IS RETURNING DATA TO US BECAUSE WE DONT KNOW THE ACTUAL LENGTH UNTIL WE HAVE DECOMPRESSED THE DATA
                While (True)
                    Dim readBytes As Integer = tmpStream.Read(tmpBuffer, 0, 4096)

                    'IF WE READ SOMETHING THEN APPEND IT TO THE RETURN STRING OTHERWISE STOP THE LOOP
                    If readBytes > 0 Then
                        tmpReturn.Append(System.Text.Encoding.UTF8.GetString(tmpBuffer, 0, readBytes))
                    Else
                        Exit While
                    End If
                End While

                'CLOSE THE STREAM WHEN WE ARE DONE WITH IT
                tmpStream.Close()

                'RETURN THE DECOMPRESSED STRING TO THE CALLING FUNCTION
                Return tmpReturn.ToString()
            End Using
        End Using

    End Function

    Public Shared Function Compress(ByVal UncompressedData As String) As String
        Dim tmpBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(UncompressedData)
        Using tmpMemoryStream As New MemoryStream()
            Using tmpStream As New GZipOutputStream(tmpMemoryStream)

                'JUST WRITE ALL OF THE DATA IN ONE MASSIVE CHUNK TO THE STREAM AND LET THE CSHARPLIB WORRY ABOUT COMPRESSING IT
                tmpStream.Write(tmpBytes, 0, tmpBytes.Length)
                tmpStream.Flush()
                tmpStream.Close()

                'RETURN THE MEMORYSTREAM CONVERTED TO A BASE 64 STRING TO TAKE CARE OF NULL VALUES CHARS AND STUFF LIKE THAT
                Return System.Convert.ToBase64String(tmpMemoryStream.ToArray())
            End Using
        End Using
    End Function

End Class