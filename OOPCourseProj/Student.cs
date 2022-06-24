using System;


namespace OOPCourseProj
{
    /// <summary>
    /// Class with info about students
    /// </summary>
    [Serializable]
    internal class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }    
        public int age { get; set; }
        public string gender { get; set; }
        public string group { get; set; }
        public double firstSem { get; set; }
        public double secondSem { get; set; }
        public double thirdSem { get; set; }
        public double fourthSem { get; set; }
        public double fifthSem { get; set; }
        public double sixthSem { get; set; }
        public double sevenSem { get; set; }
        public double eighthSem { get; set; }
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="lastName">last name</param>
        /// <param name="age">age</param>
        /// <param name="gender">gender</param>
        /// <param name="group">student's group</param>
        /// <param name="firstSem">first semester</param>
        /// <param name="secondSem">second semester</param>
        /// <param name="thirdSem">third semester</param>
        /// <param name="fourthSem">fourth semester</param>
        /// <param name="fifthSem">fifth semester</param>
        /// <param name="sixthSem">sixth semester</param>
        /// <param name="sevenSem">seventh semester</param>
        /// <param name="eighthSem">eighth semester</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Student(string firstName, string lastName, int age, string gender, string group, double firstSem, double secondSem, double thirdSem, double fourthSem, double fifthSem, double sixthSem, double sevenSem, double eighthSem)
        {
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.age = age;
            this.gender = gender ?? throw new ArgumentNullException(nameof(gender));
            this.group = group ?? throw new ArgumentNullException(nameof(group));
            if (firstSem > 0 && firstSem < 6)
                this.firstSem = firstSem;
            else this.firstSem = 0;
            if (secondSem > 0 && secondSem < 6)
                this.secondSem = secondSem;
            else this.secondSem = 0;
            if (thirdSem > 0 && thirdSem < 6)
                this.thirdSem = thirdSem;
            else this.thirdSem = 0;
            if (fourthSem > 0 && fourthSem < 6)
                this.fourthSem = fourthSem;
            else this.fourthSem = 0;
            if (fifthSem > 0 && fifthSem < 6)
                this.fifthSem = fifthSem;
            else this.fifthSem = 0;
            if (sixthSem > 0 && sixthSem < 6)
                this.sixthSem = sixthSem;
            else this.sixthSem = 0;
            if (sevenSem > 0 && sevenSem < 6)
                this.sevenSem = sevenSem;
            else this.sevenSem = 0;
            if (eighthSem > 0 && eighthSem < 6)
                this.eighthSem = eighthSem;
            else this.eighthSem = 0;
        }
        /// <summary>
        /// Constructor with some parameters
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="lastName">last name</param>
        /// <param name="age">age</param>
        /// <param name="gender">gender</param>
        /// <param name="group">student's group</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Student(string firstName, string lastName, int age, string gender, string group)
        {
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.age = age;
            this.gender = gender ?? throw new ArgumentNullException(nameof(gender));
            this.group = group ?? throw new ArgumentNullException(nameof(group));
            firstSem = 0;
            secondSem = 0;
            thirdSem = 0;
            fourthSem = 0;
            fifthSem = 0;
            sixthSem = 0;
            sevenSem = 0;
            eighthSem = 0;
        }
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Student()
        {
            firstName = " ";
            lastName = " ";
            age = 18;
            gender = " ";
            group = " ";
            firstSem = 0;
            secondSem = 0;
            thirdSem = 0;
            fourthSem = 0;
            fifthSem = 0;
            sixthSem = 0;
            sevenSem = 0;
            eighthSem = 0;
        }

        
    }
}
