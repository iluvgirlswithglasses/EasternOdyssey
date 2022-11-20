using Godot;
using System;
using static System.Math;

public class RevInitDeltaTimeSpiralGun : SpiralGun {
	[Export]
	public float TurnDirectionDeg = 45;
	[Export]
	public float InitTravel;

	protected override void ShootBullet(double alpha) {
		// prepare object
		BulletAdv bullet = (BulletAdv) BulletScene.Instance();
		bullet.F = GetBulletVector(alpha);

		bullet.Layers = Constants.NO_LAYER;
		bullet.CollisionLayer = Constants.PLAYER_LAYER;
		bullet.Target = this.Target;
		bullet.Damage = this.Damage;

		Scene.AddChild(bullet);
		bullet.Position = new Vector2(
			GlobalPosition.x + Speed * InitTravel * (float) Cos(alpha),
			GlobalPosition.y + Speed * InitTravel * (float) Sin(alpha)
		);
	}
	
	// turn 90deg after init pos
	protected override Func<BulletAdv, Vector2> GetBulletVector(double alpha) {
		return (obj) => { 
			double theta = alpha + RotateSpeed * obj.Delta + TurnDirectionDeg / 180 * PI;
			Vector2 velo = new Vector2(
				(float) Cos(theta) * (Speed + obj.Delta * Acceleration), 
				(float) Sin(theta) * (Speed + obj.Delta * Acceleration)
			);
			obj.Rotation = (float) theta;
			return velo; 
		};
	}
}
