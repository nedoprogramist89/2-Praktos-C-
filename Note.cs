using System;
using System.Collections.Generic;

namespace PracticalWork2
{
    public class Note
    {
        public static List<Note> notes = Files.Deserialization<Note>(MainWindow.path);

        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public Note(string name, string description)
        {
            this.name = name;
            this.description = description;
            date = MainWindow.currentDate;
        }
    }
}
