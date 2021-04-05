﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;



namespace NMFileClasses
{


    class FindTemp
    {
        public string path;
        public List<string> listOfFiles = new List<string>();

        //якщо нічого не передалось - проблема
        public FindTemp()
        {
            path = @"c:\Windows\temp";

            //string Account = Environment.UserName;
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            try
            {
                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        listOfFiles.Add(file.Name);
                        //file.Delete();
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "Not Access",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            
        }

        
    }

    class ClearTemp
    {
        public string path;
        //public List<string> listOfFiles = new List<string>();

        public ClearTemp()
        {

        }

        public ClearTemp(ListBox listBox, ProgressBar progressBar)
        {
            path = @"c:\Windows\temp";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
                        
            if (dirInfo.Exists)
            {
                int count = dirInfo.GetFiles().Length;
                double step = (double) 100 / count;
                progressBar.Value = 0;
                string nonDeleted = "";
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    try
                    {
                        listBox.Items.Remove(file.Name);
                        progressBar.Value = Convert.ToInt32((Convert.ToDouble(progressBar.Value) + step)) - 1;
                        file.Delete();
                    }
                    catch(System.IO.IOException) 
                    {
                        nonDeleted += file.Name + "\n";
                        listBox.Items.Remove(file.Name);
                        listBox.Items.Add(file.Name);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        nonDeleted += file.Name + "\n";
                        listBox.Items.Remove(file.Name);
                        listBox.Items.Add(file.Name);
                    }
                }                

                progressBar.Value = 100;
                if (listBox.Items.Count == 0)
                {
                    MessageBox.Show(
                        "We deleted everything!",
                        "Success!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                } 
                else
                {
                    MessageBox.Show(
                        "Cant delete: \n" + nonDeleted,
                        "Success!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            } 
        }
    }
}