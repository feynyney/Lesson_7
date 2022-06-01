using System;

namespace HW7_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "Database.txt";
            bool flag = true;

            Repository repository = new Repository(path);
            while(flag)
            {
                Console.WriteLine(
                    "\n" +
                    "0 - to exit \n" +
                    " 1 - Show records \n" +
                    " 2 - Create new worker \n" +
                    " 3 - Show chosen record \n" +
                    " 4 - Delete record \n" +
                    " 5 - Edit record" +
                    " 6 - Show records in period \n" +
                    " 7 - ShowDescendingRecords \n" +
                    " 8 - ShowAscendingRecords \n" +
                    "\n");
                string action = Console.ReadLine();
                
                switch (action)
                {
                    case "0":
                        flag = false;
                        return;

                    case "1":
                        repository.ShowRecords();
                        break;

                    case "2":
                        repository.CreateWorker();
                        break;

                    case "3":
                        repository.ShowExactRecord();
                        break;

                    case "4":
                        repository.DeleteRecord();
                        break;

                    case "5":
                        repository.EditRecord();
                        break;

                    case "6":
                        repository.ShowRecordsInPeriod();
                        break;

                    case "7":
                        repository.ShowDescendingRecords();
                        break;

                    case "8":
                        repository.ShowAscendingRecords();
                        break;
                }
            
            }

            repository.Save();
        }
    }
}