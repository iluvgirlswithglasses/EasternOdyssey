using Godot;
using System;

public class Bullet : KinematicBody2D
{
	public int Target;	// the bullet will deal damage to this target type
	public int Damage;

	// temporarily, these values are constants
	public float Speed;
	public float Acceleration;
	public float Angle;
	
	public Vector2 Velocity;

	public void Init(int t, int d, float s, float a, float angle) {
		Target = t;
		Damage = d;
		Speed = s;
		Acceleration = a;
		Angle = angle;

		Velocity = new Vector2((float) Math.Cos(Angle)*Speed, (float) Math.Sin(Angle)*Speed);
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// remove this later
		Init(0, 0, 800.0f, 0.0f, 0.0f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		MoveAndSlide(Velocity);
	}
}
