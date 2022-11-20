using Godot;
using System.Collections.Generic;

public class Level3Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
		AddPhase(new List<string>(){"PyroButterfly-00-00", "FireFairy-00-01"});
		base._Ready();
		
		Collectible = new List<string>(){
			"", "", "", "", "", "", "", "", "",
		};

		// Faraway Voyage of 380,000 Kilometers 
		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/Stage3.mp3");
		AudioPlayer.Stream = stream;
		AudioPlayer.Play(PickupMusic.D);
		AudioPlayer.VolumeDb = -2;
	}

}
