using Godot;
using System;

public partial class PistolGun : Gun {

	private PackedScene bulletScene = (PackedScene) GD.Load("res://Asset/Object/Bullet.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		this.FireRate = 0.2f;
	}

	public override void Shoot() {
		KinematicBody2D bullet = (KinematicBody2D) bulletScene.Instance();
		Scene.AddChild(bullet);
		bullet.Position = GlobalPosition;
	}
}
