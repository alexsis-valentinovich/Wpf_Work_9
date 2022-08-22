using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Wpf_Work_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class MyCommands
    {
        public static RoutedUICommand Exit { get; set; }
        public static RoutedUICommand OpenMy { get; set; }
        public static RoutedUICommand SaveMy { get; set; }
        static MyCommands()
        {
            InputGestureCollection inputsEx = new InputGestureCollection();
            inputsEx.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            Exit = new RoutedUICommand("Выход", "Exit", typeof(MyCommands), inputsEx);

            InputGestureCollection inputsOpen = new InputGestureCollection();
            inputsOpen.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+O"));
            OpenMy = new RoutedUICommand("Открыть", "OpenMy", typeof(MyCommands), inputsOpen);

            InputGestureCollection inputsSave = new InputGestureCollection();
            inputsSave.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+S"));
            SaveMy = new RoutedUICommand("Сохранить", "SaveMy", typeof(MyCommands), inputsSave);
        }

    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Uri uriMy = new Uri("DicLight.xaml", UriKind.Relative);
            ResourceDictionary resourceMy = Application.LoadComponent(uriMy) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceMy);

        }

        private void ExitEx(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)// СВЕТЛАЯ ТЕМА МЕНЮ ТЕКСТ
        {
            Uri uriMy = new Uri("DicLight.xaml", UriKind.Relative);
            ResourceDictionary resourceMy = Application.LoadComponent(uriMy) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceMy);
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)// ТЕМНАЯ ТЕМА МЕНЮ ТЕКСТ
        {
            Uri uriMy = new Uri("DicDark.xaml", UriKind.Relative);
            ResourceDictionary resourceMy = Application.LoadComponent(uriMy) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceMy);
        }


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Текстовые файл, .txt|*.txt|Все файлы, *.*|*.*";
            if (OpenFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(OpenFileDialog.FileName);
            }
        }
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Текстовые файл, .txt|*.txt|Все файлы, *.*|*.*";
            if (SaveFileDialog.ShowDialog() == true)

            {
                File.WriteAllText(SaveFileDialog.FileName, textBox.Text);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontBox = ((sender as ComboBox).SelectedItem as String);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontBox);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double sizeFont = Convert.ToDouble(((sender as ComboBox).SelectedItem as String));
            if (textBox != null)
            {
                textBox.FontSize = sizeFont;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;
                (sender as Button).BorderThickness = new Thickness(3, 3, 3, 3);
            }

            else
            {
                textBox.FontWeight = FontWeights.Normal;
                (sender as Button).BorderThickness = new Thickness(1, 1, 1, 1);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
                (sender as Button).BorderThickness = new Thickness(3, 3, 3, 3);
            }

            else
            {
                textBox.FontStyle = FontStyles.Normal;
                (sender as Button).BorderThickness = new Thickness(1, 1, 1, 1);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations.Count == 0)
            {
                textBox.TextDecorations.Add(TextDecorations.Underline);
                (sender as Button).BorderThickness = new Thickness(3, 3, 3, 3);
            }

            else
            {
                textBox.TextDecorations.Remove(TextDecorations.Underline[0]);
                (sender as Button).BorderThickness = new Thickness(1, 1, 1, 1);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Текстовые файл, .txt|*.txt|Все файлы, *.*|*.*";
            if (OpenFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(OpenFileDialog.FileName);
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Текстовые файл, .txt|*.txt|Все файлы, *.*|*.*";
            if (SaveFileDialog.ShowDialog() == true)

            {
                File.WriteAllText(SaveFileDialog.FileName, textBox.Text);
            }
        }


        //рисование----------------------------------------------------
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            canvasMy.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            canvasMy.EditingMode = InkCanvasEditingMode.Select;
        }

        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            canvasMy.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private void comboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string comboColors = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (canvasMy != null)
            {
                if (comboColors == "Красный")
                {
                    canvasMy.DefaultDrawingAttributes.Color = Colors.Red;
                }
                if (comboColors == "Зеленый")
                {
                    canvasMy.DefaultDrawingAttributes.Color = Colors.Green;
                }
                if (comboColors == "Черный")
                {
                    canvasMy.DefaultDrawingAttributes.Color = Colors.Black;
                }
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Графический файл, .sandy|*.sandy|Все файлы, *.*|*.*";
            if (OpenFileDialog.ShowDialog() == true)
            {
                var fc = new FileStream(OpenFileDialog.FileName, FileMode.OpenOrCreate);
                StrokeCollection strokes = new StrokeCollection(fc);
                canvasMy.Strokes = strokes;
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Графический файл, .sandy|*.sandy|Все файлы, *.*|*.*";
            if (SaveFileDialog.ShowDialog() == true)

            {
                FileStream fc = File.Open(SaveFileDialog.FileName, FileMode.OpenOrCreate);
                canvasMy.Strokes.Save(fc);
                fc.Close();
            }
        }


    }
}
