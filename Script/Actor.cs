using Godot;
using System;

public class Actor : KinematicBody2D {

	[Export]
	public int Health { get; set; }
	public Vector2 Velocity { get; set; }
	[Export]
	public string ExplosionDir = "BasicExplosion";
	public PackedScene ExplosionScene;
	[Export]
	public float ExplosionScaleX = 3;
	public float ExplosionScaleY = 3;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		ExplosionScene = (PackedScene) GD.Load(
			String.Format("res://Asset/Object/Explosion/{0}.tscn", ExplosionDir)
		);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta) {
		
	}

	/** @ utils */
	public virtual void TakeDamage(int d) {
		Health -= d;
		if (Health <= 0) {
			SummonExplosion();
			GetParent().RemoveChild(this);
			AnnounceKill();
		}
	}

	public virtual void AnnounceKill() {

	}

	public virtual void SummonExplosion() {
		Explosion expl = (Explosion) ExplosionScene.Instance();
		expl.Scale = new Vector2(ExplosionScaleX, ExplosionScaleY);
		GetTree().Root.GetChild(0).AddChild(expl);
		expl.Position = this.GlobalPosition;
	}
}
