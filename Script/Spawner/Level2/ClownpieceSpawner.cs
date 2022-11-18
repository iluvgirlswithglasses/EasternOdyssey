using Godot;
using System;

public class ClownpieceSpawner : Spawner {
	private PackedScene clownpieceScene = (PackedScene) GD.Load("res://Asset/Object/Enemy/Clownpiece.tscn");

	public override void _Ready() {
		base._Ready();
		SpawnRate = 0;
		EnemyCount = 1;
	}

	protected override void Spawn() {
		Clownpiece clownpiece = (Clownpiece) clownpieceScene.Instance();
		clownpiece.Manager = Manager;
		Scene.AddChild(clownpiece);
		clownpiece.Position = this.GlobalPosition;
	}

	public override void PlayPhaseMusic() {
		// Pierrot of the Star ~ Spangled Banner 
		// AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/Clownpiece.mp3");
		// AudioStreamPlayer player = (AudioStreamPlayer) Scene.GetNode("AudioPlayer");
		// player.Stream = stream;
		// player.Play();
	}
}
