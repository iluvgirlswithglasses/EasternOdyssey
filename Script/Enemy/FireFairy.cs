using System;
using System.Collections.Generic;
using Godot;

public class FireFairy : VeloMovementEnemy {

	[Export]
	public float ShootTDiff = 0.1f;	// time between each bullet

	protected List<Gun> Guns = new List<Gun>();

	public override void _Ready() {
		base._Ready();
		Node ls = GetNode("Guns");
		foreach (Node i in ls.GetChildren()) {
			Guns.Add(i as Gun);
		}
	}

	public override void ChangeFireRate(float fr) {
		base.ChangeFireRate(fr);
		foreach (Gun i in Guns)
			i.FireRate = fr;
	}

	public override void ChangeGunDelta(float d) {
		base.ChangeGunDelta(d);
		for (int i = 0; i < Guns.Count; i++)
			Guns[i].Delta = ShootTDiff * i + d;
	}

	public override void ChangeRelativeToPlayer(int r) {
		base.ChangeRelativeToPlayer(r);

	}
}
