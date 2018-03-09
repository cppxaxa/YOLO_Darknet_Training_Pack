using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoTT2Darknet_MakeDataCompatible
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (File.Exists("VoTTResultsPath.txt"))
            {
                string path = File.ReadAllText("VoTTResultsPath.txt").Trim();

                if (Directory.Exists(path))
                    txtVottResultsPath.Text = path;
            }
        }

        private void btnBrowseVottResultsPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtVottResultsPath.Text = fbd.SelectedPath;

                    File.WriteAllText("VoTTResultsPath.txt", fbd.SelectedPath);
                }
            }
        }

        private void btnMakeCompatible_Click(object sender, EventArgs e)
        {
            while (txtVottResultsPath.Text.Length > 0 && (txtVottResultsPath.Text[txtVottResultsPath.Text.Length - 1] == '\\' || txtVottResultsPath.Text[txtVottResultsPath.Text.Length - 1] == '/'))
                txtVottResultsPath.Text = txtVottResultsPath.Text.Substring(0, txtVottResultsPath.Text.Length - 1);

            //MessageBox.Show(txtVottResultsPath.Text);

            string relativePathToTestFile = @"data\test.txt";
            string relativePathToTrainFile = @"data\train.txt";

            string TestFileContents = File.ReadAllText(txtVottResultsPath.Text + "\\" + relativePathToTestFile);
            string TrainFileContents = File.ReadAllText(txtVottResultsPath.Text + "\\" + relativePathToTrainFile);





            string[] TrainFileLines = TrainFileContents.Split(new string[] { ".jpg" }, StringSplitOptions.None);

            var TrainFileWriter = File.CreateText(txtVottResultsPath.Text + "\\" + relativePathToTrainFile);
            bool firstLine = true;


            foreach (var line in TrainFileLines)
            {
                string val = ModdedTrim(line);

                if (val != "" && val != "\r\n" && val != "\n" && val != "\r")
                {
                    Console.WriteLine(val + ".jpg");

                    if (!firstLine)
                        TrainFileWriter.WriteLine();
                    else
                        firstLine = false;

                    TrainFileWriter.Write(val + ".jpg");
                }
            }

            TrainFileWriter.Close();




            string[] TestFileLines = TestFileContents.Split(new string[] { ".jpg" }, StringSplitOptions.None);

            var TestFileWriter = File.CreateText(txtVottResultsPath.Text + "\\" + relativePathToTestFile);
            firstLine = true;

            foreach (var line in TestFileLines)
            {
                string val = ModdedTrim(line);

                if (val != "" && val != "\r\n" && val != "\n" && val != "\r")
                {
                    Console.WriteLine(val + ".jpg");

                    if (!firstLine)
                        TestFileWriter.WriteLine();
                    else
                        firstLine = false;

                    TestFileWriter.Write(val + ".jpg");
                }
            }

            TestFileWriter.Close();




            Console.WriteLine("!!Done!!");
        }

        private string ModdedTrim(string val)
        {
            while (val.Length > 0 && !char.IsLetterOrDigit(val[0]))
                val = val.Substring(1);

            while (val.Length > 0 && !char.IsLetterOrDigit(val[val.Length - 1]))
                val = val.Substring(0, val.Length - 1);

            return val;
        }
    }
}
