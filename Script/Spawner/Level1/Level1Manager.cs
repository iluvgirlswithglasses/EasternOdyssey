using Godot;
using System;
using System.Collections.Generic;

public class Level1Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		AddPhase(new List<string>(){"LightFairy-00-00", "LightFairy-00-01"});
		AddPhase(new List<string>(){"MoonRabitSpawner"});
		base._Ready();

		// The Space Shrine Maiden Appears
		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/Stage1.mp3");
		AudioPlayer.Stream = stream;
		AudioPlayer.Play(PickupMusic.D);
		AudioPlayer.VolumeDb = -2;
	}

}
