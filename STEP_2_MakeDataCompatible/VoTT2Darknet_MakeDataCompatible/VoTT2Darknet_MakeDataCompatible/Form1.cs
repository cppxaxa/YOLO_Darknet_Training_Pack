﻿using System;
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
        public Form1(string _path = "")
        {
            InitializeComponent();

            if (_path != "")
            {
                string path = Path.GetFullPath(_path);
                if (Directory.Exists(path))
                    txtVottResultsPath.Text = path;
            }

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

            /* Make Test and Train file compatible
             */

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








            /* Mod cfg file and set subdivision to 16
             */

            string relativePathToCfgFile = @"yolo-obj.cfg";
            string[] CfgFileLines = File.ReadAllLines(txtVottResultsPath.Text + "\\" + relativePathToCfgFile);

            var writer = File.CreateText(txtVottResultsPath.Text + "\\" + relativePathToCfgFile);

            foreach (var line in CfgFileLines)
            {
                //Console.WriteLine(line);

                string[] keyValue = line.Split('=');

                if (keyValue.Length > 1)
                {
                    string[] valueArray = new string[keyValue.Length - 1];
                    for (int i = 1; i < keyValue.Length; i++)
                        valueArray[i - 1] = keyValue[i];

                    string key = keyValue[0];
                    string value = String.Join("", valueArray);


                    // Modification conditions

                    if (key.Trim() == "subdivisions")
                    {
                        value = "16";

                        Console.WriteLine("\t\tSubdivisions Changes to " + value);
                    }

                    //Console.WriteLine(key);

                    writer.WriteLine(key + "=" + value);
                }
                else
                    writer.WriteLine(line);
            }

            writer.Close();





            /* Create backup folder in VoTT_Results
             */

            Directory.CreateDirectory(txtVottResultsPath.Text + "\\backup");




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
