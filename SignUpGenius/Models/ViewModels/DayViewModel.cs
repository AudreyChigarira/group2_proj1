using System;
using System.Collections.Generic;

namespace SignUpGenius.Models.ViewModels
{
    public class DayViewModel
    {
        public IEnumerable<AppointmentTime> Monday { get; set; }

        public IEnumerable<AppointmentTime> Tuesday { get; set; }

        public IEnumerable<AppointmentTime> Wednesday { get; set; }

        public IEnumerable<AppointmentTime> Thursday { get; set; }

        public IEnumerable<AppointmentTime> Friday { get; set; }

        public IEnumerable<AppointmentTime> Saturday { get; set; }

        public IEnumerable<AppointmentTime> Sunday { get; set; }
    }
}
