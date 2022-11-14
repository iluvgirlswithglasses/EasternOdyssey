using Godot;
using System;

public class Player : KinematicBody2D {

	public const float Speed = 20000.0f;

	Vector2 Velocity = Vector2.Zero;
	
	private PistolGun gun = new PistolGun();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero) {
			float monoDirection = 1.21f;
			if (direction.x != 0 && direction.y != 0)
				monoDirection = 1.0f;
			Velocity.x = direction.x * Speed * monoDirection * delta;
			Velocity.y = direction.y * Speed * monoDirection * delta;
		} else {
			Velocity.x = Mathf.MoveToward(Velocity.x, 0, Speed);
			Velocity.y = Mathf.MoveToward(Velocity.y, 0, Speed);
		}
		
		// The Gun
		gun.Update(delta);

		MoveAndSlide(Velocity);
	}
}
