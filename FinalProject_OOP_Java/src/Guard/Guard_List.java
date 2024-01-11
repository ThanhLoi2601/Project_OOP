package Guard;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.LinkedList;
import java.util.List;

import System.SystemPark;
import Time.TimeSpan;

public class Guard_List implements Guard_Management_Interface
{
	 public static List<Guard> Docfile(String path) throws FileNotFoundException
     {
         List<Guard> ls = new LinkedList<Guard>();
         File file= new File(path);
         try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
			try
			 {
			     String line = reader.readLine();
			     while (line != null)
			     {
			         String[] a = line.split(";");

			         if (a.length == 7)
			         {
			             Guard bv = new Guard(a[0], a[1], Integer.parseInt(a[2]), Long.parseLong(a[3]), TimeSpan.Parse(a[4]), a[5], a[6]);
			             ls.add(bv);
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
	 
	 @SuppressWarnings("resource")
	public static Guard DocFile_(String path) throws IOException
     {
		 File file= new File(path);
		 BufferedReader reader = new BufferedReader(new FileReader(file));
         String line = reader.readLine();
         String[] a = line.split(";");
         return new Guard(a[0], a[1], Integer.parseInt(a[2]), Long.parseLong(a[3]), TimeSpan.Parse(a[4]), a[5], a[6]);
     }
	 
	 public static void OuputList(List<Guard> list)
     {
         System.out.printf("|%23s|%20s|%6s|%11s|%9s|%25s|%15s|\n","ID","Name","Shifts","Salary/1day","Overtime","Address","Call Number");
         for(int i=0; i<list.size(); i++)
         {
        	 Guard gua =list.get(i);
        	 gua.Gua_Output();
         }
     }

	@Override
	public void OuputListWorker() {
		// TODO Auto-generated method stub
		System.out.println("_______Thong tin chi tiet danh sach bao ve_____");
        Guard_List.OuputList(SystemPark.List_Guard_Main);
		
	}

	@Override
	public void OuputInformation() {
		// TODO Auto-generated method stub
		System.out.println("Information of Manager:");
		System.out.printf("|%23s|%20s|%6s|%11s|%9s|%25s|%15s|\n","ID","Name","Shifts","Salary/1day","Overtime","Address","Call Number");
        SystemPark.Manager.Gua_Output();
	}
}
