Imports DevExpress.Xpf.Printing
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace HideExportFormats

    Partial Public Class MainWindow
        Inherits Window

        Private link As SimpleLink
        Public Sub New()
            InitializeComponent()

            AddHandler preview.Loaded, AddressOf OnPreviewLoaded
        End Sub

        Private Sub OnPreviewLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim data() As String = CultureInfo.CurrentCulture.DateTimeFormat.DayNames

            link = New SimpleLink With {.DetailTemplate = DirectCast(Resources("dayNameTemplate"), DataTemplate), .DetailCount = data.Length}
            AddHandler link.CreateDetail, Sub(s, args) args.Data = data(args.DetailIndex)

            preview.DocumentSource = link
            link.CreateDocument()
        End Sub
    End Class
End Namespace
