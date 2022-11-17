using Godot;
using System;
using System.Collections.Generic;

public class Level1Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		AddPhase(new List<string>(){"FireFairy-00-00", "FireFairy-00-01"});
		AddPhase(new List<string>(){"ClownpieceSpawner"});
		base._Ready();
	}

}
