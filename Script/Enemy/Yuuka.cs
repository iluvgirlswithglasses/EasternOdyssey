using Godot;
using System;
using static System.Math;

public class Yuuka : VeloMovementEnemy {
	
	[Export]
	public int Speed = 0;
	[Export]
	public float RotateSpeed = 1f;

	private HealthDisplayer healthDisp;

	public override void _Ready() {
		base._Ready();
		f = (d) => {
			// the first 3 seconds
			if (d < 3.0) {
				return new Vector2(-120f * (float) Cos(d/3), 0);
			}
			// the rest
			return new Vector2(
				0,
				0
			);
		};
		
		// healthbar
		healthDisp = (HealthDisplayer) GetTree().Root.GetChild(0).GetNode("BossHealthBar");
		healthDisp.SetMaxHealth(Health);
		healthDisp.SetCurrentHealth(Health);
		healthDisp.SetLabel("BOSS: ");
		healthDisp.Visible = true;
	}

	public override void TakeDamage(int d) {
		base.TakeDamage(d);
		healthDisp.SetCurrentHealth(Health);
	}

	public override void ProcessOutOfScreen() {
		// do nothing
	}
}
