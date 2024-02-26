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

    public partial class NoteWindow2 : Window
    {
        Note selectedNote = new Note("", "");

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Note newNote = new Note(NoteName2.Text, NoteDescription2.Text);
            int index = Note.notes.IndexOf(newNote);
            Note.notes[index] = newNote;
            Files.Serialization(Note.notes, MainWindow.path);
            Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Note.notes.Remove(selectedNote);
            Files.Serialization(Note.notes, MainWindow.path);
            Close();
        }

        public NoteWindow2()
        {
            InitializeComponent();
            foreach (Note note in Note.notes)
            {
                if (note.name == MainWindow.selected)
                {
                    NoteName2.Text = note.name;
                    NoteDescription2.Text = note.description;
                    selectedNote = note;
                    break;
                }
            }
        }
    }
}
