using Godot;
using System;

public partial class IceFairyGun : Gun {

	protected PackedScene BulletScene;

	[Export]
	public string BulletSprite = "IceFairyBullet";
	[Export]
	public int DAMAGE = 10;
	[Export]
	public float SPEED = 800.0f;
	[Export]
	public float ACCELERATION = 0.0f;
	[Export]
	public float THETA_DEG = 0.0f;
	public float THETA;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
		THETA = THETA_DEG/180f*(float)Math.PI;
		BulletScene = (PackedScene) GD.Load(String.Format("res://Asset/Object/Bullet/Enemy/{0}.tscn", BulletSprite));
		this.Target = "Player";
	}

	public override void Shoot() {
		// setup bullet
		Bullet bullet = (Bullet) BulletScene.Instance();
		bullet.Init(
			DAMAGE, 
			SPEED, ACCELERATION, THETA + GetAngleTo(Scene.GetNode<Node2D>("Player").Position), 
			Constants.NO_LAYER, Constants.PLAYER_LAYER, "Player"
		);
		// add
		Scene.AddChild(bullet);
		bullet.Position = GlobalPosition;
	}
}
