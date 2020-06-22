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
            string RandomJCI = ""; //Basically a Help variable
            string firestix = ""; //pathData in clear form
            string tent = Console.ReadLine().Replace("\"", "");//Path to file
            string[] DoctorH = System.IO.File.ReadAllLines(tent); //Array of string in that file
            StringBuilder sb = new StringBuilder(); //Main StringBuilder
            StringBuilder events = new StringBuilder();
            var kins = new List<int>();//List of int ofr moving actions
            char[] alex;//list of chars of pathData
            int[] actions = null;
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
                    alex = firestix.ToArray();
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
                else if(oeufhd.Contains("\"floor\""))
                {
                    Regex rx = new Regex("floor\": (.*?),");
                    int yeeter = Convert.ToInt32(rx.Match(oeufhd).Groups[1].Value);
                    //actions.Append(yeeter);
                    sb.Append($"{oeufhd.Replace($"\"floor\": {yeeter}", $"\"floor\": {yeeter+kins[yeeter+kins[yeeter]]}")}\n");
                }
                else
                {
                    sb.Append($"{oeufhd}\n");
                }

            }

            using var sw = new StreamWriter(tent.Replace(".adofai", "CursedV2")+".adofai");
            sw.WriteLine(sb.ToString());
            Console.WriteLine("\ndata written to file "+ tent.Replace(".adofai", "CursedV") + ".adofai");
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
        }
    }
    class Curser
    {
        public string pathData { get; set; }
    }
}
