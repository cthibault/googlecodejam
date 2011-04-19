using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeJam
{
    public class T9Problem : IProblem
    {
        public string Words { get; set; }

        public T9Problem(string words)
        {
            Words = words;
        }

        public string Solve()
        {
            StringBuilder builder = new StringBuilder();

            string value = string.Empty;
            string previousValue = string.Empty;
            foreach (char c in Words)
            {
                value = _t9Value(c);
                if (previousValue.LastOrDefault() == value.FirstOrDefault())
                    builder.Append(" ");
                builder.Append(value);
                previousValue = value;
            }

            return builder.ToString();
        }
        private string _t9Value(char c)
        {
            string output = string.Empty;
            switch (c)
            {
                case ' ':
                    output = "0";
                    break;
                case 'a':
                case 'A':
                    output = "2";
                    break;
                case 'b':
                case 'B':
                    output = "22";
                    break;
                case 'c':
                case 'C':
                    output = "222";
                    break;
                case 'd':
                case 'D':
                    output = "3";
                    break;
                case 'e':
                case 'E':
                    output = "33";
                    break;
                case 'f':
                case 'F':
                    output = "333";
                    break;
                case 'g':
                case 'G':
                    output = "4";
                    break;
                case 'h':
                case 'H':
                    output = "44";
                    break;
                case 'i':
                case 'I':
                    output = "444";
                    break;
                case 'j':
                case 'J':
                    output = "5";
                    break;
                case 'k':
                case 'K':
                    output = "55";
                    break;
                case 'l':
                case 'L':
                    output = "555";
                    break;
                case 'm':
                case 'M':
                    output = "6";
                    break;
                case 'n':
                case 'N':
                    output = "66";
                    break;
                case 'o':
                case 'O':
                    output = "666";
                    break;
                case 'p':
                case 'P':
                    output = "7";
                    break;
                case 'q':
                case 'Q':
                    output = "77";
                    break;
                case 'r':
                case 'R':
                    output = "777";
                    break;
                case 's':
                case 'S':
                    output = "7777";
                    break;
                case 't':
                case 'T':
                    output = "8";
                    break;
                case 'u':
                case 'U':
                    output = "88";
                    break;
                case 'v':
                case 'V':
                    output = "888";
                    break;
                case 'w':
                case 'W':
                    output = "9";
                    break;
                case 'x':
                case 'X':
                    output = "99";
                    break;
                case 'y':
                case 'Y':
                    output = "999";
                    break;
                case 'z':
                case 'Z':
                    output = "9999";
                    break;
            }

            return output;
        }
    }
}
