using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ScreenShot
{
    class Program
    {


        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Joe Ostrander");
                Console.WriteLine("Use this to copy the desktop to a file from command line.");
                Console.WriteLine("2017.02.23");
                Console.WriteLine();

            }
            else
            {
                TakeScreenshot();
            }
            
        }

        private static void TakeScreenshot()
        {
            ScreenShot.ScreenCapture SC = new ScreenShot.ScreenCapture();

            try
            {
                Image bmTemp = SC.CaptureScreen();
                bmTemp.Save("desktop.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Console.WriteLine("Desktop captured to:  desktop.jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
