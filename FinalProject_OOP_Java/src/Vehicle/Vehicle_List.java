package Vehicle;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.LinkedList;
import java.util.List;

public class Vehicle_List {

	// Đọc các vehicle có trong file có đường dẫn path
	public static List<Vehicle> Docfile(String path) throws FileNotFoundException
    {
        List<Vehicle> ls = new LinkedList<Vehicle>();
        File file= new File(path);
        try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
			try
			 {
			     String line = reader.readLine();
			     while (line != null)
			     {
			         String[] a = line.split(";");

			         if (a.length == 8)
			         {
			             Vehicle pt;
			             SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
	                     if (a[4].compareTo("null")!=0)
	                     {
	                    	 if (a[0].charAt(0) == '1')
	                             pt = new Vehicle_Electric(a[0], a[1], a[2], formatter.parse(a[3]), formatter.parse(a[4]), Integer.parseInt(a[5]), Double.parseDouble(a[6]));
	                         else if (a[0].charAt(0) == '2')
	                             pt = new Vehicle_Car(a[0], a[1], a[2], formatter.parse(a[3]), formatter.parse(a[4]), Integer.parseInt(a[5]));
	                         else if (a[0].charAt(0) == '3')
	                             pt = new Vehicle_Motobike(a[0], a[1], a[2], formatter.parse(a[3]), formatter.parse(a[4]), Integer.parseInt(a[5]));
	                         else if (a[0].charAt(0) == '4')
	                             pt = new Vehicle_Scooter(a[0], a[1], a[2], formatter.parse(a[3]), formatter.parse(a[4]), Integer.parseInt(a[5]));
	                         else if (a[0].charAt(0) == '5')
	                        	 pt = new Vehicle_Bike(a[0], a[1], a[2], formatter.parse(a[3]), formatter.parse(a[4]));
	                         else if (a[0].charAt(0) == '6')
	                             pt = new Vehicle_Truck(a[0], a[1], a[2], formatter.parse(a[3]), formatter.parse(a[4]), Integer.parseInt(a[5]));
	                         else
	                             throw new Exception("ERROR");
	                     }
	                     else
	                     {
	                         if (a[0].charAt(0) == '1')
	                             pt = new Vehicle_Electric(a[0], a[1], a[2], formatter.parse(a[3]), Integer.parseInt(a[5]),Double.parseDouble(a[6]));
	                         else if (a[0].charAt(0) == '2')
	                             pt = new Vehicle_Car(a[0], a[1], a[2], formatter.parse(a[3]), Integer.parseInt(a[5]));
	                         else if (a[0].charAt(0) == '3')
	                             pt = new Vehicle_Motobike(a[0], a[1], a[2], formatter.parse(a[3]), Integer.parseInt(a[5]));
	                         else if (a[0].charAt(0) == '4')
	                             pt = new Vehicle_Scooter(a[0], a[1], a[2], formatter.parse(a[3]), Integer.parseInt(a[5]));
	                         else if (a[0].charAt(0) == '5')
	                             pt = new Vehicle_Bike(a[0], a[1], a[2], formatter.parse(a[3]));
	                         else if (a[0].charAt(0) == '6')
	                             pt = new Vehicle_Truck(a[0], a[1], a[2], formatter.parse(a[3]), Integer.parseInt(a[5]));
	                         else
	                             throw new Exception("ERROR");
	                     }
	                     
	                     pt.Veh_Input_Other_services(Integer.parseInt(a[7]));
	                        
			             ls.add(pt);
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
        
        return ls;
    }
	
	//Xuất toàn bộ các Vehicle có trong ls 
	public static void OutList(List<Vehicle> ls)
    {
        System.out.printf("|%23s|%10s|%10s|%22s|%22s|%15s|%10s|\n", "ID", "Type", "Locate", "In Time", "Out Time", "Other Services", "Vehicle");
        for(int i=0; i<ls.size();i++)
        {
        	Vehicle veh=ls.get(i);
            veh.Veh_Output();
        }

        System.out.println("OTHER SERVICE LIST FOR EACH VEHICLE");
        System.out.println("I. ELECTRIC VEHICLE");
        System.out.println("1.Charge");
        System.out.println("2.No charging");
        System.out.println("II. CAR VEHICLE:");
        System.out.println("1.Refuel");
        System.out.println("2.Car wash");
        System.out.println("3.Both");
        System.out.println("4.No service");
        System.out.println("III. MOTORBIKE VEHICLE");
        System.out.println("1.Refuel");
        System.out.println("2.No service");
        System.out.println("IV. SCOOTER VEHICLE");
        System.out.println("1.Refuel");
        System.out.println("2.No service");
        System.out.println("V. BIKE VEHICLE");
        System.out.println("1.Bike wash");
        System.out.println("2.No service");
        System.out.println("VI. TRUCK VEHICLE");
        System.out.println("1.Refuel");
        System.out.println("2.Truck wash");
        System.out.println("3.Both");
        System.out.println("4.No service");
    }
	
	//Ghi veh vào cuối file có đường dẫn path
	public static void GhiFile_finalize(Vehicle veh,String path) throws IOException
 	{
 		 File fs = new File(path);
          if(!fs.exists())
         	 fs.createNewFile();
          FileWriter fw =new FileWriter(fs,true);
          BufferedWriter bw = new BufferedWriter(fw);
          bw.newLine();
          bw.write(veh.toString());
          bw.close();
          System.out.println("File: "+path+" da duoc chinh sua thanh cong!!");
 	}
	
	//Xóa File có đường dẫn path và ghi lại ls vào file mới tạo có cùng đường dẫn cũ 
	public static void GhiFile(List<Vehicle> ls, String path) throws IOException
	{
		File fs = new File(path);
		if(fs.delete())
		{
			fs.createNewFile();
			BufferedWriter bw = new BufferedWriter(new FileWriter(fs));
			for(Vehicle veh:ls)
			{
				bw.write(veh.toString());
				bw.newLine();
				bw.flush();
			}
			bw.close();
			System.out.println("File: "+path+ " da duoc chinh sua thanh cong!!");
		}else
			System.out.println("Ghi file vào "+path+" that bai!!");
		
	}
}
