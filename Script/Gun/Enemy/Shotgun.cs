using Godot;
using System;
using static System.Math;

public class Shotgun : SpiralGun {
    [Export]
    public double DegDirection = -180;
    public double Direction;
    [Export]
    public double BulletSpanDeg = 30;
    public double BulletSpan;
    public double BulletGap;

    public override void _Ready() {
        base._Ready();
        // BulletsPerShot MUST BE >= 2
        BulletSpan = BulletSpanDeg / 180 * PI;
        BulletGap = BulletSpan / (BulletsPerShot - 1);

        Direction = DegDirection / 180 * PI;
        Direction -= BulletSpan / 2;
    }

    public override void Shoot() {
        for (int i = 0; i < BulletsPerShot; i++) {
            double alpha = Direction + i * BulletGap;
            ShootBullet(alpha);
        }
    }
 }
