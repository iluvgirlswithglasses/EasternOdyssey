using Godot;
using System;

public class Gun : Node2D {

	public float FireRate { get; set; }
	public float Delta { get; set; }

	// the layer which this gun will shoot bullets to
	public uint HostileLayer { get; set; }
	
	protected Node Scene { get; set; }
	protected KinematicBody2D Parent { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Parent = GetParent<KinematicBody2D>();
		Scene = Parent.GetParent();
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
