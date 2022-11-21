using Godot;
using System;
using System.Collections.Generic;

public class Level1Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		PickupLevel.CurrentLevel = 1;
		PickupLevel.SaveLevelToFile();

		AddPhase(new List<string>(){"LightFairy-00-00", "LightFairy-00-01"});
		AddPhase(new List<string>(){"WindFairy-01-00", "LightFairy-01-01", "LightFairy-01-02"});
		AddPhase(new List<string>(){"WindFairy-02-00", "WindFairy-02-01", "LightFairy-02-02"});	// heal
		AddPhase(new List<string>(){"IceFairy-03-00", "FireFairy-03-01"});
		AddPhase(new List<string>(){"LightFairy-04-00", "LightFairy-04-01", "WindFairy-04-02"});
		AddPhase(new List<string>(){"VertexFairy-05-00", "VertexFairy-05-01"});	// heal
		AddPhase(new List<string>(){"FireFairy-06-00", "IceFairy-06-01"});	// heal
		AddPhase(new List<string>(){"MoonRabitSpawner"});
		base._Ready();

		Collectible = new List<string>(){
			"", "", "HealingItem", "", "", "HealingItem", "HealingItem", "",
		};

		// The Space Shrine Maiden Appears
		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/Stage1.mp3");
		AudioPlayer.Stream = stream;
		AudioPlayer.Play(PickupMusic.D);
		AudioPlayer.VolumeDb = -2;
	}

}
