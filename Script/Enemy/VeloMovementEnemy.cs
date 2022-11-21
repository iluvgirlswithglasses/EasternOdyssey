using System;
using Godot;

public class VeloMovementEnemy : Actor {

	protected float Delta = 0;

	[Export]
	public int Point = 10;	// the point gained for killing this enemy

	// THIS FIELD MUST BE SET BY THE SPAWNER
	// OTHERWISE THE GAME WILL CRASH
	public SpawnerManager Manager;

	public Func<float, Vector2> f;	// calculate the Velocity, given time as the parameter

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();

		// these objects belongs to NO LAYER
		// because if they do, they will collide with each others
		Layers = Constants.NO_LAYER;
		CollisionMask = Constants.ENEMY_LAYER;
	}

	public override void _Process(float delta) {
		Delta += delta;
		Velocity = f(Delta);
		Vector2 collision = MoveAndSlide(Velocity);
		// if (collision != null) {
		// 	for (int i = 0; i < GetSlideCount(); i++) {
		// 		var collider = (KinematicBody2D) GetSlideCollision(i).Collider;
		// 		if (collider.IsInGroup("Player")) {
		// 			Player player = (Player) GetSlideCollision(i).Collider;
		// 			player.TakeDamage(1000);
		// 		}
		// 	}
		// }
		// if out of scene
		ProcessOutOfScreen();
	}

	public override void AnnounceKill() {
		base.AnnounceKill();
		Manager.CountKill(Point);
	}

	public virtual void ChangeFireRate(float fr) {

	}

	public virtual void ChangeGunDelta(float d) {
		
	}

	public virtual void ChangeRelativeToPlayer(int r) {
		
	}

	public virtual void ProcessOutOfScreen() {
		if (ScreenTool.IsOutOfScreenByMargin(GetViewportRect().Size, Position, 100)) {
			GetParent().RemoveChild(this);
			Manager.CountLoss();
		}
	}
}
