using Godot;
using static System.Math;

public class Clownpiece : VeloMovementEnemy {
	[Export]
	public int Speed = 0;
	[Export]
	public float RotateSpeed = 1f;
	[Export]
	public int FurryThreshold = 150;

	private IceFairyGun pistol1;
	private IceFairyGun pistol2;
	private HealthDisplayer healthDisp;

	private AudioStreamMP3 DeathSE = (AudioStreamMP3) GD.Load("res://Audio/SE/BossDeath.mp3");
	private AudioStreamPlayer SEPlayer;

	public override void _Ready() {
		base._Ready();
		// some guns that are disabled by default
		pistol1 = GetNode<IceFairyGun>("PistolGun1");
		pistol2 = GetNode<IceFairyGun>("PistolGun2");
		pistol1.SetProcess(false);
		pistol2.SetProcess(false);
		// movement
		f = (d) => {
			// the first 2 seconds
			if (d < 4.0) {
				return new Vector2(-100, 0);
			}
			// the rest
			return new Vector2(
				(float) Cos(d * RotateSpeed) * Speed,
				(float) Sin(d * RotateSpeed) * Speed
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
		if (Health <= FurryThreshold) {
			pistol1.SetProcess(true);
			pistol2.SetProcess(true);
		}
		healthDisp.SetCurrentHealth(Health);
	}

	public override void AnnounceKill() {
		base.AnnounceKill();
		SEPlayer.Stream = DeathSE;
		SEPlayer.Play();
	}

	public override void ProcessOutOfScreen() {
		// take no action
	}
}
