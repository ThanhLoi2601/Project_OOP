package Vehicle;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.ParseException;
import java.util.Date;

public class Vehicle_Truck extends Vehicle
{
	public Vehicle_Truck() {
		super();
		// TODO Auto-generated constructor stub
	}

	public Vehicle_Truck(String iD, Date in_time, Date out_time) {
		super(iD, in_time, out_time);
		// TODO Auto-generated constructor stub
		this.Veh_iMoney = 80;
	}

	public Vehicle_Truck(String iD, Date in_time) {
		super(iD, in_time);
		// TODO Auto-generated constructor stub
		this.Veh_iMoney = 80;
	}

	public Vehicle_Truck(String iD, String locate, Date in_time, Date out_time, int battery) {
		super(iD, locate, in_time, out_time);
		// TODO Auto-generated constructor stub
		this.Veh_iMoney = 80;
		this.setVeh_iBattery(battery);
	}

	public Vehicle_Truck(String iD, String locate, Date in_time) {
		super(iD, locate, in_time);
		// TODO Auto-generated constructor stub
		this.Veh_iMoney = 80;
	}

	public Vehicle_Truck(String iD, String type, String locate, Date in_time, Date out_time, int battery) {
		super(iD, type, locate, in_time, out_time);
		// TODO Auto-generated constructor stub
		this.Veh_iMoney = 80;
		this.setVeh_iBattery(battery);
	}

	public Vehicle_Truck(String iD, String type, String locate, Date in_time, int battery) {
		super(iD, type, locate, in_time);
		// TODO Auto-generated constructor stub
		this.Veh_iMoney = 80;
		this.setVeh_iBattery(battery);
	}
	
	 public void Veh_Input_OutTime() throws IOException, ParseException
     {
         super.Veh_Input_OutTime();
     }
	 
	 public void Veh_Input_OutTime(String out_time) throws ParseException
     {
         super.Veh_Input_OutTime(out_time);
     }

	 public void Veh_Input(String iD, String type, String locate, Date in_time, Date out_time, int battery)
     {
         super.Veh_Input(iD, type, locate, in_time, out_time);
         this.setVeh_iBattery(battery);
     }
	 
	 public void Veh_Input_Other_services() throws NumberFormatException, IOException
     {
         System.out.println("Chon them dich vu:");
         System.out.println("1.Do xang");
         System.out.println("2.Rua xe");
         System.out.println("3.Ca 2 dich vu");
         System.out.println("4.Khong them dich vu");
         InputStreamReader ips= new InputStreamReader(System.in);
         BufferedReader br =new BufferedReader(ips);
         this.Veh_iOther_services = Integer.parseInt(br.readLine());
     }

     public void Veh_Input_Other_services(int x)
     {
    	 this.setVeh_iOther_services(x);
     }
     
     public void Veh_Output()
     {
    	 super.Veh_Output();
    	 System.out.printf("%10s|\n", " Truck");
     }
     
     public String path_Vehicle()
     {
         return super.path_Vehicle();
     }

     public long Veh_Calculate_Time()
     {
         return super.Veh_Calculate_Time();
     }

     public double Veh_Calculate_Money_Parking()
     {
    	 double time = this.Veh_Calculate_Time();
         return this.Veh_iMoney * time;
     }

     public double Veh_Calculate_Money_Other_services()
     {
         double tong = 0;
         if (this.Veh_iOther_services == 1)
             tong += (100 - this.Veh_iBattery) * 5000;
         else if (this.Veh_iOther_services == 2)
             tong += 400000; //Tiền rửa xe 400000đ
         else if (this.Veh_iOther_services == 3)
             tong += (100 - this.Veh_iBattery) * 5000 + 400000;

         return tong;
     }

     public double Veh_Calculate_Money_Sum()
     {
         return super.Veh_Calculate_Money_Sum();
     }
     
     public String toString()
     {
         return super.toString() +"null;"+this.Veh_iOther_services;
     }
}
