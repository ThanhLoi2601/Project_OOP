using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public abstract class Vehicle : Finding_Vehicle
    {
        protected string Veh_sID; // ID
        protected string Veh_sType; //Kiểu (Màu)
        protected string Veh_sLocate; //Vị trí khu, ô
        protected DateTime Veh_dIn_time; // thời gian vào
        protected DateTime Veh_dOut_time; // Thời gian ra
        private bool Veh_bCheck_Out_time = false;
        protected int Veh_iMoney; //Tiền giữ xe trong 1 phút
        protected int Veh_iBattery= -1; //Năng lượng
        protected int Veh_iOther_services = 0; // các dịch vụ khác 
        public string Veh_ID
        {
            get { return this.Veh_sID; }
            set
            {
                int s = 0;
                for (int i = 0; i < value.Length; i++)
                    if (value[i] == '_')
                        s++;
                if (s != 2)
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
                else
                    this.Veh_sID = value;
            }
        }

        public string Veh_Type
        {
            get { return this.Veh_sType; }
            set { this.Veh_sType = value; }
        }

        public string Veh_Locate
        {
            get { return this.Veh_sLocate; }
            set
            {
                this.Veh_sLocate = value;
            }
        }
        public DateTime Veh_In_time
        {
            get { return this.Veh_dIn_time; }
            set { this.Veh_dIn_time = value; }
        }

        public DateTime Veh_Out_time
        {
            get { return this.Veh_dOut_time; }
            set
            {
                if (value > this.Veh_In_time)
                    this.Veh_dOut_time = value;
                else
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
            }
        }

        public bool Veh_Check_Out_time
        {
            get { return this.Veh_bCheck_Out_time; }
            set
            {
                if (value != true && value != false)
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
                this.Veh_bCheck_Out_time = value;
            }
        }

        public int Veh_Money
        {
            get { return this.Veh_iMoney; }
            set
            {
                if (value >= 0)
                    this.Veh_iMoney = value;
                else
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
            }
        }

        public int Veh_Battery
        {
            get { return this.Veh_iBattery; }
            set
            {
                if (value < -1 || value > 100)
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
                this.Veh_iBattery = value;
            }
        }

        public int Veh_Other_services
        {
            get { return this.Veh_iOther_services; }
            set
            {
                if (value < 1 || value > 4)
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
                this.Veh_iOther_services = value;
            }
        }

        public Vehicle()
        {
            this.Veh_In_time = new DateTime();
            this.Veh_Out_time = new DateTime();
        }

        public Vehicle(string iD, string type, string locate, DateTime in_time, DateTime out_time)
        {
            this.Veh_ID = iD;
            this.Veh_Type = type;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
            this.Veh_Out_time = out_time;
            this.Veh_Check_Out_time = true;
        }


        public Vehicle(string iD, string type, string locate, DateTime in_time)
        {
            this.Veh_ID = iD;
            this.Veh_Type = type;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
        }
        public Vehicle(string iD, string locate, DateTime in_time, DateTime out_time)
        {
            this.Veh_ID = iD;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
            this.Veh_Out_time = out_time;
            this.Veh_Check_Out_time = true;
        }

        public Vehicle(string iD, string locate, DateTime in_time)
        {
            this.Veh_ID = iD;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
        }



        public Vehicle(string iD, DateTime in_time, DateTime out_time)
        {
            this.Veh_ID = iD;
            this.Veh_In_time = in_time;
            this.Veh_Out_time = out_time;
            this.Veh_Check_Out_time = true;
        }

        public Vehicle(string iD, DateTime in_time)
        {
            this.Veh_ID = iD;
            this.Veh_In_time = in_time;
        }
        ~Vehicle()
        {
        }

        public virtual void Veh_Input()
        {
            Console.Write("Nhap ID: ");
            this.Veh_ID = Console.ReadLine();
            Console.Write("Nhap Type: ");
            this.Veh_Type = Console.ReadLine();
            Console.Write("Nhap vi tri: ");
            this.Veh_Locate = Console.ReadLine();
            Console.Write("Nhap thoi gian vao: ");
            string sTimeI = Console.ReadLine();
            this.Veh_In_time = DateTime.Parse(sTimeI);
            Console.WriteLine("Xe da ra chua?");
            Console.WriteLine("1.Roi");
            Console.WriteLine("2.Chua");
            Console.Write("Chon: ");
            int c = int.Parse(Console.ReadLine());
            if (c == 1)
                this.Veh_Input_OutTime();
        }

        public void Veh_Input(string iD, string type, string locate, DateTime in_time, DateTime out_time)
        {
            this.Veh_ID = iD;
            this.Veh_Type = type;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
            this.Veh_Out_time = out_time;
            this.Veh_Check_Out_time = true;
        }

        public virtual void Veh_Input(string iD, string type, string locate, DateTime in_time)
        {
            this.Veh_ID = iD;
            this.Veh_Type = type;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
        }
        public void Veh_Input(string iD, string locate, DateTime in_time, DateTime out_time)
        {
            this.Veh_ID = iD;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
            this.Veh_Out_time = out_time;
            this.Veh_Check_Out_time = true;
        }

        public void Veh_Input(string iD, string locate, DateTime in_time)
        {
            this.Veh_ID = iD;
            this.Veh_Locate = locate;
            this.Veh_In_time = in_time;
        }



        public void Veh_Input(string iD, DateTime in_time, DateTime out_time)
        {
            this.Veh_ID = iD;
            this.Veh_In_time = in_time;
            this.Veh_Out_time = out_time;
            this.Veh_Check_Out_time = true;
        }

        public void Veh_Input(string iD, DateTime in_time)
        {
            this.Veh_ID = iD;
            this.Veh_In_time = in_time;
        }

        public virtual void Veh_Input_OutTime()
        {
            Console.Write("Nhap thoi gian ra: ");
            string sTimeO = Console.ReadLine();
            this.Veh_Out_time = DateTime.Parse(sTimeO);
            this.Veh_Check_Out_time = true;
        }

        public virtual void Veh_Input_OutTime(string out_time)
        {
            this.Veh_Out_time = DateTime.Parse(out_time);
            this.Veh_Check_Out_time = true;
        }

        public virtual void Veh_Output()
        {

            //String temp = this.Veh_dIn_time.Day + "/" + this.Veh_dIn_time.Month + "/" + this.Veh_dIn_time.Year;
            string strOut_time = "NULL";
            string strBattery="NULL";
            if (this.Veh_Check_Out_time == true)
                strOut_time= this.Veh_Out_time.ToString();
            if(this.Veh_Battery==-1)
                strBattery= this.Veh_Battery.ToString();
            Console.Write("|{0,23}|{1,10}|{2,10}|{3,22}|{4,22}|{5,15}|", this.Veh_sID, this.Veh_sType, this.Veh_Locate, this.Veh_In_time, strOut_time, this.Veh_Other_services);
            // Console.Write(this.Veh_sID + "   |" + this.Veh_sType + "|   " + this.Veh_Locate + "  |" + this.Veh_In_time + "| " + strOut_time + " |      " + this.Veh_Other_services + " | ");

        }
        //      time of parking vehicle
        public virtual TimeSpan Veh_Calculate_Time()
        {
            return this.Veh_Out_time - this.Veh_In_time;
        }
        public string Locate_Vehicle() // Tra cuu vi tri xe
        {
            string[]arr=this.Veh_Locate.Split('_');
            if (arr[1] == "ST1")
                return "Sy_15A NguyenHuuCanh Street.Chung Cu  Khu A VinHome RiverSide.TPHCM city : Stall 1  :  " + arr[2];
            else return "Sy_15A NguyenHuuCanh Street.Chung Cu  Khu A VinHome RiverSide.TPHCM city : Stall 1  :  " + arr[2];
        }
        // finding string đường đi 
        public virtual string path_Vehicle()
        {
            string str = "Start --> ";
            string[] a = this.Veh_ID.Split('_');
            string[] b = a[1].Split('.');

            if (b[0][1] == '1')
                str += "Door 1 --> ";
            else if (b[0][1] == '3')
                str += "Door 3 --> ";
            else
                return "ERROR";
            if (b.Length == 5)
            {
                str += "Door 5 --> Stall 2 --> " + "Khu " + b[3][0] + " o " + b[3][1] + b[3][2] + " --> ";
                if (b[4][1] == '2')
                    str += "Door 2 --> End";
                else if (b[4][1] == '4')
                    str += "Door 4 --> End";
                else
                    return "ERROR";
            }
            else if (b.Length == 4)
            {
                str += "Stall 1 --> " + "Khu " + b[2][0] + " o " + b[2][1] + b[2][2] + " --> ";
                if (b[3][1] == '2')
                    str += "Door 2 --> End";
                else if (b[3][1] == '4')
                    str += "Door 4 --> End";
                else
                    return "ERROR";
            }
            else return "ERROR";

            return str;
        }

        public virtual string toString()
        {
            string strOutTime;
            if (this.Veh_bCheck_Out_time == false)
                strOutTime = "null";
            else
                strOutTime = this.Veh_Out_time.ToString();

            string strBa;
            if (this.Veh_Battery==-1)
                strBa = "null";
            else
                strBa = this.Veh_Battery.ToString();

            return this.Veh_ID + ";" + this.Veh_Type + ";" + this.Veh_Locate + ";" + this.Veh_In_time + ";" + strOutTime + ";" + strBa + ";";
        }
        public abstract void Veh_Input_Other_services(); //Nhập vào dịch vụ khác 
        public abstract void Veh_Input_Other_services(int x);
        public abstract double Veh_Calculate_Money_Parking(); // tính tiền giữ xe
        public abstract double Veh_Calculate_Money_Other_services(); // tính tiền các dịch vụ khác

        public virtual double Veh_Calculate_Money_Sum()
        {
            return this.Veh_Calculate_Money_Parking() + this.Veh_Calculate_Money_Other_services();
        }
        public static bool operator >(Vehicle x, Vehicle y)
        {
            return x.Veh_Calculate_Money_Sum() > y.Veh_Calculate_Money_Sum();
        }
        public static bool operator <(Vehicle x, Vehicle y)
        {
            return x.Veh_Calculate_Money_Sum() < y.Veh_Calculate_Money_Sum();
        }
        public static bool operator >=(Vehicle x, Vehicle y)
        {
            return x.Veh_Calculate_Money_Sum() >= y.Veh_Calculate_Money_Sum();
        }
        public static bool operator <=(Vehicle x, Vehicle y)
        {
            return x.Veh_Calculate_Money_Sum() <= y.Veh_Calculate_Money_Sum();
        }
        public static bool operator ==(Vehicle x, Vehicle y)
        {
            return x.Veh_Calculate_Money_Sum() == y.Veh_Calculate_Money_Sum();
        }
        public static bool operator !=(Vehicle x, Vehicle y)
        {
            return x.Veh_Calculate_Money_Sum() != y.Veh_Calculate_Money_Sum();
        }
        public static Vehicle String_to_Vehicle(string line)
        {
            string[] a = line.Split(';');
            Vehicle pt;
            if (a[4] != "null")
            {
                if (a[0][0] == '1')
                    pt = new Vehicle_Electric(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]), double.Parse(a[6]));
                else if (a[0][0] == '2')
                    pt = new Vehicle_Car(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                else if (a[0][0] == '3')
                    pt = new Vehicle_Motobike(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                else if (a[0][0] == '4')
                    pt = new Vehicle_Scooter(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                else if (a[0][0] == '5')
                    pt = new Vehicle_Bike(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]));
                else if (a[0][0] == '6')
                    pt = new Vehicle_Truck(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                else
                    throw new Exception("ERROR");
            }
            else
            {
                if (a[0][0] == '1')
                    pt = new Vehicle_Electric(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]), double.Parse(a[6]));
                else if (a[0][0] == '2')
                    pt = new Vehicle_Car(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                else if (a[0][0] == '3')
                    pt = new Vehicle_Motobike(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                else if (a[0][0] == '4')
                    pt = new Vehicle_Scooter(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                else if (a[0][0] == '5')
                    pt = new Vehicle_Bike(a[0], a[1], a[2], DateTime.Parse(a[3]));
                else if (a[0][0] == '6')
                    pt = new Vehicle_Truck(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                else
                    throw new Exception("ERROR");
            }

            pt.Veh_Input_Other_services(int.Parse(a[7]));
            return pt;
        }
    }
}
