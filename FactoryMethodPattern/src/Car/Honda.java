package Car;

public class Honda implements ICar {
	
	private String cauHinh;
	private String nhaSanXuat;
	
	public Honda() {
		cauHinh = "50cc";
		nhaSanXuat = "Vggg";
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
		System.out.println("Honda:" + this.cauHinh + "--" + this.nhaSanXuat);
		
	}
	
	
}
