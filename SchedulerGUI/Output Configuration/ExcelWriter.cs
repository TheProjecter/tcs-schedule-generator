using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using SchedulerGUI.ClassInformation;
using System.Reflection;

namespace SchedulerGUI.Output_Configuration
{
    class ExcelWriter
    {
        // Initialize nulls for Excel.
        private Excel.Application xlApp = null;
        private Excel.Workbook xlWorkBook = null;
        private Excel.Worksheet xlWorkSheet = null;

        public void outputToFile(string fileName, Schedule[] schedules)
        {
            fileName += "teacherSchedules.xlsx";

            //Start Excel and get Application object.
            this.xlApp = new Excel.Application();

            // Open the Source Workbook and get the active sheet
            this.xlWorkBook = this.xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            this.xlWorkSheet = this.xlWorkBook.ActiveSheet;

            int columnNumber = 5;

            foreach (Schedule schedule in schedules)
            {
                insertTeacherSchedule(columnNumber, schedule);
            }

            

        }

        private void insertTeacherSchedule(int columnNumber, Schedule schedule)
        {
            try
            {
                for (int day = 1; day <= 5; day++)
                {
                    for (int period = 1; period <= 7; period++)
                    {
                        Course course = schedule.getCourse(day, period);

                        if (course == null)
                        {
                            continue;
                        }
                        else
                        {
                            int row = (day - 1) * 8 + period + 2;
                            if (period <= 4)
                            {
                                xlWorkSheet.Cells[row, columnNumber] = course.getCourseCode();
                                xlWorkSheet.Cells[row, columnNumber + 1] = course.getCourseRoom();
                            }
                            else
                            {
                                xlWorkSheet.Cells[row + 1, columnNumber] = course.getCourseCode();
                                xlWorkSheet.Cells[row + 1, columnNumber + 1] = course.getCourseRoom();
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                xlWorkBook.Close(false, null, null);
                xlApp.Quit();
            }
        }
    }
}
