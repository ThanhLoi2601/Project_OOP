package Device;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;
import java.util.Scanner;
import java.lang.*;
@SuppressWarnings("unused")
public abstract class Device {
	//... fields
	protected String sDevice_ID;
	protected String sDevice_Name;
	protected String sDevice_Type;
	protected String sDevice_Locate;
	protected String sDevice_Status;
	protected Date dtDevice_IN;
	protected Date dtDevice_OUT;
	// the list path of videos in camera seen
	protected List<String> Device_lpathVideo;
	// the main computer of the Main_COmp of Device_Elevator
	protected String sDevice_ID_mainComp;
	// Power Capacity for car
	protected double dDevice_PowerCapacity;
	private Scanner input;
	//...Properties
	public String getsDevice_ID() {
		return sDevice_ID;
	}
	public void setsDevice_ID(String sDevice_ID) {
		this.sDevice_ID = sDevice_ID;
	}
	public String getsDevice_Name() {
		return sDevice_Name;
	}
	public void setsDevice_Name(String sDevice_Name) {
		this.sDevice_Name = sDevice_Name;
	}
	public String getsDevice_Type() {
		return sDevice_Type;
	}
	public void setsDevice_Type(String sDevice_Type) {
		this.sDevice_Type = sDevice_Type;
	}
	public String getsDevice_Locate() {
		return sDevice_Locate;
	}
	public void setsDevice_Locate(String sDevice_Locate) {
		this.sDevice_Locate = sDevice_Locate;
	}
	public String getsDevice_Status() {
		return sDevice_Status;
	}
	public void setsDevice_Status(String sDevice_Status) {
		this.sDevice_Status = sDevice_Status;
	}
	public Date getDtDevice_IN() {
		return dtDevice_IN;
	}
	public void setDtDevice_IN(Date dtDevice_IN) {
		this.dtDevice_IN = dtDevice_IN;
	}
	public Date getDtDevice_OUT() {
		return dtDevice_OUT;
	}
	public void setDtDevice_OUT(Date dtDevice_OUT) {
		this.dtDevice_OUT = dtDevice_OUT;
	}
	@Override
	public String toString() {
		// TODO Auto-generated method stub
		return this.getsDevice_ID()+";"+this.getsDevice_Name()+";"+this.getsDevice_Type()+";"+this.getsDevice_Locate()+";"+this.getsDevice_Status()+";"+this.getDtDevice_IN().toString()+";"+this.getDtDevice_OUT().toString();
	}
	// Constructor
	public Device(String sDevice_ID, String sDevice_Name, String sDevice_Type, String sDevice_Locate,
			String sDevice_Status, Date dtDevice_IN, Date dtDevice_OUT) {
		super();
		this.sDevice_ID = sDevice_ID;
		this.sDevice_Name = sDevice_Name;
		this.sDevice_Type = sDevice_Type;
		this.sDevice_Locate = sDevice_Locate;
		this.sDevice_Status = sDevice_Status;
		this.dtDevice_IN = dtDevice_IN;
		this.dtDevice_OUT = dtDevice_OUT;
	}
	public Device() {
		super();
		// TODO Auto-generated constructor stub
		this.dtDevice_IN=new java.util.Date();
		this.dtDevice_OUT=new java.util.Date();
	}
	public abstract void Dev_Input() throws ParseException;
	public  void Dev_Input1() throws ParseException
	{
		input = new Scanner(System.in);
		System.out.print("ID: "); this.sDevice_ID =input.next();
		System.out.print("Name: ");this.sDevice_Name=input.next();
		System.out.print("Type: ");this.sDevice_Type=input.next();
		System.out.print("Locate: ");this.sDevice_Locate=input.next();
		System.out.print("Situation: ");this.sDevice_Status=input.next();
		System.out.print("Start: ");String IN_time=input.next(); this.dtDevice_IN=new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(IN_time);
		System.out.print("Refix: ");String OUT_time=input.next();this.dtDevice_OUT=new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").parse(OUT_time);
	}
	public void Dev_Ouput()
	{
        SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy hh:mm:ss a");
		System.out.printf("|%20s|%15s|%25s|%20s|%10s|%23s|%23s|\n",this.sDevice_ID ,this.sDevice_Name ,this.sDevice_Type,this.sDevice_Locate,this.sDevice_Status,formatter.format(this.dtDevice_IN),formatter.format(this.dtDevice_OUT));
	}
	@SuppressWarnings("deprecation")
	public void finalize() throws Throwable
	{
		try 
		{
		   System.out.println("Inside finalize method of Demo Class.");
		} 
		catch (Throwable e) 
		{
		   throw e;
		} 
		finally 
		{
		    System.out.println("Calling finalize method of the Object class");
		    // Calling finalize() of Object class
		    super.finalize();
		}
	}
}
