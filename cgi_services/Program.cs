using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace cgi_services
{
    class Program
    {
        static void Main(string[] param)
        {
            if (param.Length > 0)
            {
                string[] args = param[0].Replace(" ","").Split(',');
                if (args.Length>0)
                {
                    if (args[0].ToLower().Equals("s") && args.Length==3)
                    {
                        Console.Write("Trying To Start Process");
                        string exef = args[1]; //"C:\\wamp\\bin\\php\\php5.6.25\\php-cgi.exe";
                        string arg = "-b " + args[2];// 127.0.0.1:9000
                        Process proc = new Process();
                        proc.StartInfo.FileName = exef;
                        proc.StartInfo.Arguments = arg;
                        proc.StartInfo.CreateNoWindow = true;
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.Start();
                    }
                    else if (args[0].ToLower().Equals("d") && args.Length == 2)
                    {
                        Console.Write("Trying To Stop Process");
                        foreach (Process proc in Process.GetProcesses())
                        {
                            //Console.Write(proc.ProcessName.ToString()+"\n");
                            if (proc.ProcessName.Equals(args[1]))
                            {
                              proc.Kill();
                            }
                        }
                    }
                }
                else if (args[0].ToLower().Equals("- help"))
                {
                    Console.Write("Uses:- \n cgi_services <Mode>,<Cgi Path>,<IP> \n Mode:S[Start]/D[Dispose]");
                }
                else
                {
                    Console.Write("Error: Wrong Argument pass. Type -help");
                }
            }
            else {
                Console.Write("AVS Technology Background Worker.Type -help");
            }
        }
    }
}
