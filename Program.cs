using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CursedStuffCandyH
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I would recommend to drag your adofai level here");
            string tent = Console.ReadLine().Replace("\"", "");//Path to file
            string[] DoctorH = File.ReadAllLines(tent); //Array of string in that file
            StringBuilder sb = new StringBuilder(); //Main StringBuilder
            string FileNameAdd = "CursedV2";
            Console.WriteLine("Please choose what curse do you want to do with this level, \n1-Angled sections with extra beat(DONE), \n2-Twirls are missing(DONE), \n3-Only swing charting(DONE), \n4-there's a twirl on every tile(NOT YET), \n5-there's no fun allowed(NOT YET), \n6-every time you go up or down it gets faster(NOT YET), \n7-No Swing Charting.(DONE)");
            bool checker = false;
            while (!checker)
            {
                bool pizza = Int32.TryParse(Console.ReadLine(), out int number);
                if (pizza)
                {
                    switch (number)
                    {
                        case 1:
                            Console.WriteLine("Case 1!");
                            sb = ExtraAngledBeatus(DoctorH);
                            checker = true;
                            FileNameAdd = "ExtraAngledBeatus";
                            break;
                        case 2:
                            Console.WriteLine("Case 2!");
                            sb = NoUTwirls(DoctorH);
                            checker = true;
                            FileNameAdd = "NoUTwirls";
                            break;
                        case 3:
                            Console.WriteLine("Case 3!");
                            sb = NoUSwings(DoctorH);
                            FileNameAdd = "NoUSwings";
                            checker = true;
                            break;
                        case 7:
                            Console.WriteLine("Case 7!");
                            FileNameAdd = "NoUKSwings";
                            sb = NoUKSwings(DoctorH);
                            checker = true;
                            break;
                        default:
                            Console.WriteLine("Case default!");
                            //Everything which not else
                            checker = true;
                            break;
                    }

                }
                else
                {
                Console.WriteLine("Fuck you. Suffer with this endless loop of torture.");
                }
            }
            using var sw = new StreamWriter(tent.Replace(".adofai", FileNameAdd) +".adofai");
            sw.WriteLine(sb.ToString());
            Console.WriteLine("\ndata written to file "+ tent.Replace(".adofai", FileNameAdd) + ".adofai");
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }
        public static StringBuilder ExtraAngledBeatus(string[] DoctorH)
        {
            string RandomJCI = ""; //Basically a Help variable
            string firestix = ""; //pathData in clear form
            StringBuilder sb = new StringBuilder();
            var kins = new List<int>();//List of int ofr moving actions
            foreach (string oeufhd in DoctorH)
            {
                if (oeufhd.Contains("pathData"))
                {
                    RandomJCI = oeufhd;
                    RandomJCI = RandomJCI.Insert(0, "{");
                    RandomJCI = RandomJCI.Insert(oeufhd.Length, "}");
                    Curser m = JsonConvert.DeserializeObject<Curser>(RandomJCI);
                    firestix = m.pathData;
                    char cube = firestix[0];
                    firestix = firestix.Remove(0, 1);
                    Console.WriteLine(firestix);
                    StringBuilder bruj = new StringBuilder();
                    bruj.Append(cube);
                    char[] h = { 'U', 'R', 'D', 'L' };
                    int rhombus = 0;
                    kins.Add(rhombus);
                    foreach (char rikri in firestix)
                    {

                        if (rikri != cube && !h.Contains(rikri))
                        {
                            bruj.Append($"{rikri}{rikri}");
                            kins.Add(rhombus);
                            rhombus++;
                            kins.Add(rhombus);
                        }
                        else
                        {
                            bruj.Append(rikri);
                            kins.Add(rhombus);
                        }
                        cube = rikri;
                    }
                    string CursedPathData = $"\"pathData\": \"{bruj.ToString()}\",";
                    Console.WriteLine(CursedPathData);
                    for (int i = 0; i < kins.Count; i++)
                    {
                        Console.Write(kins[i].ToString() + " ");
                    }
                    sb.Append(CursedPathData + "\n");

                }
                else if (oeufhd.Contains("\"floor\""))
                {
                    Regex rx = new Regex("floor\": (.*?),");
                    int yeeter = Convert.ToInt32(rx.Match(oeufhd).Groups[1].Value);
                    sb.Append($"{oeufhd.Replace($"\"floor\": {yeeter}", $"\"floor\": {yeeter + kins[yeeter + kins[yeeter]]}")}\n");
                }
                else
                {
                    sb.Append($"{oeufhd}\n");
                }

            }
            return sb;
        }
        public static StringBuilder NoUTwirls(string[] DoctorH)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string line in DoctorH)
            {
                if (!line.Contains("\"Twirl\""))
                {
                    sb.Append(line+"\n");
                }
            }
            return sb;
        }
        public static StringBuilder NoUSwings(string[] DoctorH)
        {
            char[] straight = { 'U', 'D' };
            char[] swingright = { 'T', 'F' };
            char[] swingleft = { 'G', 'B' };
            string RandomJCI = ""; //Basically a Help variable
            string firestix = ""; //pathData in clear form
            StringBuilder sb = new StringBuilder();
            foreach (string line in DoctorH)
            {
                if (line.Contains("pathData"))
                {
                    RandomJCI = line;
                    RandomJCI = RandomJCI.Insert(0, "{");
                    RandomJCI = RandomJCI.Insert(line.Length, "}");
                    Curser m = JsonConvert.DeserializeObject<Curser>(RandomJCI);
                    firestix = m.pathData;
                    Console.WriteLine("What Swing do you want to choose? 1-/ , 2-\\ or 3-RANDOM SWING SIDE EVERY TILE");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            int he = 0;
                            foreach(char h in straight)
                            {
                                firestix = firestix.Replace(h, swingright[he]);
                                he++;
                            }
                            break;
                        case 2:
                            int hee = 0;
                            foreach (char h in straight)
                            {
                                firestix = firestix.Replace(h, swingleft[hee]);
                                hee++;
                            }
                            break;
                        case 3:
                            Console.WriteLine("RANDOM CASE HERE WE GO!");
                            StringBuilder randum = new StringBuilder();
                            Random bru = new Random();
                            foreach(char letter in firestix)
                            {
                                if (straight.Contains(letter))
                                {
                                    char hletter = ' ';
                                    switch (bru.Next(1, 2))
                                    {
                                        case 1:
                                            hletter = letter;
                                            randum.Append(swingleft[bru.Next(0, 2)]);
                                            break;
                                        case 2:
                                            hletter = letter;
                                            randum.Append(swingright[bru.Next(0, 2)]);
                                            break;
                                    }
                                }
                                else
                                {
                                    randum.Append(letter);
                                }
                            }
                            firestix = randum.ToString();
                            break;
                    }
                    sb.Append($"\"pathData\": \"{firestix}\",\n");
                }
                else
                {
                    sb.Append(line+"\n");
                }
            }
            return sb;
        }
        public static StringBuilder NoUKSwings(string[] DoctorH)
        {
            char[] straight = { 'U', 'D', 'U', 'D' };
            char[] swung = {'T', 'F', 'G', 'B'};
            string RandomJCI = ""; //Basically a Help variable
            string firestix = ""; //pathData in clear form
            StringBuilder sb = new StringBuilder();
            foreach (string line in DoctorH)
            {
                if (line.Contains("pathData"))
                {
                    RandomJCI = line;
                    RandomJCI = RandomJCI.Insert(0, "{");
                    RandomJCI = RandomJCI.Insert(line.Length, "}");
                    Curser m = JsonConvert.DeserializeObject<Curser>(RandomJCI);
                    firestix = m.pathData;
                    foreach(char vacuum in swung)
                    {
                        firestix = firestix.Replace(vacuum, straight[Array.IndexOf(swung, vacuum)]);
                    }
                    sb.Append($"\"pathData\": \"{firestix}\",\n");
                }
                else
                {
                    sb.Append(line + "\n");
                }
            }

            return sb;
        }
    }
    class Curser
    {
        public string pathData { get; set; }
    }
}
