using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public class Door_Main : Door
    {
        public List<Device> ElectricGatesList
        {
            get { return this.m_ElectricGateList; }
            set { this.m_ElectricGateList = value; }
        }

        public Door_Main(string door_ID, string door_IDStall, string door_Status,
            List<Device> list_Dev_Eletric_Gate) : base(door_ID, door_IDStall, door_Status)
        {
            this.ElectricGatesList = list_Dev_Eletric_Gate;
        }
        public Door_Main() : base()
        {
            this.ElectricGatesList = new List<Device>();
        }
        public override void Input()
        {
            base.Input();

        }
        public void String_to_Door(string line)
        {
            string[] arr1 = line.Split(";");
            if (arr1.Length == 3)
            {
                this.Door_ID = arr1[0];
                this.Door_IDStall = arr1[1];
                if (arr1[2] == "w" || arr1[2] == "W")
                {
                    this.Door_Status = "work";
                }
                else this.Door_Status = "stop";
            }
        }
        public override void Docfile(string path1, string path2)
        {

            try
            {
                StreamReader sr1 = new StreamReader(path1, Encoding.UTF8);
                string line = sr1.ReadLine();
                while (line != null)
                {
                    string[] arr1 = line.Split(";");
                    if (arr1.Length == 3)
                    {
                        this.Door_ID = arr1[0];
                        this.Door_IDStall = arr1[1];
                        if (arr1[2] == "w" || arr1[2] == "W")
                        {
                            this.Door_Status = "work";
                        }
                        else this.Door_Status = "stop";
                    }
                    line = sr1.ReadLine();
                }
                this.ElectricGatesList = Device_List.Readfile(path2);// danh sách các eletric gate
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        public override void Ouput1()
        {
            base.Ouput();
            Console.WriteLine("Device of Door: ");
            Device_List.OuputList(this.ElectricGatesList);
        }
    }
}
