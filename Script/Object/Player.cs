using Godot;
using System;

public partial class Player : CharacterBody2D 
{
	public const float Speed = 20000.0f;
	
	private PistolGun gun = new PistolGun();

	public override void _PhysicsProcess(double _delta) {
		float delta = (float) _delta;
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero) {
			velocity.x = direction.x * Speed * delta;
			velocity.y = direction.y * Speed * delta;
		} else {
			velocity.x = Mathf.MoveToward(Velocity.x, 0, Speed);
			velocity.y = Mathf.MoveToward(Velocity.y, 0, Speed);
		}
		
		// The Gun
		gun.Update(delta);

		Velocity = velocity;
		MoveAndSlide();
	}
}
