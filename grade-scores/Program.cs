using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grade_scores
{
    class Program
    {
        static void Main(string[] args)
        {
            String fileName = args[0];
            File file = new File(fileName);
            String fileContents = file.GetFileContents();
            ProcessStudents processStudent;
            processStudent = new ProcessStudents(fileContents);
            String newOrderedRawText = processStudent.getOrderedStudents();
            file.WriteToFile(newOrderedRawText);
            #if DEBUG
                Console.Write(newOrderedRawText);
                Console.ReadLine();
            #endif
            
           
            
            
           
        }
    }
}
