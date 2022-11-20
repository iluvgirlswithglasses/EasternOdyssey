using Godot;
using System;
using static System.Math;

public class Yuuka : VeloMovementEnemy {

	private HealthDisplayer healthDisp;
	private int phase = 0;
	private int[] Thresholds = {900, 0};

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
		for (int i = 0; i < Thresholds.GetLength(0); i++) {
			SetGunSetState(i, false);
		}
		SetGunSetState(0, true);
	}

	public override void TakeDamage(int d) {
		base.TakeDamage(d);
		healthDisp.SetCurrentHealth(Health);
		if (Health <= 0)
			return;
		// 
		if (Health <= Thresholds[phase]) {
			SetGunSetState(phase, false);
			phase++;
			SetGunSetState(phase, true);
		}
	}

	public override void ProcessOutOfScreen() {
		// do nothing
	}

	protected void SetGunSetState(int i, bool state) {
		foreach (Node2D node in GetNode<Node2D>(string.Format("GunSet{0}", i)).GetChildren()) {
			node.SetProcess(state);
		}
	}
}
