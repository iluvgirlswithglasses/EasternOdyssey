using System;
using Godot;

public class VertexFairy : VeloMovementEnemy {

	private DeltaTimeSpiralGun gun;

	public override void _Ready() {
		base._Ready();
		gun = (DeltaTimeSpiralGun) GetNode("Gun");
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
