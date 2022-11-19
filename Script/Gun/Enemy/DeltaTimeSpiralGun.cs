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
	public bool FixedLocation;	// if all the bullets should be shot at one single location
	[Export]
	public float InitTravel;	// how far from the center are the bullets before they are launched

	[Export]
	public float FirstBulletAlpha = 0f;     // first bullet's orient

	// opening fire
	protected bool OpeningFire = false;
	protected float FiredTime = 0f;
	protected int FiredBullet = 0;      // bullets fired int this shot
	protected Vector2 FiredLoc;

	public override void _Ready() {
		base._Ready();
		this.Target = "Player";
		BulletScene = (PackedScene) GD.Load(
			String.Format("res://Asset/Object/Bullet/Enemy/{0}.tscn", BulletSprite)
		);
		AngleDiff = AngleDiff / 180 * (float) PI;
		FirstBulletAlpha = FirstBulletAlpha / 180 * (float) PI;
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
				FiredLoc = this.GlobalPosition;
			}
		}
	}

	protected override void ShootBullet(double alpha) {
		// prepare object
		BulletAdv bullet = (BulletAdv) BulletScene.Instance();
		bullet.F = GetBulletVector(alpha);

		bullet.Layers = Constants.NO_LAYER;
		bullet.CollisionLayer = Constants.PLAYER_LAYER;
		bullet.Target = this.Target;
		bullet.Damage = this.Damage;

		Scene.AddChild(bullet);
		if (FixedLocation)
			bullet.Position = FiredLoc;
		else
			bullet.Position = this.GlobalPosition;
		
		bullet.Position = GetInitPosition(bullet, alpha);
	}

	protected virtual Vector2 GetInitPosition(BulletAdv bullet, double alpha) {
		return new Vector2(
			bullet.Position.x + Speed * InitTravel * (float) Cos(alpha),
			bullet.Position.y + Speed * InitTravel * (float) Sin(alpha)
		);
	}
}
