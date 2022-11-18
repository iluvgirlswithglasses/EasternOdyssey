using Godot;
using static System.Math;

public class MoonRabit : VeloMovementEnemy {
	
	[Export]
	public int Speed = 0;
	[Export]
	public float RotateSpeed = 1f;

	public override void _Ready() {
		f = (d) => {
			// the first 3 seconds
			if (d < 3.0) {
				return new Vector2(-120f * (float) Cos(d/3), 0);
			}
			// the rest
			return new Vector2(
				(float) Cos((d - 2) * RotateSpeed) * Speed,
				(float) Sin(- PI/4 + (d - 2) * RotateSpeed) * Speed * 0.45f
			);
		};
	}

	public override void ProcessOutOfScreen() {
		// take no action
	}
}
