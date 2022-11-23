using Godot;

public class PlayerBullet : Bullet {
	static AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/SE/OnHit.mp3");
	
	public AudioStreamPlayer player;

	public override void _Ready() {
		base._Ready();
		stream.Loop = false;
		player = GetTree().Root.GetChild(0).GetNode<AudioStreamPlayer>("GunEffectPlayer");
	}

	public override void Destroy() {
		player.Stream = stream;
		player.Play();
		base.Destroy();
	}
}
