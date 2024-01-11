using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    class Vehicle_Electric : Vehicle, Electricity_Vehicle
    {
        //Battery là điện
        //dịch vụ khác là sạc điện
        private TimeSpan Veh_dTime_Charge; //Thời gian sạc
        private double Veh_dElec_Capacity; //Dung lượng bình sạc
        public TimeSpan Veh_Time_Charge
        {
            get { return this.Veh_dTime_Charge; }
            set
            {
                this.Veh_dTime_Charge = value;
            }
        }

        public double Veh_Elec_Capacity
        {
            get { return this.Veh_dElec_Capacity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} khong hop le !");
                this.Veh_dElec_Capacity = value;
            }
        }

        public Vehicle_Electric() : base()
        {
            this.Veh_dTime_Charge = new TimeSpan();
            this.Veh_Money = 70;
        }

        public Vehicle_Electric(string iD, string type, string locate, DateTime in_time, DateTime out_time, int battery, double capacity) : base(iD, type, locate, in_time, out_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Elec_Capacity = capacity;
            this.Veh_Money = 70;
        }

        public Vehicle_Electric(string iD, string type, string locate, DateTime in_time, DateTime out_time, int battery) : base(iD, type, locate, in_time, out_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Money = 70;
        }
        public Vehicle_Electric(string iD, string type, string locate, DateTime in_time, int battery, double capacity) : base(iD, type, locate, in_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Elec_Capacity = capacity;
            this.Veh_Money = 70;
            this.Veh_Out_time=DateTime.Now;
        }

        public Vehicle_Electric(string iD, string locate, DateTime in_time, DateTime out_time, int battery, double capacity) : base(iD, locate, in_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Elec_Capacity = capacity;
            this.Veh_Money = 70;
        }

        public Vehicle_Electric(string iD, string locate, DateTime in_time, double capacity) : base(iD, locate, in_time)
        {
            this.Veh_Elec_Capacity = capacity;
            this.Veh_Money = 70;
        }

        public Vehicle_Electric(string iD, string type, string locate, DateTime in_time, int battery) : base(iD, type, locate, in_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Money = 70;
        }
        public Vehicle_Electric(string iD, DateTime in_time, DateTime out_time, double capacity) : base(iD, in_time, out_time)
        {
            this.Veh_Elec_Capacity = capacity;
            this.Veh_Money = 70;
        }

        public Vehicle_Electric(string iD, DateTime in_time, double capacity) : base(iD, in_time)
        {
            this.Veh_Elec_Capacity = capacity;
            this.Veh_Money = 70;
        }
        ~Vehicle_Electric()
        {
        }

        public override void Veh_Input()
        {
            base.Veh_Input();
            Console.Write("Nhap phan tram pin: ");
            this.Veh_Battery = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap Capacity: ");
            this.Veh_Elec_Capacity = double.Parse(Console.ReadLine());
        }

        public override void Veh_Input_OutTime()
        {
            base.Veh_Input_OutTime();
        }
        public override void Veh_Input_OutTime(string out_time)
        {
            base.Veh_Input_OutTime(out_time);
        }
        public void Veh_Input(string iD, string type, string locate, DateTime in_time, DateTime out_time, int battery, double capacity)
        {
            base.Veh_Input(iD, type, locate, in_time, out_time);
            this.Veh_Battery = battery;
            this.Veh_Elec_Capacity = capacity;
        }

        public void Veh_Input(string iD, string type, string locate, DateTime in_time, int battery, double capacity,int OtherService)
        {
            base.Veh_Input(iD, type, locate, in_time);
            this.Veh_Battery = battery;
            this.Veh_Elec_Capacity = capacity;
            this.Veh_Other_services = OtherService;
        }

        public void Veh_Input(string iD, string locate, DateTime in_time, DateTime out_time, int battery, double capacity)
        {
            base.Veh_Input(iD, locate, in_time);
            this.Veh_Battery = battery;
            this.Veh_Elec_Capacity = capacity;
        }

        public void Veh_Input(string iD, string locate, DateTime in_time, double capacity)
        {
            base.Veh_Input(iD, locate, in_time);
            this.Veh_Elec_Capacity = capacity;
        }

        public void Veh_Input(string iD, string type, string locate, DateTime in_time, int battery,int service)
        {
            base.Veh_Input(iD, type, locate, in_time);
            this.Veh_Battery = battery;
            this.Veh_Other_services=service;
        }
        public void Veh_Input(string iD, DateTime in_time, DateTime out_time, double capacity)
        {
            base.Veh_Input(iD, in_time, out_time);
            this.Veh_Elec_Capacity = capacity;
        }

        public void Veh_Input(string iD, DateTime in_time, double capacity)
        {
            base.Veh_Input(iD, in_time);
            this.Veh_Elec_Capacity = capacity;
        }

        public override void Veh_Input_Other_services()
        {
            Console.WriteLine("Sac pin hay khong?");
            Console.WriteLine("1.Sac");
            Console.WriteLine("2.Khong sac");
            this.Veh_Other_services = int.Parse(Console.ReadLine());
        }

        public override void Veh_Input_Other_services(int x)
        {
            this.Veh_Other_services = x;
        }

        public override void Veh_Output()
        {
            base.Veh_Output();
            Console.WriteLine("{0,10}|"," Electric");
        }

        public override TimeSpan Veh_Calculate_Time()
        {
            return base.Veh_Calculate_Time();
        }

        public override double Veh_Calculate_Money_Parking()
        {
            TimeSpan time = this.Veh_Calculate_Time();
            double Minutes = time.Days * 24 * 60 + time.Hours * 60 + time.Minutes + time.Seconds / 60;
            return this.Veh_Money * Minutes;
        }
        public void Information()
        {
            Console.WriteLine("Thoi gian sac pin:" + this.Veh_Time_Charge.ToString());
            Console.WriteLine("Tien gui xe:" + this.Veh_Calculate_Money_Parking());
            Console.WriteLine("Tien dich vu:" + this.Veh_Calculate_Money_Other_services());
            Console.WriteLine("Tong:" + this.Veh_Calculate_Money_Sum());
        }
        public override double Veh_Calculate_Money_Other_services()
        {

            double tong = 0;
            if (this.Veh_Other_services == 1)
            {
                TimeSpan time = this.Veh_Calculate_Time();
                double Hours = time.Days * 24 + time.Hours + time.Minutes / 60 + time.Seconds / (60 * 60);
                double Hours_Charge = this.Veh_Time_Charge.Days * 24 + this.Veh_Time_Charge.Hours + this.Veh_Time_Charge.Minutes / 60 + this.Veh_Time_Charge.Seconds / (60 * 60);
                double x = Hours_Charge - Hours;
                if (x < 0)
                    tong += 1700 * Hours_Charge;
                else
                    tong += 1700 * Hours;
            }

            return tong;
        }
        // Tinh tien tong
        public override double Veh_Calculate_Money_Sum()
        {
            return base.Veh_Calculate_Money_Sum();
        }

        //hàm tính thời gian sạc // (dung luong, P) tg=dl/cs
        public void Veh_Calculate_Time_Charge(double Wattage)
        {
            double t = Math.Round(this.Veh_dElec_Capacity / Wattage, 2);
            int hours = (int)t;
            int minutes = (int)((t - hours) * 60);
            int seconds = (int)((t - minutes) * 60);
            this.Veh_Time_Charge = new TimeSpan(hours, minutes, seconds);
        }

        // string đường đi
        public override string path_Vehicle()
        {
            return base.path_Vehicle();
        }

        public static explicit operator Vehicle_Bike(Vehicle_Electric x)
        {
            Vehicle_Bike kq = new Vehicle_Bike();
            kq.Veh_ID = x.Veh_ID;
            kq.Veh_Type = x.Veh_Type;
            kq.Veh_Locate = x.Veh_Locate;
            kq.Veh_In_time = x.Veh_In_time;
            kq.Veh_Out_time = x.Veh_Out_time;
            kq.Veh_Battery = x.Veh_Battery; // phan tram pin
            return kq;
        }

        public static explicit operator Vehicle_Car(Vehicle_Electric x)
        {
            Vehicle_Car kq = new Vehicle_Car();
            kq.Veh_ID = x.Veh_ID;
            kq.Veh_Type = x.Veh_Type;
            kq.Veh_Locate = x.Veh_Locate;
            kq.Veh_In_time = x.Veh_In_time;
            kq.Veh_Out_time = x.Veh_Out_time;
            kq.Veh_Battery = x.Veh_Battery;
            return kq;
        }

        public static explicit operator Vehicle_Motobike(Vehicle_Electric x)
        {
            Vehicle_Motobike kq = new Vehicle_Motobike();
            kq.Veh_ID = x.Veh_ID;
            kq.Veh_Type = x.Veh_Type;
            kq.Veh_Locate = x.Veh_Locate;
            kq.Veh_In_time = x.Veh_In_time;
            kq.Veh_Out_time = x.Veh_Out_time;
            kq.Veh_Battery = x.Veh_Battery;
            return kq;
        }

        public static explicit operator Vehicle_Scooter(Vehicle_Electric x)
        {
            Vehicle_Scooter kq = new Vehicle_Scooter();
            kq.Veh_ID = x.Veh_ID;
            kq.Veh_Type = x.Veh_Type;
            kq.Veh_Locate = x.Veh_Locate;
            kq.Veh_In_time = x.Veh_In_time;
            kq.Veh_Out_time = x.Veh_Out_time;
            kq.Veh_Battery = x.Veh_Battery;
            return kq;
        }

        public static explicit operator Vehicle_Truck(Vehicle_Electric x)
        {
            Vehicle_Truck kq = new Vehicle_Truck();
            kq.Veh_ID = x.Veh_ID;
            kq.Veh_Type = x.Veh_Type;
            kq.Veh_Locate = x.Veh_Locate;
            kq.Veh_In_time = x.Veh_In_time;
            kq.Veh_Out_time = x.Veh_Out_time;
            kq.Veh_Battery = x.Veh_Battery;
            return kq;
        }

        public override string toString()
        {
            return base.toString() + this.Veh_Elec_Capacity +";" + this.Veh_Other_services;
        }
    }
}
