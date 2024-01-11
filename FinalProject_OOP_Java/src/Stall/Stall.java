package Stall;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.LinkedList;
import java.util.List;

import Device.Device;
import Device.Device_List;
import Door.Door;
import Door.Door_List;
import Guard.Guard;
import Guard.Guard_List;
import Vehicle.Vehicle;

public class Stall {
	 // fields
    private String Stall_sID;
    private String Stall_sName;
    private int Stall_iNumCar;
    private int Stall_iNumBike;
    private int Stall_iNumElec;
    private List<Door> Stall_lList_door;
    private List<Device> Stall_lList_device;
    private List<Guard> Stall_lList_guard;
    private List<Vehicle> Stall_lList_vehicle;
    // Properties
	public String getStall_sID() {
		return Stall_sID;
	}
	public void setStall_sID(String stall_sID) {
		Stall_sID = stall_sID;
	}
	public String getStall_sName() {
		return Stall_sName;
	}
	public void setStall_sName(String stall_sName) {
		Stall_sName = stall_sName;
	}
	public int getStall_iNumCar() {
		return Stall_iNumCar;
	}
	public void setStall_iNumCar(int stall_iNumCar) {
		Stall_iNumCar = stall_iNumCar;
	}
	public int getStall_iNumBike() {
		return Stall_iNumBike;
	}
	public void setStall_iNumBike(int stall_iNumBike) {
		Stall_iNumBike = stall_iNumBike;
	}
	public int getStall_iNumElec() {
		return Stall_iNumElec;
	}
	public void setStall_iNumElec(int stall_iNumElec) {
		Stall_iNumElec = stall_iNumElec;
	}
	public List<Door> getStall_lList_door() {
		return Stall_lList_door;
	}
	public void setStall_lList_door(List<Door> stall_lList_door) {
		Stall_lList_door = stall_lList_door;
	}
	public List<Device> getStall_lList_device() {
		return Stall_lList_device;
	}
	public void setStall_lList_device(List<Device> stall_lList_device) {
		Stall_lList_device = stall_lList_device;
	}
	public List<Guard> getStall_lList_guard() {
		return Stall_lList_guard;
	}
	public void setStall_lList_guard(List<Guard> stall_lList_guard) {
		Stall_lList_guard = stall_lList_guard;
	}
	public List<Vehicle> getStall_lList_vehicle() {
		return Stall_lList_vehicle;
	}
	public void setStall_lList_vehicle(List<Vehicle> stall_lList_vehicle) {
		Stall_lList_vehicle = stall_lList_vehicle;
	}
    
	public Stall()
    {
         this.Stall_lList_door = new LinkedList<Door>();
         this.Stall_lList_device = new LinkedList<Device>();
         this.Stall_lList_guard = new LinkedList<Guard>();
         this.Stall_lList_vehicle = new LinkedList<Vehicle>();
    }
	
	public Stall(String Stall_ID,String Stall_name, int Stall_NumCar,int Stall_Numbike,int Stall_Elec) 
    {
        this.Stall_sID = Stall_ID;
        this.Stall_sName = Stall_name;
        this.Stall_iNumCar = Stall_NumCar;
        this.Stall_iNumBike = Stall_Numbike;
        this.Stall_iNumElec = Stall_Elec;
    }
	// Methods
	public void Stall_Docfile(String path1) throws FileNotFoundException
	{
		  File file= new File(path1);
	         try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
				try
				 {
				     String line = reader.readLine();
				     while (line != null)
				     {
				         String[] arr1 = line.split(";");

				         if (arr1.length == 5)
				         {
				        	 this.Stall_sID = arr1[0];
			                 this.Stall_sName = arr1[1];
			                 this.Stall_iNumCar = Integer.parseInt(arr1[2]);
			                 this.Stall_iNumBike = Integer.parseInt(arr1[3]);
			                 this.Stall_iNumElec = Integer.parseInt(arr1[4]);
				         }
				         else throw new Exception("EROLL");
				         line = reader.readLine();
				     }
				     reader.close();
				 }
				 catch (Exception e)
				 {
				     System.out.print(e);
				 }
			} catch (FileNotFoundException e) {
				throw e;
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	}
	
	public void Stall_Ouput()
    { 
        System.out.println("ID of Stall:"+this.Stall_sID + ",Name of stall:" + this.Stall_sName + ",Maxium number of car:" + this.Stall_iNumCar + ",Maxium number of bike:" + this.Stall_iNumBike + ",Maxium of electric car:" + this.Stall_iNumElec);
        // Output list of device of Stall
        System.out.println("___List of Devices of"+this.Stall_sName+":___");
        Device_List.Ouput(this.Stall_lList_device);
        // Output List of Guard of Stall
        System.out.println("___List of Guards of" + this.Stall_sName + ":___");
        Guard_List.OuputList(this.Stall_lList_guard);
        // Ouput List of Door of Stall
        System.out.println("___List of Doors of" + this.Stall_sName + ":___");
        Door_List.Ouput_1(this.Stall_lList_door);

    }
    
}
