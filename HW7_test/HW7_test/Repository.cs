using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW7_test
{
    struct Repository
    {
        private Worker[] workers_array;
        private int currentIndex;
        private string Path;

        public Repository(string path)
        {
            Path = path;
            File.Open(path, FileMode.OpenOrCreate).Close();
            this.workers_array = new Worker[8];
            currentIndex = 0;
            foreach(var currentLine in File.ReadLines(Path))
            {
                AddWorker(Worker.Division(currentLine));
            }
        }

        public void CreateWorker()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of birth: ");
            DateTime date_of_birth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Place of birth");
            string place_of_birth = Console.ReadLine();

            AddWorker(new Worker(currentIndex, DateTime.Now, name, age, date_of_birth, place_of_birth));
        }

        public void AddWorker(Worker worker)
        {
            if(currentIndex == workers_array.Length)
            {
                Array.Resize(ref workers_array, workers_array.Length*2);
            }
            workers_array[currentIndex++] = worker;
        }

        public void ShowRecords()
        {
            Console.WriteLine($"{"Id"} {"AddTime",15} {"Name",15} {"Age",15} {"Birth",15} {"Place of birth",25} \n");

            foreach (var worker in workers_array.Take(currentIndex))
            {
                Console.WriteLine(worker.PrintOut());
            }
        }

        public void ShowExactRecord()
        {
            Console.Write("Enter id: ");
            int exact_id = int.Parse(Console.ReadLine());
            if(exact_id >= currentIndex)
            {
                Console.WriteLine("There is no record with this id...");
            }
            else
            {
                Console.WriteLine(workers_array[exact_id].PrintOut());
            }
        }

        public void DeleteRecord()
        {
            Console.WriteLine("Enter id record to delete: ");
            int record_to_delete = int.Parse(Console.ReadLine());
            if(record_to_delete >= currentIndex)
            {
                Console.WriteLine("There is no record with this id...");
            }
            else
            {
                for(int i = record_to_delete; i < workers_array.Length - 1; i++)
                {
                    workers_array[i] = workers_array[i + 1];
                    workers_array[i].Id = i;
                }

                currentIndex--;
            }
        }

        public void EditRecord()
        {
            Console.WriteLine("Enter id to edit: ");
            int id_to_edit = int.Parse(Console.ReadLine());
            if (id_to_edit >= currentIndex)
            {
                Console.WriteLine("There is no this id...");
            }
            else
            {
                string name;
                int age;
                DateTime date_of_birth;
                string place_of_birth;
                Console.WriteLine("What would you like to edit? " +
                    "\n 1 - name " +
                    "\n 2 - age " +
                    "\n 3 - date of birth " +
                    "\n 4 - place of birth " +
                    "\n 5 - edit all");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        name = Console.ReadLine();
                        workers_array[id_to_edit].Name = name;
                        break;

                    case "2":
                        age = int.Parse(Console.ReadLine());
                        workers_array[id_to_edit].Age = age;
                        break;

                    case "3":
                        date_of_birth = DateTime.Parse(Console.ReadLine());
                        workers_array[id_to_edit].Date_of_birth = date_of_birth;
                        break;

                    case "4":
                        place_of_birth = Console.ReadLine();
                        workers_array[id_to_edit].Place_of_birth = place_of_birth;
                        break;

                    case "5":
                        name = Console.ReadLine();
                        workers_array[id_to_edit].Name = name;

                        age = int.Parse(Console.ReadLine());
                        workers_array[id_to_edit].Age = age;

                        date_of_birth = DateTime.Parse(Console.ReadLine());
                        workers_array[id_to_edit].Date_of_birth = date_of_birth;

                        place_of_birth = Console.ReadLine();
                        workers_array[id_to_edit].Place_of_birth = place_of_birth;
                        break;

                    default:
                        return;
                }
            }  
        }

        public void ShowRecordsInPeriod()
        {
            Console.WriteLine("Show records from: ");
            DateTime time_from = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("To: ");
            DateTime time_to = DateTime.Parse(Console.ReadLine());    
            
            foreach(var worker in workers_array.Take(currentIndex))
            {
                if(worker.Time_of_note >= time_from && worker.Time_of_note <= time_to)
                {
                    Console.WriteLine(worker.PrintOut());
                }
            }
        }

        public void ShowDescendingRecords()
        {
            foreach (var worker in workers_array.Take(currentIndex).OrderByDescending(date => date.Time_of_note))
            {
                Console.WriteLine(worker.PrintOut());
            }
        }

        public void ShowAscendingRecords()
        {
            foreach (var worker in workers_array.Take(currentIndex).OrderBy(date => date.Time_of_note))
            {
                Console.WriteLine(worker.PrintOut());
            }
        }

        public void Save()
        {
            using StreamWriter sw = new StreamWriter(File.Open(Path, FileMode.Create));
            foreach(var worker in workers_array.Take(currentIndex))
            {
                sw.WriteLine(worker.Serialize());
            }
        }
    }
}
