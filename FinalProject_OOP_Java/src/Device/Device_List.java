package Device;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import System.SystemPark;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalDateTime;
public class Device_List implements Device_Engineer_Interface {
	public static List<Device> Readfile(String path)throws FileNotFoundException
	{
		List<Device> list=new ArrayList<Device>();
		File file=new File(path);
		try (BufferedReader br=new BufferedReader(new FileReader(file)))
		{
			try 
			{	
				String line=br.readLine();
				while(line!=null)
				{
					String[] arr=line.split(";");
					if(arr.length==8)
					{
						if(arr[1].trim().equals("Camera"))
						{
							Device camera=new Device_Camera();
							camera.sDevice_ID=arr[0];
							camera.sDevice_Name=arr[1];
							camera.sDevice_Type=arr[2];
							camera.sDevice_Locate=arr[3];
							if(arr[4].equals("w")||arr[4].equals("W"))
							{
								camera.sDevice_Status="work";
							}
							else {
								camera.sDevice_Status="stop";
							}
							camera.dtDevice_IN = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[5]);
	                        camera.dtDevice_OUT = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[6]);
	                        String[] arr_temp=arr[7].split("#");
	                        for(int i=0;i<arr_temp.length;i++)
	                        {
	                        	camera.Device_lpathVideo.add(arr_temp[i]);
	                        }
						}
						if(arr[1].trim().equals("Elevator"))
						{
							Device elevator=new Device_Elevator();
				   			elevator.sDevice_ID=arr[0];
							elevator.sDevice_Name=arr[1];
							elevator.sDevice_Type=arr[2];
							elevator.sDevice_Locate=arr[3];
							if(arr[4].equals("w")||arr[4].equals("W"))
							{
								elevator.sDevice_Status="work";
							}
							else {
								elevator.sDevice_Status="stop";
							}
							elevator.dtDevice_IN = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[5]);
							elevator.dtDevice_OUT = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[6]);
	                        elevator.sDevice_ID_mainComp=arr[7];
	                        list.add(elevator);
						}
						if(arr[1].trim().equals("ElectricStation"))
						{
							Device electra=new Device_ElectricStation();
							electra.sDevice_ID=arr[0];
							electra.sDevice_Name=arr[1];
							electra.sDevice_Type=arr[2];
							electra.sDevice_Locate=arr[3];
							if(arr[4].equals("w")||arr[4].equals("W"))
							{
								electra.sDevice_Status="work";
							}
							else {
								electra.sDevice_Status="stop";
							}
							electra.dtDevice_IN = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[5]);
							electra.dtDevice_OUT = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[6]);
							electra.dDevice_PowerCapacity=Double.parseDouble(arr[7]);
							list.add(electra);
						}
						if(arr[1].trim().equals("ElectricGate"))
						{
							Device electricGate=new Device_ElectricGate();
							electricGate.sDevice_ID=arr[0];
							electricGate.sDevice_Name=arr[1];
							electricGate.sDevice_Type=arr[2];
							electricGate.sDevice_Locate=arr[3];
							if(arr[4].equals("w")||arr[4].equals("W"))
							{
								electricGate.sDevice_Status="work";
							}
							else {
								electricGate.sDevice_Status="stop";
							}
							electricGate.dtDevice_IN = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[5]);
							electricGate.dtDevice_OUT = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(arr[6]);
							list.add(electricGate);
						}
					}
				    else throw new Exception("Errorr");
					line=br.readLine();
					}
					br.close();
			} 
			catch(Exception e)
			{
				System.out.println(e);
			}
		}catch(FileNotFoundException e){
			throw e;
		} catch(IOException e) {
			e.printStackTrace();
		}
		return list;
	}
	public static void Ouput(List<Device> ds)
	{
		System.out.printf("|%20s|%15s|%25s|%20s|%10s|%23s|%23s|\n","Device_ID","Device_Name","Device_Type","Device_Location","Situation","Starting Up","Infixing");
		for (Device device : ds) {
			device.Dev_Ouput();
		}
	}
	public static String Find_Device(String ID,List<Device> list)
	{
		for (Device device : list) {
			if(device.sDevice_ID==ID) {
				return device.toString();
			}
		}
		return "Errorr";
	}
	@Override
	public List<Device> List_Device_1Month() {
		
		 List<Device> list = new ArrayList<Device>();
		 
         for(Device dev:SystemPark.List_Devices_Main)
         {
             if(dev.dtDevice_OUT.getMonth()!=12&& dev.dtDevice_OUT.getYear()==LocalDate.now().getYear())
             {
                 if(dev.dtDevice_OUT.getMonth()==((int)LocalDateTime.now().getMonthValue()))
                 {
                     list.add(dev);
                 }
             }
             else
             {
                 if (dev.dtDevice_OUT.getMonth()==12 && ((int)LocalDateTime.now().getMonthValue())==12 && ((int)LocalDateTime.now().getYear())==dev.dtDevice_OUT.getYear())    
                 {
                     list.add(dev);
                 }
             }

         }
         
         return list;  
           
	}

	@Override
	public List<Device> List_Device_Stop() {
		List<Device> list=new ArrayList<Device>();
		
		for(Device dev : SystemPark.List_Devices_Main)
		{
			if(dev.sDevice_Status=="stop")
			{
				list.add(dev);
			}
		}
		
		return list;
	}

}
