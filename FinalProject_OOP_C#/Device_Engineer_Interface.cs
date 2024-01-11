using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
   interface InfixingDevice1Months
    {
        // List Device must be refixed this  onth and next month
        List<Device> List_Device_1Month();
        //
    }
    interface ImportingStopDevice
    {
        // list Device is beeing stopping work.
        List<Device> List_Device_Stop();
    }

}
