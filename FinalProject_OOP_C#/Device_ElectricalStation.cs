using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public class Device_ElectricalStation:Device
    {
         ~Device_ElectricalStation() { }
        
        public Device_ElectricalStation():base()
        {
            this.Device_PowerCapacity=1;
        }
        public Device_ElectricalStation(string ID, string Name, string Type, string Locate,
            string Status, DateTime In, DateTime Out, double Power_Capacity):base(ID, Name, Type, Locate,
            Status, In, Out)
        {
            this.Device_PowerCapacity=Power_Capacity;
        }
        public override void Dev_Input1()
        {
            base.Dev_Input1();
            Console.Write("Input Power Capacity:");this.Device_PowerCapacity = Convert.ToDouble(Console.ReadLine());
        }
        public override void Dev_Input()
        { }
        public override string ToString()
        {
            return base.ToString()+this.Device_PowerCapacity.ToString();
        }
        public override void Dev_Output()
        {
            base.Dev_Output();
            Console.WriteLine("Power Capacity:" + this.Device_PowerCapacity);
        }
    }
}
