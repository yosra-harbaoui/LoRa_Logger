using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CsvHelper;
using Newtonsoft.Json;

namespace LoRa_Logger
{
    /// <summary>
    /// A class of features that simplify the writing and reading of files
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Open and read a CSV file
        /// </summary>
        /// <returns>
        /// a list of entries in the csv
        /// </returns>
        public static List<T> ReadCSV<T>()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    using (TextReader textReader = File.OpenText(filePath))
                    {
                        using (CsvReader csvReader = new CsvReader(textReader))
                        {
                            csvReader.Configuration.HeaderValidated = null;
                            csvReader.Configuration.MissingFieldFound = null;

                            return csvReader.GetRecords<T>().ToList();
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Convert any list of objects to CSV and save the resulting file
        /// </summary>
        /// <param name="obj">the list of objects to be converted</param>
        public static void WriteCSV<T>(List<T> objs)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV (*.csv)|*.csv";
                saveFileDialog.FileName = "OutputCSV";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (TextWriter textWriter = File.CreateText(filePath))
                    {
                        using (CsvWriter csvWriter = new CsvWriter(textWriter))
                        {
                            csvWriter.WriteRecords(objs);
                        }
                    }
                }
            }

            MessageBox.Show("File saved !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Open and read a JSON file
        /// </summary>
        /// <returns>
        /// a string containing the json
        /// </returns>
        public static string ReadJSON()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    using (TextReader textReader = File.OpenText(filePath))
                    {
                        return textReader.ReadToEnd();
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Convert any object to JSON and save the resulting file
        /// </summary>
        /// <param name="obj">the object to be converted</param>
        public static void WriteJSON(object obj)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON (*.json)|*.json";
                saveFileDialog.FileName = "OutputJSON";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string output = JsonConvert.SerializeObject(obj, Formatting.Indented);

                    File.WriteAllText(saveFileDialog.FileName, output, Encoding.UTF8);

                    MessageBox.Show("File saved !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Get selected files paths
        /// </summary>
        /// <returns>
        /// filepaths of selected files
        /// </returns>
        public static string[] GetFilePaths(int min = 2, int max = 3)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePaths = openFileDialog.FileNames;

                    if (filePaths.Length < min || filePaths.Length > max)
                    {
                        MessageBox.Show("You need to select " + min + " or " + max + " files !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        if (MessageBox.Show("Selected files:" + Environment.NewLine + string.Join(Environment.NewLine, filePaths.ToArray()), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            return filePaths;
                        }
                    }
                }
            }

            return null;
        }
    }
}