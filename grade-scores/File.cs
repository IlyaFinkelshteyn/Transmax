using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace grade_scores
{
    public class File
    {
        String fileName;
        String absoluteFilePath;
        String suffix = "-graded.txt";

        public File(String fileName)
        {
            this.fileName = fileName;
            GetAbsolutePath();
        }

        private void GetAbsolutePath()
        {
            if (fileName == System.IO.Path.GetFullPath(fileName))
            {
                absoluteFilePath = fileName;
            }
            else
            {
                String location = Assembly.GetExecutingAssembly().Location;
                String directory = System.IO.Path.GetDirectoryName(location);
                this.absoluteFilePath = directory + @"\" + fileName;
            }
        }
        public string AbsolutePath
        {
            get
            {
                return absoluteFilePath;
            }
        }
        public String GetFileContents()
        {
            String readText = System.IO.File.ReadAllText(absoluteFilePath);
            return readText;
        }
        public bool WriteToFile(String fileContents)
        {
            System.IO.File.WriteAllText(absoluteFilePath.Replace(".txt",suffix), fileContents);
            return true;
        }
    }
}
