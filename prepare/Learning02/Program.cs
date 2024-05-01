using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2028;
        job1._endYear = 2035;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Senior Software Engineer";
        job2._startYear = 2035;
        job2._endYear = 2060;

        Resume myResume = new Resume();

        myResume._name = "Albert Conceição";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
   
    }
}