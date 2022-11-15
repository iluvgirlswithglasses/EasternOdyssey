using Godot;
using System;

public partial class IceFairyGun : Gun {

	private PackedScene bulletScene = (PackedScene) GD.Load("res://Asset/Object/Bullet/Enemy/IceFairyBullet.tscn");

	const int DAMAGE = 20;
	const float SPEED = 800.0f;
	const float ACCELERATION = 0.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
		this.FireRate = 0.2f;
		this.HostileLayer = Constants.PLAYER_LAYER;
		this.Target = "Player";
	}

	public override void Shoot() {
		// setup bullet
		Bullet bullet = (Bullet) bulletScene.Instance();
		bullet.Init(DAMAGE, SPEED, ACCELERATION, GetAngleTo(Scene.GetNode<Node2D>("Player").Position), this.HostileLayer, "Player");
		// add
		Scene.AddChild(bullet);
		bullet.Position = GlobalPosition;
	}
}
