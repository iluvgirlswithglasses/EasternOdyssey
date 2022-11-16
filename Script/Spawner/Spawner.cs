using Godot;

public class Spawner : Node2D {

    public Node Scene;
    public SpawnerManager Manager;

    [Export]
    public uint EnemyCount { get; set; }
    [Export]
    public float SpawnRate { get; set; }

    // Waited time from spawn to action
    [Export]
    public float WaitTime { get; set; }
    protected bool Started { get; set; }

    private float Delta;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Scene = GetTree().Root.GetChild(0);
        Manager = GetParent<SpawnerManager>();
        // `Started` is set to true by default
        WaitTime = 0;
        Started = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        Delta += delta;
        if (!Started) {
            if (Delta >= WaitTime) {
                Started = true;
            } else {
                return;
            }
        }
        // if started
        if (Delta >= SpawnRate) {
            Delta -= SpawnRate;
            Spawn();
            if (--EnemyCount == 0) {
                GetParent().RemoveChild(this);
                return;
            }
        }
    }

    /** @ utils */
    protected virtual void Spawn() {

    }
}
