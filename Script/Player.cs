using Godot;
using System;

public class Player : Actor {

	public const float Speed = 20000.0f;
	public bool IsDeath = false;

	private Vector2 ScreenSize;
	private SpawnerManager Manager;
	private HealthDisplayer HealthDisp;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
		
		Layers = Constants.PLAYER_LAYER;
		CollisionLayer = Constants.PLAYER_LAYER;

		Health = 100;
		ScreenSize = GetViewportRect().Size;

		Node scene = GetTree().Root.GetChild(0);
		Manager = (SpawnerManager) scene.GetNode("SpawnerManager");
		HealthDisp = (HealthDisplayer) scene.GetNode("PlayerHealthBar");
		HealthDisp.SetMaxHealth(Health);
		HealthDisp.SetCurrentHealth(Health);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		if (!IsDeath) {
			// Get the input direction and handle the movement/deceleration.
			// As good practice, you should replace UI actions with custom gameplay actions.
			Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
			Vector2 velocity;

			if (direction != Vector2.Zero) {
				float monoDirection = 1.21f;
				if (direction.x != 0 && direction.y != 0)
					monoDirection = 1.0f;
				velocity = new Vector2(
					direction.x * Speed * monoDirection * delta, 
					direction.y * Speed * monoDirection * delta
				);
			} else {
				velocity = new Vector2(Mathf.MoveToward(Velocity.x, 0, Speed), Mathf.MoveToward(Velocity.y, 0, Speed));
			}

			Velocity = velocity;

			// apply movement
			MoveAndSlide(Velocity);
			
			// prevent player from going out of scene
			Position = new Vector2(
				fix(Position.x, 0, ScreenSize.x), 
				fix(Position.y, 0, ScreenSize.y)
			);
		}
	}

	public override void TakeDamage(int d) {
		Health -= d;
		GD.Print("Current Health = ", Health);
		if (Health <= 0) {
			Health = 0;		// just to make sure this is non-negative
			IsDeath = true;
			Manager.GameOver();
		}
		HealthDisp.SetCurrentHealth(Health);
	}

	public void Heal(int d) {
		Health += d;
		if (Health > 100) Health = 100;
		HealthDisp.SetCurrentHealth(Health);
	}

	/** @ tools */
	private float fix(float x, float l, float r) {
		x = Math.Max(x, l);
		x = Math.Min(x, r);
		return x;
	}
}
