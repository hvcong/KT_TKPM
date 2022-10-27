package CarFactory;

import Car.Honda;
import Car.ICar;
import Car.Nexus;
import Car.Toyota;

public class CarFactory {

	public static final ICar getCar(String typeCar) {
		if(typeCar == null) {
			return null;
		}
		
		if(typeCar.equalsIgnoreCase("Honda")) {
			return new Honda();
		}
		
		if(typeCar.equalsIgnoreCase("Toyota")) {
			return new Toyota();
		}
		
		if(typeCar.equalsIgnoreCase("Nexus")) {
			return new Nexus();
		}
		return null;
	}
}