using System;
using Godot;

public class VeloMovementEnemy : Actor {

	protected float Delta = 0;
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

		AddCollisionExceptionWith(this);
	}

	public override void _Process(float delta) {
		Delta += delta;
		Velocity = f(Delta);
		MoveAndSlide(Velocity);
		// if out of scene
		ProcessOutOfScreen();
	}

	public override void AnnounceKill() {
		base.AnnounceKill();
		Manager.CountKill();
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
