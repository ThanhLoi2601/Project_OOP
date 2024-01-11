package Door;

import java.io.FileNotFoundException;
import java.util.List;

import Device.Device;
import System.ListDoor_Interface;
import System.SystemPark;

public abstract class Door implements ListDoor_Interface
{
	protected String sDoor_ID;
    protected String sDoor_IDStall;
    protected String sDoor_Status;
    protected List<Device> m_ElectricGateList;
    protected List<Device> m_ElevatorList;
    
    public String getsDoor_ID() {
		return sDoor_ID;
	}
	public void setsDoor_ID(String sDoor_ID) {
		this.sDoor_ID = sDoor_ID;
	}
	public String getsDoor_IDStall() {
		return sDoor_IDStall;
	}
	public void setsDoor_IDStall(String sDoor_IDStall) {
		this.sDoor_IDStall = sDoor_IDStall;
	}
	public String getsDoor_Status() {
		return sDoor_Status;
	}
	public void setsDoor_Status(String sDoor_Status) {
		this.sDoor_Status = sDoor_Status;
	}
	public List<Device> getM_ElectricGateList() {
		return m_ElectricGateList;
	}
	public void setM_ElectricGateList(List<Device> m_ElectricGateList) {
		this.m_ElectricGateList = m_ElectricGateList;
	}
	public List<Device> getM_ElevatorList() {
		return m_ElevatorList;
	}
	public void setM_ElevatorList(List<Device> m_ElevatorList) {
		this.m_ElevatorList = m_ElevatorList;
	}
	protected Door()
    {
        this.setsDoor_ID("");
        this.setsDoor_IDStall("");
        this.setsDoor_Status("work");
    }
	protected Door( String door_ID, String door_IDStall, String door_Status)
    {
		this.setsDoor_ID(door_ID);
		this.setsDoor_IDStall(door_IDStall);
		this.setsDoor_Status(door_Status);
    }
	
	public void Input(String door_ID, String door_IDStall, String door_Status)
    {
		this.setsDoor_ID(door_ID);
        this.setsDoor_IDStall(door_IDStall);
        this.setsDoor_Status(door_Status);
    }
	
	public void Ouput()
    {
        System.out.println(this.sDoor_ID + "   |  " + this.sDoor_IDStall + "  |        " + this.getsDoor_Status()+"       |");
    }
	public abstract void Docfile(String path1,String path2) throws FileNotFoundException;
	public abstract void Ouput1();
	public String DoorList_FindingDoor_address(String name)
    {
        name=name.toLowerCase();
        if (name == "door 1" || name == "door1") return Door_List.Door_1.getsDoor_ID();
        else if (name.compareTo("door 2")==0  || name.compareTo("door2")==0) return Door_List.Door_2.getsDoor_ID();
        else if (name.compareTo("door 3")==0 || name.compareTo("door3")==0) return Door_List.Door_3.getsDoor_ID();
        else if (name.compareTo("door 4")==0 || name.compareTo("door4")==0) return Door_List.Door_4.getsDoor_ID();
		else if (name.compareTo("door 5")==0 || name.compareTo("door5")==0) return Door_List.Door_5.getsDoor_ID();
        else return "ERROR";
    }
	
	 public void OuputListDoor(String ID)
     {
		 List<Door> ls= SystemPark.List_Doors;
		 for (int i=0; i<ls.size(); i++)
         {
             if (ls.get(i).getsDoor_ID().compareTo(ID)==0)
             {
            	 ls.get(i).Ouput1();
            	 return;
             }
         }
         System.out.println("No information!!!");
     }
}

