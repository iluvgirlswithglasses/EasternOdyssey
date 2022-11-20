using Godot;

public abstract class CollectibleItem : KinematicBody2D {

    public Vector2 Velocity = new Vector2(0, 0);
    public Node Scene;
    public Player PlayerObj;

    [Export]
    public float Acceleration = -75f;

    public override void _Ready() {
        this.Layers = Constants.PLAYER_LAYER;
        this.CollisionLayer = Constants.PLAYER_LAYER;
        Scene = GetTree().Root.GetChild(0);
        PlayerObj = (Player) Scene.GetNode("Player");
    }

    public override void _Process(float delta) {
        base._Process(delta);
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
                    GetParent().RemoveChild(this);
                }
            }
        }
    }

    public virtual void OnPlayerContact() {

    }
}
