using MLLearning;
using System.IO;

namespace MLLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("Do you want continue for the Sentiment Prediction? (yes/no)");
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "yes" || userInput == "y")
                {
                    Console.WriteLine("You choose to continue.");
                    continueRunning = true;
                    fncInput();

                }
                else if (userInput == "no" || userInput == "n")
                {
                    Console.WriteLine("You decided not to continue.");
                    continueRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }          
        }

        public static void fncInput()
        {
            Console.WriteLine("How you feel Today?");
            string sfeeling = Console.ReadLine();
            var sentiment = fncPrediction(sfeeling);
            Console.WriteLine($"Your input Text: {sfeeling}\nYour Sentiment: {sentiment}");
        }
        public static string fncPrediction(string sfeeling)
        {
            // Add input data
            var sampleData = new SentimentModel.ModelInput()
            {
                Col0 = sfeeling
            };

            // Load model and predict output of sample data
            var result = SentimentModel.Predict(sampleData);

            // If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
            var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
            return sentiment;
            
        }
    }
}
