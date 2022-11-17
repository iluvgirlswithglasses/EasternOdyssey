using Godot;
using static System.Math;

public partial class ForwardFrontlineSpawner : Spawner {
	private PackedScene enemyScene;

	[Export]
	public string EnemyDir = "IceFairy";
	[Export]
	public int Health;
    [Export]
    public float FireRate = 1.25f;
	[Export]
	public float ForwardTime = 2;
	[Export]
	public float ForwardSpeed = -200f;
    [Export]
    public float YDistance = 75f;   // y distance between each enemy in this frontline
    [Export]
    public float TDistance = 0f;    // time distance ----

    protected int SpawnCount = 0;

	public override void _Ready() {
		base._Ready();
        enemyScene = (PackedScene) GD.Load(string.Format("res://Asset/Object/Enemy/{0}.tscn", EnemyDir));
	}

	protected override void Spawn() {
		VeloMovementEnemy enemy = (VeloMovementEnemy) enemyScene.Instance();
		enemy.Health = Health;
		enemy.Manager = Manager;
        enemy.ChangeFireRate(FireRate);

		enemy.f = (d) => {
            float localForwardTime = ForwardTime + TDistance * SpawnCount;
			if (d <= localForwardTime)
				// the speed of this object is changed by a Cos() function
				return new Vector2(
					(float) Cos((d / localForwardTime) * PI / 2) * ForwardSpeed,
					0f
				);
			// stop after forward time
			return new Vector2(0, 0);
		};
		// add
		Scene.AddChild(enemy);
		enemy.Position = new Vector2(
            GlobalPosition.x, 
            GlobalPosition.y + SpawnCount*YDistance
        );

        SpawnCount++;
	}
}
