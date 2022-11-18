using System;
using Godot;

public class IceFairy : VeloMovementEnemy {

	private IceFairyGun gun;

	public override void _Ready() {
		base._Ready();
		gun = (IceFairyGun) GetNode("Gun");
	}

	public override void ChangeFireRate(float fr) {
		base.ChangeFireRate(fr);
		gun.FireRate = fr;
	}

	public override void ChangeGunDelta(float d) {
		base.ChangeGunDelta(d);
		gun.Delta = d;
	}

	public override void ChangeRelativeToPlayer(int r){
		base.ChangeRelativeToPlayer(r);
		gun.RELATIVE_TO_PLAYER = r;
	}
}
