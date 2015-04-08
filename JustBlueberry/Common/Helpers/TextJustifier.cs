namespace JustBlueberry.Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TextJustifier
    {
        public static string Justify(string input, int indentation = 0)
        {
            IList<string> containedWords = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            StringBuilder result = new StringBuilder();
            int outputTextWidth = GlobalConstants.DefaultBlueberryInfoWidth;
            StringBuilder currentLine = new StringBuilder();
            string line = "";
            int spacesToAdd = 0;
            int gapsCount = 0;

            for (int i = 0; i < containedWords.Count; i++)
            {
                if (currentLine.Length + containedWords[i].Length <= outputTextWidth)
                {
                    currentLine.Append(containedWords[i] + " ");
                }
                else
                {
                    i--;
                    line = currentLine.ToString().Trim();

                    spacesToAdd = outputTextWidth - line.Length;
                    gapsCount = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() - 1;
                    if (gapsCount == 0)
                    {
                        result.Append(new string(' ', indentation));
                        result.AppendLine(line);
                        currentLine.Clear();
                        continue;
                    }

                    if (spacesToAdd == gapsCount)
                    {
                        line = line.Replace(" ", "  ");
                    }
                    else
                    {
                        int indexToAdd = line.IndexOf(" ");
                        while (true)
                        {
                            int spaces = (int)Math.Ceiling((double)spacesToAdd / gapsCount);
                            line = line.Insert(indexToAdd, new string(' ', spaces));

                            spacesToAdd -= spaces;
                            if (spacesToAdd == 0)
                            {
                                break;
                            }
                            indexToAdd = line.IndexOf(" ", indexToAdd + spaces + 1);
                            gapsCount--;
                        }
                    }
                    result.Append(new string(' ', indentation));
                    result.AppendLine(line);
                    currentLine.Clear();
                }
            }
            line = currentLine.ToString().Trim();
            spacesToAdd = outputTextWidth - line.Length;
            gapsCount = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count() - 1;
            if (gapsCount == 0)
            {
                result.Append(new string(' ', indentation));
                result.Append(line);
                return result.ToString();
            }
            if (spacesToAdd == gapsCount)
            {
                line = line.Replace(" ", "  ");
            }
            else
            {
                int indexToAdd = line.IndexOf(" ");
                while (true)
                {
                    int spaces = (int)Math.Ceiling((double)spacesToAdd / gapsCount);
                    line = line.Insert(indexToAdd, new string(' ', spaces));

                    spacesToAdd -= spaces;
                    if (spacesToAdd == 0)
                    {
                        break;
                    }
                    indexToAdd = line.IndexOf(" ", indexToAdd + spaces + 1);
                    gapsCount--;
                }
            }
            result.Append(new string(' ', indentation));
            result.Append(line);
            return result.ToString();
        }
    }
}
