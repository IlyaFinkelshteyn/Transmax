using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grade_scores
{
    class ProcessStudents
    {
        Student[] students;
        Student[] newOrderedStudents;
        int size;
        String rawText;
        

        public ProcessStudents(String rawText)
        {
            this.rawText = rawText;                       
        }
        public String getOrderedStudents()
        {
            ProcessRawText();
            OrderStudents();
            return getOrderedText();
        }
        private void ProcessRawText()
        {
            string[] lines;          
            lines = rawText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            size = lines.Length;
            this.students = new Student[size];

            for(int i = 0 ;i < size; i++)
            {
                string[] splitLine = lines[i].Split(',');
                students[i] = new Student();
                students[i].firstName = splitLine[0].Trim();
                students[i].surName = splitLine[1].Trim();
                int parsedInt;
                if (Int32.TryParse(splitLine[2], out parsedInt))
                    students[i].score = parsedInt;
                else
                    throw new Exception("Score in the file is not an int.");
            }
            
        }
        private void OrderStudents()
        {
            IEnumerable<Student> query = students.OrderByDescending(student => student.score).ThenBy(student => student.surName).ThenBy(student => student.firstName);
            newOrderedStudents = new Student[size];
            int index = 0;
            foreach ( Student s in query)
            {
                newOrderedStudents[index] = new Student();
                newOrderedStudents[index].firstName = s.firstName;
                newOrderedStudents[index].surName = s.surName;
                newOrderedStudents[index].score = s.score;
                index++;
            }
        }
      
        private String getOrderedText()
        {
            String rawOrderedText;
            rawOrderedText = "";           
            for(int i = 0; i < size ; i++)
            {
                rawOrderedText = rawOrderedText + newOrderedStudents[i].surName + "," + newOrderedStudents[i].firstName + "," +
                    +newOrderedStudents[i].score ;
                if (i + 1 != size)
                    rawOrderedText = rawOrderedText + System.Environment.NewLine;
            }           
            return rawOrderedText;
        }
        
        
    }
}
