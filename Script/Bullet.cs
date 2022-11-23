using Godot;
using System;

public class Bullet : KinematicBody2D {

	// this bullet will only hit this group of target
	public string Target { get; set; }

	public int Damage;
	public float Speed;
	public float Acceleration;
	public float Angle;
	
	public Vector2 Velocity;

	public void Init(int d, float s, float a, float angle, uint layerPresent, uint layerMask, string target) {
		Damage = d;
		Speed = s;
		Acceleration = a;
		Angle = angle;
		Rotation = angle;

		Velocity = new Vector2((float) Math.Cos(Angle)*Speed, (float) Math.Sin(Angle)*Speed);

		Layers = layerPresent;
		CollisionLayer = layerMask;
		Target = target;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta) {
		Velocity = new Vector2(
			Velocity.x + (float) Math.Cos(Angle) * delta * Acceleration, 
			Velocity.y + (float) Math.Sin(Angle) * delta * Acceleration
		);
		Move(Velocity);
	}

	public void Move(Vector2 velocity) {
		Vector2 collision = MoveAndSlide(velocity);
		if (collision != null) {
			for (int i = 0; i < GetSlideCount(); i++) {
				var collider = (KinematicBody2D) GetSlideCollision(i).Collider;
				if (collider.IsInGroup(Target)) {
					var target = (Actor) GetSlideCollision(i).Collider;
					target.TakeDamage(Damage);
					Destroy();
					return;
				}
			}
		}
		// check if out of scene
		if (ScreenTool.IsOutOfScreen(GetViewportRect().Size, Position))
			GetParent().RemoveChild(this);
	}

	public virtual void Destroy() {
		// add effect here
		if (this != null)
			GetParent().RemoveChild(this);
	}
}
