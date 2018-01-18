using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the database interface
            DatabaseInterface db = new DatabaseInterface();
            //create instances of Tech, Cohort, Student and Instructor interfaces
            Tech tech = new Tech();
            Student student = new Student();
            Cohort cohort = new Cohort();
            Instructor instructor = new Instructor();
            displayData data = new displayData();

            // Check/create the Student table
            db.CheckStudentTable();
            //Check/create the Instructor table
            db.CheckInstructorTable();
            //Check/Create the Tech table
            db.CheckTechTable();
            //Check/Create the Cohort table
            db.CheckCohortTable();
            //Check/Create the Student/Cohort table
            db.CheckStudentCohortTable();
            //Check/Create the Instructor/Cohort table
            db.CheckInstructorCohortTable();

            int choice;

            do
            {
                choice = MainMenu.Show();

                switch (choice)
                {
                    case 1:
                        //add cohort
                        Console.WriteLine("Enter the Name of the Cohort (example: Day 22 or Evening 3)");
                        Console.Write(">");
                        string CohortName = Console.ReadLine();

                        Console.WriteLine("Enter the id of the technology used in this Cohort.");
                        //run code to display all tech in table with id number and tech name
                        Dictionary<int, string> techList = tech.GetTech();
                        foreach(KeyValuePair<int, string> t in techList){
                            Console.WriteLine(t.Value + " = " + t.Key);
                        }
                        
                        Console.Write(">");
                        int CohortTech = int.Parse(Console.ReadLine());

                        // Insert Cohort into database
                        db.Insert($@"
                            INSERT INTO Cohort
                            (CohortId, Name, TechId)
                            VALUES
                            (null, '{CohortName}', {CohortTech})
                        ");
                        break;
                    case 2:
                        //add student
                        Console.WriteLine("Enter the Student's First Name");
                        Console.Write(">");
                        string SFirstName = Console.ReadLine();

                        Console.WriteLine("Enter the Student's Last Name");
                        Console.Write(">");
                        string SLastName = Console.ReadLine();

                        // Insert Student into database
                        int studentId = db.Insert($@"
                            INSERT INTO Student
                            (StudentId, FirstName, LastName)
                            VALUES
                            (null, '{SFirstName}', '{SLastName}')
                        ");

                        Console.WriteLine("Add Student to Cohort by adding Cohort Id. If unknown enter 0");
                        Console.Write(">");
                        //run code to display the cohorts in table with id number and cohort name
                        Dictionary<int, string> cohortList = tech.GetTech();
                        foreach(KeyValuePair<int, string> c in cohortList){
                            Console.WriteLine(c.Value + " = " + c.Key);
                        }
                        Console.Write(">");
                        int CohortAssigned = int.Parse(Console.ReadLine()); 

                        //add student to cohort
                        if(CohortAssigned > 0){
                            db.Insert($@"
                                INSERT INTO StudentCohort
                                (StudentCohortId, StudentId, CohortId)
                                VALUES
                                (null, '{studentId}', '{CohortAssigned}')
                            ");
                        }
                        break;
                    case 3:
                        //add instructor
                        Console.WriteLine("Enter the Instructor's First Name");
                        Console.Write(">");
                        string IFirstName = Console.ReadLine();

                        Console.WriteLine("Enter the Instructor's Last Name");
                        Console.Write(">");
                        string ILastName = Console.ReadLine();

                        // Insert Instructor into database
                        db.Insert($@"
                            INSERT INTO Instructor
                            (InstructorId, FirstName, LastName)
                            VALUES
                            (null, '{IFirstName}', '{ILastName}')
                        ");
                        break;
                    case 4:
                        //add tech
                        Console.WriteLine("Add the name of a Server Side Tech");
                        Console.Write(">");
                        string TechName = Console.ReadLine();

                        // Insert Tech into database
                        db.Insert($@"
                            INSERT INTO Tech
                            (TechId, Name)
                            VALUES
                            (null, '{TechName}')
                        ");
                        break;
                    case 5:
                        //assign student to cohort
                        Console.WriteLine("Enter Student's Name");
                        Console.Write(">");
                        string studentName = Console.ReadLine();

                        int sId = student.GetStudentId(studentName);

                        Console.WriteLine("Enter Cohort Name (ex. Day 22)");
                        Console.Write(">");
                        string cName = Console.ReadLine();

                        int cId = cohort.GetCohortId(cName);

                        db.Insert($@"
                            INSERT INTO StudentCohort
                            (StudentCohortId, StudentId, CohortId)
                            VALUES
                            (null, '{sId}', '{cId}')
                        ");
                        break;
                    case 6:
                        //assign instructor to cohort
                        Console.WriteLine("Enter Instructors's Name");
                        Console.Write(">");
                        string instructorName = Console.ReadLine();

                        int inId = instructor.GetInstructorId(instructorName);

                        Console.WriteLine("Enter Cohort Name (ex. Day 22)");
                        Console.Write(">");
                        string inCName = Console.ReadLine();

                        int inCId = cohort.GetCohortId(inCName);

                        db.Insert($@"
                            INSERT INTO InstructorCohort
                            (InstructorCohortId, InstructorId, CohortId)
                            VALUES
                            (null, '{inId}', '{inCId}')
                        ");
                        break;
                    case 7:
                        //assign tech to cohort
                        Console.WriteLine("Which Cohort would you like to assign a Technology to? (ex. Day 22)");
                        Console.Write(">");
                        string cTechAssign = Console.ReadLine();

                        int tCohortId = cohort.GetCohortId(cTechAssign);

                        Console.WriteLine("Enter the id of the technology used in this Cohort.");
                        //run code to display all tech in table with id number and tech name
                        Dictionary<int, string> cTechList = tech.GetTech();
                        foreach(KeyValuePair<int, string> t in cTechList){
                            Console.WriteLine(t.Value + " = " + t.Key);
                        }
                        Console.Write(">");
                        int CohortTechId = int.Parse(Console.ReadLine());

                        db.Update($@"
                            UPDATE Cohort
                            SET TechId = {CohortTechId}
                            WHERE CohortId = {tCohortId};
                        ");

                        break;
                    case 8:
                        //display cohort data
                        Console.WriteLine("Which Cohort would you like to view data for? (ex. Day 22 or Evening 5)");
                        Console.Write(">");
                        string displayCohort = Console.ReadLine();

                        data.DisplayCohortInfo(displayCohort);
                        Console.Read();
                        

                        //display Cohort- single
                        //display Instructor(s)- list
                        //display Tech- single
                        //display Students- list
                        break;
                }

            }
            while (choice != 9);


        }
    }
}
