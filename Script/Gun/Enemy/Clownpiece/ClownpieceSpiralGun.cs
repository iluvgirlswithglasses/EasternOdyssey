using Godot;

public class ClownpieceSpiralGun : SpiralGun {
	public override void _Ready() {
		base._Ready();
		BulletScene = (PackedScene) GD.Load("res://Asset/Object/Bullet/Enemy/ClownpieceSpiralBullet.tscn");
	}
}
