using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LetterFrequency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 1: We cast the sender to a textbox
            TextBox Txtbx = sender as TextBox;
            // 2: We retreive the text from Txtbx
            string InputText = Txtbx.Text;
            
            char[] d = { ' ' };
            // We split the string into 'words' and remove empty elements (double spaces)
            string[] Words = Txtbx.Text.Split(d, StringSplitOptions.RemoveEmptyEntries);
            List<CharacterCounter> CounterData = new List<CharacterCounter>();
            List<char> characters = new List<char>();
            // We extract each character from each word
            foreach (var Word in Words)
            {
                foreach (char Character in Word)
                {
                    characters.Add(Character);
                }
            }
            PrintArray(characters);
            // While we still have characters to count
            while (characters.Count > 0)
            {
                //Get the first character
                char target = characters[0];
                //Count the amount of that character present in the array
                int c = characters.Count(x => (x == target));
                // Add that Data to the result
                CounterData.Add(new CharacterCounter() { Character = target.ToString(), count= c });
                // Remove all instances of that character
                characters.RemoveAll(x => x == target);
            }
            //Sort The data (alphabetically)
            CounterData.Sort();
            //Print the result to the output.
            OutPut.Text = "";
            int a = 0;
            foreach (var item in CounterData)
            {
                String s = item.ToString();
                string s1 = $"[{s}";
                string s2 = s1.PadRight(8, ' ');
                string s3 = $"{s2}]";
                OutPut.Text += s3;
                a++;
                a = a % 3;
                if (a == 0)
                {
                    OutPut.Text += "\n";
                }
            }
        }

        private void PrintArray<T>(IEnumerable<T> words)
        {
            Console.WriteLine(words.ToString());
            foreach (var item in words)
            {
                Console.Write($"{item}|");
            }
            Console.WriteLine("");
        }

    }
}
