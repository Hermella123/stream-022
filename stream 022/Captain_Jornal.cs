using System;
using System.IO;

namespace stream_022
{
    class Captain_Jornal
    {
        public string date;
        public Captain_Jornal()
        {
            date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            if (!File.Exists(date + ".txt"))
            {
                using (StreamWriter sw = new StreamWriter(date + ".txt"))
                {
                    sw.Write("Captain's log\n");
                    sw.Write("Start Date<" + date + ">\n\n");
                    sw.Close();
                }

            }
            else
            {
                using (StreamWriter sw = new StreamWriter("temp.txt"))
                {
                    using (StreamReader sr = new StreamReader(date + ".txt"))
                    {
                        string read = sr.ReadLine();
                        while (read != "Jean-Luc Picard")
                        {
                            sw.WriteLine(read);
                            read = sr.ReadLine();
                        }
                        sw.Close();
                    }
                }
                using (StreamWriter sw = new StreamWriter(date + ".txt"))
                {
                    using (StreamReader sr = new StreamReader("temp.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                        sw.Close();
                    }
                }
                File.Delete("temp.txt");
            }
        }
        public void endLine()
        {
            using (StreamWriter sw = File.AppendText(date + ".txt"))
            {
                sw.WriteLine("Jean-Luc Picard");
                sw.Close();
            }
        }
        public void Save(string input)
        {
            string correct;
            if (input.Contains("start"))
            {
                correct = input.After("start");
            }
            else if (input.Contains("stop"))
            {
                correct = input.Before("stop");
            }
            else
            {
                correct = input;
            }

            StreamWriter sw = File.AppendText(date + ".txt");
            sw.WriteLine(correct);
            sw.Close();
        }
    }
}
