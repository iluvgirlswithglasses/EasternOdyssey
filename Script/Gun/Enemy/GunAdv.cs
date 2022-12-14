using Godot;
using System;
using static System.Math;

public abstract class GunAdv : Gun {

	protected PackedScene BulletScene;

	[Export]
	public string BulletSprite;
	[Export]
	public int Damage = 10;
	[Export]
	public float Speed = 20.0f;
	[Export]
	public float Acceleration = 200.0f;
	[Export]
	public float RotateSpeed = 1.0f;

	public override void _Ready() {
		base._Ready();
		this.Target = "Player";
		BulletScene = (PackedScene) GD.Load(String.Format("res://Asset/Object/Bullet/Enemy/{0}.tscn", BulletSprite));
	}

	// ShootBullet() only shoot ONE bullet
	// not to be confused with Shoot(), which might shoot multiple bullets per shot
	protected virtual void ShootBullet(double alpha) {
		BulletAdv bullet = (BulletAdv) BulletScene.Instance();
		bullet.F = GetBulletVector(alpha);
		AddBulletToWorld(bullet);
	}

	protected virtual Func<BulletAdv, Vector2> GetBulletVector(double alpha) {
		return (obj) => { 
			double theta = alpha + RotateSpeed * obj.Delta;
			Vector2 velo = new Vector2(
				(float) Cos(theta) * (Speed + obj.Delta * Acceleration), 
				(float) Sin(theta) * (Speed + obj.Delta * Acceleration)
			);
			obj.Rotation = (float) theta;
			return velo; 
		};
	}

	protected virtual void AddBulletToWorld(Bullet bullet) {
		bullet.Layers = Constants.NO_LAYER;
		bullet.CollisionLayer = Constants.PLAYER_LAYER;
		bullet.Target = this.Target;
		bullet.Damage = this.Damage;

		Scene.AddChild(bullet);
		bullet.Position = this.GlobalPosition;
	}
}
