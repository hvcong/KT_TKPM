package demo;

import Car.ICar;
import CarFactory.CarFactory;

public class carFactoryDemo {
	
	public static void main(String[] args) {
		
		ICar honda = CarFactory.getCar("Honda");
		ICar nexus = CarFactory.getCar("Nexus");
		ICar toyota = CarFactory.getCar("Toyota");
		
		honda.showInfor();
		nexus.showInfor();
		toyota.showInfor();
		
	}

}