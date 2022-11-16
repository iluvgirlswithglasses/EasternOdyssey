using Godot;

public class Spawner : Node2D {

    public Node Scene;

    [Export]
    public uint EnemyCount { get; set; }
    [Export]
    public float SpawnRate { get; set; }

    private float Delta;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Scene = GetParent();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        Delta += delta;
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
