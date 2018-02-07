using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Program
    {
        struct Patient
        {
            public string FullName { get; set; }
            public string Department { get; set; }
            public string Doctor { get; set; }
            public int BedNumber { get; set; }

            public Patient(string fullName, string department, string doctor)
            {
                this.FullName = fullName;
                this.Department = department;
                this.Doctor = doctor;
                this.BedNumber = 0;
            }
        }
        static void Main(string[] args)
        {
            List<Patient> database = new List<Patient>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Output")
                {
                    break;
                }
                string[] tokens = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToArray();
                string doctorsName = tokens[1] + tokens[2];
                Patient currPatient = new Patient(tokens[3], tokens[0], doctorsName);
                int lastOccupedBedInDepartment = 0;

                if (database.Where(x => x.Department == tokens[0]).Count() > 0)
                {
                    lastOccupedBedInDepartment = database.Where(x => x.Department == tokens[0])
                        .OrderByDescending(x => x.BedNumber).First().BedNumber;
                }
                if (lastOccupedBedInDepartment == 60)
                {
                    continue;
                }
                currPatient.BedNumber = lastOccupedBedInDepartment + 1;
                database.Add(currPatient);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string pattern = @"(?<first_name>[A-Za-z]+)\s*(?<second_name>[A-Za-z]*)\s*(?<digit>\d)*";
                Regex rg = new Regex(pattern);
                Match mc = rg.Match(input);
                
                if (mc.Groups["second_name"].Value != "")
                {
                    string doctor = mc.Groups["first_name"].Value + mc.Groups["second_name"].Value;
                    foreach (var patient in database.Where(x => x.Doctor == doctor).OrderBy(x => x.FullName))
                    {
                        Console.WriteLine(patient.FullName);
                    }
                }
                
                else if (mc.Groups["digit"].Value != "")
                {
                    int roomTiPrintPatient = int.Parse(mc.Groups["digit"].Value);
                    foreach (var patient in database.Where(x => x.Department == mc.Groups["first_name"].Value)
                        .Where(x => x.BedNumber <= roomTiPrintPatient * 3 && x.BedNumber > (roomTiPrintPatient - 1) * 3)
                        .OrderBy(x => x.FullName))
                    {
                        Console.WriteLine(patient.FullName);
                    }
                }
                else
                {
                    foreach (var patient in database.Where(x => x.Department == mc.Groups["first_name"].Value)
                        .OrderBy(x => x.BedNumber))
                    {
                        Console.WriteLine(patient.FullName);
                    }
                }

            }
        }
    }
}
