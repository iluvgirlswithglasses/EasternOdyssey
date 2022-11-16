using Godot;
using System;

public class SpawnerManager : Node {
	
	public int StageKillCount { get; set; }
	public int StageEnemyCount { get; set; }

	public int PhaseLossCount { get; set; }
	public int PhaseEnemyCount { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	/** @ basic */
	// player's kill count
	public void CountKill() {
		StageKillCount++;
	}

	// number of enemy that's done there role
	public void CountLoss() {
		PhaseLossCount++;
		if (PhaseLossCount == PhaseEnemyCount) {
			PhaseLossCount = 0;
			PhaseEnemyCount = 0;
			NextPhase();
		}
	}

	/** @ controller */
	// go to next phase
	public virtual void NextPhase() {

	}
}
