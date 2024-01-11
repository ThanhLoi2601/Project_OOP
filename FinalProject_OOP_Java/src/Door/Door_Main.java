package Door;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.LinkedList;
import java.util.List;

import Device.Device;
import Device.Device_List;

public class Door_Main extends Door
{
	public Door_Main(String door_ID, String door_IDStall, String door_Status,List<Device> list_Dev_Eletric_Gate) 
    {
		super(door_ID, door_IDStall, door_Status);
        this.setM_ElectricGateList(list_Dev_Eletric_Gate);
    }

	public Door_Main()
    {
		super();
        this.m_ElectricGateList = new LinkedList<Device>();
    }
	
	@Override
	public void Docfile(String path1, String path2) throws FileNotFoundException {
		// TODO Auto-generated method stub
         File file= new File(path1);
         try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
			try
			 {
			     String line = reader.readLine();
			     while (line != null)
			     {
			         String[] arr1 = line.split(";");

			         if (arr1.length == 3)
			         {
			        	 this.sDoor_ID = arr1[0];
	                     this.sDoor_IDStall = arr1[1];
	                     if (arr1[2].compareTo("w")==0  || arr1[2].compareTo("W")==0)
	                        {
	                            this.sDoor_Status = "work";
	                        }
	                        else this.sDoor_Status = "stop";
			         }
			         else throw new Exception("EROLL");
			         line = reader.readLine();
			     }
			     reader.close();
			     this.m_ElectricGateList = Device_List.Readfile(path2);// danh sách các eletric gate
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

	@Override
	public void Ouput1() {
		// TODO Auto-generated method stub
		super.Ouput();
		System.out.println("Device of Door: ");
        Device_List.Ouput(this.m_ElectricGateList);
	}

}
