using Godot;
using static System.Math;

public class FireFairyFrontlineSpawner : Spawner {

	private PackedScene fairyScene = (PackedScene) GD.Load("res://Asset/Object/Enemy/FireFairy.tscn");

	[Export]
	public float FairySpeed = 100f;
	[Export]
	public int XDirection = 1;
	[Export]
	public int YDirection = 1;
	[Export]
	public double XRadMod = 1;
	[Export]
	public float XConst = 0;
	[Export]
	public int Health = 5;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
	}

	protected override void Spawn() {
		FireFairy fairy = (FireFairy) fairyScene.Instance();
		fairy.Health = Health;
		fairy.Manager = Manager;
		if (Point != 0)
			fairy.Point = Point;

		fairy.f = (d) => { 
			return new Vector2(
				XDirection * FairySpeed * (float) Cos(d * XRadMod) + XConst, YDirection * FairySpeed
			); 
		};
		// add
		Scene.AddChild(fairy);
		fairy.Position = GlobalPosition;
	}
}
