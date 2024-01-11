package Program;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Scanner;

import Device.Device;
import Device.Device_ElectricStation;
import Device.Device_Engineer_Interface;
import Device.Device_List;
import Door.Door_List;
import Door.Door_Main;
import Door.Door_Middle;
import Guard.Guard;
import Guard.Guard_Data_Cal;
import Guard.Guard_List;
import Guard.Guard_Management_Interface;
import Guard.Guard_Vehicle_OUT;
import System.ListDoor_Interface;
import System.SystemPark;
import Time.TimeSpan;
import Vehicle.Electricity_Vehicle;
import Vehicle.Finding_Vehicle;
import Vehicle.Vehicle;
import Vehicle.Vehicle_Car;
import Vehicle.Vehicle_Electric;
import Vehicle.Vehicle_List;

public class Program {

	enum Choice_Person
    {
        User(1),
        Guard(2),
        Manager(3),
        Engineer(4),
        OUT(10);
		
		private int value;
		private Choice_Person(int value)
		{
			this.setValue(value);
		}
		public int getValue() {
			return value;
		}
		public void setValue(int value) {
			this.value = value;
		}
		
		public static Choice_Person getChoice_PersonByValue(int value) {
            for (Choice_Person d : Choice_Person.values()) {
                if (d.value == value) {
                    return d;
                }
            }
            return null;
        }
    }
	
	enum Choice_User
    {
        // User
        TraCuuDuongDi(5),
        TraCuuViTriXe(6),
        TraCuuPhuongTienXeDien(7),
        TraCuuTienGuiXe(8);
		
		private int value;
		private Choice_User(int value)
		{
			this.setValue(value);
		}
		public int getValue() {
			return value;
		}
		public void setValue(int value) {
			this.value = value;
		}
		public static Choice_User getChoice_UserByValue(int value) {
            for (Choice_User d : Choice_User.values()) {
                if (d.value == value) {
                    return d;
                }
            }
            return null;
        }
    }
	
    enum Choice_Guard
    {
        // Guard
        TraCuuDanhSachPhuongTienHienTai(9),
        TraCuuDanhSachPhuongTienQuaKhu(11),
        TraCuuThongTinBanThan(12),
        ChoXeRaKhoi(13),// Xoa vehicle khoi danh sach hien tai va chuyen vao danh sach qua khu
                         // Tim 1 vehicle trong list vehicle on 
                         // Sau do xoa vehicle do trong list on
                         // Them vao list off
                         // write lai 2 file txt
        TraCuuKhuVucTuanTra(19),
        TraCuuThoiGianTuanTra(20);
    	
    	private int value;
		private Choice_Guard(int value)
		{
			this.setValue(value);
		}
		public int getValue() {
			return value;
		}
		public void setValue(int value) {
			this.value = value;
		}
		
		public static Choice_Guard getChoice_GuardByValue(int value) {
            for (Choice_Guard d : Choice_Guard.values()) {
                if (d.value == value) {
                    return d;
                }
            }
            return null;
        }
    }
    enum Choice_Manage
    {
        // management
        TraCuuDanhSachCacGuard(14),// Details
        // Tra cuu thong tin Manager
        TraCuuThongTinQuanLy(18),
        //Tra cứu địa chỉ  các cửa
        TraCuuDiaChiCacCua(21),
    	//tra cuu danh sach cac cua
    	TraCuuThongTinCacCua(22);
        
        private int  value;
		private Choice_Manage(int value)
		{
			this.setValue(value);
		}
		public int getValue() {
			return value;
		}
		public void setValue(int value) {
			this.value = value;
		}
		public static Choice_Manage getChoice_ManageByValue(int value) {
            for (Choice_Manage d : Choice_Manage.values()) {
                if (d.value == value) {
                    return d;
                }
            }
            return null;
        }
    }
    enum Choice_Engineer
    {
        // Engineer
        TraCuuDanhSachCacThietBiCanSuaChua(15),//
        TraCuuDanhSachCacThietBiDungHD(16),
        TraCuuToanBoDanhSachThietBiHeThong(17);
    	private int value;
		private Choice_Engineer(int value)
		{
			this.setValue(value);
		}
		public int getValue() {
			return value;
		}
		public void setValue(int value) {
			this.value = value;
		}
		
		public static Choice_Engineer getChoice_EngineerByValue(int value) {
            for (Choice_Engineer d : Choice_Engineer.values()) {
                if (d.value == value) {
                    return d;
                }
            }
            return null;
        }
    }
	
	@SuppressWarnings("unused")
	public static void main(String[] args) throws IOException, ParseException {
		// TODO Auto-generated method stub
		 SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy hh:mm:ss");
		 SystemPark.ReadData();

		 
		 @SuppressWarnings("resource")
		 Scanner sc = new Scanner(System.in);
         System.out.println("___Truy Cap Quyen truy cap!!!___");
         System.out.println("[1]:User   [2]:Guard    [3]:Manager    [4]:Engineer   [10]:Exit");
         System.out.print("Choice:"); int ch1=sc.nextInt();
         do
         {
             switch (Choice_Person.getChoice_PersonByValue(ch1))
             {
                 case User:
                     System.out.println("[5]: Tra cuu duong di     [6]: Tra cuu vi tri       [7]:Tra Cuu Phuong Tien Xe Dien   [8]:Tra cuu tien gui xe ");
                     System.out.print("Choice:"); int ch2 = sc.nextInt();;
                     System.out.println("Demo 1 electric vehicle:1_D1-D5-st2-Y05.D4_1008;Trang;SY_ST2_Y05;14/11/2022 2:10:00 PM;null;10;1291929;1");
                     System.out.println("Demo 2 car:2_D1-D5-st2-T01-D4_1019;Vang chuoi;SY_ST2_T01;14/11/2022 1:10:00 PM;null;85;null;2");
                     Vehicle veh1 = new Vehicle_Electric("1_D1-D5-st2-Y05-D4_1008", "Trang", "SY_ST2_Y05" ,formatter.parse("14/11/2022 14:10:00"), 10, 1291929);
                     Vehicle veh2 = new Vehicle_Car("2_D1-D5-st2-T01-D4_1019", "Vang chuoi", "SY_ST2_T01", formatter.parse("14/11/2022 13:10:00"),85);
                     switch (Choice_User.getChoice_UserByValue(ch2))
                     {
                         case TraCuuDuongDi:
                             Finding_Vehicle Find = veh1;
                             System.out.println("Way of car:" + Find.path_Vehicle());
                             Find=veh2;
                             System.out.println("Way of electric vehicle:" + Find.path_Vehicle());
                             break;
                         case TraCuuViTriXe:
                        	 System.out.println("Demo 1:");
                             Finding_Vehicle Find1 = veh1;
                             System.out.println(Find1.Locate_Vehicle());
                             break;
                         case TraCuuPhuongTienXeDien:
                             System.out.println("Demo 1 Electric station: ES_6_St1_Sy_ & 4; ElectricStation; SonyWHIOO78; SY_ST2_Z45; W; 27 / 5 / 2019 7:06:00; 29 / 5 / 2024 23:55:00; 1805");
                         	 Device_ElectricStation dev= new Device_ElectricStation("ES_6_St1_Sy_ & 4", "ElectricStation", "SonyWHIOO78", "SY_ST2_Z45","work",formatter.parse("27/5/2019 7:06:00"),formatter.parse("29/5/2024 23:55:00"),1805);
                             Vehicle_Electric veh3= new Vehicle_Electric("1_D1-D5-st2-Y05-D4_1008", "Trang", "SY_ST2_Y05", formatter.parse("14/11/2022 14:10:00"), 10, 1291929);
                             Electricity_Vehicle elec = veh3;
                             veh3.Veh_Input_Other_services();
                             elec.Veh_Calculate_Time_Charge(dev.getdDevice_PowerCapacity());
                             elec.Information();
                             break;
                         case TraCuuTienGuiXe:
                             System.out.println("Demo 2:");
                             veh2.Veh_Input_Other_services();
                             Finding_Vehicle find3 = veh2;
                             System.out.println("Tien gui xe:" + find3.Veh_Calculate_Money_Parking());
                             System.out.println("Tien dich vu:"+ find3.Veh_Calculate_Money_Other_services());
                             System.out.println("Tong:" + find3.Veh_Calculate_Money_Sum());
                             break;
                     }
                     break;
                 case Guard:
                     System.out.println("[9]:Tra Cuu Danh Sach Phuong Tien Hien Tai  [11]:Tra Cuu Danh Sach Phuong Tien History    [12]: Tra cuu thong tin ban than  [13]:Cho xe ra khoi ");
                     System.out.println("[19]:Tra cuu khu vuc tuan tra    [20]:Tra cuu thoi gian tuan tra");
                     System.out.print("Choice: ");int ch3=sc.nextInt();;
                     System.out.println("Demo guard: SY_ST2_Gua_PQYZ_3_1011;  Vo Tuan Van    ;3;30000;0:1:0:0; 7 VVN,Thu Duc,TPHCM   ;0858238281 ");
                     Guard mans = new Guard("SY_ST2_Gua_PQYZ_3_1011", "  Vo Tuan Van    ", Integer.parseInt("3"), Long.parseLong("30000"), TimeSpan.Parse("0:1:0:0"), " 7 VVN,Thu Duc,TPHCM   ", "0858238281 ");
                     Guard_Data_Cal dt = new Guard();
                     switch (Choice_Guard.getChoice_GuardByValue(ch3))
                     {
                         case TraCuuDanhSachPhuongTienHienTai:
                             dt.Gua_List_Veh_ON();
                             break;
                         case TraCuuDanhSachPhuongTienQuaKhu:
                             dt.Gua_List_Veh_OFF();
                             break;
                         case TraCuuThongTinBanThan:
                             dt.Gua_Output_Person(mans);
                             break;
                         case ChoXeRaKhoi:
                             System.out.println("Demo 2 car:2_D1-D5-st2-T01-D4_1019;Vang chuoi;SY_ST2_T01;14/11/2022 13:10:00;null;85;null;2");
                             // Tim va xoa vehicle do trong list on
                             Guard_Vehicle_OUT gua= new Guard();
                             Vehicle veh=gua.Find_Delete_Vehicle("2_D1-D5-st2-T01-D4_1019");
                             dt.Gua_List_Veh_ON();
                             //Xóa và Ghi lại vào file System_List_Vehicle_On
                             Vehicle_List.GhiFile(SystemPark.List_Vehicle_On_Main,"System_List_Vehicle_On.txt");
                             // Them vao list off
                             Date t= new Date();
                             veh.Veh_Input_OutTime(formatter.format(t));
                             SystemPark.Add_Vehicle(veh);
                             dt.Gua_List_Veh_OFF();
                             //Thêm phương tiện vừa xóa trên vào cuối file System_List_Vehicle_Off
                             Vehicle_List.GhiFile_finalize(veh, "System_List_Vehicle_Off.txt");

                             break;
                         case TraCuuKhuVucTuanTra:
                             dt = mans;
                             System.out.println(dt.Gua_Patrol_area());
                             break;
                         case TraCuuThoiGianTuanTra:
                             dt = mans;
                             System.out.println(dt.Gua_Patrol_time());    
                             break;
                     }    
                     break;
                 case Manager:
                     System.out.println("[14]: Tra Cuu Danh Sach Cac bao ve    [18]: Tra cuu thong tin quan ly    [21]: Tra cuu dia chi cua 1 door  [22]: Tra cuu toan bo thong tin cua 1 Door");
                     System.out.print("Choice: ");int ch4=sc.nextInt();;
                     Guard_Management_Interface Inter= new Guard_List();
                     ListDoor_Interface Door_Search1= new Door_Main();
                     ListDoor_Interface Door_Search2= new Door_Middle();
                     switch(Choice_Manage.getChoice_ManageByValue(ch4))
                     {
                         case TraCuuDanhSachCacGuard:
                             Inter.OuputListWorker();
                             break;
                         case TraCuuThongTinQuanLy:
                             Inter.OuputInformation();  
                             break;
                         case TraCuuDiaChiCacCua:
                        	 System.out.println("Demo main Door 3: ");  System.out.println("Address of Door 3: "+ Door_Search1.DoorList_FindingDoor_address("Door 3"));
                        	 System.out.println("Demo middile Door 5: ");  System.out.println("Address of Door 5: "+ Door_Search2.DoorList_FindingDoor_address("door5"));
                        	 break;
                         case TraCuuThongTinCacCua:
                        	 System.out.println("Demo Information of Door 5: ");
                        	 System.out.println(" ID of Door        |  ID of Stall | Situation of Door |");
                        	 Door_Search1.OuputListDoor(Door_List.Door_5.getsDoor_ID());
                        	 break;
                     }    
                     break;
                 case Engineer:
                     System.out.println("[15]:Tra Cuu Danh Sach Cac Thiet Bi Can Sua Chua    [16]:Tra cuu cac thiet bi dung hoat dong      [17]: Tra cuu toan bo cac thiet bi trong he thong");
                     System.out.print("Choice: "); int ch5 = sc.nextInt();;
                     switch (Choice_Engineer.getChoice_EngineerByValue(ch5))
                     {
                         case TraCuuDanhSachCacThietBiCanSuaChua:
                        	 Device_Engineer_Interface Infix=new Device_List();
                             List<Device> lis = Infix.List_Device_1Month();
                             if(lis.size() == 0)
                             {
                                 System.out.println("System will normally work next month");
                             }
                             else
                             {
                                 System.out.println("___List of need infixing devices___");
                                 Device_List.Ouput(lis);
                             }
                             break;
                         case TraCuuDanhSachCacThietBiDungHD:
                        	 Device_Engineer_Interface Imp = new Device_List();
                             List<Device> lis1 = Imp.List_Device_Stop();
                             if(lis1.size() == 0)
                             {
                                 System.out.println("System is normally working!!! ");
                             }
                             else
                             {
                                 System.out.println("___List of stopping working devices");
                                 Device_List.Ouput(lis1);
                             }
                             break;
                         case TraCuuToanBoDanhSachThietBiHeThong:
                             System.out.println("___List of all devices in System parking___");
                             SystemPark.Ouput_1_SystemPark();
                             Device_List.Ouput(SystemPark.List_Devices_Main);
                             break;
                     }    
                     break;
                 default:
                     System.out.println("____Change___");
                     break;
             }
             System.out.println("[1]:User   [2]:Guard    [3]:Manager    [4]:Engineer   [10]:Exit");
             System.out.print("Choice (person):"); ch1 = sc.nextInt();;
         } while (ch1 != 10);// nếu ch1==10 tự động exit chương trình
         
	}

}
