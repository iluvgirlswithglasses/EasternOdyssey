using System;
using System.Collections.Generic;
using Godot;

public class FireFairy : VeloMovementEnemy {
	private List<Gun> guns = new List<Gun>();

	public override void _Ready() {
		base._Ready();
		Node ls = GetNode("Guns");
		foreach (Node i in ls.GetChildren()) {
			guns.Add(i as Gun);
		}
	}

	public override void ChangeFireRate(float fr) {
		base.ChangeFireRate(fr);
		foreach (Gun i in guns)
			i.FireRate = fr;
	}

	public override void ChangeGunDelta(float d) {
		base.ChangeGunDelta(d);
		foreach (Gun i in guns)
			i.Delta = d;
	}
}
