using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using grade_scores;
namespace grade_scores.tests
{
    [TestClass]
    public class ProcessStudents_tests
    {
        [TestMethod]
        public void TestProcessStudents()
        {
            String rawText =
                @"Stephanie,Wood,90
Darren,Wood,90
Rebekah,Wood,50
Judi,Bowring,90
Geoff,Bowring,99
John,Wood,75
Val,Wood,75
Janelle,Wood,75
Josh,Herron,80
Tom,Herron,75
Olivia,Herron,75
Melanie,Bowring,89";
            String expected =
                @"Bowring,Geoff,99
Bowring,Judi,90
Wood,Darren,90
Wood,Stephanie,90
Bowring,Melanie,89
Herron,Josh,80
Herron,Olivia,75
Herron,Tom,75
Wood,Janelle,75
Wood,John,75
Wood,Val,75
Wood,Rebekah,50";           
            ProcessStudents target = new ProcessStudents(rawText);
            String actual = target.getOrderedStudents();
            Assert.AreEqual(expected, actual);
        } 
        [TestMethod] 
        public void TestProcessStudentsWithSpace()
        {
            String rawText =
                @"Stephanie,Wood,90
Darren , Wood, 90
Rebekah , Wood, 50
Judi , Bowring, 90
Geoff , Bowring, 99
John , Wood, 75
Val , Wood, 75
Janelle , Wood, 75
Josh, Herron, 80
Tom, Herron, 75
Olivia, Herron, 75
Melanie, Bowring, 89";
            String expected =
                @"Bowring,Geoff,99
Bowring,Judi,90
Wood,Darren,90
Wood,Stephanie,90
Bowring,Melanie,89
Herron,Josh,80
Herron,Olivia,75
Herron,Tom,75
Wood,Janelle,75
Wood,John,75
Wood,Val,75
Wood,Rebekah,50";      
     
            ProcessStudents target = new ProcessStudents(rawText);
            String actual = target.getOrderedStudents();
            Assert.AreEqual(expected, actual);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void MissingFromFile()
        {
            String rawMissingText = 
                @"Bowring,Geoff,99
Bowring,Judi,90
Wood,Darren,90
Wood,Stephanie,90
Bowring,Melanie,89
Herron,Josh,80
Herron,75
Herron,Tom,75
Wood,Janelle,75
Wood,John,75
Wood,Val,75
Wood,Rebekah,50";
            ProcessStudents target = new ProcessStudents(rawMissingText);
            target.getOrderedStudents();
        }
    }
}
