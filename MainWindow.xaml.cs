using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Timers;
using System.Windows.Threading;
namespace ScreenTime
{
    
    public partial class MainWindow : Window
    {
        
        public List<string> LastProssese { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LastProssese = getProcesses();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            content.Content = ArrayToDisplay(getNewProcess(LastProssese, getProcesses()), " + ") + ArrayToDisplay(getClosedProcess(LastProssese, getProcesses()), " - ");
            LastProssese = getProcesses();


            Prossese.Content = ArrayToDisplay(getProcesses(), "");
        }
    
        


    
    




















        static public List<string> getProcesses()
        {
            Process[] processlist = Process.GetProcesses();
            List<string> processNames = new List<string>();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    processNames.Add(process.ProcessName);
                } 
            }
            return processNames;
        }
        static private List<string> getClosedProcess(List<string> lastProssese, List<string> processNames)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < lastProssese.Count; i++)
            {
                if (!processNames.Contains(lastProssese[i]))
                {
                    output.Add(lastProssese[i]);
                }
            }

            return output;
        }
        static private List<string> getNewProcess(List<string> lastProssese, List<string> processNames)
        {
            List<string> output = new List<string>();
            for (int i = 0; i < processNames.Count; i++)
            {
                if (!lastProssese.Contains(processNames[i]))
                {
                    output.Add(processNames[i]);
                }
            }

            return output;
        }

        
        static String ArrayToDisplay(List<string> Process,String prefix)
        {
            String massage = "";
            foreach(String process in Process)
            {
                massage += prefix + process + "\n";
            }
            return massage;
        }



        
    }
}