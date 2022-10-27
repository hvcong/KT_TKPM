package test;

import factorys.AbstractFactory;
import factorys.ChairFactory;
import factorys.TableFactory;

public class FactoryProducer {
	public static AbstractFactory getFactory(String factoryType) {
		if(factoryType.equalsIgnoreCase("TableFactory")) {
			return new TableFactory();
		}
			if(factoryType.equalsIgnoreCase("ChairFactory")) {
				return new ChairFactory();
			}
		
		
		return null;
	}
}