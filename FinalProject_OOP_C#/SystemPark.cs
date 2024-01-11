using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public static class SystemPark
    {
        private static string SystemPark_ID="Sy_15A NguyenHuuCanh Street.Chung Cu  Khu A VinHome RiverSide.TPHCM city";
        private static string SystemPark_Name = "Sy_Chung Cu  Khu A VinHome RiverSide.TPHCM city";
        public static Stall Stall_1 = new Stall();
        public static Stall Stall_2 = new Stall();
        // Danh Sach cac thiet bi cua System
        public static List<Device> List_Devices_Main = new List<Device>(); 
        // Danh Sach hien tai cac phuong tien hien co
        public static List<Vehicle> List_Vehicle_On_Main = new List<Vehicle>();
        // Danh Sach lich sư luu tru cua he thong
        public static List<Vehicle> List_Vehicle_Off_Main = new List<Vehicle>();
        // Danh Sach Cac bao ve 
        public static List<Guard> List_Guard_Main = new List<Guard>();
        // Danh Sach Cac cua chinh
        public static List<Door> List_Doors = new List<Door>();
        // Quan Ly Systempark
        public static Guard Manager=new Guard();
        public static void ReadData()
        {
            // Main System
            SystemPark.List_Devices_Main = Device_List.Readfile(@"System_List_Device.txt");// List System_Devices
            Door_List.Readfile();// List System_Door
            SystemPark.List_Guard_Main = Guard_List.Docfile(@"System_List_Guard.txt");
            SystemPark.List_Vehicle_On_Main = Vehicle_List.Docfile(@"System_List_Vehicle_On.txt");
            SystemPark.List_Vehicle_Off_Main = Vehicle_List.Docfile(@"System_List_Vehicle_Off.txt");
            // Manager:
            SystemPark.Manager = Guard_List.DocFile_(@"System_Manager.txt");
            // Read file txt
            //... List_Devices Stall_1
            //... List_Devices Stall_2
            SystemPark.Stall1_Stall2_list_Devices_add();
            //...List_Vehicles in stall 1
            //...List_Vehicles in stall 2
            SystemPark.Stall1_Stall2_List_Vehicle_add();
            //... List_Guards Stall_1
            //... List_Guard Stall_2
            SystemPark.Stall1_Stall2_Guards_add();


            // Stall_1
            //... Infor of Stall 1
            SystemPark.Stall_1.Stall_Docfile(@"Stall1.txt");
            //... List_Guards Stall_1


            //... List_Door Stall_1
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_1);
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_2);
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_3);
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_4);


            // Stall_2
            //... Infor of Stall 2
            SystemPark.Stall_2.Stall_Docfile(@"Stall2.txt");


            //... List_Door Stall_2
            SystemPark.Stall_2.Stall_List_Door.Add(Door_List.Door_5);

        }
        // Demo Data for Debug
        public static void DemoData()
        {
            SystemPark.String_Add_Device_MainList(); // List Device
            SystemPark.String_Add_Guard_MainList(); // List Guard
            SystemPark.String_Add_OnVehicle_MainList(); // list ON vehicle list
            SystemPark.String_Add_OffVehicle_MainList();// list OFF vehicle list
            SystemPark.Add_Infor_All_Door(); // list door
            SystemPark.Add_Stall(); // list stall
            SystemPark.Add_Managerment(); // Managerment
            //... List_Devices Stall_1
            //... List_Devices Stall_2
            SystemPark.Stall1_Stall2_list_Devices_add();
            //...List_Vehicles in stall 1
            //...List_Vehicles in stall 2
            SystemPark.Stall1_Stall2_List_Vehicle_add();
            //... List_Guards Stall_1
            //... List_Guard Stall_2
            // ... Infor of stall 1 and stall 2
            SystemPark.Stall1_Stall2_Guards_add();
            //... List_Door Stall_1
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_1);
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_2);
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_3);
            SystemPark.Stall_1.Stall_List_Door.Add(Door_List.Door_4);
            //... List_Door Stall_2
            SystemPark.Stall_2.Stall_List_Door.Add(Door_List.Door_5);
        }
        private static void Stall1_Stall2_List_Vehicle_add()
        {
            foreach(Vehicle veh in SystemPark.List_Vehicle_On_Main)
            {
                string[] arr = veh.Veh_Locate.Split("_");
                if (arr[1] == "ST1") SystemPark.Stall_1.Stall_List_Vehicles.Add(veh);
                else if (arr[1] == "ST2") SystemPark.Stall_2.Stall_List_Vehicles.Add(veh);
            }

            foreach (Vehicle veh in SystemPark.List_Vehicle_Off_Main)
            {
                string[] arr = veh.Veh_Locate.Split("_");
                if (arr[1] == "ST1") SystemPark.Stall_1.Stall_List_Vehicles.Add(veh);
                else if (arr[1] == "ST2") SystemPark.Stall_2.Stall_List_Vehicles.Add(veh);
            }
        }
        
        private static void Stall1_Stall2_list_Devices_add()
        {
            foreach(Device dev in SystemPark.List_Devices_Main)
            {
                string[] arr=dev.Device_Locate.Split("_");
                if (arr[1]=="ST1") SystemPark.Stall_1.Stall_List_Device.Add(dev);
                else if (arr[1] == "ST2") SystemPark.Stall_2.Stall_List_Device.Add(dev);
            }    
        }
        private static void Stall1_Stall2_Guards_add()
        {
            foreach(Guard gu in SystemPark.List_Guard_Main)
            {
                string[] arr=gu.Gua_ID.Split("_");
                if (arr[1] == "ST1") SystemPark.Stall_1.Stall_List_Guards.Add(gu);
                else if (arr[1] == "ST2") SystemPark.Stall_2.Stall_List_Guards.Add(gu);
            }
        }
        public static void OuputSystemPark()
        {
            Console.WriteLine("___Information for System parking____");
            Console.WriteLine("Name:" + SystemPark.SystemPark_ID);
            string[]arr=SystemPark.SystemPark_ID.Split("_");
            Console.WriteLine("Address:" + arr[1]);
            Console.WriteLine("____//Stall_1//____");
            SystemPark.Stall_1.Stall_Ouput();
            Console.WriteLine("____//Stall_2//____");
            SystemPark.Stall_2.Stall_Ouput();
        }
        public static void Ouput_1_SystemPark()
        {
            Console.WriteLine("___Information for System parking____");
            Console.WriteLine("Name:" + SystemPark.SystemPark_ID);
            string[] arr = SystemPark.SystemPark_ID.Split("_");
            Console.WriteLine("Address:" + arr[1]);
        }
        
        //Thêm 1 vehicle trong List_Vehicle_Off_Main
        public static void Add_Vehicle(Vehicle veh)
        {
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            if (SystemPark.List_Vehicle_Off_Main[SystemPark.List_Vehicle_Off_Main.Count-1]==veh)
                Console.WriteLine("Successful addition List_Vehicle_Off!!");
            else
                Console.WriteLine("Addition failed!!");
        }
        public static void Add_Stall()
        {
            SystemPark.Stall_1.String_to_Stall("SY_ST1;STALL 1;60;400;0");
            SystemPark.Stall_2.String_to_Stall("SY_ST2;STALL 2;180;0;80");
        }
        // Door
        public static void Add_Managerment()
        {
            SystemPark.Manager = Guard.String_to_Guard("SY_ST2_Gua_PQYZ_3_1011;  Mai Anh Khoa   ;3;30120;0:1:0:0; 98AVN,Thu Duc,TPHCM   ;0154723881");
        }
        public static void Add_Infor_All_Door()
        {
            //... Door 1
            Door_List.Door_1.String_to_Door("Door1_SY_ST1    ;SY_ST1_A15;w");
            Device dev = Device.String_to_Device("EG_1_1_E_SY_L7;ElectricGate;SamSungK94P;SY_ST1_A14;w;18/5/2019 5:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EG_1_3_E_SY_L7;ElectricGate;SamSungK95P;SY_ST1_A15;w;18/5/2019 3:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EG_1_4_E_SY_L7;ElectricGate;SamSungK94P;SY_ST1_A16;w;18/5/2019 1:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            //... Door 2
            Door_List.Door_2.String_to_Door("Door2_SY_ST1    ;SY_ST1_K01;w");
            dev = Device.String_to_Device("EG_2_1_E_SY_L7;ElectricGate;SamSungK95P;SY_ST1_K14;w;20/5/2019 5:35 PM;29/5/2023 7:30 AM;10/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EG_2_2_E_SY_L7;ElectricGate;SamSungK94P;SY_ST1_SY_ST1_K15;w;19/5/2020 3:35 PM;29/5/2024 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EG_2_3_E_SY_L7;ElectricGate;SamSungK94P;SY_ST1_K16;w;18/5/2019 1:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            //... Door 3
            Door_List.Door_3.String_to_Door("Door3_SY_ST1    ;SY_ST1_E50;w");
            dev = Device.String_to_Device("EG_3_1_E_SY_L7;ElectricGate;SamSungK94P;SY_ST1_E50;w;18/5/2019 5:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EG_3_2_E_SY_L7;ElectricGate;SamSungK95P;SY_ST1_F50;w;18/5/2019 3:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM\r\n");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            //... Door 4
            Door_List.Door_4.String_to_Door("Door4_SY_ST1    ;SY_ST1_E01;w");
            dev = Device.String_to_Device("EG_4_1_E_SY_L7;ElectricGate;SamSungK94P;SY_ST1_E1;w;18/5/2019 5:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EG_4_2_E_SY_L7;ElectricGate;SamSungK95P;SY_ST1_F1;w;18/5/2019 3:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM\r\n");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            //... Door 5
            Door_List.Door_5.String_to_Door("Door5_SY_ST1_ST2;SY_ST1_ST2;w");
            dev = Device.String_to_Device("EL_1_1_P_SY_L9;Elevator;Mishubishi_ElectricK89P;SY_ST1_ST2_E14;w;18/5/2019 15:35 PM;19/5/2026 4:30 AM;HP_41756Gh6k");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EL_2_1_P_SY_L9;Elevator;Mishubishi_ElectricK89P;SY_ST1_ST2_F14;w;28/5/2019 15:35 PM;29/5/2026 4:30 AM;HP_65896Gh5k");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EL_1_2_V_SY_L8;Elevator;Mishubishi_ElectricO57Z;SY_ST1_ST2_E15;w;8/6/2019 15:35 PM;9/7/2026 4:30 AM;Dell_15486Gh5k");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EL_2_2_V_SY_L8;Elevator;Mishubishi_ElectricO57Z;SY_ST1_ST2_E15;w;7/6/2019 15:35 PM;8/7/2026 4:30 AM;Dell_14546Gh5k");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EL_1_3_V_SY_L8;Elevator;Mishubishi_ElectricO57Z;SY_ST1_ST2_E15;w;15/6/2019 15:35 PM;16/7/2026 5:30 AM;Dell_14546Gh5k");
            Door_List.Door_1.ElectricGatesList.Add(dev);
            dev = Device.String_to_Device("EL_2_3_V_SY_L8;Elevator;Mishibishi_ElectricP07X;SY_ST1_ST2_E15;w;17/6/2019 15:35 PM;17/7/2026 3:30 PM;Dell_20567Gh5k");
            Door_List.Door_1.ElectricGatesList.Add(dev);
        }
        // Demo các Guard list main
        public static void String_Add_Guard_MainList()
        {
            
            Guard gua = Guard.String_to_Guard("SY_ST1_Gua_ABCD_1_1000; Huynh Tuan Kha  ;1;30000;0:1:0:0; 2 VVN,Thu Duc,TPHCM   ;0858238298"); 
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST1_Gua_ABCD_2_1001;   Vo Van Tu     ;2;30000;0:1:30:0;3 VVN,Thu Duc,TPHCM    ;0858238299");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST1_Gua_ABCD_3_1002; Huynh Minh Kha  ;3;30000;0:1:0:0; 5 VVN,Thu Duc,TPHCM   ;0858238218");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST1_Gua_GHIK_1_1003; Huynh Quoc Minh ;1;30000;0:1:20:0;2 Dan Chu,Thu Duc,TPHCM;0858238881");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST1_Gua_GHIK_2_1004; Nguyen Tuan Kha ;2;30000;0:0:30:0;5 VVK,Thu Duc,TPHCM    ;0858238234");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST1_Gua_GHIK_3_1005; Nguyen Xuan Hung;3;30000;0:2:0:0; 4 VVL,Thu Duc,TPHCM   ;0858238324");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST2_Gua_LMNO_1_1006; Huynh Minh Tuan ;1;30000;0:5:0:0; 3 MK,Thu Duc,TPHCM    ;0858238242");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST2_Gua_LMNO_2_1007;  Tran Linh Kha  ;2;30000;0:1:0:0; 1 PVB,Thu Duc,TPHCM   ;0858238999");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST2_Gua_LMNO_3_1008; Huynh Xuan Minh ;3;30000;0:0:40:0;10 VVN,Thu Duc,TPHCM   ;0858238123");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST2_Gua_PQYZ_1_1009; Huynh Van Linh  ;1;30000;0:0:30:0;8 VVN,Thu Duc,TPHCM    ;0858238321");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST2_Gua_PQYZ_2_1010; Nguyen Tuan Quoc;2;30000;0:1:0:0; 100 VVN,Thu Duc,TPHCM ;0858238213");
            SystemPark.List_Guard_Main.Add(gua);
            gua = Guard.String_to_Guard("SY_ST2_Gua_PQYZ_3_1011;  Vo Tuan Van    ;3;30000;0:1:0:0; 7 VVN,Thu Duc,TPHCM   ;0858238281");
            SystemPark.List_Guard_Main.Add(gua);
        }
        // Demo các string chuyển thành các Device add vào trong System.list.device
        public static void String_Add_Device_MainList()
        {
            Device dev = Device.String_to_Device("Ca_1_St1_Sy_@1;    Camera     ;\t  SamSungAGS5     ;SY_ST1_A12    ;w;15/3/2022 12:00 AM;15/4/2023 12:00 AM;ABCDEF#DEFGH#LMNOP#QRSW#ZY");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("Ca_2_St1_Sy_^2;    Camera     ; \t  SamSungAGS5     ;SY_ST1_E24    ;w;16/3/2022 11:20 AM;20/5/2023 3:00 PM;ABCDEF#DEFGH#LMNOP#QRSW#ZY");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("Ca_4_St2_Sy_(7;    Camera     ;  \t  SamSungAGS5\t;SY_ST2_A12    ;w;17/5/2022 5:05 AM;18/5/2023 11:00 PM;ABCDEF#DEFGH#LMNOP#QRSW#ZY");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("ES_5_St1_Sy_*9;ElectricStation;       SonyWHIOO78     ;SY_ST2_Y45    ;w;27/5/2019 7:05 AM;29/5/2024 11:45 PM;1505");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("ES_6_St1_Sy_&4;ElectricStation;\t  SonyWHIOO78     ;SY_ST2_Z45    ;W;27/5/2019 7:06 AM;29/5/2024 11:55 PM;1805");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_1_1_E_SY_L7;  ElectricGate ;  \t  SamSungK94P     ;SY_ST1_A14    ;w;18/5/2019 5:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_1_3_E_SY_L7;  ElectricGate ;       SamSungK95P     ;SY_ST1_A15    ;w;18/5/2019 3:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_1_4_E_SY_L7;  ElectricGate ;\t  SamSungK94P\t;SY_ST1_A16    ;w;18/5/2019 1:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_2_1_E_SY_L7;  ElectricGate ;\t  SamSungK95P\t;SY_ST1_K14    ;w;20/5/2019 5:35 PM;29/5/2023 7:30 AM;10/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_2_2_E_SY_L7;  ElectricGate ;\t  SamSungK94P\t;SY_ST1_K15    ;w;19/5/2020 3:35 PM;29/5/2024 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_2_3_E_SY_L7;  ElectricGate ;\t  SamSungK94P\t;SY_ST1_K16    ;w;18/5/2019 1:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_3_1_E_SY_L7;  ElectricGate ;       SamSungK94P     ;SY_ST1_E50    ;w;18/5/2019 5:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_3_2_E_SY_L7;  ElectricGate ;       SamSungK95P     ;SY_ST1_F50    ;w;18/5/2019 3:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_4_1_E_SY_L7;  ElectricGate ;       SamSungK94P     ;SY_ST1_E1     ;w;18/5/2019 5:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EG_4_2_E_SY_L7;  ElectricGate ;       SamSungK95P     ;SY_ST1_F1     ;w;18/5/2019 3:35 PM;29/5/2023 7:30 AM;09/12/2022 11:00 AM#10/12/2022 4:00 AM#11/12/2022 10:05 PM#13/12/2022 09:32 PM");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EL_1_1_P_SY_L9;    Elevator   ;Mishubishi_ElectricK89P;SY_ST1_ST2_E14;w;18/5/2019 15:35 PM;19/5/2026 4:30 AM;HP_41756Gh6k");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EL_2_1_P_SY_L9;    Elevator   ;Mishubishi_ElectricK89P;SY_ST1_ST2_F14;w;28/5/2019 15:35 PM;29/5/2026 4:30 AM;HP_65896Gh5k");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EL_1_2_V_SY_L8;    Elevator   ;Mishubishi_ElectricO57Z;SY_ST1_ST2_E15;w;8/6/2019 15:35 PM;9/7/2026 4:30 AM;Dell_15486Gh5k");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EL_2_2_V_SY_L8;    Elevator   ;Mishubishi_ElectricO57Z;SY_ST1_ST2_E15;w;7/6/2019 15:35 PM;8/7/2026 4:30 AM;Dell_14546Gh5k");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EL_1_3_V_SY_L8;    Elevator   ;Mishubishi_ElectricO57Z;SY_ST1_ST2_E15;w;15/6/2019 15:35 PM;16/7/2026 5:30 AM;Dell_14546Gh5k");
            SystemPark.List_Devices_Main.Add(dev);
            dev = Device.String_to_Device("EL_2_3_V_SY_L8;    Elevator   ;Mishibishi_ElectricP07X;SY_ST1_ST2_E15;w;17/6/2019 15:35 PM;17/7/2026 3:30 PM;Dell_20567Gh5k");
            SystemPark.List_Devices_Main.Add(dev);
        }
        // demo các string thành vehicle add vào systempark.list.vehicle ON
        public static void String_Add_OnVehicle_MainList()
        {
            Vehicle veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Y05.D4_1008;Trang;SY_ST2_Y05;14/11/2022 2:10:00 PM;null;10;1291929;1");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.T01.D4_1019;Vang chuoi;SY_ST2_T01;14/11/2022 1:10:00 PM;null;85;null;2");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.T02.D4_1019;Vang chuoi;SY_ST2_T02;14/11/2022 1:10:00 PM;null;85;null;4");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.K04.D2_1035;Xanh la;SY_ST1_K04;14/11/2022 10:10:00 AM;null;20;null;2");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.K05.D2_1039;Cam;SY_ST1_K05;14/11/2022 9:10:00 AM;null;11;null;2");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.I09.D2_1054;Hong;SY_ST1_I09;14/11/2022 7:10:00 AM;null;null;null;1");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.C02.D4_1062;Vang;SY_ST1_C02;14/11/2022 10:10:00 AM;null;50;null;2");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.A04.D4_1068;Trang;SY_ST1_A04;14/11/2022 11:10:00 AM;null;90;null;4");
            SystemPark.List_Vehicle_On_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.B04.D4_1069;Nau;SY_ST1_B04;14/11/2022 9:10:00 AM;null;40;null;3");

        }
        // demo các string thành vehicle add vào systempark.list.vehicle OFF
        public static void String_Add_OffVehicle_MainList()
        {
            Vehicle veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Y01.D4_1000;  Trang  ;SY_ST2_Y01;14/11/2022 9:10:00 AM ;14/11/2022 12:10:00 PM;10;5000   ;1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.st1.C01.D4_1012; Do; SY_ST1_C01; 14 / 11 / 2022 9:30:00 AM; 14 / 11 / 2022 12:10:00 PM; 40; null; 3");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.st1.B01.D4_1011; Vang; SY_ST1_B01; 14 / 11 / 2022 10:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.st1.A01.D4_1010; Bac; SY_ST1_A01; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 50; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Z05.D4_1009; Xanh ngoc; SY_ST2_Z05; 14 / 11 / 2022 6:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 80; 2888282; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Z04.D4_1007; Xanh la; SY_ST2_Z04; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 89; 1920211; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Y04.D4_1006; Do; SY_ST2_Y04; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 1; 100000; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Z03.D4_1005; Vang; SY_ST2_Z03; 14 / 11 / 2022 8:00:00 AM; 14 / 11 / 2022 10:10:00 PM; 10; 291929; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Y03.D4_1004; Trang; SY_ST2_Y03; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 80; 97288; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Z02.D4_1003; Xanh bien; SY_ST2_Z02; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 9:10:00 PM; 60; 918283; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Y02.D4_1002; Tim; SY_ST2_Y02; 14 / 11 / 2022 11:10:00 AM; 14 / 11 / 2022 1:10:00 PM; 50; 91000; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);

            veh = Vehicle.String_to_Vehicle("3_D3.st1.G01.D2_1020; Trang; SY_ST1_G01; 14 / 11 / 2022 5:10:00 AM; 14 / 11 / 2022 11:10:00 AM; 19; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.R02.D4_2018; Xanh la; SY_ST2_R02; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 20; null; 3");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.O02.D4_2017; Xanh bien; SY_ST2_O02; 14 / 11 / 2022 12:10:00 PM; 14 / 11 / 2022 6:10:00 PM; 40; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.N02.D4_2016; Vang; SY_ST2_N02; 13 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.M02.D4_2015; Trang; SY_ST2_M02; 14 / 11 / 2022 10:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 90; null; 4");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.L01.D4_1014; Cam; SY_ST2_L01; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 3");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.R01.D4_1018; Xanh la; SY_ST2_R01; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 20; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.O01.D4_1017; Xanh bien; SY_ST2_O01; 14 / 11 / 2022 12:10:00 PM; 14 / 11 / 2022 6:10:00 PM; 40; null; 4");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.N01.D4_1016; Vang; SY_ST2_N01; 13 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 3");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.M01.D4_1015; Trang; SY_ST2_M01; 14 / 11 / 2022 10:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 90; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.D5.st2.L01.D4_1014; Cam; SY_ST2_L01; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("2_D1.st1.D01.D4_1013; Bac; SY_ST1_D01; 14 / 11 / 2022 9:10:00 PM; 14 / 11 / 2022 11:10:00 PM; 30; null; 4");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("1_D1.D5.st2.Z01.D4_1001;    Do   ;SY_ST2_Z01;14/11/2022 10:10:00 AM;14/11/2022 11:10:00 PM;20;10000  ;2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.D03.D4_1067; Den; SY_ST1_D03; 14 / 11 / 2022 6:10:00 AM; 14 / 11 / 2022 4:10:00 PM; 10; null; 4");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.C03.D4_1066; Bac; SY_ST1_C03; 14 / 11 / 2022 10:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 70; null; 4");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.B03.D4_1065; Vang; SY_ST1_B03; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 100; null; 3");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.A03.D4_1064; Hong; SY_ST1_A03; 14 / 11 / 2022 6:00:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 3");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.D02.D4_1063; Trang; SY_ST1_D02; 14 / 11 / 2022 2:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 75; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.B02.D4_1061; Den; SY_ST1_B02; 14 / 11 / 2022 8:10:00 AM; 14 / 11 / 2022 11:10:00 AM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("6_D1.st1.A02.D4_1060; Trang; SY_ST1_A02; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.K10.D2_1059; Xanh la; SY_ST1_K10; 14 / 11 / 2022 7:15:00 AM; 14 / 11 / 2022 11:30:00 AM; null; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.I10.D2_1058; Tim; SY_ST1_I10; 14 / 11 / 2022 7:30:00 AM; 14 / 11 / 2022 12:30:00 PM; null; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.H10.D2_1057; Cam; SY_ST1_H10; 14 / 11 / 2022 1:30:00 AM; 14 / 11 / 2022 12:10:00 PM; null; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.G10.D2_1056; Trang; SY_ST1_G10; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 12:30:00 PM; null; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.K09.D2_1055; Vang; SY_ST1_K09; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 11:10:00 AM; null; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.H09.D2_1053; Den; SY_ST1_H09; 14 / 11 / 2022 8:15:00 AM; 14 / 11 / 2022 11:30:00 AM; null; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.G09.D2_1052; Tim; SY_ST1_G09; 14 / 11 / 2022 3:10:00 AM; 14 / 11 / 2022 11:10:00 AM; null; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.K08.D2_1051; Nau; SY_ST1_K08; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 11:10:00 AM; null; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("5_D3.st1.I08.D2_1050; Trang; SY_ST1_I08; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; null; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.H08.D2_1049; Trang; SY_ST1_H08; 14 / 11 / 2022 2:10:00 PM; 14 / 11 / 2022 8:10:00 PM; 90; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.G08.D2_1048; Nau do;SY_ST1_G08; 14 / 11 / 2022 3:40:00 AM; 14 / 11 / 2022 11:10:00 AM; 15; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.K07.D2_1047; Den; SY_ST1_K07; 14 / 11 / 2022 8:10:00 AM; 14 / 11 / 2022 11:30:00 AM; 95; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.I07.D2_1046; Do; SY_ST1_I07; 14 / 11 / 2022 4:10:00 PM; 14 / 11 / 2022 9:15:00 PM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.H07.D2_1045; Hong; SY_ST1_H07; 14 / 11 / 2022 9:10:00 PM; 14 / 11 / 2022 11:10:00 PM; 35; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.G07.D2_1044; Trang; SY_ST1_G07; 14 / 11 / 2022 8:10:00 AM; 14 / 11 / 2022 10:10:00 PM; 15; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.K06.D2_1043; Nau; SY_ST1_K06; 14 / 11 / 2022 10:00:00 AM; 14 / 11 / 2022 11:30:00 PM; 90; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.I06.D2_1042; Vang; SY_ST1_I06; 14 / 11 / 2022 4:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 28; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.H06.D2_1041; Xam; SY_ST1_H06; 14 / 11 / 2022 10:30:00 AM; 14 / 11 / 2022 12:10:00 PM; 18; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.G06.D2_1040; Trang; SY_ST1_G06; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 35; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.I05.D2_1038; Nau; SY_ST1_I05; 14 / 11 / 2022 8:10:00 AM; 14 / 11 / 2022 11:10:00 AM; 45; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.H05.D2_1037; Den; SY_ST1_H05; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 51; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.G05.D2_1036; Xanh bien; SY_ST1_G05; 14 / 11 / 2022 10:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 11; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.I04.D2_1034; Trang; SY_ST1_I04; 14 / 11 / 2022 5:10:00 AM; 14 / 11 / 2022 8:10:00 PM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.H04.D2_1033; Vang; SY_ST1_H04; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 10:10:00 AM; 15; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.G04.D2_1032; Hong; SY_ST1_G04; 14 / 11 / 2022 6:00:00 AM; 14 / 11 / 2022 12:10:00 PM; 50; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.K03.D2_1031; Xam; SY_ST1_K03; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 75; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("4_D3.st1.I03.D2_1030; Den; SY_ST1_I03; 14 / 11 / 2022 8:30:00 AM; 14 / 11 / 2022 9:10:00 PM; 80; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.H03.D2_1029; Tim; SY_ST1_H03; 14 / 11 / 2022 3:10:00 PM; 14 / 11 / 2022 9:00:00 PM; 91; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.G03.D2_1028; Trang; SY_ST1_G03; 14 / 11 / 2022 3:10:00 PM; 14 / 11 / 2022 11:10:00 PM; 20; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.K02.D2_1027; Vang; SY_ST1_K02; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.I02.D2_1026; Trang; SY_ST1_I02; 14 / 11 / 2022 1:10:00 PM; 14 / 11 / 2022 2:10:00 PM; 30; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.H02.D2_1025; Tim; SY_ST1_H02; 14 / 11 / 2022 5:10:00 AM; 14 / 11 / 2022 11:10:00 PM; 50; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.G02.D2_1024; Tim; SY_ST1_G02; 14 / 11 / 2022 8:10:00 AM; 14 / 11 / 2022 11:10:00 AM; 35; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.K01.D2_1023; Hong; SY_ST1_K01; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 3:10:00 PM; 25; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.I01.D2_1022; Bach kim; SY_ST1_I01; 14 / 11 / 2022 9:10:00 AM; 14 / 11 / 2022 12:10:00 PM; 10; null; 1");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
            veh = Vehicle.String_to_Vehicle("3_D3.st1.H01.D2_1021; Trang; SY_ST1_H01; 14 / 11 / 2022 7:10:00 AM; 14 / 11 / 2022 10:10:00 AM; 30; null; 2");
            SystemPark.List_Vehicle_Off_Main.Add(veh);
        }
    }
}
