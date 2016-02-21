using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;

namespace JARVIS
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        SpeechRecognitionEngine reg = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            s.Speak("Welcome to Ultron, the Artificially Intelligent Assistant!");
            string[] commands = File.ReadAllLines("filesr.txt").ToArray();
            reg.SetInputToDefaultAudioDevice();
            reg.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(commands))));
            reg.RecognizeAsync(RecognizeMode.Multiple);
            reg.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
            


        }

        public string time()
        {
            DateTime n = DateTime.Now;
            string o = n.GetDateTimeFormats('t')[0];
            return o;
        }
        

        public void rec(object sender, SpeechRecognizedEventArgs x)
        {
            string recString = x.Result.Text;
            int count =1;
            const string startCommand = "google";
            var text = x.Result.Text;

            switch (recString)
            {
                /*
                default:
                    s.Speak("Command not recognised!");
                    break;
                *///gets annoying
                case "hello":
                    s.Speak("Hello there sir");
                    break;
                case "what's your name":
                    s.Speak("I am Ultron!");
                    break;
                case "how are you":
                    s.Speak("I'm good, and yourself?");
                    string feelingResponse = x.Result.Text;
                    reg.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec1);
                    break;
                case "what's the time":
                    s.Speak(time());
                    break;
                case "open google":
                    s.Speak("Opening google.com");
                    Process.Start("chrome.exe", "http:\\www.google.com");
                    break;
                case "launch system monitor":
                    s.Speak("System monitor is currently in alpha, use with caution!");
                    Process.Start("C:\\Users\\coffe_000\\Documents\\System Monitor\\bin\\Debug\\jarvis.exe");
                    break;
                case "open spotify":
                    s.Speak("Opening Spotify");
                    Process.Start("chrome.exe", "http:\\play.spotify.com");
                    break;
                case "good bye now":
                    s.Speak("Safely Exiting now!");
                    Application.Exit();
                    break;
                case "open reddit":
                    s.Speak("Opening red it .com");
                    Process.Start("chrome.exe", "http:\\reddit.com");
                    break;
                case "i'm going to sleep":
                    s.Speak("Ok, hope you have a good sleep. Hibernating now!");
                    Process.Start("shutdown", "/h /f");
                    break;
                case "open netsec":
                    s.Speak("Opening r netsec");
                    Process.Start("chrome.exe", "http:\\reddit.com\\r\\netsec");
                    break;
                case "i want to read the sydney morning herald":
                    s.Speak("Opening the Sydney Morning Herald");
                    Process.Start("chrome.exe", "http:\\smh.com.au");
                    break;
                case "open netflix":
                    s.Speak("Opening netflix.com");
                    Process.Start("chrome.exe", "http:\\netflix.com");
                    break;
                case "lock my computer":
                    s.Speak("Locking the computer sir!");
                    Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                    break;
                case "open my programming tabs":
                    s.Speak("Ok, hope you learn something for me sir.");
                    Process.Start("chrome.exe", "http:\\reddit.com\\r\\programming");
                    Process.Start("chrome.exe", "http:\\reddit.com\\r\\compsci");
                    Process.Start("chrome.exe", "http:\\github.com\\trending");
                    Process.Start("chrome.exe", "http:\\hackforums.net\\forumdisplay.php?fid=151");
                    Process.Start("chrome.exe", "http:\\www.sciencedaily.com\\news\\computers_math\\computer_programming");
                    Process.Start("chrome.exe", "https:\\www.reddit.com\\r\\learnprogramming");
                    Process.Start("chrome.exe", "https:\\www.reddit.com\\r\\shittyprogramming/");
                    Process.Start("chrome.exe", "https:\\www.reddit.com\\r\\ProgrammerHumor");
                    Process.Start("chrome.exe", "https:\\www.reddit.com\\r\\dailyprogrammer");
                    break;
                case "page down":
                    SendKeys.Send("{PGDN}");
                    break;
                case "page up":
                    SendKeys.Send("{PGUP}");
                    break;                
                case "i'm confused":
                    s.Speak("I'm sorry sir, I wish i could help!");
                    break;
                case "you're useless":
                    s.Speak("this is awkward.");
                    break;
                case "close tab":                    
                    SendKeys.Send("^{w}");
                    s.Speak("Tab closed");
                    break;
                case "go back":
                    SendKeys.Send("{BS}");
                    s.Speak("Going back.");
                    break;
                case "go forward":
                    SendKeys.Send("+{BS}");
                    s.Speak("Going back forward.");
                    break;
                case "i'm stuck":
                    Process.Start("chrome.exe", "http:\\stackoverflow.com");
                    Process.Start("chrome.exe", "http:\\codeproject.com");
                    s.Speak("Hmm, I'm not sure i can help you sir, maybe these guys can!");
                    break;
                case "switch tab":
                    SendKeys.Send("^{Tab}");
                    break;
                case "open facebook":
                    Process.Start("chrome.exe", "http:\\facebook.com");
                    s.Speak("Opening facebook");
                    break;
                case "refresh":
                    SendKeys.Send("{F5}");
                    break;
                case "close window":
                    SendKeys.Send("%{F4}");
                    s.Speak("Closing window");
                    break;
                case "alt tab":
                    s.Speak("Alt Tab b ing");
                    SendKeys.Send("%{TAB " + count + "}");
                    count += 1;
                    break;
                case "what's the date":
                    s.Speak(DateTime.Today.ToString("dd-MM-yyyy"));
                    break;
                case "doe":

                    if (text.StartsWith(startCommand)) 
                        {
                        var nextt = text.Replace(startCommand, string.Empty).Trim();
                        
                        }
                    break;

            }

            if (text.StartsWith(startCommand))
            {   
                var nextt = text.Replace(startCommand, string.Empty).Trim();
                string[] filestr = new string[] { nextt }; //typecast

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"filesr.txt", true))
                {
                    file.WriteLine(nextt);
                }
                s.Speak(nextt);
            }

        }
        int runOnce = 1;
        public void rec1(object sender, SpeechRecognizedEventArgs x)
        {
            
            string recString = x.Result.Text;
            if (runOnce == 1)
            {
                switch (recString)
                {
                    case "good":
                        s.Speak("that's good to hear sir.");
                        runOnce = 2;
                        break;
                    case "bad":
                        s.Speak("sorry to hear that");
                        runOnce = 2;
                        break;
                }
            }
         }
        
            
    }

}
