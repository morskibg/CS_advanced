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
            public string PatientsName { get; set; }
            public string Department { get; set; }
            public string Doctor { get; set; }
            public int BedNumber { get; set; }

            public Patient(string patientsName, string department, string doctor)
            {
                this.PatientsName = patientsName;
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
                string doctorsName = tokens[1] + " " + tokens[2];
                string patientsName = tokens[3];
                string department = tokens[0];
                Patient currPatient = new Patient(patientsName, department, doctorsName);
                int lastOccupedBedInDepartment = 0;

                if (database.Where(x => x.Department == department).Count() > 0)
                {
                    lastOccupedBedInDepartment = database.Where(x => x.Department == department)
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
                string pattern = @"(?<first_name>\b[^\s]+)\s*(?<digit>\b[\d]*)\s*(?<second_name>\b[^\s]*)";
                Regex rg = new Regex(pattern);
                Match mc = rg.Match(input);

                if (mc.Groups["digit"].Value != "")
                {
                    int roomToPrintPatients = int.Parse(mc.Groups["digit"].Value);

                    foreach (var patient in database.Where(x => x.Department == mc.Groups["first_name"].Value)
                        .Where(x => x.BedNumber <= roomToPrintPatients * 3 && x.BedNumber > roomToPrintPatients * 3 - 3)
                        .OrderBy(x => x.PatientsName))
                    {
                        Console.WriteLine(patient.PatientsName);
                    }
                }

                else if (mc.Groups["second_name"].Value != "")
                {

                    string doctor = mc.Groups["first_name"].Value + " " + mc.Groups["second_name"].Value;

                    foreach (var patient in database.Where(x => x.Doctor == doctor).OrderBy(x => x.PatientsName))
                    {
                        Console.WriteLine(patient.PatientsName);
                    }
                }
                else
                {
                    foreach (var patient in database.Where(x => x.Department == mc.Groups["first_name"].Value)
                        .OrderBy(x => x.BedNumber))
                    {
                        Console.WriteLine($"{patient.PatientsName}");
                    }
                }

            }
        }
    }
}
