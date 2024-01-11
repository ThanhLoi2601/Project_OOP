package Vehicle;

public interface Finding_Vehicle {
	String path_Vehicle();                // finding string đường đi 
    double Veh_Calculate_Money_Parking(); // tính tiền giữ xe // string 
    double Veh_Calculate_Money_Other_services(); // tính tiền các dịch vụ khác
    double Veh_Calculate_Money_Sum();            //tính tiền tổng
    String Locate_Vehicle(); // Tra cuu vi tri xe
}
