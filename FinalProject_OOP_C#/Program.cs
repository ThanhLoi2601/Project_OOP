using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FinalProject_OOP
{
    internal class Program
    {
        //... Quyen truy cap
        enum Choice_Person
        {
            User=1,
            Guard=2,
            Manager=3,
            Engineer=4,
            OUT=10
        }
        enum Choice_User
        {
            // User
            TraCuuDuongDi=5,
            TraCuuViTriXe=6,
            TraCuuPhuongTienXeDien=7,
            TraCuuTienGuiXe=8,
        }
        enum Choice_Guard
        {
            // Guard
            TraCuuDanhSachPhuongTienHienTai = 9,
            TraCuuDanhSachPhuongTienQuaKhu = 11,
            TraCuuThongTinBanThan = 12,
            ChoXeRaKhoi = 13,// Xoa vehicle khoi danh sach hien tai va chuyen vao danh sach qua khu
                             // Tim 1 vehicle trong list vehicle on 
                             // Sau do xoa vehicle do trong list on
                             // Them vao list off
                             // write lai 2 file txt
            TraCuuKhuVucTuanTra = 19,
            TraCuuThoiGianTuanTra=20
        }
        enum Choice_Manage
        {
            // management
            TraCuuDanhSachCacGuard = 14,// Details
            // Tra cuu thong tin Manager
            TraCuuThongTinQuanLy=18,
                // Tra cuu thong tin cua cac cua
            TraCuuDiaChiCacCua=21,
            // Tra cuu toan bo thong tin cua 1 Door nao do
            TraCuuDanhSachCacCua=22
        }
        enum Choice_Engineer
        {
            // Engineer
            TraCuuDanhSachCacThietBiCanSuaChua=15,//
            TraCuuDanhSachCacThietBiDungHD=16,
            TraCuuToanBoDanhSachThietBiHeThong=17
        }
        private static void Main(string[] args) 
        {

            // Read Data
            SystemPark.ReadData();
            //Demo Data (Debug)
            
            //SystemPark.DemoData();
            
            Console.WriteLine("___Truy Cap Quyen truy cap!!!___");
            Console.WriteLine("[1]:User   [2]:Guard    [3]:Manager    [4]:Engineer   [10]:Exit");
            Console.Write("Choice:"); int ch1=Convert.ToInt32(Console.ReadLine());
            do
            {
                switch (ch1)
                {
                    case (int)Choice_Person.User:
                        Console.WriteLine("[5]: Tra cuu duong di     [6]: Tra cuu vi tri       [7]:Tra Cuu Phuong Tien Xe Dien   [8]:Tra cuu tien gui xe ");
                        Console.Write("Choice:"); int ch2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Demo 1 electric vehicle:1_D1.D5.st2.Y05.D4_1008;Trang;SY_ST2_Y05;14/11/2022 2:10:00 PM;null;10;1291929;1");
                        Console.WriteLine("Demo 2 car:2_D1.D5.st2.T01.D4_1019;Vang chuoi;SY_ST2_T01;14/11/2022 1:10:00 PM;null;85;null;2");
                        Vehicle veh1 = new Vehicle_Electric("1_D1.D5.st2.Y05.D4_1008", "Trang", "SY_ST2_Y05" ,DateTime.Parse("14/11/2022 2:10:00 PM"), 10, 1291929);
                        Vehicle veh2 = new Vehicle_Car("2_D1.D5.st2.T01.D4_1019", "Vang chuoi", "SY_ST2_T01", DateTime.Parse("14/11/2022 1:10:00 PM"),85);
                        switch (ch2)
                        {
                            case (int)Choice_User.TraCuuDuongDi:
                                Finding_Vehicle Find = veh1;
                                Console.WriteLine("Way of car:" + Find.path_Vehicle());
                                Find=veh2;
                                Console.WriteLine("Way of electric vehicle:" + Find.path_Vehicle());
                                break;
                            case (int)Choice_User.TraCuuViTriXe:
                                Finding_Vehicle Find1 = veh1;
                                Console.WriteLine("Demo 1:");
                                Console.WriteLine(Find1.Locate_Vehicle());
                                break;
                            case (int)Choice_User.TraCuuPhuongTienXeDien:
                                Console.WriteLine("Demo Electric station: ES_6_St1_Sy_ & 4; ElectricStation; SonyWHIOO78; SY_ST2_Z45; W; 27 / 5 / 2019 7:06 AM; 29 / 5 / 2024 11:55 PM; 1805");
                                Device dev= new Device_ElectricalStation("ES_6_St1_Sy_ & 4", "ElectricStation", "SonyWHIOO78", "SY_ST2_Z45","work",DateTime.Parse("27/5/2019 7:06 AM"),DateTime.Parse("29/5/2024 11:55 PM"),1805);
                                Vehicle_Electric veh3= new Vehicle_Electric("1_D1.D5.st2.Y05.D4_1008", "Trang", "SY_ST2_Y05", DateTime.Parse("14/11/2022 2:10:00 PM"), 10, 1291929);
                                Electricity_Vehicle elec = veh3;
                                veh3.Veh_Input_Other_services();
                                elec.Veh_Calculate_Time_Charge(dev.Device_PowerCapacity);
                                elec.Information();
                                break;
                            case (int)Choice_User.TraCuuTienGuiXe:
                                Console.WriteLine("Demo 2:");
                                veh2.Veh_Input_Other_services();
                                Finding_Vehicle find3 = veh2;
                                Console.WriteLine("Tien gui xe:" + find3.Veh_Calculate_Money_Parking());
                                Console.WriteLine("Tien dich vu:"+ find3.Veh_Calculate_Money_Other_services());
                                Console.WriteLine("Tong:" + find3.Veh_Calculate_Money_Sum());
                                break;
                        }
                        break;
                    case (int)Choice_Person.Guard:
                        Console.WriteLine("[9]:Tra Cuu Danh Sach Phuong Tien Hien Tai  [11]:Tra Cuu Danh Sach Phuong Tien History    [12]: Tra cuu thong tin ban than  [13]:Cho xe ra khoi ");
                        Console.WriteLine("[19]:Tra cuu khu vuc tuan tra    [20]:Tra cuu thoi gian tuan tra");
                        Console.Write("Choice: ");int ch3=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Demo guard: SY_ST2_Gua_PQYZ_3_1011;  Vo Tuan Van    ;3;30000;0:1:0:0; 7 VVN,Thu Duc,TPHCM   ;0858238281 ");
                        Guard mans = new Guard("SY_ST2_Gua_PQYZ_3_1011", "  Vo Tuan Van    ", int.Parse("3"), long.Parse("30000"), TimeSpan.Parse("0:1:0:0"), " 7 VVN,Thu Duc,TPHCM   ", "0858238281");
                        Guard_Data_Cal dt = new Guard();
                        switch (ch3)
                        {
                            case(int)Choice_Guard.TraCuuDanhSachPhuongTienHienTai:
                                dt.Gua_List_Veh_ON();
                                break;
                            case (int)Choice_Guard.TraCuuDanhSachPhuongTienQuaKhu:
                                dt.Gua_List_Veh_OFF();
                                break;
                            case (int)Choice_Guard.TraCuuThongTinBanThan:
                                dt.Gua_Output_Person(mans);
                                break;
                            case (int)Choice_Guard.ChoXeRaKhoi:
                                Console.WriteLine("Demo 2 car:2_D1.D5.st2.T01.D4_1019;Vang chuoi;SY_ST2_T01;14/11/2022 1:10:00 PM;null;85;null;2");
                                // Tim 1 vehicle trong list vehicle on
                                Guard_Vehicle_OUT gua = new Guard();
                                Vehicle veh = gua.Find_Delete_Vehicle("2_D1.D5.st2.T02.D4_1019");
                                dt.Gua_List_Veh_ON();
                                // Them vao list off
                                DateTime t= DateTime.Now;
                                veh.Veh_Input_OutTime(t.ToString());
                                SystemPark.Add_Vehicle(veh);
                                dt.Gua_List_Veh_OFF();
                                // write lai 2 file txt
                                System.IO.File.Delete(@"System_List_Vehicle_On.txt");
                                Vehicle_List.GhiFile(SystemPark.List_Vehicle_On_Main, @"System_List_Vehicle_On.txt");
                                System.IO.File.Delete(@"System_List_Vehicle_Off.txt");
                                Vehicle_List.GhiFile(SystemPark.List_Vehicle_Off_Main, @"System_List_Vehicle_Off.txt");

                                break;
                            case (int)Choice_Guard.TraCuuKhuVucTuanTra:
                                dt = mans;
                                Console.WriteLine(dt.Gua_Patrol_area());
                                break;
                            case (int)Choice_Guard.TraCuuThoiGianTuanTra:
                                dt = mans;
                                Console.WriteLine(dt.Gua_Patrol_time());    
                                break;
                        }    
                        break;
                    case (int)Choice_Person.Manager:
                        Console.WriteLine("[14]: Tra Cuu Danh Sach Cac bao ve    [18]: Tra cuu thong tin quan ly [21]:Tra cuu dia chi cua 1 door [22]: Tra cuu toan bo thong tin cua 1 Door");
                        Console.Write("Choice: ");int ch4=Convert.ToInt32(Console.ReadLine());
                        Guard_Management_Interface Inter= new Guard_List();
                        ListDoor_Interface Door_Search1 = new Door_Main();
                        ListDoor_Interface Door_Search2 = new Door_Middle();
                        switch(ch4)
                        {
                            case (int)Choice_Manage.TraCuuDanhSachCacGuard:
                                Inter.OuputListWorker();
                                break;
                            case (int)Choice_Manage.TraCuuThongTinQuanLy:
                                Inter.OuputInformation();  
                                break;
                            case (int)Choice_Manage.TraCuuDiaChiCacCua:
                                Console.WriteLine("Demo main Door 3:"); Console.WriteLine("Address of Door 3:"+Door_Search1.DoorList_FindingDoor_address("Door 3"));
                                Console.WriteLine("Demo middile Door 5: "); Console.WriteLine("Address of door 5:"+Door_Search2.DoorList_FindingDoor_address("door5"));
                                break;
                            case (int)Choice_Manage.TraCuuDanhSachCacCua:
                                Console.WriteLine("Demo Information of Door 5:");
                                Console.WriteLine(" ID of Door        |  ID of Stall | Situation of Door |");
                                Door_Search1.OuputListDoor(Door_List.Door_5.Door_ID);
                                break;
                        }    
                        break;
                    case (int)Choice_Person.Engineer:
                        Console.WriteLine("[15]:Tra Cuu Danh Sach Cac Thiet Bi Can Sua Chua    [16]:Tra cuu cac thiet bi dung hoat dong      [17]: Tra cuu toan bo cac thiet bi trong he thong");
                        Console.Write("Choice: "); int ch5 = Convert.ToInt32(Console.ReadLine());
                        switch (ch5)
                        {
                            case (int)Choice_Engineer.TraCuuDanhSachCacThietBiCanSuaChua:
                                InfixingDevice1Months Infix=new Device_List();
                                List<Device> lis = Infix.List_Device_1Month();
                                if(lis.Count == 0)
                                {
                                    Console.WriteLine("System will normally work next month");
                                }
                                else
                                {
                                    Console.WriteLine("___List of need infixing devices___");
                                    Device_List.OuputList(lis);
                                }
                                break;
                            case (int)Choice_Engineer.TraCuuDanhSachCacThietBiDungHD:
                                ImportingStopDevice Imp = new Device_List();
                                List<Device> lis1 = Imp.List_Device_Stop();
                                if(lis1.Count == 0)
                                {
                                    Console.WriteLine("System is normally working!!! ");
                                }
                                else
                                {
                                    Console.WriteLine("___List of stopping working devices");
                                    Device_List.OuputList(lis1);
                                }
                                break;
                            case (int)Choice_Engineer.TraCuuToanBoDanhSachThietBiHeThong:
                                Console.WriteLine("___List of all devices in System parking___");
                                SystemPark.Ouput_1_SystemPark();
                                Device_List.OuputList(SystemPark.List_Devices_Main);
                                break;
                        }    
                        break;
                    default:
                        Console.WriteLine("____Change___");
                        break;
                }
                Console.WriteLine("[1]:User   [2]:Guard    [3]:Manager    [4]:Engineer   [10]:Exit");
                Console.Write("Choice (person):"); ch1 = Convert.ToInt32(Console.ReadLine());
            } while (ch1 != 10);// nếu ch1==10 tự động exit chương trình
            
            
        }
    }
}
