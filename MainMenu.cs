using System;

namespace EscapeRoom
{
    public class MainMenu
    {
        public static int Show()
        {
            Console.Clear();
            Console.WriteLine ("WELCOME TO NSS ESCAPE ROOM");
            Console.WriteLine ("**************************************");
            Console.WriteLine ("1. Add Cohort");
            Console.WriteLine ("2. Add Student");
            Console.WriteLine ("3. Add Instructor");
            Console.WriteLine ("4. Add Tech");
            Console.WriteLine ("5. Assign Student to Cohort");
            Console.WriteLine ("6. Assign Instructor to Cohort");
            Console.WriteLine ("7. Assign Tech to Cohort");
            Console.WriteLine ("8. Display Cohort Data");
            Console.WriteLine ("9. Exit");
            Console.Write ("> ");
            ConsoleKeyInfo enteredKey = Console.ReadKey();
            Console.WriteLine("");
            return int.Parse(enteredKey.KeyChar.ToString());
        }
    }
}