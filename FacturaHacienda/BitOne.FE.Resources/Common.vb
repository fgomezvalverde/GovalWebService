Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml
Imports System.Text

Public Class Common


    ''' <summary>
    ''' Serializar a un XML
    ''' </summary>
    ''' <param name="pDocumento"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SerializeToXML(pDocumento As Object) As String

        Dim serializer As XmlSerializer = New XmlSerializer(pDocumento.GetType)        
        Dim stream As System.IO.Stream = New System.IO.MemoryStream()
        Dim xtWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(stream, Encoding.UTF8)

        serializer.Serialize(xtWriter, pDocumento)

        xtWriter.Flush()

        stream.Seek(0, System.IO.SeekOrigin.Begin)

        Dim reader As System.IO.StreamReader = New System.IO.StreamReader(stream, Encoding.UTF8)

        Return reader.ReadToEnd()

    End Function

    ''' <summary>
    ''' Convierte un String a Stream
    ''' </summary>
    ''' <param name="pXml"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SerializeToXmlDocument(pXml As String) As Stream

        Dim xmlDocument As New XmlDocument

        xmlDocument.LoadXml(pXml)

        Dim xmlSerializer As New XmlSerializer(xmlDocument.GetType)
        Dim memoryStream As New MemoryStream

        xmlSerializer.Serialize(memoryStream, xmlDocument)
        Dim streamReader = New StreamReader(memoryStream)
        memoryStream.Position = 0

        Return memoryStream

    End Function

    ''' <summary>
    ''' Encripta un string
    ''' </summary>
    ''' <param name="pCadenaAencriptar"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Encrypt(pCadenaAencriptar As String) As String

        Dim encryted = Encoding.UTF8.GetBytes(pCadenaAencriptar)
        Dim result = Convert.ToBase64String(encryted)

        Return result

    End Function

    ''' <summary>
    ''' Desencripta un string
    ''' </summary>
    ''' <param name="pCadenaAdesencriptar"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Decrypt(pCadenaAdesencriptar As String) As String

        Dim decryted = Convert.FromBase64String(pCadenaAdesencriptar)
        Dim result = Encoding.UTF8.GetString(decryted)

        Return result

    End Function


End Class
