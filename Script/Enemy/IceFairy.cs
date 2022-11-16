using System;
using Godot;

public class IceFairy : Actor {

	private float Delta = 0;

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
		if (ScreenTool.IsOutOfScreen(GetViewportRect().Size, Position))
			GetParent().RemoveChild(this);
	}
}
