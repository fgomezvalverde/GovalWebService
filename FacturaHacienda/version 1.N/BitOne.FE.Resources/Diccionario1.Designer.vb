﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Public Class Diccionario
    
    Private Shared resourceMan As Global.System.Resources.ResourceManager
    
    Private Shared resourceCulture As Global.System.Globalization.CultureInfo
    
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub
    
    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("BitOne.FE.Resources.Diccionario", GetType(Diccionario).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property
    
    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Public Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 06.
    '''</summary>
    Public Shared ReadOnly Property Contrato() As String
        Get
            Return ResourceManager.GetString("Contrato", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 2.
    '''</summary>
    Public Shared ReadOnly Property SituacionContingencia() As String
        Get
            Return ResourceManager.GetString("SituacionContingencia", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 1.
    '''</summary>
    Public Shared ReadOnly Property SituacionNormal() As String
        Get
            Return ResourceManager.GetString("SituacionNormal", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 3.
    '''</summary>
    Public Shared ReadOnly Property SituacionSinInternet() As String
        Get
            Return ResourceManager.GetString("SituacionSinInternet", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 01.
    '''</summary>
    Public Shared ReadOnly Property TipoDocumentoFactura() As String
        Get
            Return ResourceManager.GetString("TipoDocumentoFactura", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 03.
    '''</summary>
    Public Shared ReadOnly Property TipoDocumentoNotaCredito() As String
        Get
            Return ResourceManager.GetString("TipoDocumentoNotaCredito", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 02.
    '''</summary>
    Public Shared ReadOnly Property TipoDocumentoNotaDebito() As String
        Get
            Return ResourceManager.GetString("TipoDocumentoNotaDebito", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 05.
    '''</summary>
    Public Shared ReadOnly Property TipoDocumentoNotaDespacho() As String
        Get
            Return ResourceManager.GetString("TipoDocumentoNotaDespacho", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 04.
    '''</summary>
    Public Shared ReadOnly Property TipoDocumentoTiquete() As String
        Get
            Return ResourceManager.GetString("TipoDocumentoTiquete", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 03.
    '''</summary>
    Public Shared ReadOnly Property TipoIdentificionDIMEX() As String
        Get
            Return ResourceManager.GetString("TipoIdentificionDIMEX", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 01.
    '''</summary>
    Public Shared ReadOnly Property TipoIdentificionFisica() As String
        Get
            Return ResourceManager.GetString("TipoIdentificionFisica", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 02.
    '''</summary>
    Public Shared ReadOnly Property TipoIdentificionJuridica() As String
        Get
            Return ResourceManager.GetString("TipoIdentificionJuridica", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 04.
    '''</summary>
    Public Shared ReadOnly Property TipoIdentificionNITE() As String
        Get
            Return ResourceManager.GetString("TipoIdentificionNITE", resourceCulture)
        End Get
    End Property
End Class
