using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using SchedulerGUI.ClassInformation;

namespace SchedulerGUI.Source_Configuration
{
    class ExcelReader
    {
        // Initialize nulls for Excel for finally block.
        private Excel.Application xlApp = null;
        private Excel.Workbook xlWorkBook = null;
        private Excel.Worksheet xlWorkSheet = null;

        public Course[] readFile(string fileName) 
        {
                
            try
            {
                Excel.Range range;
                //Start Excel and get Application object.
                this.xlApp = new Excel.Application();

                // Open the Source Workbook and get the active sheet
                this.xlWorkBook = this.xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                this.xlWorkSheet = this.xlWorkBook.ActiveSheet;

                // Get cells with data
                range = this.xlWorkSheet.UsedRange;
                int rows = range.Rows.Count;

                // Create course list
                Course[] courses = new Course[rows - 1];

                // Loop through all rows of source file
                for (int rCnt = 2; rCnt <= rows; rCnt++)
                {
                    // Extract course info from Excel
                    string teacherName = (string)(range.Cells[rCnt, 1] as Excel.Range).Value2;
                    string courseName = (string)(range.Cells[rCnt, 2] as Excel.Range).Value2;
                    int courseCode = (int)(range.Cells[rCnt, 3] as Excel.Range).Value2;
                    string courseRoom = (string)(range.Cells[rCnt, 4] as Excel.Range).Value2;
                    int hoursPerWeek = (int)(range.Cells[rCnt, 5] as Excel.Range).Value2;
                    int doublePeriods = (int)(range.Cells[rCnt, 6] as Excel.Range).Value2;

                    // Create course with info
                    Course course = new Course(courseCode, teacherName, courseName, courseRoom, hoursPerWeek, doublePeriods);
                    // Add course to course list
                    courses[rCnt - 2] = course;

                }

                // Return the course list
                return courses;

            }
            catch (Exception e)
            {
                // On fail, return null
                return null;
            }
            finally {

                // Close the application and workbook.
                this.xlWorkBook.Close(false, null, null);
                this.xlApp.Quit();
            }

        }
    }
}