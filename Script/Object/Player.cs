using Godot;
using System;

public class Player : KinematicBody2D {

	public const float Speed = 20000.0f;

	Vector2 ScreenSize;
	Vector2 Velocity = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		ScreenSize = GetViewportRect().Size;
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

		// apply movement
		MoveAndSlide(Velocity);
		
		// prevent player from going out of scene
		Position = new Vector2(
			fix(Position.x, 0, ScreenSize.x), 
			fix(Position.y, 0, ScreenSize.y)
		);
	}

	/** @ tools */
	private float fix(float x, float l, float r) {
		x = Math.Max(x, l);
		x = Math.Min(x, r);
		return x;
	}
}
