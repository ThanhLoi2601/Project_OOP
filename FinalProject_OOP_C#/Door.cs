using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public abstract class Door:ListDoor_Interface
    {
        protected string sDoor_ID;
        protected string sDoor_IDStall;
        protected string sDoor_Status;
        protected List<Device> m_ElectricGateList;
        protected List<Device> m_ElevatorList;
        public string Door_ID
        {
            get { return this.sDoor_ID; }
            set { this.sDoor_ID = value; }
        }
         public string Door_IDStall
        {
            get { return this.sDoor_IDStall; }
            set { this.sDoor_IDStall=value; }
        }
        public string Door_Status
        {
            get { return this.sDoor_Status; }
            set
            {
                this.sDoor_Status = value;
            }
        }
        
        protected Door()
        {
            this.Door_ID = "";
            this.Door_IDStall = "";
            this.Door_Status = "work";
        }
        ~Door() { }

        protected Door( string door_ID, string door_IDStall, string door_Status)
        {
            this.Door_ID = door_ID;
            this.Door_IDStall = door_IDStall;
            this.Door_Status = door_Status;
        }
        public void Input(string door_ID, string door_IDStall, string door_Status)
        {
            this.Door_ID = door_ID;
            this.Door_IDStall=door_IDStall;
            this.Door_Status=door_Status;
        }
        public virtual void Input()
        {
            Console.WriteLine("ID door:"); 
            this.Door_ID = Console.ReadLine();
            Console.Write("ID stall of door:");
            this.Door_IDStall = Console.ReadLine();
            Console.WriteLine("Situation:");
            this.Door_Status = Console.ReadLine();
        }
        public virtual void Ouput()
        {
            Console.WriteLine(this.Door_ID + "   |  " + this.Door_IDStall + "  |        " + this.Door_Status+"       |");
        }
        public abstract void Docfile(string path1,string path2);
        public abstract void Ouput1();
        public string DoorList_FindingDoor_address(string name)
        {
            name = name.ToLower();
            if (name == "door 1" || name == "door1") return Door_List.Door_1.Door_ID;
            else if (name == "door 2" || name == "door2") return Door_List.Door_2.Door_ID;
            else if (name == "door 3" || name == "door3") return Door_List.Door_3.Door_ID;
            else if (name == "door 4" || name == "door4") return Door_List.Door_4.Door_ID;
            else if (name == "door 5" || name == "door5") return Door_List.Door_5.Door_ID;
            else return "ERROR";
        }
        public void OuputListDoor(string ID)
        {
            foreach (Door door in SystemPark.List_Doors)
            {
                if (door.Door_ID == ID)
                {
                    door.Ouput1();
                    return;
                }
            }
            Console.WriteLine("No information!!!");
        }
        
        /*
        string DoorList_FindingDoor_address(string name)
        {
            name = name.ToLower();
            if (name == "door 1" || name == "door1") return Door_List.Door_1.Door_ID;
            else if (name == "door 2" || name == "door2") return Door_List.Door_2.Door_ID;
            else if (name == "door 3" || name == "door3") return Door_List.Door_3.Door_ID;
            else if (name == "door 4" || name == "door4") return Door_List.Door_4.Door_ID;
            else if (name == "door 5" || name == "door5") return Door_List.Door_5.Door_ID;
            else return "ERROR";
        }
        void OuputListDoor(string ID)
        { 
            foreach(Door door in SystemPark.List_Doors) 
            {
                if (door.Door_ID == ID)
                {
                    door.Ouput();
                    return;
                }
            }
            Console.WriteLine("No information!!!");
        }
        */
    }
}
