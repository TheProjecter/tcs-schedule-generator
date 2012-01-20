using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SchedulerGUI.Source_Configuration;
using SchedulerGUI.ClassInformation;
using SchedulerGUI.Output_Configuration;
using SchedulerGUI.CSP_Solver;

namespace SchedulerGUI
{
    public partial class generatorGUI : Form
    {
        public generatorGUI()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void sourceBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = sourceFileDialog.ShowDialog();
            if (result == DialogResult.OK)
                sourceTextBox.Text = sourceFileDialog.FileName; 

        }

        private void outputFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = outputBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
                outputFolderTextBox.Text = outputBrowserDialog.SelectedPath;
        }

        private void generateScheduleButton_Click(object sender, EventArgs e)
        {
            ExcelReader xlReader = new ExcelReader();
            CSPSolver cspSolver = new CSPSolver();
            ExcelWriter xlOutput = new ExcelWriter();

            Course[] courses = xlReader.readFile(sourceTextBox.Text);

            Schedule[] schedules = cspSolver.findScheduleSolution(courses);

            xlOutput.outputToFile(outputFolderTextBox.Text, schedules);
        }
    }
}
