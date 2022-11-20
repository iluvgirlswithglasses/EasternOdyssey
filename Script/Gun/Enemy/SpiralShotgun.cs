using Godot;
using static System.Math;

// simply multiple shotgun, shot in spiral direction
public class SpiralShotgun : Node2D {
    protected PackedScene GunScene; // the type MUST BE Shotgun or its descendant

    [Export]
    public string GunDir = "Shotgun";
    [Export]
    public int GunCount = 8;    // how many shotgun will this have
    [Export]
    public float FirstGunDirectionDeg = -180;   // the shooting direction of the middle gun
    public float FirstGunDirection;
    [Export]
    public float ShotgunSpanDeg = 360;
    public float ShotgunSpan;
    public float ShotgunGap;

    [Export] public float FireRate;
    [Export] public float Delta;

    [Export] public string BulletSprite;
    [Export] public int Damage;
    [Export] public float Speed;
    [Export] public float Acceleration;
    [Export] public float RotateSpeed;

    [Export] public float BulletSpanDeg = 30;
    [Export] public bool RelativeToPlayer = false;

    public override void _Ready() {
        base._Ready();
        GunScene = (PackedScene) GD.Load(
            string.Format("res://Asset/Gun/Enemy/{0}.tscn", GunDir)
        );
        //
        ShotgunSpan = ShotgunSpanDeg / 180 * (float) PI;
        ShotgunGap = ShotgunSpan / (GunCount - 1);
        FirstGunDirection = FirstGunDirectionDeg / 180 * (float) PI;
        FirstGunDirection -= ShotgunSpan / 2;
        // mount the guns on this node
        for (int i = 0; i < GunCount; i++) {
            Shotgun gun = (Shotgun) GunScene.Instance();

            // shotgun class
            gun.DegDirection = (FirstGunDirection + ShotgunGap * i) / PI * 180;
            gun.BulletSpanDeg = BulletSpanDeg;
            gun.RelativeToPlayer = RelativeToPlayer;

            // gun adv
            gun.BulletSprite = BulletSprite;
            gun.Damage = Damage;
            gun.Acceleration = Acceleration;
            gun.Speed = Speed;
            gun.RotateSpeed = RotateSpeed;

            // gun class
            gun.FireRate = FireRate;
            gun.Delta = Delta;

            // add to world
            this.AddChild(gun);
        }
    }

    public override void _Process(float delta) {
        base._Process(delta);
    }
}
