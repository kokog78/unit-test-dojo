using System;
using System.IO;
using System.Text;

namespace dojo
{
    public class Parser
    {

        private readonly string _resourcePath;

        public Parser()
        {
            // Relatív útvonal beállítása
            _resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "parser.txt");
        }

        public string[] Parse(string input)
        {
            string?[] result = new string?[3];
            StringBuilder current = new StringBuilder();
            bool lookup = false;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                switch (currentChar)
                {
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                        lookup = current.Length > 0;
                        if (lookup)
                        {
                            Update(result, current.ToString());
                            current.Clear();
                            lookup = false;
                        }
                        break;
                    default:
                        current.Append(currentChar);
                        break;
                }
            }

            if (current.Length > 0)
            {
                Update(result, current.ToString());
            }

            return result;
        }

        private void Update(string[] array, string part)
        {
            int what = Lookup(part);
            switch (what)
            {
                case 2:
                    array[2] = (array[2] ?? "") + (array[2]?.Length > 0 ? " " : "") + part;
                    break;
                case 0:
                    if (array[0] == null)
                    {
                        array[0] = part;
                    }
                    else
                    {
                        array[2] = (array[2] ?? "") + (array[2]?.Length > 0 ? " " : "") + part;
                    }
                    break;
                case 1:
                    if (array[1] == null)
                    {
                        array[1] = part;
                    }
                    else
                    {
                        array[2] = (array[2] ?? "") + (array[2]?.Length > 0 ? " " : "") + part;
                    }
                    break;
            }
        }

        private int Lookup(string part)
        {
            if (string.IsNullOrEmpty(part))
            {
                return -1;
            }

            bool isNumeric = true;
            foreach (char c in part)
            {
                if (!char.IsDigit(c))
                {
                    isNumeric = false;
                    break;
                }
            }

            if (isNumeric && part.Length == 4)
            {
                return 0;
            }

            if (IsThere(part))
            {
                return 1;
            }

            return 2;
        }

        public bool IsThere(string part)
        {
            try
            {
                if (File.Exists(_resourcePath))
                {
                    foreach (var line in File.ReadLines(_resourcePath, Encoding.UTF8))
                    {
                        if (line.Trim().Equals(part, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }

            return false;
        }
    }
}
