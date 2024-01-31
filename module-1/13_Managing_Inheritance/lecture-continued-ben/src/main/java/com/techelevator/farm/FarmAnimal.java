package com.techelevator.farm;

public abstract class FarmAnimal implements Singable {
	private String name;
	private String sound;
	protected boolean isAsleep;

	public FarmAnimal(String name, String sound) {
		this.name = name;
		this.sound = sound;
		isAsleep = false;
	}

	public String getName() {
		return name;
	}

	public final String getSound() {
		if (isAsleep) {
			return "Zzzzz...";
		}
		return sound;
	}

	public void sleep(boolean isAsleep) {
		this.isAsleep = isAsleep;
	}

	public abstract void eat();

}