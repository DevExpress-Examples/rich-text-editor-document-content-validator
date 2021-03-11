Imports DevExpress.Office.Services
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraRichEdit
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows.Forms
Imports System.Xml.Linq

Namespace ContentAnalyzer
	Partial Public Class Form1
		Inherits RibbonForm

		Private ReadOnly log As New List(Of UnsupportedContentItem)()

		Public Sub New()
			InitializeComponent()

			richEditControl.AddService(GetType(ILogUnsupportedContentService), New LogUnsupportedContentService(Me.log))
			AddHandler richEditControl.BeforeImport, AddressOf OnBeforeImport
			AddHandler richEditControl.EmptyDocumentCreated, AddressOf OnEmptyDocumentCreated
			AddHandler richEditControl.DocumentLoaded, AddressOf OnDocumentLoaded

			Dim ribbonControl As RibbonControl = richEditControl.CreateRibbon(RichEditToolbarType.File)
			Me.Controls.Add(ribbonControl)


			Me.gridControl.DataSource = Me.log
		End Sub

		Private Sub OnBeforeImport(ByVal sender As Object, ByVal e As DevExpress.XtraRichEdit.BeforeImportEventArgs)
			Me.log.Clear()
		End Sub
		Private Sub OnEmptyDocumentCreated(ByVal sender As Object, ByVal e As EventArgs)
			Me.log.Clear()
			Me.gridControl.RefreshDataSource()
		End Sub

		Private Sub OnDocumentLoaded(ByVal sender As Object, ByVal e As EventArgs)
			Me.gridControl.RefreshDataSource()
			If Me.log.Count = 0 Then
				MessageBox.Show("Your document does not contain any verified unsupported tags." & vbCrLf & "If the document is loaded or rendered incorrectly, submit a ticket to our Support Center and attach your document to the ticket.")
			End If
		End Sub
	End Class

	Public Class LogUnsupportedContentService
		Implements ILogUnsupportedContentService

'INSTANT VB NOTE: The field log was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private ReadOnly log_Conflict As List(Of UnsupportedContentItem)
		Private unsupportedItems As Dictionary(Of String, String)
		Private dictionaryPath As String = "dictionary.csv"
		Public Sub New(ByVal log As List(Of UnsupportedContentItem))
			Me.log_Conflict = log
			Me.unsupportedItems = New Dictionary(Of String, String)()

			InitializeDictionary()
		End Sub

		Private Sub InitializeDictionary()
			Try
				Dim pathElement As XElement = XDocument.Parse(System.IO.File.ReadAllText("Settings.config")).Descendants("configuration").Descendants("dictionaryPath").FirstOrDefault()

				If pathElement IsNot Nothing Then
					Dim path As String = pathElement.Value
					Using client As New WebClient()
						client.DownloadFile(path, dictionaryPath)
					End Using
				End If
			Finally
				If System.IO.File.Exists(dictionaryPath) Then
					Dim dictionaryItems() As String = System.IO.File.ReadAllLines(dictionaryPath)
					For Each item As String In dictionaryItems
						Dim values() As String = item.Split(";"c)
						unsupportedItems(values(0).ToLower()) = values(1).ToLower()
					Next item
				End If
			End Try
		End Sub

		Public Sub Log(ByVal fileName As String, ByVal tag As String, ByVal [namespace] As String, ByVal prefix As String) Implements ILogUnsupportedContentService.Log

			If unsupportedItems.ContainsKey(tag.ToLower()) Then
				Dim item As New UnsupportedContentItem()
				item.FileName = fileName
				item.Tag = tag
				item.Namespace = [namespace]
				item.Prefix = prefix
				item.Description = unsupportedItems(tag.ToLower())

				log_Conflict.Add(item)
			End If
		End Sub
	End Class

	Public Class UnsupportedContentItem
		Public Property FileName() As String
		Public Property Tag() As String
		Public Property [Namespace]() As String
		Public Property Prefix() As String
		Public Property Description() As String
	End Class
End Namespace
