using Godot;
using static System.Math;

public class Clownpiece : VeloMovementEnemy {
	[Export]
	public int Speed = 0;
	[Export]
	public float RotateSpeed = 1f;

	public override void _Ready() {
		
		f = (d) => {
			return new Vector2(
				(float) Cos(d * RotateSpeed) * Speed,
				(float) Sin(d * RotateSpeed) * Speed
			);
		};
	}
}
