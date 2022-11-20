using Godot;
using System;
using static System.Math;

public class YuukaSpiralGun : Node2D {

	protected PackedScene GunScene = (PackedScene) GD.Load("res://Asset/Gun/Enemy/SpiralGun.tscn");

	[Export] public string BulletSprite;

	[Export] public int SpiralCount;            // spiral per shot
	[Export] public float SpiralAngleDiff;      // angle different between each spiral
	[Export] public float SpiralTimeDiff;       // time different between each spiral
	[Export] public bool FixedLocation;         // if all the bullets should be shot at one single location

	[Export] public float FireRate;
	[Export] public float Delta;

	[Export] public int Damage = 10;
	[Export] public float Speed;
	[Export] public float Acceleration;
	[Export] public float RotateSpeed;

	[Export] public int BulletsPerShot = 24;

	public override void _Ready() {
		base._Ready();
		SpiralAngleDiff = SpiralAngleDiff / 180 * (float) PI;
		//
		for (int i = 0; i < SpiralCount; i++) {
			SpiralGun gun = (SpiralGun) GunScene.Instance();

			// spiral gun class
			gun.BulletsPerShot = BulletsPerShot;
			gun.Alpha = i * SpiralAngleDiff;
			// gun adv
			gun.BulletSprite = BulletSprite;
			gun.Damage = Damage;
			gun.Acceleration = Acceleration;
			gun.Speed = Speed;
			gun.RotateSpeed = RotateSpeed;
			// gun class
			gun.FireRate = FireRate;
			gun.Delta = Delta + i * SpiralTimeDiff;
			
			// add to world
			this.AddChild(gun);
		}
	}
}
