using Godot;
using static System.Math;

public class MoonRabit : VeloMovementEnemy {
	
	[Export]
	public int Speed = 0;
	[Export]
	public float RotateSpeed = 1f;

	private HealthDisplayer healthDisp;

	private AudioStreamMP3 DeathSE = (AudioStreamMP3) GD.Load("res://Audio/SE/BossDeath.mp3");
	private AudioStreamPlayer SEPlayer;

	public override void _Ready() {
		base._Ready();
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
		
		// healthbar
		healthDisp = (HealthDisplayer) GetTree().Root.GetChild(0).GetNode("BossHealthBar");
		healthDisp.SetMaxHealth(Health);
		healthDisp.SetCurrentHealth(Health);
		healthDisp.SetLabel("BOSS: ");
		healthDisp.Visible = true;

		//
		DeathSE.Loop = false;
		SEPlayer = GetTree().Root.GetChild(0).GetNode<AudioStreamPlayer>("ExplosionPlayer");
	}

	public override void TakeDamage(int d) {
		base.TakeDamage(d);
		healthDisp.SetCurrentHealth(Health);
	}

	public override void AnnounceKill() {
		SEPlayer.Stream = DeathSE;
		SEPlayer.Play();
	}

	public override void ProcessOutOfScreen() {
		// take no action
	}
}
