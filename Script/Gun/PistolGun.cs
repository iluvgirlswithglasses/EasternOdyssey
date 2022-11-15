using Godot;
using System;
using static Constants;

public partial class PistolGun : Gun {

	private PackedScene bulletScene = (PackedScene) GD.Load("res://Asset/Object/Bullet.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		this.FireRate = 0.2f;
		this.HostileLayer = Constants.ENEMY_LAYER;
	}

	public override void Shoot() {
		KinematicBody2D bullet = (KinematicBody2D) bulletScene.Instance();
		bullet.Layers = this.HostileLayer;
		Scene.AddChild(bullet);
		bullet.Position = GlobalPosition;
	}
}
