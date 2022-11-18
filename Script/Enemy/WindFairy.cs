using Godot;
using System;

public class WindFairy : FireFairy {

	public override void ChangeRelativeToPlayer(int r) {
		base.ChangeRelativeToPlayer(r);
		foreach (Gun i in Guns) {
			IceFairyGun j = i as IceFairyGun;
			j.RELATIVE_TO_PLAYER = r;
			if (r == 0) {
				// not relative to player
				// --> change default fire angle to PI
				j.ALPHA = (float) Math.PI;
			}
		}
	}
}
