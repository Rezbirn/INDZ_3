using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace INDZ_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }

            e.Handled = true;
        }

        private void TextBox_Drop(object sender, DragEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    if (System.IO.Path.GetExtension(file).ToLower() == ".txt")
                    {
                        textBox.Text += File.ReadAllText(file);
                    }
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.Text))
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                {
                    textBox.Text += e.Data.GetData(DataFormats.Text).ToString();
                }
            }
        }

        private void ClearCommand_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.IsFocused)
            {
                TextBox1.Clear();
            }
            else if (TextBox2.IsFocused)
            {
                TextBox2.Clear();
            }
            else if (TextBox3.IsFocused)
            {
                TextBox3.Clear();
            }
        }

        private void ExitCommand_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}