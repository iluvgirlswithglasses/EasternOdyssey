using Godot;
using System;
using static System.Math;

public abstract class SpiralGun : Gun {

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
    [Export]
    public int BulletsPerShot = 24;

    public override void _Ready() {
        base._Ready();
        this.Target = "Player";
        BulletScene = (PackedScene) GD.Load(String.Format("res://Asset/Object/Bullet/Enemy/{0}.tscn", BulletSprite));
    }

    public override void Shoot() {
        double angle = 2 * PI / BulletsPerShot;
        for (int i = 0; i < BulletsPerShot; i++) {
            // calculations
            double alpha = angle * i;
            // add rotation here

            // prepare object
            BulletAdv bullet = (BulletAdv) BulletScene.Instance();

            bullet.Layers = Constants.NO_LAYER;
            bullet.CollisionLayer = Constants.PLAYER_LAYER;
            bullet.Target = this.Target;
            bullet.Damage = this.Damage;

            bullet.F = AssignBullet(alpha);
            // launch
            Scene.AddChild(bullet);
            bullet.Position = this.GlobalPosition;
        }
    }

    protected virtual Func<BulletAdv, Vector2> AssignBullet(double alpha) {
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
}
