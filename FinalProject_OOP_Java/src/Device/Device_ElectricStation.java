package Device;
import java.text.ParseException;
import java.util.Date;
import java.util.Scanner;

public class Device_ElectricStation extends Device {
	// Fields

	private Scanner input1;
	// Properties 
	public double getdDevice_PowerCapacity() {
		return dDevice_PowerCapacity;
	}

	public void setdDevice_PowerCapacity(double dDevice_PowerCapacity) {
		this.dDevice_PowerCapacity = dDevice_PowerCapacity;
	}
	// Constructors
	public Device_ElectricStation() {
		super();
		this.dDevice_PowerCapacity=1;
		// TODO Auto-generated constructor stub
	}
	public Device_ElectricStation(String sDevice_ID, String sDevice_Name, String sDevice_Type, String sDevice_Locate,
			String sDevice_Status, Date dtDevice_IN, Date dtDevice_OUT, double dDevice_PowerCapacity) {
		super(sDevice_ID, sDevice_Name, sDevice_Type, sDevice_Locate, sDevice_Status, dtDevice_IN, dtDevice_OUT);
		this.dDevice_PowerCapacity = dDevice_PowerCapacity;
	}

	// Methods
	@Override
	public void Dev_Input() throws ParseException {
		// TODO Auto-generated method stub

		input1 = new Scanner(System.in);
		this.Dev_Input1();
		System.out.println("Input power capacity:");
		this.dDevice_PowerCapacity=Double.parseDouble(input1.next());
	}
	
	@Override
	public void Dev_Ouput() {
		// TODO Auto-generated method stub
		super.Dev_Ouput();
		System.out.println("Input Power Capacity:"+this.dDevice_PowerCapacity);
	}

	@Override
	public void finalize() throws Throwable {
		// TODO Auto-generated method stub
		super.finalize();
	}
	

	

	
}
