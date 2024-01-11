using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    interface Electricity_Vehicle
    {
        void Veh_Calculate_Time_Charge(double Wattage);// Truyen vao cong suat thiet bi
        void Information();
    }
    interface Finding_Vehicle
    {
        string path_Vehicle();                // finding string đường đi 
        double Veh_Calculate_Money_Parking(); // tính tiền giữ xe // string 
        double Veh_Calculate_Money_Other_services(); // tính tiền các dịch vụ khác
        double Veh_Calculate_Money_Sum();            //tính tiền tổng
        string Locate_Vehicle(); // Tra cuu vi tri xe
    }
}
