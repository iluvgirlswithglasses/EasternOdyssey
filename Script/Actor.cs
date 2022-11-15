using Godot;
using System;

public class Actor : KinematicBody2D {
	public int Health { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		
	}

	/** @ utils */
	public void TakeDamage(int d) {
		Health -= d;
		if (Health <= 0) GetParent().RemoveChild(this);
	}
}