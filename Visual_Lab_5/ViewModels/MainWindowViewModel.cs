using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using ReactiveUI;

namespace Visual_Lab_5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string text = "";
        string text2 = "";
        string patternold = "";
        string patternnew = "";

        public string TextIn
        {
            get { return text; }

            set
            {
                this.RaiseAndSetIfChanged(ref text, value);
                TextOut = "";
                foreach (Match match in Regex.Matches(text, patternnew))
                {
                    TextOut += $"{match.Value}\n";
                }

            }
        }
        public string TextOut
        {
            get { return text2; }

            set
            {
                this.RaiseAndSetIfChanged(ref text2, value);
            }
        }

        string pathin = "";

        public string SetPath
        {
            get => pathin;

            set
            {
                pathin = value;
                TextIn = File.ReadAllText(pathin);
            }
        }

        string pathout = "";

        public string GetPath
        {
            get => pathout;

            set
            {
                pathout = value;
                File.AppendAllText(pathout, text2);
            }
        }


        public string PatternOld
        {
            get => patternold;

            set
            {
                patternold = value;
            }
        }

        public string PatternNew
        {
            get => patternnew;

            set
            {
                patternnew = value;
                TextOut = "";
                foreach (Match match in Regex.Matches(text, patternnew))
                {
                    TextOut += $"{match.Value}\n";
                }
            }
        }
    }
}