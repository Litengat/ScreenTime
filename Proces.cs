using System;

public class Proces
{
	public static List<string> LastProssese { get; set; }
	public Proces()
	{
		LastProssese = getProcesses();
	}
    public List<string> getProcesses()
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

    private List<string> getClosedProcess(List<string> lastProssese, List<string> processNames)
    {
        List<string> output = new List<string>();
        for (int i = 0; i < lastProssese.Count; i++)
        {
            Console.WriteLine(lastProssese[i]);
            if (!processNames.Contains(lastProssese[i]))
            {
                output.Add(lastProssese[i]);
            }
        }

        return output;
    }
    private List<string> getNewProcess(List<string> lastProssese, List<string> processNames)
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
    private String ArrayToDisplay(List<string> Process)
    {
        String massage = "";
        foreach (String process in Process)
        {
            massage += process + "\n";
        }
        return massage;
    }
}
}
