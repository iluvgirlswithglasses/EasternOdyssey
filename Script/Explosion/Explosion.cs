using Godot;

public class Explosion : AnimatedSprite {
	// self-destruct after
	[Export]
	public float SelfDestructTime = 1;
	protected float Delta = 0;

	public override void _Ready() {
		this.Frame = 0;
	}

	public override void _PhysicsProcess(float delta) {
		base._PhysicsProcess(delta);
		Delta += delta;
		if (Delta >= SelfDestructTime)
			GetParent().RemoveChild(this);
	}
}
