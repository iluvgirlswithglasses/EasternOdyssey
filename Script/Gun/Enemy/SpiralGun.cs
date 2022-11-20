using Godot;
using System;
using static System.Math;

public class SpiralGun : GunAdv {
	[Export]
	public int BulletsPerShot = 24;
	[Export]
	public float Alpha = 0;

	public override void _Ready() {
		base._Ready();
	}

	public override void Shoot() {
		double angle = 2 * PI / BulletsPerShot;
		for (int i = 0; i < BulletsPerShot; i++) {
			double alpha = Alpha + angle * i;
			ShootBullet(alpha);
		}
	}
}
