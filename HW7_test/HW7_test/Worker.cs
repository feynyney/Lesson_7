using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_test
{
    struct Worker
    {
        public int Id { get; set; }

        public DateTime Time_of_note { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Date_of_birth { get; set; }

        public string Place_of_birth { get; set; }

        public Worker(int id, DateTime time_of_note, string name, int age, DateTime date_of_birth, string place_of_birth)
        {
           this.Id = id;
           Time_of_note = time_of_note;
           Name = name;
           Age = age;
           Date_of_birth = date_of_birth;
           Place_of_birth = place_of_birth;
        }

        public static Worker Division(string line)
        {
            string[] divided_line = line.Split('#');

            return new Worker(
                int.Parse(divided_line[0]),
                DateTime.Parse(divided_line[1]),
                divided_line[2],
                int.Parse(divided_line[3]),
                DateTime.Parse(divided_line[4]),
                divided_line[5]);
        }

        public string Serialize()
        {
            return $"{Id}#{Time_of_note}#{Name}#{Age}#{Date_of_birth.ToShortDateString()}#{Place_of_birth}";
        }

    
        public string PrintOut()
        {
            return $"{Id} {Time_of_note,22} {Name,10} {Age,13} {Date_of_birth.ToShortDateString(),19} {Place_of_birth,18}";
        }
    }
}
