using System;
using System.Media;
using System.Speech.Synthesis;
using System;
using System.Media;
using System.Speech.Synthesis;

internal class Program
{
    class Chatbot
    {
        static void Main()
        {
            // Play the recorded greeting
            PlayGreeting();

            // Initialize TTS
            SpeechSynthesizer speaker = new SpeechSynthesizer();
            speaker.Volume = 100;

            // Display ASCII Cybersecurity Art
            Console.Title = "Cybonick - Cybersecurity Assistant";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
        ____  ____  ____  ____  
       ||S ||||E ||||C ||||U ||  
       ||__||||__||||__||||__||  
       |/__\||/__\||/__\||/__\|  
        ____  ____  ____  ____  
       ||R ||||I ||||T ||||Y ||  
       ||__||||__||||__||||__||  
       |/__\||/__\||/__\||/__\|  
   *******************************
   *  [🔒]  CYBERSECURITY BOT  [🔒]  *
   *******************************
");
            Console.ResetColor();

            // Greeting and introduction
            string welcomeMessage = "Hello! What's your name?";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(welcomeMessage);
            Console.ResetColor();
            speaker.Speak(welcomeMessage);

            string userName = Console.ReadLine();

            string askFeeling = $"Nice to meet you, {userName}! How are you today?";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(askFeeling);
            Console.ResetColor();
            speaker.Speak(askFeeling);

            Console.ReadLine(); // capture how user is feeling

            string intro = "I'm Cybonick, your cybersecurity assistant. " +
                           "You can ask me about topics like phishing, password safety, malware, and more. " +
                           "Type 'exit' to end the chat.";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(intro);
            Console.ResetColor();
            // Don't speak this message

            // Keywords and Responses
            string[] keywords = {
                "phishing", "password", "safe browsing", "malware", "firewall", "encryption",
                "social engineering", "vpn", "ransomware", "two-factor", "antivirus", "cyber attack",
                "data breach", "cookies", "https", "update", "backup", "identity theft", "spoofing",
                "keylogger", "adware", "spyware", "botnet", "zero-day", "patch", "dark web",
                "cyber hygiene", "shoulder surfing", "brute force", "digital footprint",
                "hi", "hello", "how are you"
            };

            string[] responses = {
                "Phishing is when attackers trick you into giving personal info by pretending to be someone you trust.",
                "A strong password should be long and use letters, numbers, and special characters.",
                "Safe browsing means avoiding sketchy websites and using secure HTTPS connections.",
                "Malware is software that harms your device, like viruses and ransomware.",
                "A firewall blocks harmful traffic and protects your network.",
                "Encryption scrambles your data so only someone with the key can read it.",
                "Social engineering tricks people into giving out private information.",
                "A VPN hides your IP address and protects your online activity.",
                "Ransomware locks your files and demands money to unlock them.",
                "Two-factor authentication adds an extra step when logging in for better security.",
                "Antivirus software helps detect and remove harmful programs.",
                "A cyber attack is an attempt to damage or steal data from a computer system.",
                "A data breach is when private data is accessed without permission.",
                "Cookies are files websites use to track your activity.",
                "HTTPS means the website is using a secure connection.",
                "Updating software helps fix bugs and security holes.",
                "Backups keep your data safe in case of a cyber attack.",
                "Identity theft happens when someone uses your personal info to pretend to be you.",
                "Spoofing means pretending to be someone else to trick people.",
                "A keylogger records what you type to steal passwords and data.",
                "Adware shows you unwanted ads and may slow down your system.",
                "Spyware secretly watches what you do on your computer.",
                "A botnet is a group of infected devices controlled by a hacker.",
                "Zero-day exploits are attacks that happen before software makers fix a problem.",
                "A patch is an update that fixes a bug or vulnerability.",
                "The dark web is a hidden part of the internet often used for illegal activity.",
                "Cyber hygiene means using safe habits like strong passwords and updates.",
                "Shoulder surfing is when someone watches you type your PIN or password.",
                "Brute force attacks try every password combination until one works.",
                "Your digital footprint is all the data you leave behind online.",
                "Hello! How can I assist you with cybersecurity today?",
                "Hi there! What would you like to learn about?",
                "I'm doing well, thank you! Ready to help you stay safe online!"
            };

            // Show available topics
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nYou can ask about these topics:");
            for (int i = 0; i < keywords.Length - 3; i++) // Skip the last 3 (greetings)
            {
                Console.WriteLine("• " + keywords[i]);
            }
            Console.ResetColor();

            // Chat Loop
            bool chatting = true;
            while (chatting)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nAsk me a question: ");
                Console.ResetColor();

                string userInput = Console.ReadLine().ToLower();

                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nGoodbye! Stay safe online.");
                    speaker.Speak("Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                bool found = false;

                for (int i = 0; i < keywords.Length; i++)
                {
                    if (userInput.Contains(keywords[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(responses[i]);
                        Console.ResetColor();
                        // No TTS here for response
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("I'm not sure about that. Try asking a different cybersecurity question.");
                    Console.ResetColor();
                    // No TTS here either
                }
            }
        }

        static void PlayGreeting()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer("greeting.wav"))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error playing greeting audio: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}
