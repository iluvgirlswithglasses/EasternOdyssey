using System;
using Godot;

public class IceFairy : Actor {

	private float Delta = 0;

	public Func<float, Vector2> f;	// calculate the Velocity, given time as the parameter

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
		Health = 20;
		Layers = Constants.ENEMY_LAYER;
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
