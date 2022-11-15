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

	public void Init(int d, float s, float a, float angle, uint layers, string target) {
		Damage = d;
		Speed = s;
		Acceleration = a;
		Angle = angle;
		Rotation = angle;

		Velocity = new Vector2((float) Math.Cos(Angle)*Speed, (float) Math.Sin(Angle)*Speed);

		Layers = layers;
		Target = target;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		Vector2 collision = MoveAndSlide(Velocity);
		if (collision != null) {
			for (int i = 0; i < GetSlideCount(); i++) {
				var collider = (KinematicBody2D) GetSlideCollision(i).Collider;
				if (collider.IsInGroup(Target)) {
					GD.Print(collider.GetGroups()[0]);
					var target = (Actor) GetSlideCollision(i).Collider;
					target.TakeDamage(Damage);
					GetParent().RemoveChild(this);
					return;
				}
			}
		}
	}
}
