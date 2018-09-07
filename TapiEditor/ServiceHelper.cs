using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TapiEditor
{
    public class ServiceHelper
    {
        public bool Status {
            get;
            private set;
        }
        public string ServiceName { get; set; }
        public ServiceHelper(string servicename)
        {
            ServiceName = servicename;
        }
        public void RestartService()
        {
            ServiceController service = new ServiceController(ServiceName);
            switch(service.Status)
            {
                case ServiceControllerStatus.Stopped:
                    try
                    {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running);
                        Status = true;
                        break;
                    }
                    catch(Exception ex)
                    {
                        Status = false;
                        Console.WriteLine(ex.Message);
                        break;
                    }
                case ServiceControllerStatus.Running:
                    try
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped);
                        Thread.Sleep(100);
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running);
                        Status = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Status = false;
                        Console.WriteLine(ex.Message);
                        break;
                    }
            }
            
        }
    }
}
