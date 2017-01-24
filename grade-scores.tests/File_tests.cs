using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace grade_scores.tests
{
    [TestClass]
    public class File_tests
    {
        [TestMethod]
        [DeploymentItem("student.txt",".")]
        public void TestFile()
        {
            File target = new File("student.txt");
            String actual = target.GetFileContents();
            String expected =
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
        Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [DeploymentItem("studentEmpty.txt",".")]
        public void GetEmptyFile()
        {
            File target = new File("studentEmpty.txt");
            String actual = target.GetFileContents();
            String expected = "";
            Assert.AreEqual(expected, actual);
 
        }
    }
}
