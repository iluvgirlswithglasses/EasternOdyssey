using System;
using Godot;

public class LightFairy : VeloMovementEnemy {

	private LightFairyGun[] guns = new LightFairyGun[3];

	public override void _Ready() {
		base._Ready();
		for (int i = 0; i < 3; i++)
			guns[i] = (LightFairyGun) GetNode(string.Format("Gun{0}", i));
	}

	public override void ChangeFireRate(float fr) {
		base.ChangeFireRate(fr);
		foreach (LightFairyGun i in guns)
			i.FireRate = fr;
	}

	public override void ChangeGunDelta(float d) {
		base.ChangeGunDelta(d);
		foreach (LightFairyGun i in guns)
			i.Delta = d;
	}
}
