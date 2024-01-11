package Time;

import java.util.Date;

public class TimeSpan {
	public long diffDays; // Số ngày khác 
	public long diffSeconds; //Số giây khác
	public long diffMinutes; //Số phút khác
	public long diffHours; // Số giờ khác
	public long getDiffDays() {
		return diffDays;
	}
	public void setDiffDays(long diffDays) {
		this.diffDays = diffDays;
	}
	public long getDiffSeconds() {
		return diffSeconds;
	}
	public void setDiffSeconds(long diffSeconds) {
		this.diffSeconds = diffSeconds;
	}
	public long getDiffMinutes() {
		return diffMinutes;
	}
	public void setDiffMinutes(long diffMinutes) {
		this.diffMinutes = diffMinutes;
	}
	public long getDiffHours() {
		return diffHours;
	}
	public void setDiffHours(long diffHours) {
		this.diffHours = diffHours;
	}
	
	public TimeSpan()
	{
		super();
	}
	//Trả về khoảng thời gian theo đơn vị Formatdiff
	public static long diffTime(Date dateStart, Date dateStop, String Formatdiff) //Formatdiff = "Hours","Minutes","Seconds"
	{ 
		if(dateStop==null)
			dateStop=new Date();
		long diff=dateStop.getTime()- dateStart.getTime();
		if(Formatdiff=="Hours")
			return diff/(60*60*1000);
		else if(Formatdiff=="Minutes")
			return diff/(60*1000);
		else if(Formatdiff=="Seconds")
			return diff/(1000);
		else throw new ArithmeticException("EROLL");
	}
	//Ép kiểu từ kiều string sang TimeSpan
	public static TimeSpan Parse(String strTime)
	{
		String[] a= strTime.split(":");
		if(a.length!=4) throw new ArithmeticException("EROLL");
		TimeSpan t = new TimeSpan();
		t.diffDays = Long.parseLong(a[0]);
		t.diffHours = Long.parseLong(a[1]);
		t.diffMinutes = Long.parseLong(a[2]);
		t.diffSeconds = Long.parseLong(a[3]);
		
		return t;
	}
	// Trả về kiểu string của khoảng thời gian; theo format:"days:hours:minutes:seconds";
	 public String ToString()
	 {
		 return this.diffDays + ":" +this.diffHours +":" +this.diffMinutes+":"+this.diffSeconds;
	 }
	
}
