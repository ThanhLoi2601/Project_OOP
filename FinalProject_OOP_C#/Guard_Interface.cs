using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    interface Guard_Data_Cal
    {
        double Gua_Calculate_Salary_1day();
        void Gua_Output_Person(Guard person);
        string Gua_Patrol_area();
        string Gua_Patrol_time();
        // Tra cuu sanh sach
        void Gua_List_Veh_ON();
        void Gua_List_Veh_OFF();
    }
    interface  Guard_Vehicle_OUT
    {
        Vehicle Find_Delete_Vehicle(string veh);
    }
}
