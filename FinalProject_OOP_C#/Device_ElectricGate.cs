using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace FinalProject_OOP
{
    public class Device_ElectricGate:Device
    {     
        ~Device_ElectricGate()
        { }
        
        public Device_ElectricGate() : base()
        {
            this.Device_Works = new List<DateTime>();
        }
        public Device_ElectricGate(string ID, string Name, string Type, string Locate,
            string Status, DateTime In, DateTime Out, List<DateTime> Works) :base(ID, Name, Type, Locate,
            Status, In, Out)
        {
            this.Device_Works = Works;   
        }
        public override void Dev_Output()
        {
            base.Dev_Output();
            Console.WriteLine("List working times of electric gate" + "<" + this.Device_ID + ">");
            for (int i = 0; i < Device_Works.Count; i++)
            {
                Console.WriteLine(Device_Works[i].ToString());
            }
        }
        public override void Dev_Input1()
        {
            base.Dev_Input1();
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Dev_Input()
        { }
    }
}
