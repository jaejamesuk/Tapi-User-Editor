using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TapiEditor
{
    class Program
    {
        public static TapiProperties p = new TapiProperties();
        static void Main(string[] args)
        {
            Console.WriteLine("_-TapiEditor-_");
            Console.WriteLine("+ PLEASE ENTER THE USERNAME +");
            p.User = Console.ReadLine().ToString();
            Console.WriteLine("\n\n- PLEASE ENTER THE PASSWORD (OR LEAVE BLANK FOR DEFAULT) -");
            Console.ReadLine();
            p.Password = "IDGFCDA";
            try
            {
                RegistryKey tapi = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Avaya\IP400\TSPI", true);
                Console.WriteLine("\nSetting User To: " + p.User);
                tapi.SetValue("Options", p.User);
                Console.WriteLine("\nSetting Password To Default");
                tapi.SetValue("Password", p.Password);
                Console.WriteLine("\nSuccess, Press Any Key To Restart Telephony Service");
                Console.ReadKey();
                ServiceHelper sH = new ServiceHelper("Telephony");
                sH.RestartService();
                if (sH.Status)
                {
                    Console.WriteLine("\n\n_-========ALL FINISHED=========-_");
                    System.Diagnostics.Process.Start(@"C:\Windows\System32\dialer.exe");
                }
                else
                {
                    Console.WriteLine("\nHmm... Something Went Wrong When Restarting The Telephony Service! Maybe Try Running As Administrator");
                }
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("\nHmm... Something Went Wrong When Opening The Key! Maybe Try Running As Administrator?");
                Console.WriteLine("Technical Details: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPress Any Key To Exit");
                Console.ReadKey();
            }
            
        }
    }
}
