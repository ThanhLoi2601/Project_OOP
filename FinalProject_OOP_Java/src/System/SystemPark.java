package System;
import java.io.IOException;
import java.util.LinkedList;
import java.util.List;

import Device.Device;
import Device.Device_List;
import Door.Door;
import Door.Door_List;
import Guard.Guard;
import Guard.Guard_List;
import Stall.Stall;
import Vehicle.Vehicle;
import Vehicle.Vehicle_List;

public class SystemPark {
	private static String SystemPark_ID="Sy_15A NguyenHuuCanh Street.Chung Cu  Khu A VinHome RiverSide.TPHCM city";
    @SuppressWarnings("unused")
	private static String SystemPark_Name = "Sy_Chung Cu  Khu A VinHome RiverSide.TPHCM city";
    public static Stall Stall_1 = new Stall();
    public static Stall Stall_2 = new Stall();
    // Danh Sach cac thiet bi cua System
    public static List<Device> List_Devices_Main = new LinkedList<Device>(); 
    // Danh Sach hien tai cac phuong tien hien co
    public static List<Vehicle> List_Vehicle_On_Main = new LinkedList<Vehicle>();
    // Danh Sach lich sư luu tru cua he thong
    public static List<Vehicle> List_Vehicle_Off_Main = new LinkedList<Vehicle>();
    // Danh Sach Cac bao ve 
    public static List<Guard> List_Guard_Main = new LinkedList<Guard>();
    // Danh Sach Cac cua chinh
    public static List<Door> List_Doors = new LinkedList<Door>();
    // Quan Ly Systempark
    public static Guard Manager=new Guard();
    
    public static void ReadData() throws IOException
    {
        // Main System
        SystemPark.List_Devices_Main = Device_List.Readfile("System_List_Device.txt");// List System_Devices
        Door_List.Readfile();// List System_Door
        SystemPark.List_Guard_Main = Guard_List.Docfile("System_List_Guard.txt");
        SystemPark.List_Vehicle_On_Main = Vehicle_List.Docfile("System_List_Vehicle_On.txt");
        SystemPark.List_Vehicle_Off_Main = Vehicle_List.Docfile("System_List_Vehicle_Off.txt");
        // Manager:
        SystemPark.Manager = Guard_List.DocFile_("System_Manager.txt");
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
        SystemPark.Stall_1.Stall_Docfile("Stall1.txt");
        //... List_Guards Stall_1


        //... List_Door Stall_1
        SystemPark.Stall_1.getStall_lList_door().add(Door_List.Door_1);
        SystemPark.Stall_1.getStall_lList_door().add(Door_List.Door_2);
        SystemPark.Stall_1.getStall_lList_door().add(Door_List.Door_3);
        SystemPark.Stall_1.getStall_lList_door().add(Door_List.Door_4);


        // Stall_2
        //... Infor of Stall 2
        SystemPark.Stall_2.Stall_Docfile("Stall2.txt");


        //... List_Door Stall_1
        SystemPark.Stall_2.getStall_lList_door().add(Door_List.Door_5);

    }
 
    
    private static void Stall1_Stall2_List_Vehicle_add()
    {
        for(Vehicle veh : SystemPark.List_Vehicle_On_Main)
        {
            String[] arr = veh.getVeh_sLocate().split("_");
            if (arr[1] == "ST1") SystemPark.Stall_1.getStall_lList_vehicle().add(veh);
            else if (arr[1] == "ST2") SystemPark.Stall_2.getStall_lList_vehicle().add(veh);
        }

        for (Vehicle veh : SystemPark.List_Vehicle_Off_Main)
        {
            String[] arr = veh.getVeh_sLocate().split("_");
            if (arr[1] == "ST1") SystemPark.Stall_1.getStall_lList_vehicle().add(veh);
            else if (arr[1] == "ST2") SystemPark.Stall_2.getStall_lList_vehicle().add(veh);
        }
    }
    
    private static void Stall1_Stall2_list_Devices_add()
    {
        for(Device dev : SystemPark.List_Devices_Main)
        {
            String[] arr=dev.getsDevice_Locate().split("_");
            if (arr[1]=="ST1") SystemPark.Stall_1.getStall_lList_device().add(dev);
            else if (arr[1] == "ST2") SystemPark.Stall_2.getStall_lList_device().add(dev);
        }    
    }
    
    private static void Stall1_Stall2_Guards_add()
    {
        for(Guard gu : SystemPark.List_Guard_Main)
        {
            String[] arr=gu.getGua_sID().split("_");
            if (arr[1] == "ST1") SystemPark.Stall_1.getStall_lList_guard().add(gu);
            else if (arr[1] == "ST2") SystemPark.Stall_2.getStall_lList_guard().add(gu);
        }
    }
    
    public static void OuputSystemPark()
    {
        System.out.println("___Information for System parking____");
        System.out.println("Name:" + SystemPark.SystemPark_ID);
        String[]arr=SystemPark.SystemPark_ID.split("_");
        System.out.println("Address:" + arr[1]);
        System.out.println("____//Stall_1//____");
        SystemPark.Stall_1.Stall_Ouput();
        System.out.println("____//Stall_2//____");
        SystemPark.Stall_2.Stall_Ouput();
    }
    
    public static void Ouput_1_SystemPark()
    {
        System.out.println("___Information for System parking____");
        System.out.println("Name:" + SystemPark.SystemPark_ID);
        String[] arr = SystemPark.SystemPark_ID.split("_");
        System.out.println("Address:" + arr[1]);
    }
    
  //Thêm 1 vehicle trong List_Vehicle_Off_Main
    public static void Add_Vehicle(Vehicle veh)
    {
        SystemPark.List_Vehicle_Off_Main.add(veh);
        if (SystemPark.List_Vehicle_Off_Main.get(SystemPark.List_Vehicle_Off_Main.size()-1)==veh)
        	System.out.println("Successful addition List_Vehicle_Off!!");
        else
        	System.out.println("Addition failed!!");
    }
}
