using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Collect personal details
        Console.WriteLine("Enter your full name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your email address:");
        string email = Console.ReadLine();

        Console.WriteLine("Enter your phone number:");
        string phone = Console.ReadLine();

        // Collect education details
        List<Education> educationList = new List<Education>();
        Console.WriteLine("Enter your education details (type 'done' when finished):");
        while (true)
        {
            Console.WriteLine("Enter the name of the institution:");
            string institution = Console.ReadLine();
            if (institution.ToLower() == "done") break;

            Console.WriteLine("Enter the degree obtained:");
            string degree = Console.ReadLine();

            Console.WriteLine("Enter the year of graduation:");
            string year = Console.ReadLine();

            educationList.Add(new Education(institution, degree, year));
        }

        // Collect work experience
        List<WorkExperience> workExperienceList = new List<WorkExperience>();
        Console.WriteLine("Enter your work experience (type 'done' when finished):");
        while (true)
        {
            Console.WriteLine("Enter the company name:");
            string company = Console.ReadLine();
            if (company.ToLower() == "done") break;

            Console.WriteLine("Enter the job title:");
            string jobTitle = Console.ReadLine();

            Console.WriteLine("Enter the duration (e.g., 2018-2020):");
            string duration = Console.ReadLine();

            Console.WriteLine("Enter the job description:");
            string jobDescription = Console.ReadLine();

            workExperienceList.Add(new WorkExperience(company, jobTitle, duration, jobDescription));
        }

        // Collect skills
        List<string> skills = new List<string>();
        Console.WriteLine("Enter your skills (type 'done' when finished):");
        while (true)
        {
            string skill = Console.ReadLine();
            if (skill.ToLower() == "done") break;
            skills.Add(skill);
        }

        // Display the resume
        Console.WriteLine("\nRESUME\n");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Email: " + email);
        Console.WriteLine("Phone: " + phone);

        Console.WriteLine("\nEducation:");
        foreach (var edu in educationList)
        {
            Console.WriteLine(edu.ToString());
        }

        Console.WriteLine("\nWork Experience:");
        foreach (var work in workExperienceList)
        {
            Console.WriteLine(work.ToString());
        }

        Console.WriteLine("\nSkills:");
        foreach (var skill in skills)
        {
            Console.WriteLine("- " + skill);
        }
    }
}

class Education
{
    public string Institution { get; set; }
    public string Degree { get; set; }
    public string Year { get; set; }

    public Education(string institution, string degree, string year)
    {
        Institution = institution;
        Degree = degree;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Degree} from {Institution} ({Year})";
    }
}

class WorkExperience
{
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public string Duration { get; set; }
    public string JobDescription { get; set; }

    public WorkExperience(string company, string jobTitle, string duration, string jobDescription)
    {
        Company = company;
        JobTitle = jobTitle;
        Duration = duration;
        JobDescription = jobDescription;
    }

    public override string ToString()
    {
        return $"{JobTitle} at {Company} ({Duration})\n    {JobDescription}";
    }
}
