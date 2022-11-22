using Godot;
using System.Collections.Generic;

public class Level3Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
		AddPhase(new List<string>(){"PyroButterfly-00-00", "FireFairy-00-01"});
		AddPhase(new List<string>(){"LightFairy-01-00", "LightFairy-01-01", "LightFairy-01-02", "LightFairy-01-03", "ShotgunFairy-01-04"});
		AddPhase(new List<string>(){"FireFairy-02-00", "WindFairy-02-01", "LightFairy-02-02"});	// heal
		AddPhase(new List<string>(){"CryoButterfly-03-00", "WindFairy-03-01", "WindFairy-03-02"});
		AddPhase(new List<string>(){"ShotgunFairy-04-00", "WindFairy-04-01", "WindFairy-04-02"});	// heal
		AddPhase(new List<string>(){"VertexFairy-05-00", "LightFairy-05-01", "IceFairy-05-02"});
		AddPhase(new List<string>(){"CryoButterfly-06-00", "CryoButterfly-06-01"});	// heal
		AddPhase(new List<string>(){"IceFairy-07-00", "FireFairy-07-01", "IceFairy-07-02", "FireFairy-07-03", "ShotgunFairy-07-04"});	// heal
		AddPhase(new List<string>(){"YuukaSpawner"});
		
		base._Ready();
		
		Collectible = new List<string>(){
			"", "", "HealingItem", "", "HealingItem", "", "HealingItem", "HealingItem", "",
		};

		// Faraway Voyage of 380,000 Kilometers 
		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/Stage3.mp3");
		AudioPlayer.Stream = stream;
		AudioPlayer.Play(PickupMusic.D);
		AudioPlayer.VolumeDb = -2;
	}

}
