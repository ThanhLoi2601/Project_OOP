package Device;
import java.text.ParseException;
import java.util.Date;
import java.util.Scanner;

public class Device_Elevator extends Device {
	// fields

	private Scanner input1;
	// properties
	public String getsDevice_ID_mainComp() {
		return sDevice_ID_mainComp;
	}
	public void setsDevice_ID_mainComp(String sDevice_ID_mainComp) {
		this.sDevice_ID_mainComp = sDevice_ID_mainComp;
	}
	// Constructor
	
	public Device_Elevator() {
		super();
		// TODO Auto-generated constructor stub
		// 
		this.sDevice_ID_mainComp="";
	}
	public Device_Elevator(String sDevice_ID, String sDevice_Name, String sDevice_Type, String sDevice_Locate,
			String sDevice_Status, Date dtDevice_IN, Date dtDevice_OUT, String sDevice_ID_mainComp) {
		super(sDevice_ID, sDevice_Name, sDevice_Type, sDevice_Locate, sDevice_Status, dtDevice_IN, dtDevice_OUT);
		this.sDevice_ID_mainComp = sDevice_ID_mainComp;
	}
	@Override
	public String toString() {
		// TODO Auto-generated method stub
		return super.toString()+this.getsDevice_ID_mainComp();
	}
	// Methods
	@Override
	public void Dev_Input() throws ParseException {
		input1 = new Scanner(System.in); 
		this.Dev_Input1();
		System.out.print("ID of main computer:");
		this.sDevice_ID_mainComp=input1.next();
	}
	@Override
	public void finalize() throws Throwable {
		// TODO Auto-generated method stub
		super.finalize();
	}
	@Override
	public void Dev_Ouput() {
		// TODO Auto-generated method stub
		super.Dev_Ouput();
		System.out.println("ID of the main computer:"+this.sDevice_ID_mainComp);
	}
	
}
