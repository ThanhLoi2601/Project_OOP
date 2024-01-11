package Device;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Device_Camera extends Device {
	// fields
	// properties
	public List<String> getDevice_lpathVideo() {
		return Device_lpathVideo;
	}
	public void setDevice_lpathVideo(List<String> device_lpathVideo) {
		Device_lpathVideo = device_lpathVideo;
	}
	
	// Constructors
	public Device_Camera(String sDevice_ID, String sDevice_Name, String sDevice_Type, String sDevice_Locate,
			String sDevice_Status, Date dtDevice_IN, Date dtDevice_OUT, List<String> device_lpathVideo) {
		super(sDevice_ID, sDevice_Name, sDevice_Type, sDevice_Locate, sDevice_Status, dtDevice_IN, dtDevice_OUT);
		Device_lpathVideo = device_lpathVideo;
	}
	public Device_Camera() {
		super();
		// TODO Auto-generated constructor stub
		// Intilize the new list string
		this.Device_lpathVideo= new ArrayList<String>();
	}
	@Override
	public String toString() {
		// TODO Auto-generated method stub
		return super.toString();
	}

	@Override
	public void Dev_Ouput() {
		// TODO Auto-generated method stub
		super.Dev_Ouput();
		System.out.println("List of path video");
		for(int i=0;i<this.Device_lpathVideo.size();i++)
		{
			System.out.println("Link"+i+":"+this.Device_lpathVideo.get(i));
		}
	}
	@Override
	public void finalize() throws Throwable {
		// TODO Auto-generated method stub
		super.finalize();
	}
	@Override
	public void Dev_Input() throws ParseException {
		// TODO Auto-generated method stub
		this.Dev_Input1();
	}
	
}
