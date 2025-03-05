    namespace dojo;

    using System.Text;
    
    public class Parser
    {
        public string[] Parse(string input)
        {
            string[] result = new string[3];
            StringBuilder current = new StringBuilder();
            bool lookup = false;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                switch (currentChar)
                {
                    case ' ':
                    case '\t':
                        lookup = current.Length > 0;
                        break;
                    case '\n':
                    case '\r':
                        lookup = current.Length > 0;
                        break;
                    default:
                        lookup = false;
                        current.Append(currentChar);
                        break;
                }

                if (lookup)
                {
                    Update(result, current.ToString());
                    current.Clear();
                    lookup = false;
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
                    if (array[2] == null)
                    {
                        array[2] = "";
                    }
                    if (array[2].Length > 0)
                    {
                        array[2] += " ";
                    }
                    array[2] += part;
                    break;
                case 0:
                    if (array[0] == null)
                    {
                        array[0] = part;
                    }
                    else
                    {
                        if (array[2] == null)
                        {
                            array[2] = "";
                        }
                        if (array[2].Length > 0)
                        {
                            array[2] += " ";
                        }
                        array[2] += part;
                    }
                    break;
                case 1:
                    if (array[1] == null)
                    {
                        array[1] = part;
                    }
                    else
                    {
                        if (array[2] == null)
                        {
                            array[2] = "";
                        }
                        if (array[2].Length > 0)
                        {
                            array[2] += " ";
                        }
                        array[2] += part;
                    }
                    break;
            }
        }

        private int Lookup(string part)
        {
            if (part == null)
            {
                return -1;
            }

            bool ok = true;
            for (int i = 0; i < part.Length; i++)
            {
                char currentChar = part[i];
                switch (currentChar)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        break;
                    default:
                        ok = false;
                        break;
                }
            }

            if (ok && part.Length == 4)
            {
                return 0;
            }

            try
            {
                if (IsThere(part))
                {
                    return 1;
                }
            }
            catch (IOException)
            {
                return 2;
            }

            return 2;
        }

        private bool IsThere(string part)
        {
            string path = "parser.txt";
            try
            {
                using (Stream stream = typeof(Parser).Assembly.GetManifestResourceStream($"Dojo.{path}"))
                {
                    if (stream != null)
                    {
                        bool ok = false;
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Equals(part))
                                {
                                    ok = true;
                                }
                            }
                        }
                        return ok;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }