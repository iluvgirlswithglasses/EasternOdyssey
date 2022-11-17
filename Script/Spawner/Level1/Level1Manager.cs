using Godot;
using System;
using System.Collections.Generic;

public class Level1Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		AddPhase(new List<string>(){"IceFairy-00-00", "IceFairy-00-01"});
		AddPhase(new List<string>(){"FireFairy-01-00", "FireFairy-01-01"});
		AddPhase(new List<string>(){"IceFairy-02-00", "FireFairy-02-01"});
		AddPhase(new List<string>(){"FireFairy-03-00", "IceFairy-03-01"});
		AddPhase(new List<string>(){"IceFairy-04-00"});
		AddPhase(new List<string>(){"IceFairy-05-00", "WindFairy-05-01"});
		AddPhase(new List<string>(){"ClownpieceSpawner", "ClownpieceSupportSpawner-00", "ClownpieceSupportSpawner-01"});
		base._Ready();
	}

}
