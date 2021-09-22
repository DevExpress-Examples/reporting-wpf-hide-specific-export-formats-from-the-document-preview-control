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

    Public Partial Class MainWindow
        Inherits Window

        Private link As SimpleLink

        Public Sub New()
            InitializeComponent()
            preview.Loaded += AddressOf OnPreviewLoaded
        End Sub

        Private Sub OnPreviewLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim data As String() = CultureInfo.CurrentCulture.DateTimeFormat.DayNames
            link = New SimpleLink With {.DetailTemplate = CType(Resources("dayNameTemplate"), DataTemplate), .DetailCount = data.Length}
            link.CreateDetail += Function(s, args) CSharpImpl.__Assign(args.Data, data(args.DetailIndex))
            preview.DocumentSource = link
            link.CreateDocument()
        End Sub

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
