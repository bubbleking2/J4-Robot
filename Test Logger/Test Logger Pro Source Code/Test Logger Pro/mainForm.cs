using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Logger_Pro
{
    public partial class mainForm : Form
    {
        Dictionary<int, string> instructions;
        bool instructionsFileValid = true;

        Dictionary<int, string> parseInstructionFile()
        {
            Dictionary<int, string> instructions = new Dictionary<int,string>();
            string[] instructionsList = System.IO.File.ReadAllLines("commandReference.txt");

            for(int i = 0; i < instructionsList.Length; i++)
            {
                string[] thisInstruction = instructionsList[i].Split('|');
                if (thisInstruction.Length == 5)
                {
                    for (int j = 0; j < thisInstruction[1].Length; j++)
                    {
                        if (thisInstruction[1][j] < 48 || thisInstruction[1][j] > 57)
                        {
                            thisInstruction[1] = thisInstruction[1].Remove(j, 1);
                            j--;
                        }
                    }
                    for (int j = 0; j < thisInstruction[2].Length; j++)
                    {
                        if (thisInstruction[2][j] == ' ')
                        {
                            thisInstruction[2] = thisInstruction[2].Remove(j, 1);
                            j--;
                        }
                    }
                    for (int j = 0; j < thisInstruction[3].Length; j++)
                    {
                        if (thisInstruction[3][j] == ' ')
                        {
                            thisInstruction[3] = thisInstruction[3].Remove(j, 1);
                            j--;
                        }
                    }

                    try
                    {
                        instructions.Add(Convert.ToInt32(thisInstruction[1]), thisInstruction[2] + ' ' + thisInstruction[3]);
                    }
                    catch
                    {
                        instructionsFileValid = false;
                        break;
                    }
                }
            }
            return instructions;
        } 

        int[] dump(string input)
        {
            string[] data = input.Split(',');
            int[] output = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] < 48 || data[i][j] > 57)
                    {
                        data[i] = data[i].Remove(j, 1);
                        j--;
                    }
                }

                try
                {
                    output[i] = Convert.ToInt32(data[i]);
                }
                catch
                {
                }
            }

            return output;
        }

        string[] intToInstruction(int[] input)
        {
            string[] commands = new string[input.Length];
            int lengthOfOutput = commands.Length;
            string[] output;

            for (int i = 0; i < input.Length; i++)
            {
                if (instructions.ContainsKey(input[i]))
                {
                    commands[i] = instructions[input[i]];
                }
                else
                {
                    lengthOfOutput = i;
                    break;
                }
            }

            output = new string[lengthOfOutput];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = commands[i];
            }

                return output;
        }

        string[] prepareStringForOutput(string[] input)
        {
            int tabCount = 0;
            string[] output = new string[input.Length];

            foreach (string s in input)
            {
                if (s[0] == 'E')
                    tabCount++;
                else
                    tabCount--;
            }
            if (tabCount < 0)
                tabCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i][0] == 'E')
                    tabCount--;
                string thisOutput = i + "\t";
                for (int j = 0; j < tabCount; j++)
                    thisOutput += '\t';
                output[i] += thisOutput + input[i];
                if (input[i][0] == 'B')
                    tabCount++;
            }

            return output;
        }

        public mainForm()
        {
            InitializeComponent();
            System.IO.File.AppendAllText("commandReference.txt", "");
            instructions = parseInstructionFile();
            saveFile.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (!instructionsFileValid)
            {
                outputBox.Items.Add("Invalid Instructions File");
                windowDumpButton.Enabled = false;
                fileDumpButton.Enabled = false;
                chooseOutput.Enabled = false;
            }
        }

        private void fileDumpButton_Click(object sender, EventArgs e)
        {
            int[] data = dump(inputBox.Text);
            string[] instructions = intToInstruction(data);
            string[] output = prepareStringForOutput(instructions);

            System.IO.File.WriteAllText(saveFile.FileName, "");
            System.IO.File.AppendAllLines(saveFile.FileName, output);
        }

        private void windowDumpButton_Click(object sender, EventArgs e)
        {
            outputBox.Items.Clear();
            int[] data = dump(inputBox.Text);
            string[] instructions = intToInstruction(data);
            string[] output = prepareStringForOutput(instructions);

            foreach (string s in output)
                outputBox.Items.Add(s);
        }

        private void chooseOutput_Click(object sender, EventArgs e)
        {
            saveFile.ShowDialog();
        }
    }
}
