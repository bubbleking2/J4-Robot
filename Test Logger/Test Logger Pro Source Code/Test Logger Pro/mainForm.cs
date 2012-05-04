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
        Dictionary<int, string> events;
        bool eventFileValid = true;

        /// <summary>
        /// Reads the "Event List.txt" file into a dictionary.
        /// </summary>
        /// <returns>The dictionary filled with events and their call values.</returns>
        Dictionary<int, string> loadEventFile()
        {
            Dictionary<int, string> events = new Dictionary<int,string>();
            string[] eventList = System.IO.File.ReadAllLines("Event List.txt");

            for(int i = 3; i < eventList.Length - 1; i++)
            {
                string[] thisEvent = eventList[i].Split('|');

                try
                {
                    events.Add(Convert.ToInt32(thisEvent[1].Replace(" ", "")), thisEvent[2].Replace(" ", ""));
                }
                catch
                {
                    eventFileValid = false;
                    break;
                }
            }

            return events;
        } 

        /// <summary>
        /// Converts testLog arrays into C# int arrays
        /// </summary>
        /// <param name="input">The testLog array being input.</param>
        /// <returns>The int array being output.</returns>
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

        /// <summary>
        /// Reads the integers in an input array and converts them into string instructions.
        /// </summary>
        /// <param name="input">The integer array containing instructions.</param>
        /// <returns>The string instructions to output.</returns>
        string[] intToInstruction(int[] input)
        {
            string[] commands = new string[input.Length];
            int lengthOfOutput = commands.Length;
            string[] output;

            for (int i = 0; i < input.Length; i++)
            {
                int firstTwoDigits = input[i];
                while(firstTwoDigits >= 100)
                    firstTwoDigits /= 10;

                if (events.ContainsKey(firstTwoDigits))
                {
                    if (input[i] % 10 == 1)
                        commands[i] = "Begin ";
                    else if (input[i] % 10 == 2)
                        commands[i] = "Kill ";
                    else
                        commands[i] = "End ";

                    commands[i] += events[firstTwoDigits];
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

        /// <summary>
        /// Adds tabs to a string array of events to format it for output.
        /// </summary>
        /// <param name="input">The string array being converted.</param>
        /// <returns>The array containing the correctly formatted data.</returns>
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
                if (input[i][0] == 'K')
                {
                    for (int j = i - 1; input[j] != "Begin " + input[i].Split()[1] && j >= 0; j--)
                    {
                        if(input[j][0] == 'B')
                            tabCount--;
                        if (input[j][0] == 'E')
                            tabCount++;
                    }
                    
                    tabCount--;
                    if(tabCount < 0)
                        tabCount = 0;
                }

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
            System.IO.File.AppendAllText("Event List.txt", "");
            events = loadEventFile();
            saveFile.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (!eventFileValid)
            {
                outputBox.Items.Add("Invalid Instructions File");
                windowDumpButton.Enabled = false;
                fileDumpButton.Enabled = false;
                chooseOutput.Enabled = false;
            }
        }

        private void fileDumpButton_Click(object sender, EventArgs e)
        {
            events = loadEventFile();
            int[] data = dump(inputBox.Text);
            string[] instructions = intToInstruction(data);
            string[] output = prepareStringForOutput(instructions);

            System.IO.File.WriteAllText(saveFile.FileName, "");
            System.IO.File.AppendAllLines(saveFile.FileName, output);
        }

        private void windowDumpButton_Click(object sender, EventArgs e)
        {
            events = loadEventFile();
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
        }
    }
}
