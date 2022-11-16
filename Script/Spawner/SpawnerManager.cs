using Godot;
using System;
using System.Collections.Generic;

public class SpawnerManager : Node {
	
	// Stage[i]: All Spawner of a Phase
	public List<List<Spawner>> Stage = new List<List<Spawner>>();

	public int CurrentPhase;
	
	public int StageKillCount { get; set; }
	public int StageEnemyCount { get; set; }

	public int PhaseLossCount { get; set; }
	public int PhaseEnemyCount { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		CurrentPhase = -1;
		NextPhase();
	}

	/** @ basic */
	// player's kill count
	public void CountKill() {
		StageKillCount++;
		PhaseLossCount++;
		GD.Print(String.Format("Loss={0}", PhaseLossCount));
	}

	// number of enemy that's done there role
	public void CountLoss() {
		PhaseLossCount++;
		GD.Print(String.Format("Loss={0}", PhaseLossCount));
		if (PhaseLossCount == PhaseEnemyCount) {
			PhaseLossCount = 0;
			PhaseEnemyCount = 0;
			NextPhase();
		}
	}

	/** @ controller */
	// count the number of enemies in this phase
	public virtual int CountEnemyInPhase(int i) {
		uint res = 0;
		foreach (Spawner s in Stage[i])
			res += s.EnemyCount;
		return Convert.ToInt32(res);
	}

	// go to next phase
	public virtual void NextPhase() {
		CurrentPhase++;
		if (CurrentPhase == Stage.Count) {
			StageComplete();
			return;
		}
		PhaseEnemyCount = CountEnemyInPhase(CurrentPhase);
		GD.Print(String.Format("Phase = {0}; Count = {1}", CurrentPhase, PhaseEnemyCount));
		// enable spawners in this phase
		foreach (Spawner s in Stage[CurrentPhase])
			s.SetProcess(true);
	}

	public virtual void StageComplete() {
		// edit this later
		GetParent().RemoveChild(this);
	}

	/** @ tools */
	public void AddPhase(List<int> ls) {
		List<Spawner> objs = new List<Spawner>();
		foreach (int i in ls) {
			Spawner child = GetChild<Spawner>(i);
			// spawners are disable before their phase begins
			child.SetProcess(false);
			objs.Add(child);
		}
		Stage.Add(objs);
	}
}
