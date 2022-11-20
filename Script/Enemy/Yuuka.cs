using Godot;
using System;
using static System.Math;

public class Yuuka : VeloMovementEnemy {

	private HealthDisplayer healthDisp;
	private int phase = 0;

	[Export] public int FurryThreshold = 400;
	protected SpiralGun FurryGun;

	public override void _Ready() {
		base._Ready();
		f = (d) => {
			// the first 3 seconds
			if (d < 3.0) {
				return new Vector2(-120f * (float) Cos(d/3), 0);
			}
			// the rest
			return new Vector2(0, 0);
		};
		
		// healthbar
		healthDisp = (HealthDisplayer) GetTree().Root.GetChild(0).GetNode("BossHealthBar");
		healthDisp.SetMaxHealth(Health);
		healthDisp.SetCurrentHealth(Health);
		healthDisp.SetLabel("BOSS: ");
		healthDisp.Visible = true;
		
		// phases
		FurryGun = GetNode<SpiralGun>("FurryGun");
		FurryGun.SetProcess(false);
	}

	public override void TakeDamage(int d) {
		base.TakeDamage(d);
		healthDisp.SetCurrentHealth(Health);
		if (Health <= 0)
			return;
		// 
		if (Health <= FurryThreshold) {
			FurryGun.SetProcess(true);
		}
	}

	public override void ProcessOutOfScreen() {
		// do nothing
	}
}
