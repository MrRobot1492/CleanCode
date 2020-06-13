
using System;

namespace CleanCode.DuplicatedCode
{
    //Extract duplicated code into a single method
    //Right Button, Select Method Contract, Transform Out Parameters
    //Decoupling tuple primitive values by using a personalized class, as a single object return instead 
    //many return values
    //Set the methods to the corresponding class
    public class Time
    {
        public int Hours { get; }
        public int Minutes { get; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        //This method, has not related nothing with reservation methods, so is necessary to move it from here.
        //It does not belong here, it belongs to the Time Class itself
        public static Time Parse(string stringToParse)
        {
            var time = 0;
            var hours = 0;
            var minutes = 0;

            if (Validate(stringToParse))
                time = int.Parse(stringToParse.Replace(":", ""));

            hours = time / 100;
            minutes = time % 100;
            return new Time(hours, minutes);
        }

        private static bool Validate(string stringToParse)
        {
            var time = 0;

            if (string.IsNullOrWhiteSpace(stringToParse))
                throw new ArgumentNullException("stringToParse");

            if (!int.TryParse(stringToParse.Replace(":", ""), out time))
                throw new ArgumentException("stringToParse");

            return true;
        }
    }

    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...
            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...
            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }
    }
}