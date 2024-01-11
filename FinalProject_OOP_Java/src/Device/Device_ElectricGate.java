package Device;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Device_ElectricGate extends Device 
{
	// Fields
	// the list Date electric gate works
	private List<Date> Device_lworks;
	// Properties
	public List<Date> getDevice_lworks() {
		return Device_lworks;
	}

	public void setDevice_lworks(List<Date> device_lworks) {
		Device_lworks = device_lworks;
	}
	// Constructors
	@Override
	public String toString() {
		// TODO Auto-generated method stub
		return super.toString();
	}
	
	public Device_ElectricGate(String sDevice_ID, String sDevice_Name, String sDevice_Type, String sDevice_Locate,
			String sDevice_Status, Date dtDevice_IN, Date dtDevice_OUT, List<Date> device_lworks) {
		super(sDevice_ID, sDevice_Name, sDevice_Type, sDevice_Locate, sDevice_Status, dtDevice_IN, dtDevice_OUT);
		Device_lworks = device_lworks;
	}

	public Device_ElectricGate() {
		super();
		// TODO Auto-generated constructor stub
		this.Device_lworks=new ArrayList<Date>();
	}
	
	// Methods
	@Override
	public void Dev_Input() throws ParseException {
		// TODO Auto-generated method stub
		this.Dev_Input1();
	}

	@Override
	public void Dev_Ouput() {
		// TODO Auto-generated method stub
		super.Dev_Ouput();
		System.out.println("List working times of electric gate: <"+this.sDevice_ID+">");
		for(int i=0;i<this.Device_lworks.size();i++) {
			System.out.println(this.Device_lworks.get(i).toString());
		}
	}

	@Override
	public void finalize() throws Throwable {
		// TODO Auto-generated method stub
		super.finalize();
	}
	
}

