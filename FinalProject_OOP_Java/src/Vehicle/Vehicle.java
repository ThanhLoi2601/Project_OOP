package Vehicle;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import Time.TimeSpan;

public abstract class Vehicle implements Finding_Vehicle
{
	//Các thuộc tính
	protected String Veh_sID; // ID
    protected String Veh_sType; //Kiểu (Màu)
    protected String Veh_sLocate; //Vị trí khu, ô
    protected Date Veh_dIn_time; // thời gian vào
    protected Date Veh_dOut_time; // Thời gian ra
    private boolean Veh_bCheck_Out_time = false;
    protected int Veh_iMoney; //Tiền giữ xe trong 1 phút
    protected int Veh_iBattery; //Năng lượng
    protected int Veh_iOther_services=0; // các dịch vụ khác
	
    //định nghĩa thuộc tính
    public String getVeh_sID() {
		return this.Veh_sID;
	}
	public void setVeh_sID(String veh_sID) {
		int s = 0;
        for (int i = 0; i < veh_sID.length(); i++)
            if (veh_sID.charAt(i) == '_')
                s++;
        if (s != 2)
            throw new ArithmeticException("EROLL");
        else
            this.Veh_sID = veh_sID;
	}
	public String getVeh_sType() {
		return this.Veh_sType;
	}
	public void setVeh_sType(String veh_sType) {
		this.Veh_sType = veh_sType;
	}
	public String getVeh_sLocate() {
		return this.Veh_sLocate;
	}
	public void setVeh_sLocate(String veh_sLocate) {
		this.Veh_sLocate = veh_sLocate;
	}
	public Date getVeh_dIn_time() {
		return this.Veh_dIn_time;
	}
	public void setVeh_dIn_time(Date veh_dIn_time) {
		this.Veh_dIn_time = veh_dIn_time;
	}
	public Date getVeh_dOut_time() {
		return this.Veh_dOut_time;
	}
	public void setVeh_dOut_time(Date veh_dOut_time) {
		if(veh_dOut_time.compareTo(this.Veh_dIn_time) > 0 )
			this.Veh_dOut_time = veh_dOut_time;
        else
        	throw new ArithmeticException("EROLL");
	}
	public boolean isVeh_bCheck_Out_time() {
		return this.Veh_bCheck_Out_time;
	}
	public void setVeh_bCheck_Out_time(boolean veh_bCheck_Out_time) {
        if(veh_bCheck_Out_time!=true && veh_bCheck_Out_time!=false)
        	throw new ArithmeticException("EROLL");
		this.Veh_bCheck_Out_time = veh_bCheck_Out_time;
	}
	public int getVeh_iMoney() {
		return this.Veh_iMoney;
	}
	public void setVeh_iMoney(int veh_iMoney) {
		if(veh_iMoney <0)
			throw new ArithmeticException("EROLL");
		this.Veh_iMoney = veh_iMoney;
	}
	public int getVeh_iBattery() {
		return this.Veh_iBattery;
	}
	public void setVeh_iBattery(int veh_iBattery) {
		if(veh_iBattery<0 || veh_iBattery>100)
			throw new ArithmeticException("EROLL");
		this.Veh_iBattery = veh_iBattery;
	}
	public int getVeh_iOther_services() {
		return this.Veh_iOther_services;
	}
	public void setVeh_iOther_services(int veh_iOther_services) {
		if(veh_iOther_services<1 || veh_iOther_services>4)
			throw new ArithmeticException("EROLL");
		this.Veh_iOther_services = veh_iOther_services;
	}
    
	// Khởi tạo
	public Vehicle()
    {
    }
	
	public Vehicle(String iD, String type, String locate, Date in_time, Date out_time)
    {
        this.setVeh_sID(iD);
        this.setVeh_sType(type);
        this.setVeh_sLocate(locate);
        this.setVeh_dIn_time(in_time);
        this.setVeh_dOut_time(out_time);
        this.Veh_bCheck_Out_time = true;
    }
	
	 public Vehicle(String iD, String type, String locate, Date in_time)
     {
	        this.setVeh_sID(iD);
	        this.setVeh_sType(type);
	        this.setVeh_sLocate(locate);
	        this.setVeh_dIn_time(in_time);
     }
     public Vehicle(String iD,  String locate, Date in_time, Date out_time)
     {
         this.setVeh_sID(iD);
         this.setVeh_sLocate(locate);
         this.setVeh_dIn_time(in_time);
         this.setVeh_dOut_time(out_time);
         this.Veh_bCheck_Out_time = true;
     }

     public Vehicle(String iD, String locate, Date in_time)
     {
         this.setVeh_sID(iD);
         this.setVeh_sLocate(locate);
         this.setVeh_dIn_time(in_time);
     }

     public Vehicle(String iD, Date in_time, Date out_time)
     {
         this.setVeh_sID(iD);
         this.setVeh_dIn_time(in_time);
         this.setVeh_dOut_time(out_time);
         this.Veh_bCheck_Out_time = true;
     }

     public Vehicle(String iD, Date in_time)
     {
         this.setVeh_sID(iD);
         this.setVeh_dIn_time(in_time);
     }
     // các hàm
     
     public void Veh_Input(String iD, String type, String locate, Date in_time, Date out_time)
     {
         this.setVeh_sID(iD);
         this.setVeh_sType(type);
         this.setVeh_sLocate(locate);
         this.setVeh_dIn_time(in_time);
         this.setVeh_dOut_time(out_time);
         this.Veh_bCheck_Out_time = true;
     }
     
     public void Veh_Input_OutTime() throws IOException, ParseException
     {
    	 SimpleDateFormat ft = new SimpleDateFormat("dd/MM/yyyy hh:mm:ss a");
         System.out.println("Nhap thoi gian ra: ");
         InputStreamReader ips= new InputStreamReader(System.in);
         BufferedReader br =new BufferedReader(ips);
         String sTimeO = br.readLine();
         this.Veh_dOut_time = ft.parse(sTimeO);
         this.Veh_bCheck_Out_time = true;
     }
     
	public void Veh_Output()
     {
    	 String strOut_time = "NULL";
         SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy hh:mm:ss a");
         if (this.Veh_bCheck_Out_time == true)
             strOut_time= formatter.format(this.Veh_dOut_time);
         System.out.printf("|%23s|%10s|%10s|%22s|%22s|%15s|", this.Veh_sID, this.Veh_sType, this.Veh_sLocate, formatter.format(this.Veh_dIn_time), strOut_time, this.Veh_iOther_services);
     }
     
     public void Veh_Input_OutTime(String out_time) throws ParseException
     {
    	 SimpleDateFormat ft = new SimpleDateFormat("dd/MM/yyyy hh:mm:ss");
         this.Veh_dOut_time= ft.parse(out_time);
         this.Veh_bCheck_Out_time = true;
     }
     
     public long Veh_Calculate_Time() //trả về số phút giữ xe, tính thời gian giữ xe
     {
    	 //System.out.println(TimeSpan.diffTime(this.Veh_dIn_time,this.Veh_dOut_time,"Minutes"));
         return TimeSpan.diffTime(this.Veh_dIn_time,this.Veh_dOut_time,"Minutes");
     }
     
     public String path_Vehicle() // trả về string đường đi, chỉ đường từ chỗ vào đến chỗ giữ xe và đến chỗ ra
     {
         String str = "Start --> ";
         String[] a = this.Veh_sID.split("_");
         String[] b = a[1].split("-");

         if (b[0].charAt(1) == '1')
             str += "Door 1 --> ";
         else if (b[0].charAt(1) == '3')
             str += "Door 3 --> ";
         else
             return "ERROL";
         if (b.length == 5)
         {
             str += "Door 5 --> Stall 2 --> " + "Khu " + b[3].charAt(0) + " o " + b[3].charAt(1) + b[3].charAt(2) + " --> ";
             if (b[4].charAt(1) == '2')
                 str += "Door 2 --> End";
             else if (b[4].charAt(1) == '4')
                 str += "Door 4 --> End";
             else
                 return "ERROL";
         }
         else if (b.length == 4)
         {
             str += "Stall 1 --> " + "Khu " + b[2].charAt(0) + " o " + b[2].charAt(1) + b[2].charAt(2) + " --> ";
             if (b[3].charAt(1) == '2')
                 str += "Door 2 --> End";
             else if (b[3].charAt(1) == '4')
                 str += "Door 4 --> End";
             else
                 return "ERROL";
         }
         else return "ERROL";
         

         return str;
     }
     
     public abstract void Veh_Input_Other_services() throws NumberFormatException, IOException; //Nhập vào dịch vụ khác
     public abstract void Veh_Input_Other_services(int x);
     public abstract double Veh_Calculate_Money_Parking(); // tính tiền giữ xe
     public abstract double Veh_Calculate_Money_Other_services(); // tính tiền các dịch vụ khác
     public double Veh_Calculate_Money_Sum() //Tính tổng tiền= tiền giữ + tiền dịch vụ
     {
         return this.Veh_Calculate_Money_Parking() + this.Veh_Calculate_Money_Other_services();
     }
     
     public String Locate_Vehicle() // Tra cuu vi tri xe
     {
         String[]arr=this.Veh_sLocate.split("_");
         if (arr[1] == "ST1")
             return "Sy_15A NguyenHuuCanh Street.Chung Cu  Khu A VinHome RiverSide.TPHCM city : Stall 1  :  " + arr[2];
         else return "Sy_15A NguyenHuuCanh Street.Chung Cu  Khu A VinHome RiverSide.TPHCM city : Stall 1  :  " + arr[2];
     }
     
     public String toString() //Chuyển từ kiểu Vehicle sang kiểu String
     {
    	 SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
         String strOutTime;
         if (this.Veh_bCheck_Out_time == false)
             strOutTime = "null";
         else
             strOutTime = formatter.format(this.Veh_dOut_time);
         String strBa;
         if (this.Veh_iBattery==-1)
             strBa = "null";
         else
             strBa = Integer.toString(this.Veh_iBattery);

         return this.Veh_sID + ";" + this.Veh_sType + ";" + this.Veh_sLocate + ";" + formatter.format(this.Veh_dIn_time) + ";" + strOutTime + ";" + strBa + ";";
     }
     
}
