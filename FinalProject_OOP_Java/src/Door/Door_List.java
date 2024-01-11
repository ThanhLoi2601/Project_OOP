package Door;

import java.io.FileNotFoundException;
import java.util.List;

import System.SystemPark;

public class Door_List {

	public static Door_Middle Door_5 = new Door_Middle();
    public static Door_Main Door_1 = new Door_Main();
    public static Door_Main Door_2 = new Door_Main();
    public static Door_Main Door_3 = new Door_Main();
    public static Door_Main Door_4 = new Door_Main();
    
    public static void Readfile() throws FileNotFoundException
    {
        // Docfile
    	Door_5.Docfile("Door_5.txt", "Door_5_Elevator.txt");
    	Door_1.Docfile("Door_1.txt", "Door_1_ElectricGate.txt");
    	Door_2.Docfile("Door_2.txt", "Door_2_ElectricGate.txt");
    	Door_3.Docfile("Door_3.txt", "Door_3_ElectricGate.txt");
    	Door_4.Docfile("Door_4.txt", "Door_4_ElectricGate.txt");
        // Add for System
        SystemPark.List_Doors.add(Door_1);
        SystemPark.List_Doors.add(Door_2);
        SystemPark.List_Doors.add(Door_3);
        SystemPark.List_Doors.add(Door_4);
        SystemPark.List_Doors.add(Door_5);
;   }
    public static void Ouput(List<Door> list)
    {
        System.out.println(" ID of Door  |       ID of Stall     |       Situation of Door       |");
        for(int i=0; i<list.size();i++)
        {
            System.out.println(list.get(i).sDoor_ID+"     |       "+list.get(i).sDoor_IDStall+"      |       "+list.get(i).sDoor_Status);
            // Ouput list of Electric gate
            System.out.println("List of devices of Door");
            // Ouput List of elevators
        }
    }
    
    public static void Ouput_1(List<Door> list)
    {
        System.out.println("   ID of Door      |  ID of Stall | Situation of Door |");
        for (Door door : list)
        {
            door.Ouput();
        }
    }
}
