package Car;

public class Nexus implements ICar {

	private String cauHinh;
	private String nhaSanXuat;
	
	
	public Nexus() {
		cauHinh = "100cc";
		nhaSanXuat = "Cddd";
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
		System.out.println("Nexus:" + this.cauHinh + "--" + this.nhaSanXuat);
		
	}
	

}
