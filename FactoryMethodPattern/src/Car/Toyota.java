package Car;

public class Toyota implements ICar {

	private String cauHinh;
	private String nhaSanXuat;
	
	public Toyota() {
		cauHinh = "500cc";
		nhaSanXuat = "Hdd";
	}
	
	

	public String getCauHinh() {
		return cauHinh;
	}



	public void setCauHinh(String cauHinh) {
		this.cauHinh = cauHinh;
	}



	public String getNhaSanXuat() {
		return nhaSanXuat;
	}



	public void setNhaSanXuat(String nhaSanXuat) {
		this.nhaSanXuat = nhaSanXuat;
	}



	@Override
	public void showInfor() {
		// TODO Auto-generated method stub
		System.out.println("Toyota:" + this.cauHinh + "--" + this.nhaSanXuat);
		
	}
	

}
