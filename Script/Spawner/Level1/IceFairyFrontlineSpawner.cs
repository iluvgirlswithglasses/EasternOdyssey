using Godot;
using static System.Math;

public class IceFairyFrontlineSpawner : Spawner {

	private PackedScene fairyScene = (PackedScene) GD.Load("res://Asset/Object/Enemy/IceFairy.tscn");
	private float fairySpeed = 100f;

	[Export]
	public int XDirection = 1;
	[Export]
	public int YDirection = 1;
	[Export]
	public double XRadMod = 1;
	[Export]
	public int Health = 5;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
	}

	protected override void Spawn() {
		IceFairy fairy = (IceFairy) fairyScene.Instance();
		fairy.Health = Health;
		fairy.f = (d) => { 
			return new Vector2(XDirection * fairySpeed * (float) Cos(d * XRadMod), YDirection * fairySpeed); 
		};
		// add
		Scene.AddChild(fairy);
		fairy.Position = GlobalPosition;
	}
}
