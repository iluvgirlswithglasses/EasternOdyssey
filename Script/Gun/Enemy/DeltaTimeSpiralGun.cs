using Godot;
using System;
using static System.Math;

// this Gun use BulletAdv
public class DeltaTimeSpiralGun : GunAdv {

	[Export]
	public int BulletsPerShot = 24;
	[Export]
	public float BulletDelta;   // delta time between each bullet
	[Export]
	public float AngleDiff;     // angle distance between two consecutive bullets

	[Export]
	public float FirstBulletAlpha = 0f;     // first bullet's orient

	// opening fire
	protected bool OpeningFire = false;
	protected float FiredTime = 0f;
	protected int FiredBullet = 0;      // bullets fired int this shot

	public override void _Ready() {
		base._Ready();
		this.Target = "Player";
		BulletScene = (PackedScene) GD.Load(
			String.Format("res://Asset/Object/Bullet/Enemy/{0}.tscn", BulletSprite)
		);
        AngleDiff = AngleDiff / 180 * (float) PI;
	}

	public override void _Process(float d) {
		if (OpeningFire) {
			FiredTime += d;
			if (FiredTime >= BulletDelta) {
				FiredTime -= BulletDelta;
				//
				double alpha = FiredBullet * AngleDiff + FirstBulletAlpha;
				ShootBullet(alpha);
				FiredBullet++;
			}
			if (FiredBullet == BulletsPerShot) {
				OpeningFire = false;
			}
		} else {
			Delta += d;
			if (Delta >= FireRate) {
				Delta -= FireRate;

				OpeningFire = true;
				FiredTime = 0;
				FiredBullet = 0;
			}
		}
	}

	protected virtual void ShootBullet(double alpha) {
		// prepare object
		BulletAdv bullet = (BulletAdv) BulletScene.Instance();
		bullet.F = GetBulletVector(alpha);
		AddBulletToWorld(bullet);
	}
}
