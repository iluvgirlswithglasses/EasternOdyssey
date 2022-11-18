using Godot;

public class Spawner : Node2D {

    public Node Scene;
    public SpawnerManager Manager;

    [Export]
    public uint EnemyCount;
    [Export]
    public float SpawnRate;

    // Waited time from spawn to action
    [Export]
    public float WaitTime;
    protected bool Started;

    private float Delta;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Scene = GetTree().Root.GetChild(0);
        Manager = GetParent<SpawnerManager>();


        WaitTime += Constants.PHASE_TRANSITION_TIME;
        Started = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) {
        Delta += delta;
        if (!Started) {
            if (Delta >= WaitTime) {
                Delta = 0.0f;
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

    public virtual void PlayPhaseMusic() {
        
    }
}
