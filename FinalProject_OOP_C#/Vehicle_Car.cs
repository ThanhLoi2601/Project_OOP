﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    class Vehicle_Car : Vehicle
    {

        // Battery là xăng/dầu 
        //dịch vụ là đổ xăng và rửa xe
        public Vehicle_Car() : base()
        {
            this.Veh_Money = 90;
        }

        public Vehicle_Car(string iD, string type, string locate, DateTime in_time, DateTime out_time, int battery) : base(iD, type, locate, in_time, out_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Money = 90;
        }
        public Vehicle_Car(string iD, string type, string locate, DateTime in_time, int battery) : base(iD, type, locate, in_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Money = 90;
            this.Veh_Out_time=DateTime.Now;
        }

        public Vehicle_Car(string iD, string locate, DateTime in_time, DateTime out_time, int battery) : base(iD, locate, in_time)
        {
            this.Veh_Battery = battery;
            this.Veh_Money = 90;
        }

        public Vehicle_Car(string iD, string locate, DateTime in_time) : base(iD, locate, in_time)
        {
            this.Veh_Money = 90;
            this.Veh_Out_time= DateTime.Now;    
        }
        public Vehicle_Car(string iD, DateTime in_time, DateTime out_time) : base(iD, in_time, out_time)
        {
            this.Veh_Money = 90;
        }

        public Vehicle_Car(string iD, DateTime in_time) : base(iD, in_time)
        {
            this.Veh_Money = 90;
            this.Veh_Out_time= DateTime.Now;    
        }
        ~Vehicle_Car()
        {
        }

        public override void Veh_Input()
        {
            base.Veh_Input();
            Console.Write("Nhap phan tram binh xang: ");
            this.Veh_Battery = int.Parse(Console.ReadLine());
        }

        public override void Veh_Input_OutTime()
        {
            base.Veh_Input_OutTime();
        }
        public override void Veh_Input_OutTime(string out_time)
        {
            base.Veh_Input_OutTime(out_time);
        }
        public void Veh_Input(string iD, string type, string locate, DateTime in_time, DateTime out_time, int battery)
        {
            base.Veh_Input(iD, type, locate, in_time, out_time);
            this.Veh_Battery = battery;
        }

        public void Veh_Input(string iD, string type, string locate, DateTime in_time, int battery)
        {
            base.Veh_Input(iD, type, locate, in_time);
            this.Veh_Battery = battery;
        }

        public new void Veh_Input(string iD, string locate, DateTime in_time)
        {
            base.Veh_Input(iD, locate, in_time);
        }
        public new void Veh_Input(string iD, DateTime in_time, DateTime out_time)
        {
            base.Veh_Input(iD, in_time, out_time);
        }

        public new void Veh_Input(string iD, DateTime in_time)
        {
            base.Veh_Input(iD, in_time);
        }

        public override void Veh_Input_Other_services()
        {
            Console.WriteLine("Chon them dich vu:[1]:Do xang [2]:Rua xe [3]:Ca hai [4]:khong them dich vu");
            Console.Write("Choice:"); this.Veh_Other_services = Convert.ToInt32(Console.ReadLine());
        }

        public override void Veh_Input_Other_services(int x)
        {
            this.Veh_Other_services = x;
        }
        public override void Veh_Output()
        {
            base.Veh_Output();
            Console.WriteLine("{0,10}|", " Car");
        }

        public override string path_Vehicle()
        {
            return base.path_Vehicle();
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

        public override double Veh_Calculate_Money_Other_services()
        {
            double tong = 0;
            if (this.Veh_Other_services == 1)
                tong += (100 - this.Veh_Battery) * 5000;
            else if (this.Veh_Other_services == 2)
                tong += 300000; //Tiền rửa xe 300000đ
            else if (this.Veh_Other_services == 3)
                tong += (100 - this.Veh_Battery) * 5000 + 300000;

            return tong;
        }

        public override double Veh_Calculate_Money_Sum()
        {
            return base.Veh_Calculate_Money_Sum();
        }
        public override string toString()
        {
            return base.toString() + "null;" + this.Veh_Other_services;
        }
    }
}
