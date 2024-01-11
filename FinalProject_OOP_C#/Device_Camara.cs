using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FinalProject_OOP
{
    public class Device_Camera:Device
    {
        public Device_Camera():base()
        {
            this.Device_Videos=new List<string>();
        }
        public Device_Camera(string ID, string Name, string Type, string Locate,
            string Status, DateTime In, DateTime Out, List<string> Videos) :base(ID, Name, Type, Locate,
            Status, In, Out)
        {
            this.Device_Videos = Videos;
        }
        public override void Dev_Input1()
        {
            base.Dev_Input1();
        }
        public override void Dev_Input()
        { }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Dev_Output()
        {
            base.Dev_Output();
            Console.WriteLine("List of pathVideo:");
            for (int i = 0; i < this.Device_Videos.Count; i++)
            {
                Console.WriteLine("Link" + i + ":" + Device_Videos[i]);
            }
        }
        ~Device_Camera() { }
    }
}
