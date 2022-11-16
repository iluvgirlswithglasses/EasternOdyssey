using Godot;
using System;

public class Gun : Node2D {

	[Export]
	public float FireRate { get; set; }
	
	protected float Delta { get; set; }

	// the target of this gun
	public string Target { get; set; }
	
	protected Node Scene { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Scene = GetTree().Root.GetChild(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float d) {
		Delta += d;
		if (Delta >= FireRate) {
			Shoot();
			Delta -= FireRate;
		}
	}

	public virtual void Shoot() {

	}
}
