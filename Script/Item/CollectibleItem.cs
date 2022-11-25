using Godot;

public abstract class CollectibleItem : KinematicBody2D {

    public Vector2 Velocity = new Vector2(0, 0);
    public Node Scene;
    public Player PlayerObj;

    [Export]
    public float Acceleration = -75f;

    public override void _Ready() {
        this.Layers = Constants.NO_LAYER;
        this.CollisionLayer = Constants.PLAYER_LAYER;
        Scene = GetTree().Root.GetChild(0);
        PlayerObj = (Player) Scene.GetNode("Player");
    }

    public override void _PhysicsProcess(float delta) {
        base._PhysicsProcess(delta);
        Velocity = new Vector2(
            Velocity.x + Acceleration * delta,
            0
        );
        Vector2 collision = MoveAndSlide(Velocity);
        if (collision != null) {
            for (int i = 0; i < GetSlideCount(); i++) {
                var collider = (KinematicBody2D) GetSlideCollision(i).Collider;
                if (collider.IsInGroup("Player")) {
                    OnPlayerContact();
                    if (this != null) GetParent().RemoveChild(this);
                    return;
                }
            }
        }
    }

    public virtual void OnPlayerContact() {

    }
}
