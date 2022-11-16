using Godot;
using System;

public class ClownpieceSpiralGun : SpiralGun {
	[Export]
	public string BulletSprite = "ClownpieceSpiralBullet";

	public override void _Ready() {
		base._Ready();
		BulletScene = (PackedScene) GD.Load(String.Format("res://Asset/Object/Bullet/Enemy/{0}.tscn", BulletSprite));
	}
}
