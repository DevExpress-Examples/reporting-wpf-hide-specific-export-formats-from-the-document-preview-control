using DevExpress.Xpf.Printing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HideExportFormats {
    
    public partial class MainWindow : Window {
        private SimpleLink link;
        public MainWindow() {
            InitializeComponent();

            preview.Loaded += OnPreviewLoaded;
        }

        void OnPreviewLoaded(object sender, RoutedEventArgs e) {
            string[] data = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            link = new SimpleLink {
                DetailTemplate = (DataTemplate)Resources["dayNameTemplate"],
                DetailCount = data.Length
            };
            link.CreateDetail += (s, args) => args.Data = data[args.DetailIndex];

            preview.DocumentSource = link;
            link.CreateDocument();
        }
    }
}
