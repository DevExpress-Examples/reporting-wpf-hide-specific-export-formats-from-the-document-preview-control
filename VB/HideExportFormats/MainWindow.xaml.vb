Imports DevExpress.Xpf.Printing
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls

Namespace HideExportFormats

    Public Partial Class MainWindow
        Inherits Window

        Private link As SimpleLink

        Public Sub New()
            Me.InitializeComponent()
            AddHandler Me.preview.Loaded, AddressOf Me.OnPreviewLoaded
        End Sub

        Private Sub OnPreviewLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim data As String() = CultureInfo.CurrentCulture.DateTimeFormat.DayNames
            link = New SimpleLink With {.DetailTemplate = CType(Resources("dayNameTemplate"), DataTemplate), .DetailCount = data.Length}
            AddHandler link.CreateDetail, Sub(s, args) args.Data = data(args.DetailIndex)
            Me.preview.DocumentSource = link
            link.CreateDocument()
        End Sub
    End Class
End Namespace
