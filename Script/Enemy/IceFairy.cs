using System;
using Godot;

public class IceFairy : VeloMovementEnemy {
	public override void ChangeFireRate(float fr) {
		base.ChangeFireRate(fr);
		Gun gun = (Gun) GetNode("Gun");
		gun.FireRate = fr;
	}
}
