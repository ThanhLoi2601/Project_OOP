using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FinalProject_OOP
{
    public abstract class Device
    {

        // Fields
        protected string sDevice_ID;        // ID //0
        protected string sDevice_Name;     // Name //1
        protected string sDevice_Type;     // Type // 2
        protected string sDevice_Locate;   // Location // 3 
        protected string sDevice_Status;  // situation // 4
        protected DateTime dtDevice_IN;   // Time start up // 5
        protected DateTime dtDevice_OUT;  // Time refix  //6
        // the main computer of Main_Comp of Device_Elevator
        protected string sDevice_ID_MainComp; // ID máy chủ đối với cầu thang máy  //7
        // list string ID vehicle of Device_Camara
        protected List<string> Device_lpathVideo = new List<string>(); // danh sách các tệp video mỗi ngày//8
        // List of DateTime electric gate works
        protected List<DateTime> Device_lworks = new List<DateTime>();// danh sách các thời điểm cổng điện hoạt động//9
        // Power capacity for car
        protected double dDevice_PowerCapacity;// Công suất xạc của trạm điện//10
        //finalizers
        ~Device()
        { }
        // Properties
        public double Device_PowerCapacity
        {
            get { return this.dDevice_PowerCapacity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
                this.dDevice_PowerCapacity = value;
            }
        }
        public List<DateTime> Device_Works
        {
            get { return this.Device_lworks; }
            set { this.Device_lworks = value; }
        }
        public List<string> Device_Videos
        {
            get { return this.Device_lpathVideo; }
            set { this.Device_lpathVideo = value; }
        }
        public string Device_ID_MainComp
        {
            get { return this.sDevice_ID_MainComp; }
            set { this.sDevice_ID_MainComp = value; }
        }
        public string Device_ID
        {
            get { return this.sDevice_ID; }
            set { this.sDevice_ID = value; }
        }
        public string Device_Name
        {
            get { return this.sDevice_Name; }
            set { this.sDevice_Name = value; }
        }
        public string Device_Type
        {
            get { return this.sDevice_Type; }
            set { this.sDevice_Type = value; }
        }
        public string Device_Locate
        {
            get { return this.sDevice_Locate; }
            set
            {
                this.sDevice_Locate = value;
            }
        }
        public DateTime Device_IN
        {
            get { return this.dtDevice_IN; }
            set { this.dtDevice_IN = value; }
        }
        public DateTime Device_OUT
        {
            get { return this.dtDevice_OUT; }
            set { this.dtDevice_OUT = value; }
        }

        public string Device_Status
        {
            get { return this.sDevice_Status; }
            set { this.sDevice_Status = value; }
        }
        public override string ToString()
        {
            return Device_ID + ";" + Device_Name + ";" + Device_Type + ";" + Device_Locate + ";" + Device_Status + ";" + Device_IN + ";" + Device_OUT;
        }
        // Constructors
        public Device()
        {
            this.dtDevice_IN = DateTime.Now;
            this.dtDevice_OUT = DateTime.Now;

        }
        //List<string> pathVideos, double powercap
        // 
        //   this.Device_pathVideo = pathVideos;
        // this.Device_PowerCapacity = powercap;
        public Device(string ID, string Name, string Type, string Locate, string Status, DateTime In, DateTime Out)
        {
            this.sDevice_ID = ID;
            this.sDevice_Name = Name;
            this.sDevice_Type = Type;
            this.sDevice_Locate = Locate;
            this.sDevice_Status = Status;
            this.dtDevice_IN = In;
            this.dtDevice_OUT = Out;
        }
        /*
        public Device(string ID,string Name,string Type,string Locate,string Status,DateTime In,DateTime Out)
        {
            this.ID = ID;
            this.Name = Name;
            this.Type = Type;
            this.Locate = Locate;
            this.Status = Status;
            this.IN = In;
            this.OUT= Out;
        }
        */
        public virtual void Dev_Input1()
        {
            Console.Write("ID: "); this.Device_ID = Console.ReadLine();
            Console.Write("Name: "); this.Device_Name = Console.ReadLine();
            Console.Write("Type: "); this.Device_Name = Console.ReadLine();
            Console.Write("Locate: "); this.Device_Locate = Console.ReadLine();
            Console.Write("Situation:"); this.Device_Status = Console.ReadLine();
            Console.Write("Start:");
            string IN_time = Console.ReadLine();
            this.Device_IN = DateTime.Parse(IN_time);
            Console.Write("Refix: ");
            string OUT_time = Console.ReadLine();
            this.Device_OUT = DateTime.Parse(OUT_time);
        }
        public abstract void Dev_Input();
        public virtual void Dev_Output()
        {
            Console.WriteLine("|{0,20}|{1,15}|{2,25}|{3,20}|{4,10}|{5,23}|{6,23}|",this.Device_ID ,this.Device_Name ,this.Device_Type, this.Device_Locate, this.Device_Status , this.Device_IN.ToString() , this.Device_OUT.ToString());
        }

        public List<Device> List_Device_1Month()
        {
            throw new NotImplementedException();
        }
        // chuyển từ 1 string thành Device
        public static Device String_to_Device(string line)
        {
            string[] arr = line.Split(';');
            if (arr[1].Trim() == "Camera")
            {
                Device camera = new Device_Camera();
                camera.Device_ID = arr[0];
                camera.Device_Name = arr[1];
                camera.Device_Type = arr[2];
                camera.Device_Locate = arr[3];
                if (arr[4] == "w" || arr[4] == "W")
                {
                    camera.Device_Status = "work";
                }
                else
                {
                    camera.Device_Status = "stop";
                }
                camera.Device_IN = DateTime.Parse(arr[5]);
                camera.Device_OUT = DateTime.Parse(arr[6]);
                string[] arr_temp = arr[7].Split("#");
                for (int i = 0; i < arr_temp.Length; i++)
                    camera.Device_Videos.Add(arr_temp[i]);
                return camera;
            }
            if (arr[1].Trim() == "Elevator")
            {
                Device elevator = new Device_Elevator();
                elevator.Device_ID = arr[0];
                elevator.Device_Name = arr[1];
                elevator.Device_Type = arr[2];
                elevator.Device_Locate = arr[3];
                if (arr[4] == "w" || arr[4] == "W")
                {
                    elevator.Device_Status = "work";
                }
                else
                {
                    elevator.Device_Status = "stop";
                }
                elevator.Device_IN = DateTime.Parse(arr[5]);
                elevator.Device_OUT = DateTime.Parse(arr[6]);
                elevator.Device_ID_MainComp = arr[7];
                return elevator;
            }
            if (arr[1].Trim() == "ElectricGate")
            {
                Device electricGate = new Device_ElectricGate();
                electricGate.Device_ID = arr[0];
                electricGate.Device_Name = arr[1];
                electricGate.Device_Type = arr[2];
                electricGate.Device_Locate = arr[3];
                if (arr[4] == "w" || arr[4] == "W")
                {
                    electricGate.Device_Status = "work";
                }
                else
                {
                    electricGate.Device_Status = "stop";
                }
                electricGate.Device_IN = DateTime.Parse(arr[5]);
                electricGate.Device_OUT = DateTime.Parse(arr[6]);
                string[] arr_temp = arr[7].Split("#");
                for (int i = 0; i < arr_temp.Length; i++)
                {
                    electricGate.Device_Works.Add(DateTime.Parse(arr_temp[i]));
                }
                return electricGate;
            }
            else
            {
                Device elctricsta = new Device_ElectricalStation();
                elctricsta.Device_ID = arr[0];
                elctricsta.Device_Name = arr[1];
                elctricsta.Device_Type = arr[2];
                elctricsta.Device_Locate = arr[3];
                if (arr[4] == "w" || arr[4] == "W")
                {
                    elctricsta.Device_Status = "work";
                }
                else
                {
                    elctricsta.Device_Status = "stop";
                }
                elctricsta.Device_IN = DateTime.Parse(arr[5]);
                elctricsta.Device_OUT = DateTime.Parse(arr[6]);
                elctricsta.Device_PowerCapacity = double.Parse(arr[7]);
                return elctricsta;
            }
        }
    }
}
