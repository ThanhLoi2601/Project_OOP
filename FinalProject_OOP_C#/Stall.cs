using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public class Stall
    {
        // fields
        private string Stall_sID;
        private string Stall_sName;
        private int Stall_iNumCar;
        private int Stall_iNumBike;
        private int Stall_iNumElec;
        private List<Door> Stall_lList_door;
        private List<Device> Stall_lList_device;
        private List<Guard> Stall_lList_guard;
        private List<Vehicle> Stall_lList_vehicle;
        // Properties
        public string Stall_ID
        {
            get { return this.Stall_sID; }
            set { this.Stall_sID = value;}
        }
        public string Stall_Name
        {
            get { return this.Stall_sName; }
            set { this.Stall_sName = value;}
        }
        public int Stall_NumCar
        {
            get { return this.Stall_iNumCar; }
            set { this.Stall_iNumCar=value;}
        }
        public int Stall_NumBike
        {
            get { return this.Stall_iNumBike; }
            set { this.Stall_iNumBike = value; }
        }
        public int Stall_NumElec
        {
            get { return this.Stall_iNumElec; }
            set { this.Stall_iNumElec = value; }
        }
        public List<Door> Stall_List_Door
        {
            get { return this.Stall_lList_door; }
            set { this.Stall_lList_door = value;}
        }
        public List<Device> Stall_List_Device
        {
            get { return this.Stall_lList_device; }
            set { this.Stall_lList_device = value; }
        }
        public List<Guard> Stall_List_Guards
        {
            get { return this.Stall_lList_guard; }
            set { this.Stall_lList_guard = value;  }
        }
        public List<Vehicle> Stall_List_Vehicles
        {
            get { return this.Stall_lList_vehicle; }
            set { this.Stall_lList_vehicle = value; }
        }
        // Constructor
        public Stall()
        {
             this.Stall_lList_door = new List<Door>();
             this.Stall_lList_device = new List<Device>();
             this.Stall_lList_guard = new List<Guard>();
             this.Stall_lList_vehicle = new List<Vehicle>();
        }
        public Stall(string Stall_ID,string Stall_name, int Stall_NumCar,int Stall_Numbike,int Stall_Elec) 
        {
            this.Stall_ID = Stall_ID;
            this.Stall_Name = Stall_name;
            this.Stall_NumCar = Stall_NumCar;
            this.Stall_NumBike = Stall_Numbike;
            this.Stall_NumElec = Stall_Elec;
        }
        // Finalizer
        ~Stall()
        { }
        // Methods
        public void Stall_Docfile(string path1)
        { 
            // Stall information
            StreamReader sr1=new StreamReader(path1,Encoding.UTF8);
            string line=sr1.ReadLine(); 
            while(line!=null) 
            {
                string[] arr1 = line.Split(";");
                if(arr1.Length==5)
                {
                    this.Stall_ID = arr1[0];
                    this.Stall_Name = arr1[1];
                    this.Stall_NumCar = int.Parse(arr1[2]);
                    this.Stall_NumBike = int.Parse(arr1[3]);
                    this.Stall_NumElec = int.Parse(arr1[4]);
                }
                line = sr1.ReadLine();
            }
        }
        public void String_to_Stall(string line)
        {

            string[] arr1 = line.Split(";");
            if (arr1.Length == 5)
            {
                this.Stall_ID = arr1[0];
                this.Stall_Name = arr1[1];
                this.Stall_NumCar = int.Parse(arr1[2]);
                this.Stall_NumBike = int.Parse(arr1[3]);
                this.Stall_NumElec = int.Parse(arr1[4]);
            }
        }
        public void Stall_Ouput()
        { 
            Console.WriteLine("ID of Stall:"+this.Stall_ID + ",Name of stall:" + this.Stall_Name + ",Maxium number of car:" + this.Stall_NumCar + ",Maxium number of bike:" + this.Stall_NumBike + ",Maxium of electric car:" + this.Stall_NumElec);
            // Output list of device of Stall
            Console.WriteLine("___List of Devices of"+this.Stall_Name+":___");
            Device_List.OuputList(this.Stall_List_Device);
            // Output List of Guard of Stall
            Console.WriteLine("___List of Guards of" + this.Stall_Name + ":___");
            Guard_List.OuputList(this.Stall_List_Guards);
            // Ouput List of Door of Stall
            Console.WriteLine("___List of Doors of" + this.Stall_Name + ":___");
            Door_List.Ouput_1(this.Stall_List_Door);

        }
    }
}
