using Godot;
using static System.Math;

public class Clownpiece : VeloMovementEnemy {
	[Export]
	public int Speed = 0;
	[Export]
	public float RotateSpeed = 1f;
	[Export]
	public int FurryThreshold = 150;

	private IceFairyGun pistol1;
	private IceFairyGun pistol2;

	public override void _Ready() {
		// some guns that are disabled by default
		pistol1 = GetNode<IceFairyGun>("PistolGun1");
		pistol2 = GetNode<IceFairyGun>("PistolGun2");
		pistol1.SetProcess(false);
		pistol2.SetProcess(false);
		//
		f = (d) => {
			// the first 2 seconds
			if (d < 4.0) {
				return new Vector2(-100, 0);
			}
			// the rest
			return new Vector2(
				(float) Cos(d * RotateSpeed) * Speed,
				(float) Sin(d * RotateSpeed) * Speed
			);
		};
	}

	public override void TakeDamage(int d) {
		base.TakeDamage(d);
		if (Health <= FurryThreshold) {
			pistol1.SetProcess(true);
			pistol2.SetProcess(true);
		}
	}

	public override void ProcessOutOfScreen() {
		// take no action
	}
}
