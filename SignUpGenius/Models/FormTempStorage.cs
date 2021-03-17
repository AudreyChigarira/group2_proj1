using SignUpGenius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpGenius.Models
{
    //Storage class
    public class FormTempStorage
    {
        private static List<FormModel> applications = new List<FormModel>();

        public static IEnumerable<FormModel> Applications => applications;

        public static void AddApplication(FormModel application)
        {
            applications.Add(application);
        }
    }
}
