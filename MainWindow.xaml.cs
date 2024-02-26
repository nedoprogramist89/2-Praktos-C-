using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PracticalWork2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string selected = "";
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\diary\\products.csv";
        public static DateTime currentDate = DateTime.Today;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\diary");
                File.Create(path).Close();
            }
            ListBoxWork(false);
        }

        private void NewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            NoteWindow noteWindow = new NoteWindow
            {
                Owner = this
            };
            noteWindow.Show();
            ListBoxWork(true);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            currentDate = Convert.ToDateTime(CurrentDatePicker.Text);
            ListBoxWork(true);
        }

        private void ListBoxWork(bool show)
        {
            if (show)
            {
                Notes.Items.Clear();
            }

            foreach (Note note in Note.notes)
            {
                if (note.date == currentDate)
                {
                    Notes.Items.Add(note.name);
                }
            }
        }

        private void Notes_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                selected = Notes.SelectedItem.ToString();
            }
            catch
            {

            }

            NoteWindow2 noteWindow = new NoteWindow2
            {
                Owner = this
            };
            noteWindow.Show();
            ListBoxWork(true);
        }
    }
}
