using System;
using Godot;

public class ShotgunFairy : VeloMovementEnemy {

	private Shotgun gun;

	public override void _Ready() {
		base._Ready();
		gun = (Shotgun) GetNode("Gun");
	}

	public override void ChangeFireRate(float fr) {
		base.ChangeFireRate(fr);
		gun.FireRate = fr;
	}

	public override void ChangeGunDelta(float d) {
		base.ChangeGunDelta(d);
		gun.Delta = d;
	}
}
