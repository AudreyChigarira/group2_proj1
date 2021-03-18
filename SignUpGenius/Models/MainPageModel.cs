using System;
using System.Collections.Generic;
using SignUpGenius.Models.ViewModels;

namespace SignUpGenius.Models
{
    public class MainPageModel
    {
        public FormModel formModel { get; set; }

        public IEnumerable<AppointmentTime> appointmentTime { get; set; }

        public DayViewModel dayViewModel { get; set; }
    }
}
