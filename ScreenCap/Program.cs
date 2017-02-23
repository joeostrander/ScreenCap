using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ScreenShot
{
    class Program
    {

        //[DllImport("kernel32.dll")]
        //static extern bool AttachConsole(UInt32 dwProcessId);
        //private const UInt32 ATTACH_PARENT_PROCESS = 0xFFFFFFFF;

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        static String strFilePath = "desktop.jpg";
        static String output = "";
        static bool boolShowUsage = false;
        static bool boolSilent = false;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {

                if (args.Contains("/?")) {
                    boolShowUsage = true;
                }
                else
                {
                    if (System.IO.Directory.Exists(args[0]))
                    {
                        strFilePath = args[0] + "\\" + strFilePath;
                    }
                    else
                    {
                        output += "Directory not found:  " + args[0] + "\n\n";
                        boolShowUsage = true;
                    }
                }

                if (args.Contains("/silent"))
                {
                    boolSilent = true;
                }

            }

            if (boolShowUsage==false)
            {
                TakeScreenshot();
            }

            if (boolSilent)
                Environment.Exit(0);


            AllocConsole();
            //AttachConsole(ATTACH_PARENT_PROCESS);

            if (boolShowUsage)
            {
                output+="Joe Ostrander\n";
                output += "2017.02.23\n";
                output += "Take a screenshot and save to directory\n\n";
                output += "Usage:  \n"; ;
                output += System.Windows.Forms.Application.ProductName + "\n";
                output += "or\n";
                output += System.Windows.Forms.Application.ProductName + " <directory name>\n";
                output += "or\n";
                output += System.Windows.Forms.Application.ProductName + " <directory name> /silent\n\n";
                output += "Press ENTER to continue...";

                if (boolSilent == false)
                {
                    Console.WriteLine();
                    Console.WriteLine(output);
                    Console.ReadLine();
                }

            }
            else
            {
                if (boolSilent == false)
                {
                    Console.WriteLine();
                    Console.WriteLine(output);
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(2000);
                }

            }
            
            
        }

        private static void TakeScreenshot()
        {
            ScreenShot.ScreenCapture SC = new ScreenShot.ScreenCapture();

            try
            {
                Image bmTemp = SC.CaptureScreen();
                bmTemp.Save(strFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                output += "Desktop captured to:  " + strFilePath + "\n";
            }
            catch (Exception ex)
            {
                output += ex.Message + "\n";
            }


        }
    }
}
