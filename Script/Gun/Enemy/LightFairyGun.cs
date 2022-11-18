using Godot;
using static System.Math;

public class LightFairyGun : GunAdv {
	[Export]
	public float AlphaDeg = -180;
	public float Alpha;

	public override void _Ready() {
		base._Ready();
		Alpha = AlphaDeg / 180 * (float) PI;
	}

	public override void Shoot() {
		base.Shoot();
		ShootBullet(Alpha);
	}
}
