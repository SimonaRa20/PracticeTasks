namespace LoanProcessing
{
    public class Program
    {
        static void Main(string[] args)
        {
            LoanSystem loanSystem = new LoanSystem();

            // Process the loan application and provide the Show method as the callback
            loanSystem.ProcessLoanApplication(Show);
        }

        public static void Show(LoanApplicant applicant)
        {
            Console.WriteLine($"Applicant's Credit Score: {applicant.CreditScore}");
        }
    }
}