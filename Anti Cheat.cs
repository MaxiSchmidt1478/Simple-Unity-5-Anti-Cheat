using UnityEngine;
using System.Diagnostics;
/*
Das Plugin überprüft bisher nur nach namen eines Prozesses
*/

public class AntiCheat : MonoBehaviour
{
    bool banned = false;
    void Start()
    {
        if(banned == true)
        {
        ban:
            GUI.Box(new Rect(10, 10, 100, 90), "You are banned");
            GUI.Label(new Rect(10, 20, 100, 90), "Reason : Cheating");
            if (GUI.Button(new Rect(10, 10, 50, 50), "Ok"))
            {
                Application.Quit();
            }
        }
        else
        {
            Main();
        }
    }
    private bool CheckIfAProcessIsRunning(string processname)
    {
        return Process.GetProcessesByName(processname).Length > 0;
    }
    private void Main()
    {
        string[] CheatTools = { "Cheat Engine 6.5", "Cheat Engine 6.4",
            "Cheat Engine 6.3", "Cheat Engine 6.2", "Cheat Engine 6.1",
            "Cheat Engine 6.0", "Cheat Engine 5.6.1"};
        bool cheattool = CheckIfAProcessIsRunning(CheatTools[0]);
        if (cheattool == true)
        {
            while (true) ;
            Process[] pp = Process.GetProcessesByName(CheatTools[0]);
            foreach (Process p in pp)
            {
                p.Kill();
                banned = true;
                Application.Quit();
            }
        }
    }
}
