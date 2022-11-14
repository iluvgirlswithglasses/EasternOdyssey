using Godot;
using System;

public abstract class Gun {
	
	public float FireRate {get; set;}
	public float Delta {get; set;}
	
	public void Update(float d) {
		Delta += d;
		if (Delta >= FireRate) {
			// spawn bullet
			Delta -= FireRate;
		}
	}
}
