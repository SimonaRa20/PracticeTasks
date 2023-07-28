namespace Activity1
{
    /// <summary>
    ///	Definition of Zodiac sign class.
    /// </summary>
    public class Zodiac
    {
        // Static instances of zodiacs signs
        public static Zodiac ARIES = new(3, 21, 4, 19, "Aries");
        public static Zodiac TAURUS = new(4, 20, 5, 20, "Taurus");
        public static Zodiac GEMINI = new(5, 21, 6, 20, "Gemini");
        public static Zodiac CANCER = new(6, 21, 7, 22, "Cancer");
        public static Zodiac LEO = new(7, 23, 8, 22, "Leo");
        public static Zodiac VIRGO = new(8, 23, 9, 22, "Virgo");
        public static Zodiac LIBRA = new(9, 23, 10, 22, "Libra");
        public static Zodiac SCORPIO = new(10, 23, 11, 21, "Scorpio");
        public static Zodiac SAGITTARIUS = new(11, 22, 12, 21, "Sagittarius");
        public static Zodiac CAPRICORN = new(12, 22, 1, 19, "Capricorn");
        public static Zodiac AQUARIUS = new(1, 20, 2, 18, "Aquarius");
        public static Zodiac PISCES = new(2, 19, 3, 20, "Pisces");

        /// <summary>
        /// Property to return the Start Date
        /// </summary>
        public int StartDate { get; private set; }

        /// <summary>
        /// Property to return the End Date
        /// </summary>
        public int EndDate { get; private set; }

        /// <summary>
        /// Property to return the Start Month
        /// </summary>
        public int StartMonth { get; private set; }

        /// <summary>
        /// Property to return the End Month
        /// </summary>
        public int EndMonth { get; private set; }

        /// <summary>
        /// Property to return the zodiac Star Sign name
        /// </summary>
        public string StarSign { get; private set; }

        /// <summary>
        /// Constructor to initialize the zodiac objects.
        /// </summary>
        /// <param name="startMonth">start month</param>
        /// <param name="startDate">start date</param>
        /// <param name="endMonth">end month</param>
        /// <param name="endDate">end date</param>
        /// <param name="starSign">zodiac star sign</param>
        private Zodiac(int startMonth, int startDate, int endMonth, int endDate, string starSign)
        {
            this.StartMonth = startMonth;
            this.StartDate = startDate;
            this.EndMonth = endMonth;
            this.EndDate = endDate;
            this.StarSign = starSign;
        }

        /// <summary>
        /// Method to accept the birth date and return the corresponding Zodiac sign
        /// </summary>
        /// <param name="birthDate">Birth Date</param>
        /// <returns></returns>
        public static Zodiac GetZodiacSign(DateTime birthDate)
        {
            int month = birthDate.Month;  // month of birth
            int day = birthDate.Day;      // date of birth
            Zodiac zodiac;
            switch (month)
            {
                case 1:
                    zodiac = (day <= CAPRICORN.EndDate) ? CAPRICORN : AQUARIUS;
                    break;
                case 2:
                    zodiac = (day <= AQUARIUS.EndDate) ? AQUARIUS : PISCES;
                    break;
                case 3:
                    zodiac = (day <= PISCES.EndDate) ? PISCES : ARIES;
                    break;
                case 4:
                    zodiac = (day <= ARIES.EndDate) ? ARIES : TAURUS;
                    break;
                case 5:
                    zodiac = (day <= TAURUS.EndDate) ? TAURUS : GEMINI;
                    break;
                case 6:
                    zodiac = (day <= GEMINI.EndDate) ? GEMINI : CANCER;
                    break;
                case 7:
                    zodiac = (day <= CANCER.EndDate) ? CANCER : LEO;
                    break;
                case 8:
                    zodiac = (day <= LEO.EndDate) ? LEO : VIRGO;
                    break;
                case 9:
                    zodiac = (day <= VIRGO.EndDate) ? VIRGO : LIBRA;
                    break;
                case 10:
                    zodiac = (day <= LIBRA.EndDate) ? LIBRA : SCORPIO;
                    break;
                case 11:
                    zodiac = (day <= SCORPIO.EndDate) ? SCORPIO : SAGITTARIUS;
                    break;
                case 12:
                    zodiac = (day <= SAGITTARIUS.EndDate) ? SAGITTARIUS : CAPRICORN;
                    break;
                default:
                    zodiac = null;
                    break;
            }

            return zodiac;
        }
    }
}