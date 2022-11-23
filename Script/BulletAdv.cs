using Godot;
using System;

public class BulletAdv : Bullet {

	public Func<BulletAdv, Vector2> F;
	public float Delta;

	public override void _PhysicsProcess(float delta) {
		Delta += delta;
		Move(F(this));
	}
}
