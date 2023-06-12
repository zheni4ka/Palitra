using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        ObservableCollection<string> colors = new ObservableCollection<string>();

        private ViewModel _viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
            ColorListBox.ItemsSource = colors;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!colors.Contains(_viewModel.ToString()))
                colors.Add(_viewModel.ToString());
            else { MessageBox.Show("This color is already exists"); return; }
        }


        private void ColorListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((ColorListBox.SelectedItem as string) == null) { MessageBox.Show("Cannot delete an empty item ! ! ! "); return; }
            colors.Remove(ColorListBox.SelectedItem as string);
        }
    }
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public Color Palitra => Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);

        public ViewModel() { }

        public int alpha { get; set; }
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }

        public override string ToString()
        {
            return $"{Palitra}";
        }

    }


}
