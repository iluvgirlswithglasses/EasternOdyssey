using Godot;
using System;
using System.Collections.Generic;

public class Level1Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		AddPhase(new List<string>(){"FireFairy-00-00"});
		AddPhase(new List<string>(){"FireFairy-01-00"});
		AddPhase(new List<string>(){"ClownpieceSpawner"});
		AddPhase(new List<string>(){"IceFairy-00-00", "IceFairy-00-01"});
		AddPhase(new List<string>(){"IceFairy-01-00", "IceFairy-01-01"});
		base._Ready();
	}

}
