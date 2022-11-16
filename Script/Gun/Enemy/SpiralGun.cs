using Godot;
using static System.Math;

public abstract class SpiralGun : Gun {

    protected PackedScene BulletScene;

    [Export]
    public int Damage = 10;
    [Export]
    public float Speed = 800.0f;
    [Export]
    public float Acceleration = 400.0f;
    [Export]
    public float RotateSpeed = 0.0f;
    [Export]
    public int BulletsPerShot = 24;

    public override void _Ready() {
        base._Ready();
        this.Target = "Player";
    }

    public override void Shoot() {
        double angle = 2 * PI / BulletsPerShot;
        for (int i = 0; i < BulletsPerShot; i++) {
            // calculations
            double alpha = angle * i;
            // add rotation here

            // prepare object
            BulletAdv bullet = (BulletAdv) BulletScene.Instance();
            bullet.Layers = Constants.NO_LAYER;
            bullet.CollisionLayer = Constants.PLAYER_LAYER;
            bullet.Target = this.Target;
            bullet.F = (obj) => { 
                double theta = alpha + RotateSpeed * obj.Delta;
                Vector2 velo = new Vector2(
                    (float) Cos(theta) * (Speed + obj.Delta * Acceleration), 
                    (float) Sin(theta) * (Speed + obj.Delta * Acceleration)
                );
                obj.Rotation = (float) theta;
                return velo; 
            };
            // launch
            Scene.AddChild(bullet);
            bullet.Position = this.GlobalPosition;
        }
    }
}
