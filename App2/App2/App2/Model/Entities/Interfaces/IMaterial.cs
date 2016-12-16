using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Javax.Security.Auth;
using Microsoft.WindowsAzure.MobileServices;

namespace XamarinExam.Model.Entities
{
    public interface IMaterial
    {
        string id { get; set; }
        
        string Name { get; set; }
        
        string Publisher { get; set; }
        
        string PublishDate { get; set; }
    }
}
