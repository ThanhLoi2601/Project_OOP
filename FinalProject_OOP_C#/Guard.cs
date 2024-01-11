using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public class Guard : Guard_Data_Cal, Guard_Vehicle_OUT
    {
        private string Gua_sID;
        private string Gua_sName;
        private int Gua_iCa;
        private long Gua_lLuongCB;
        private TimeSpan Gua_tTime_lam_them = TimeSpan.Parse("0:0:0:0");
        private string Gua_sAddress;
        private string Gua_sCall_number;

        public string Gua_ID
        {
            get { return this.Gua_sID; }
            set { this.Gua_sID = value; }
        }

        public string Gua_Name
        {
            get { return this.Gua_sName; }
            set { this.Gua_sName = value; }
        }

        public int Gua_Ca
        {
            get { return this.Gua_iCa; }
            set
            {
                if (value > 3 || value <= 0)
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
                this.Gua_iCa = value;
            }
        }

        public long Gua_LuongCB
        {
            get { return this.Gua_lLuongCB; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(value)} khong hop le !");
                this.Gua_lLuongCB = value;
            }
        }

        public TimeSpan Gua_Time_lam_them
        {
            get { return this.Gua_tTime_lam_them; }
            set { this.Gua_tTime_lam_them = value; }
        }

        public string Gua_Address
        {
            get { return this.Gua_sAddress; }
            set { this.Gua_sAddress = value; }
        }

        public string Gua_Call_number
        {
            get { return this.Gua_sCall_number; }
            set { this.Gua_sCall_number = value; }
        }

        public Guard()
        {
        }

        public Guard(string id, string name, int ca, long luongcb, TimeSpan time_them, string address, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_LuongCB = luongcb;
            this.Gua_Time_lam_them = time_them;
            this.Gua_Address = address;
            this.Gua_Call_number = call_num;
        }

        public Guard(string id, string name, int ca, string address, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_Address = address;
            this.Gua_Call_number = call_num;
        }

        public Guard(string id, string name, int ca, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_Call_number = call_num;
        }

        public Guard(string id, int ca, long luongcb, TimeSpan time_them, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Ca = ca;
            this.Gua_LuongCB = luongcb;
            this.Gua_Time_lam_them = time_them;
            this.Gua_Call_number = call_num;
        }

        public Guard(string id, string name, int ca, long luongcb)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_LuongCB = luongcb;
        }

        ~Guard()
        {
        }

        public void Gua_Input()
        {
            Console.Write("Nhap ID: ");
            this.Gua_ID = Console.ReadLine();
            Console.Write("Nhap Name: ");
            this.Gua_Name = Console.ReadLine();
            Console.Write("Nhap Ca: ");
            this.Gua_Ca = int.Parse(Console.ReadLine());
            Console.Write("Nhap Luong CB: ");
            this.Gua_LuongCB = long.Parse(Console.ReadLine());
            Console.Write("Nhap thoi gian lam them: ");
            this.Gua_Time_lam_them = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Nhap Address: ");
            this.Gua_Address = Console.ReadLine();
            Console.Write("Nhap Call_Number: ");
            this.Gua_Call_number = Console.ReadLine();
        }

        public void Gua_Input(string id, string name, int ca, long luongcb, TimeSpan time_them, string address, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_LuongCB = luongcb;
            this.Gua_Time_lam_them = time_them;
            this.Gua_Address = address;
            this.Gua_Call_number = call_num;
        }

        public void Gua_Input(string id, string name, int ca, string address, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_Address = address;
            this.Gua_Call_number = call_num;
        }

        public void Gua_Input(string id, string name, int ca, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_Call_number = call_num;
        }

        public void Gua_Input(string id, int ca, long luongcb, TimeSpan time_them, string call_num)
        {
            this.Gua_ID = id;
            this.Gua_Ca = ca;
            this.Gua_LuongCB = luongcb;
            this.Gua_Time_lam_them = time_them;
            this.Gua_Call_number = call_num;
        }

        public void Gua_Input(string id, string name, int ca, long luongcb)
        {
            this.Gua_ID = id;
            this.Gua_Name = name;
            this.Gua_Ca = ca;
            this.Gua_LuongCB = luongcb;
        }

        public void Gua_Output()
        {
            Console.WriteLine("ID: " + this.Gua_ID);
            Console.WriteLine("Name: " + this.Gua_Name);
            Console.WriteLine("Ca: " + this.Gua_Ca);
            Console.WriteLine("Luong CB: " + this.Gua_LuongCB);
            Console.WriteLine("Thoi gian lam them: " + this.Gua_Time_lam_them);
            Console.WriteLine("Address: " + this.Gua_Address);
            Console.WriteLine("Call_Number: " + this.Gua_Call_number);
        }
        public void Gua_OutPut()
        {
            Console.WriteLine(this.Gua_ID + "|  " + this.Gua_Name + "  |   " + this.Gua_Ca + "  |     " + this.Gua_Calculate_Salary_1day() + "    | " + this.Gua_Time_lam_them + " |" + this.Gua_Address + "|      "+this.Gua_Call_number+"       |");
        }
        public double Gua_Calculate_Salary_1day()
        {
            double t = this.Gua_Time_lam_them.Days * 24 + this.Gua_Time_lam_them.Hours + this.Gua_Time_lam_them.Minutes / 60 + this.Gua_Time_lam_them.Seconds / (60 * 60);
            return 200000 + 50000 * t;
        }

        public string Gua_Patrol_area()
        {
            string[] b = this.Gua_ID.Split('_');
            return "Khu vuc tuan tra: " + b[3][0] + " , " + b[3][1] + " , " + b[3][2] + " , " + b[3][3];
        }

        public string Gua_Patrol_time()
        {
            string str = "Thoi gian tuan tra: ";
            if (this.Gua_Ca == 1)
                str += "0h --> 8h";
            else if (this.Gua_Ca == 2)
                str += "8h --> 16h";
            else
                str += "16h --> 0h";
            return str;
        }
        public void Gua_List_Veh_ON()
        {
            Console.WriteLine("___List of vehicles that are parking___");
            Vehicle_List.OutList(SystemPark.List_Vehicle_On_Main);
        }
        public void Gua_List_Veh_OFF()
        {
            Console.WriteLine("___List of vehicles that were parking___");
            Vehicle_List.OutList(SystemPark.List_Vehicle_Off_Main);
        }
        public void Gua_Output_Person(Guard person)
        {
            Console.WriteLine("Information of Guard <Person>:");
            Console.WriteLine("         ID           |        Name         |Shifts|  Salary/1day  | Overtime |        Address        |       Call Number     |");
            person.Gua_OutPut();
        }
        public static Guard String_to_Guard(string line)
        {
            string[] a = line.Split(';');
            return new Guard(a[0], a[1], int.Parse(a[2]), long.Parse(a[3]), TimeSpan.Parse(a[4]), a[5], a[6]);
        }
        //Tìm và Xóa 1 vehicle trong List_Vehicle_On_Main
        public Vehicle Find_Delete_Vehicle(string veh_ID)
        {
            for (int i = 0; i < SystemPark.List_Vehicle_On_Main.Count; i++)
                if (SystemPark.List_Vehicle_On_Main[i].Veh_ID == veh_ID)
                {
                    Vehicle veh = SystemPark.List_Vehicle_On_Main[i];
                    SystemPark.List_Vehicle_On_Main.RemoveAt(i);
                    Console.WriteLine("Successful delete Vehicle in List_Vehicle_On!!");
                    return veh;
                }
            Console.WriteLine("Delete failed!!");
            return new Vehicle_Bike();
        }
    }
}