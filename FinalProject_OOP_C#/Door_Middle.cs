using System.Runtime.CompilerServices;

namespace FinalProject_OOP
{
    public class Door_Middle : Door
    {
        public List<Device> ElevatorList
        {
            get { return this.m_ElevatorList;}
            set { this.m_ElevatorList = value; }
        }
        public Door_Middle() : base() 
        {
            ElevatorList=new List<Device>();    
        }
        public Door_Middle(string door_ID, string door_IDStall, string door_Status,
            List<Device> list_Dev_Elevator) : base(door_ID, door_IDStall, door_Status)
        {
            this.ElevatorList = list_Dev_Elevator;
        }
        public override void Docfile(string path1, string path2)
        {
            try
            {
                StreamReader sr1= new StreamReader(path1,System.Text.Encoding.UTF8);
                string line=sr1.ReadLine();
                while(line!=null) 
                {
                    string[] arr1 = line.Split(";");
                    if (arr1.Length == 3)
                    {
                        this.Door_ID = arr1[0];
                        this.Door_IDStall = arr1[1];
                        if (arr1[2] == "w")
                            this.Door_Status = "work";
                        else this.Door_Status = " Stop";
                    }
                    line=sr1.ReadLine();
                }
                this.ElevatorList= Device_List.Readfile(path2);// danh sách các elevators
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        public override void Ouput1()
        {
            base.Ouput();
            Console.WriteLine("Device of Door: ");
            Device_List.OuputList(this.ElevatorList);
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
    }
}
