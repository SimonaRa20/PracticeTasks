using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessing
{
    public class LoanSystem
    {
        public void ProcessLoanApplication(Action<LoanApplicant> showApplicant)
        {
            Random random = new Random();
            int creditScore = random.Next(1, 101);

            LoanApplicant applicant = new LoanApplicant
            {
                CreditScore = creditScore
            };

            showApplicant(applicant);
        }
    }
}
