using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string OPENAI_API_KEY = "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";
        List<Message> messages = new List<Message>();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("User: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string message = Console.ReadLine();
            string answer = "";
            if (message == "quit")
            {
                break;
            }
            messages.Add(new Message("user", message));
            OpenAIAPI api = new OpenAIAPI(OPENAI_API_KEY);

            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = message;
            completion.Model = Model.DavinciText;
            completion.MaxTokens = 4000;
            var result = api.Completions.CreateCompletionAsync(completion);
            if (result != null)
            {
                answer = result.Result.Completions[0].Text;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Bot: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(answer);
                messages.Add(new Message("bot", answer));
                Console.Write("\n");
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}

public class Message
{
    public Message(string role, string content)
    {
        Role = role;
        Content = content;
    }
    public string Role { get; set; }
    public string Content { get; set; }
}