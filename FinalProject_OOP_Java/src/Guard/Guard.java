package Guard;

import System.SystemPark;
import Time.TimeSpan;
import Vehicle.Vehicle;
import Vehicle.Vehicle_List;

public class Guard implements Guard_Data_Cal,Guard_Vehicle_OUT
{
	//Các thuộc tính
	private String Gua_sID;
	private String Gua_sName;
	private int Gua_iCa;
	private long Gua_lLuongCB;
	private TimeSpan Gua_tTime_lam_them = new TimeSpan();
	private String Gua_sAddress;
	private String Gua_sCall_number;
	
	//Các định nghĩa thuộc tính
	public String getGua_sID() {
		return Gua_sID;
	}
	public void setGua_sID(String gua_sID) {
		Gua_sID = gua_sID;
	}
	public String getGua_sName() {
		return Gua_sName;
	}
	public void setGua_sName(String gua_sName) {
		Gua_sName = gua_sName;
	}
	public int getGua_iCa() {
		return Gua_iCa;
	}
	public void setGua_iCa(int gua_iCa) {
		if (gua_iCa > 3 || gua_iCa <= 0)
            throw new ArithmeticException("EROLL");
		Gua_iCa = gua_iCa;
	}
	public long getGua_lLuongCB() {
		return Gua_lLuongCB;
	}
	public void setGua_lLuongCB(long gua_lLuongCB) {
        if (gua_lLuongCB < 0)
            throw new ArithmeticException("EROLL");
        this.Gua_lLuongCB = gua_lLuongCB;
		Gua_lLuongCB = gua_lLuongCB;
	}
	public TimeSpan getGua_tTime_lam_them() {
		return Gua_tTime_lam_them;
	}
	public void setGua_tTime_lam_them(TimeSpan gua_tTime_lam_them) {
		Gua_tTime_lam_them = gua_tTime_lam_them;
	}
	public String getGua_sAddress() {
		return Gua_sAddress;
	}
	public void setGua_sAddress(String gua_sAddress) {
		Gua_sAddress = gua_sAddress;
	}
	public String getGua_sCall_number() {
		return Gua_sCall_number;
	}
	public void setGua_sCall_number(String gua_sCall_number) {
		Gua_sCall_number = gua_sCall_number;
	}
	
	//Khởi tạo
	public Guard()
    {
		super();
    }

    public Guard(String id, String name, int ca, long luongcb, TimeSpan time_them, String address, String call_num)
    {
    	super();
        this.setGua_sID(id);
        this.setGua_sName(name);
        this.setGua_iCa(ca);
        this.setGua_lLuongCB(luongcb);
        this.setGua_tTime_lam_them(time_them);
        this.setGua_sAddress(address);
        this.setGua_sCall_number(call_num);
    }

    public Guard(String id, String name, int ca, String address, String call_num)
    {
    	super();
    	this.setGua_sID(id);
        this.setGua_sName(name);
        this.setGua_iCa(ca);
        this.setGua_sAddress(address);
        this.setGua_sCall_number(call_num);
    }

    public Guard(String id, String name, int ca, String call_num)
    {
    	super();
    	this.setGua_sID(id);
        this.setGua_sName(name);
        this.setGua_iCa(ca);
        this.setGua_sCall_number(call_num);
    }

    public Guard(String id, int ca, long luongcb, TimeSpan time_them, String call_num)
    {
    	super();
    	this.setGua_sID(id);
        this.setGua_iCa(ca);
        this.setGua_lLuongCB(luongcb);
        this.setGua_tTime_lam_them(time_them);
        this.setGua_sCall_number(call_num);
    }

    public Guard(String id, String name, int ca, long luongcb)
    {
    	super();
    	this.setGua_sID(id);
        this.setGua_sName(name);
        this.setGua_iCa(ca);
        this.setGua_lLuongCB(luongcb);
    }
   
	//Các hàm
    public void Gua_Input(String id, String name, int ca, long luongcb,TimeSpan time_them, String address, String call_num)
    {
        this.setGua_sID(id);
        this.setGua_sName(name);
        this.setGua_iCa(ca);
        this.setGua_lLuongCB(luongcb);
        this.setGua_tTime_lam_them(time_them);
        this.setGua_sAddress(address);
        this.setGua_sCall_number(call_num);
    }
    
    public void Gua_Output()
    {
    	System.out.printf("|%23s|%20s|%6s|%11s|%9s|%25s|%15s|\n",this.Gua_sID , this.Gua_sName ,this.Gua_iCa , this.Gua_Calculate_Salary_1day() , this.Gua_tTime_lam_them.ToString() , this.Gua_sAddress ,this.Gua_sCall_number);
      //  System.out.println("ID: " + this.Gua_sID);
      //  System.out.println("Name: " + this.Gua_sName);
      //  System.out.println("Ca: " + this.Gua_iCa);
      //  System.out.println("Luong CB: " + this.Gua_lLuongCB);
      //  System.out.println("Thoi gian lam them: " + this.Gua_tTime_lam_them.ToString());
      //  System.out.println("Address: " + this.Gua_sAddress);
      //  System.out.println("Call_Number: " + this.Gua_sCall_number);
    }
    //Tính tiền lương /1 ngày
    public double Gua_Calculate_Salary_1day()
    {
        long t = this.Gua_tTime_lam_them.diffHours;
        return 200000 + this.Gua_lLuongCB*t ;
    }
   
    //trả về string khu vực quản lý
    public String Gua_Patrol_area()
    {
        String[] b= this.Gua_sID.split("_");
        return "Khu vuc tuan tra: " + b[3].charAt(0) + " , " + b[3].charAt(1) + " , " + b[3].charAt(2) + " , " + b[3].charAt(3);
    }
    
    //Trả về string thời gian làm việc cố định
    public String Gua_Patrol_time()
    {
        String str = "Thoi gian tuan tra: ";
        if (this.Gua_iCa == 1)
            str += "0h --> 8h";
        else if (this.Gua_iCa == 2)
            str += "8h --> 16h";
        else
            str += "16h --> 0h";
        return str;
    }
    //Các truy cập của Guard
	@Override
	//Xuất 1 bảo vệ
	public void Gua_Output_Person(Guard person) {
		// TODO Auto-generated method stub
		System.out.println("Information of Guard <Person>:");
		System.out.printf("|%23s|%20s|%6s|%11s|%9s|%25s|%15s|\n","ID","Name","Shifts","Salary/1day","Overtime","Address","Call Number");
        person.Gua_Output();
		
	}
	
	@Override
	//Xuất List_Veh_On
	public void Gua_List_Veh_ON() {
		// TODO Auto-generated method stub
		System.out.println("___List of vehicles that are parking___");
        Vehicle_List.OutList(SystemPark.List_Vehicle_On_Main);
		
	}
	@Override
	//Xuất List_Veh_Off
	public void Gua_List_Veh_OFF() {
		// TODO Auto-generated method stub
		System.out.println("___List of vehicles that were parking___");
        Vehicle_List.OutList(SystemPark.List_Vehicle_Off_Main);
	}
	
	 //Tìm và Xóa 1 vehicle trong List_Vehicle_On_Main
    public Vehicle Find_Delete_Vehicle(String veh_ID)
    {
        for (int i = 0; i < SystemPark.List_Vehicle_On_Main.size(); i++)
            if (SystemPark.List_Vehicle_On_Main.get(i).getVeh_sID().compareTo(veh_ID)==0)
            {
            	Vehicle veh= SystemPark.List_Vehicle_On_Main.get(i);
                SystemPark.List_Vehicle_On_Main.remove(i);
                System.out.println("Successful delete Vehicle in List_Vehicle_On!!");
                return veh;
            }
        System.out.println("Delete failed!!");
        return null;
    }
}
