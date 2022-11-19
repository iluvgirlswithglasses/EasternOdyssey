using Godot;
using System;
using System.Collections.Generic;

public class Level2Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		AddPhase(new List<string>(){"IceFairy-04-00", "IceFairy-04-01"});
		AddPhase(new List<string>(){"IceFairy-05-00", "WindFairy-05-01"});	// NOTE: WindFairy at 0.2 FireRate is SPLENDID
		AddPhase(new List<string>(){"IceFairy-00-00", "IceFairy-00-01"});
		AddPhase(new List<string>(){"FireFairy-01-00", "FireFairy-01-01"});
		AddPhase(new List<string>(){"IceFairy-02-00", "IceFairy-02-01", "FireFairy-02-02"});
		AddPhase(new List<string>(){"FireFairy-03-00", "IceFairy-03-01"});
		AddPhase(new List<string>(){"WindFairySA-06-00", "WindFairySA-06-01", "IceFairy-06-02"});
		AddPhase(new List<string>(){"VertexFairy-07-00", "VertexFairy-07-01", "ShotgunFairy-07-02"});
		AddPhase(new List<string>(){"ClownpieceSpawner", "ClownpieceSupportSpawner-00", "ClownpieceSupportSpawner-01"});
		base._Ready();

		// The Space Shrine Maiden Appears
		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/Clownpiece.mp3");
		AudioPlayer = (AudioStreamPlayer) GetTree().Root.GetChild(0).GetNode("AudioPlayer");
		AudioPlayer.Stream = stream;
		AudioPlayer.Play(PickupMusic.D);
		AudioPlayer.VolumeDb = 0;
	}

}
