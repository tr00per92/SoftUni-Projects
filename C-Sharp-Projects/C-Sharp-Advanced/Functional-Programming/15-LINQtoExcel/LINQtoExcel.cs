using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

using ExcelLibrary.SpreadSheet;

namespace _15_LINQtoExcel
{
    public class LINQtoExcel
    {
        public static void Main()
        {
            List<Student> students = GetInput();
            List<Student> onlineStudentsSortedByResult = students
                .Where(student => student.StudentType == "Online")
                .OrderByDescending(student => student.CalculateResult())
                .ToList();

            // creating new workbook and sheet
            const string pathToOutputFile = "../../output/outputFile.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Online Students");

            // adding all the students
            for (int i = 0; i < onlineStudentsSortedByResult.Count; i++)
            {
                worksheet.Cells[i, 0] = new Cell(onlineStudentsSortedByResult[i].ID);
                worksheet.Cells[i, 1] = new Cell(onlineStudentsSortedByResult[i].FirstName);
                worksheet.Cells[i, 2] = new Cell(onlineStudentsSortedByResult[i].LastName);
                worksheet.Cells[i, 3] = new Cell(onlineStudentsSortedByResult[i].Email);
                worksheet.Cells[i, 4] = new Cell(onlineStudentsSortedByResult[i].Gender);
                worksheet.Cells[i, 5] = new Cell(onlineStudentsSortedByResult[i].StudentType);
                worksheet.Cells[i, 6] = new Cell(onlineStudentsSortedByResult[i].ExamResult);
                worksheet.Cells[i, 7] = new Cell(onlineStudentsSortedByResult[i].HomeworkSent);
                worksheet.Cells[i, 8] = new Cell(onlineStudentsSortedByResult[i].HomeworkEvaluated);
                worksheet.Cells[i, 9] = new Cell(onlineStudentsSortedByResult[i].TeamworkScore);
                worksheet.Cells[i, 10] = new Cell(onlineStudentsSortedByResult[i].AttendacesCount);
                worksheet.Cells[i, 11] = new Cell(onlineStudentsSortedByResult[i].Bonus);
                worksheet.Cells[i, 12] = new Cell(onlineStudentsSortedByResult[i].CalculateResult());
            }

            // saving the workbook
            workbook.Worksheets.Add(worksheet);
            workbook.Save(pathToOutputFile);
        }

        // this method reads the input from the text file
        private static List<Student> GetInput()
        {
            List<Student> students = new List<Student>();

            const string pathToFile = "../../txtFiles/Students-data.txt";
            StreamReader reader = new StreamReader(pathToFile);
            using (reader)
            {
                reader.ReadLine();
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] properties = Regex.Split(line, "\\s+");
                    int id = int.Parse(properties[0]);
                    int examResult = int.Parse(properties[6]);
                    int homeworkSent = int.Parse(properties[7]);
                    int homeworkEvaluated = int.Parse(properties[8]);
                    decimal teamwork = decimal.Parse(properties[9]);
                    int attendaces = int.Parse(properties[10]);
                    decimal bonus = decimal.Parse(properties[11]);

                    students.Add(new Student(id, properties[1], properties[2], properties[3], properties[4],
                        properties[5], examResult, homeworkSent, homeworkEvaluated, teamwork, attendaces, bonus));

                    line = reader.ReadLine();
                }
            }

            return students;
        }
    }
}
