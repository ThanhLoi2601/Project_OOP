using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public static class Door_List
    {
        
        public static Door_Middle Door_5 = new Door_Middle();
        public static Door_Main Door_1 = new Door_Main();
        public static Door_Main Door_2 = new Door_Main();
        public static Door_Main Door_3 = new Door_Main();
        public static Door_Main Door_4 = new Door_Main();
        public static void Readfile()
        {
            // Docfile
            Door_5.Docfile(@"Door_5.txt", @"Door_5_Elevator.txt");
            Door_1.Docfile(@"Door_1.txt", @"Door_1_ElectricGate.txt");
            Door_2.Docfile(@"Door_2.txt", @"Door_2_ElectricGate.txt");
            Door_3.Docfile(@"Door_3.txt", @"Door_3_ElectricGate.txt");
            Door_4.Docfile(@"Door_4.txt", @"Door_4_ElectricGate.txt");
            // Add for System
            SystemPark.List_Doors.Add(Door_1);
            SystemPark.List_Doors.Add(Door_2);
            SystemPark.List_Doors.Add(Door_3);
            SystemPark.List_Doors.Add(Door_4);
            SystemPark.List_Doors.Add(Door_5);
;       }
        public static void Output() // inteface
        {
            Readfile();
            foreach(Door d in SystemPark.List_Doors) 
            {
                Console.WriteLine(" ID of Door | ID of Stall | Situation of Door |");
                d.Ouput1();
                Console.WriteLine("___");
            }
        }
        public static void Ouput(List<Door> list)
        {
            Console.WriteLine(" ID of Door  |       ID of Stall     |       Situation of Door       |");
            foreach(Door door in list)
            {
                Console.WriteLine(door.Door_ID+"     |       "+door.Door_IDStall+"      |       "+door.Door_Status);
                // Ouput list of Electric gate
                Console.WriteLine("List of devices of Door");
                // Ouput List of elevators
            }
        }
        public static void Ouput_1(List<Door> list)
        {
            Console.WriteLine("   ID of Door      |  ID of Stall | Situation of Door |");
            foreach (Door door in list)
            {
                door.Ouput();
            }
        }
    }
}