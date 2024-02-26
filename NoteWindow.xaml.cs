using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PracticalWork2
{
    public partial class NoteWindow : Window
    {
        public static string noteName, noteDescription;

        private void NoteName_TextChanged(object sender, TextChangedEventArgs e)
        {
            noteName = NoteName.Text;
        }

        private void NoteDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            noteDescription = NoteDescription.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Note newNote = new Note(noteName, noteDescription);
            Note.notes.Add(newNote);
            Files.Serialization(Note.notes, MainWindow.path);
            Close();
        }

        public NoteWindow()
        {
            InitializeComponent();
        }
    }
}
