using System;
namespace MedeiApp.Models
{
    public class Questionnaires
    {
        public string ParticipantGender { get; set; }
        public string ParticipantName { get; set; }
        public string PackageSatisfaction { get; set; }
        public int NumberOfQuestions { get; set; }
        public int NumberAnswered { get; set; }


        public Questionnaires(int numQuest)
        {
            NumberOfQuestions = numQuest;
        }

        public void EvaluateInput(object pGender, string pName, object packageS)
        {
            int numAnswered = 0;

            //
            if (pGender != null)
            {
                ParticipantGender = pGender.ToString();
                numAnswered++;
            }
            //
            if (!string.IsNullOrWhiteSpace(pName))
            {
                ParticipantName = pName;
                numAnswered++;
            }
            //
            if (packageS != null)
            {
                PackageSatisfaction = packageS.ToString();
                numAnswered++;
            }

            NumberAnswered = numAnswered;

        }
    }
}
