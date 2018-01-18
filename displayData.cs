using System;
using System.Collections.Generic;

namespace EscapeRoom
{
    //BUGGY DOESN'T WORK PROPERLY
    public class displayData
    {
        private Cohort _cohort = new Cohort();
        private Instructor _instructor = new Instructor();
        private Student _student = new Student();

        public void DisplayCohortInfo(string cohortName){
            int cohortId = _cohort.GetCohortId(cohortName);
            string techName = _cohort.GetCohortTech(cohortName);

            List<string> instructorList = _instructor.GetInstructorList(cohortName);
            List<string> studentList = _student.GetStudentList(cohortName);





            Console.WriteLine("Cohort: " + cohortName);
            Console.WriteLine("Server Side Technology: " + techName);
            Console.WriteLine("Instructor(s): " );
            foreach(string i in instructorList){
                Console.WriteLine(i);
            }
            Console.WriteLine("Students: " );
            foreach(string s in studentList){
            
                Console.WriteLine(s);
            }
        }
    }
}