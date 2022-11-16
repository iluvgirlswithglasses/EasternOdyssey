using Godot;
using System;
using System.Collections.Generic;

public class Level1Manager : SpawnerManager {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		AddPhase(new List<int>(){0});
		AddPhase(new List<int>(){1, 2});
		AddPhase(new List<int>(){3, 4});
		base._Ready();
	}

}
