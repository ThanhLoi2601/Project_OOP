package Vehicle;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.ParseException;
import java.util.Date;

public class Vehicle_Electric extends Vehicle implements Electricity_Vehicle
{
	 //Battery là điện
    //dịch vụ khác là sạc điện
	private double Veh_dTime_Charge; //Thời gian sạc
    private double Veh_dElec_Capacity; //Dung lượng bình sạc
	

	public double getVeh_dTime_Charge() {
		return Veh_dTime_Charge;
	}

	public void setVeh_dTime_Charge(double veh_dTime_Charge) {
		Veh_dTime_Charge = veh_dTime_Charge;
	}

	public double getVeh_dElec_Capacity() {
		return Veh_dElec_Capacity;
	}

	public void setVeh_dElec_Capacity(double veh_dElec_Capacity) {
		if(veh_dElec_Capacity <= 0)
			throw new ArithmeticException("EROLL");
		Veh_dElec_Capacity = veh_dElec_Capacity;
	}

	public Vehicle_Electric()
    {
		super();
        this.setVeh_iMoney(70);
    }
	public Vehicle_Electric(String iD, String type, String locate, Date in_time, Date out_time, int battery, double capacity) 
    {
		super(iD, type, locate, in_time, out_time);
        this.setVeh_iBattery(battery);
        this.setVeh_dElec_Capacity(capacity);
        this.setVeh_iMoney(70);
    }
	public Vehicle_Electric(String iD, String type, String locate, Date in_time, Date out_time, int battery) 
    {
		super(iD, type, locate, in_time, out_time);
		this.setVeh_iBattery(battery);
		this.setVeh_iMoney(70);
    }
	public Vehicle_Electric(String iD, String type, String locate, Date in_time, int battery, double capacity) 
    {
		super(iD, type, locate, in_time);
        this.setVeh_iBattery(battery);
        this.setVeh_dElec_Capacity(capacity);
        this.setVeh_iMoney(70);
    }
	public Vehicle_Electric(String iD, String locate, Date in_time, Date out_time, int battery, double capacity) 
    {
		super(iD, locate, in_time);
        this.setVeh_iBattery(battery);
        this.setVeh_dElec_Capacity(capacity);
        this.setVeh_iMoney(70);
    }
	public Vehicle_Electric(String iD, String locate, Date in_time, double capacity) 
    {
		super(iD, locate, in_time);
        this.setVeh_dElec_Capacity(capacity);
        this.setVeh_iMoney(70);
    }
	public Vehicle_Electric(String iD, String type, String locate, Date in_time, int battery) 
    {
		super(iD, type, locate, in_time);
        this.setVeh_iBattery(battery);
        this.setVeh_iMoney(70);
    }
	 public Vehicle_Electric(String iD, Date in_time, Date out_time, double capacity)  
     {
		 super(iD,in_time,out_time);
         this.setVeh_dElec_Capacity(capacity);
         this.setVeh_iMoney(70);
     }
	 public Vehicle_Electric(String iD, Date in_time, double capacity) 
     {
		 super(iD,in_time);
         this.setVeh_dElec_Capacity(capacity);
         this.setVeh_iMoney(70);
     }
	 
	 public void Veh_Input_OutTime() throws IOException, ParseException
     {
         super.Veh_Input_OutTime();
     }
	 
	 public void Veh_Input_OutTime(String out_time) throws ParseException
     {
         super.Veh_Input_OutTime(out_time);
     }
	 
	 public void Veh_Input(String iD, String type, String locate, Date in_time, Date out_time, int battery, double capacity)
     {
         super.Veh_Input(iD, type, locate, in_time, out_time);
         this.setVeh_iBattery(battery);
         this.setVeh_dElec_Capacity(capacity);
     }
	 
	@Override
	public void Veh_Input_Other_services() throws NumberFormatException, IOException {
		// TODO Auto-generated method stub
		System.out.println("Sac pin hay khong?");
        System.out.println("1.Sac");
        System.out.println("2.Khong sac");
        InputStreamReader ips= new InputStreamReader(System.in);
        BufferedReader br =new BufferedReader(ips);
        this.Veh_iOther_services = Integer.parseInt(br.readLine());
	}
	
	@Override
	public void Veh_Input_Other_services(int x) {
		// TODO Auto-generated method stub
		this.setVeh_iOther_services(x);
	}
	
	public void Veh_Output()
    {
        super.Veh_Output();
        System.out.printf("%10s|\n", " Electric");
    }

	public long Veh_Calculate_Time()
    {
        return super.Veh_Calculate_Time();
    }
	
	@Override
	public double Veh_Calculate_Money_Parking() {
		// TODO Auto-generated method stub
		long timeMin = this.Veh_Calculate_Time();
        return this.Veh_iMoney * timeMin;
	}
	
	public void Information()
    {
        System.out.println("Thoi gian sac pin:" + this.Veh_dTime_Charge);
        System.out.println("Tien gui xe:" + this.Veh_Calculate_Money_Parking());
        System.out.println("Tien dich vu:" + this.Veh_Calculate_Money_Other_services());
        System.out.println("Tong:" + this.Veh_Calculate_Money_Sum());
    }

	@Override
	public double Veh_Calculate_Money_Other_services() {
		// TODO Auto-generated method stub
		double tong = 0;
        if (this.Veh_iOther_services == 1)
        {
        	this.Veh_Calculate_Time_Charge(20000);
            double time = this.Veh_Calculate_Time();
            double Hours = time / 60 ;
            double Hours_Charge = this.Veh_dTime_Charge;
            double x = Hours_Charge - Hours;
            if (x < 0)
                tong += 1700 * Hours_Charge;
            else
                tong += 1700 * Hours;
        }

        return tong;
	}
	
	public double Veh_Calculate_Money_Sum()
    {
        return super.Veh_Calculate_Money_Sum();
    }

    //hàm tính thời gian sạc // (dung luong, P) tg=dl/cs
    public void Veh_Calculate_Time_Charge(double Wattage)
    {
        double t = Math.round(this.Veh_dElec_Capacity / Wattage*100)/100;
        this.Veh_dTime_Charge = t;
    }
    
    // string đường đi
    public String path_Vehicle()
    {
        return super.path_Vehicle();
    }
    
    public String toString()
    {
        return super.toString() + this.Veh_dElec_Capacity +";" + this.Veh_iOther_services;
    }
}
