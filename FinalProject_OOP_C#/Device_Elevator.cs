using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FinalProject_OOP
{
    public  class Device_Elevator:Device
    {
        public Device_Elevator():base()
        {
            this.Device_ID_MainComp = "";
        }
        public Device_Elevator(string ID, string Name, string Type, string Locate,
            string Status, DateTime In, DateTime Out,string ID_Main_computer) : base(ID,Name,Type,Locate,
            Status,In,Out)
        {
            this.sDevice_ID_MainComp = ID_Main_computer;
        }
        
        public override void Dev_Input1()
        {
            base.Dev_Input1();
            Console.Write("ID of main computer:");
            this.Device_ID_MainComp = Console.ReadLine();
        }
        public override void Dev_Input()
        { }
        public override string ToString()
        {
            return base.ToString()+this.Device_ID_MainComp.ToString()+"\n";
        }
        public override void Dev_Output()
        {
            base.Dev_Output();
            Console.WriteLine("ID of main computer:" + this.Device_ID_MainComp);
        }
        ~Device_Elevator() { }
    }
}
