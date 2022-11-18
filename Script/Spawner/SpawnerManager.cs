using Godot;
using System;
using System.Collections.Generic;

public class SpawnerManager : Node {
	
	// Stage[i]: All Spawner of a Phase
	public List<List<Spawner>> Stage = new List<List<Spawner>>();

	public int CurrentPhase;
	
	// statistics of THE WHOLE STAGE
	public int StageKillCount;
	public int StageEnemyCount;
	public int StagePoint;

	// statistics of CURRENT PHASE ONLY
	public int PhaseEnemyCount;
	public int PhaseLossCount;
	public int PhaseKillCount;
	public int PhasePoint;
	public int PhaseEnterHealth;	// the health of the player before the phase starts

	private Actor Player;
	private StatDisplayer Stat;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		CurrentPhase = -1;
		Player = (Actor) GetParent().GetNode("Player");
		Stat = (StatDisplayer) GetParent().GetNode("StatDisplayer");
		NextPhase();
	}

	/** @ basic */
	// player's kill count
	public void CountKill(int pts) {
		PhaseKillCount++;
		StageKillCount++;
		PhasePoint += pts;
		StagePoint += pts;
		CountLoss();
	}

	// number of enemy that's done there role
	public void CountLoss() {
		PhaseLossCount++;
		GD.Print(String.Format("Loss={0}", PhaseLossCount));
		if (PhaseLossCount == PhaseEnemyCount) {
			// gather stats
			float percentage = (float) PhaseKillCount / PhaseEnemyCount * 100f;
			int bonusPoint = 0;
			if (Player.Health == PhaseEnterHealth) {
				bonusPoint = PhasePoint;
			}
			StagePoint += bonusPoint;

			// announce stats
			Stat.Annoucement.Text = string.Format("Phase {0} Completed !", CurrentPhase + 1);
			Stat.EnemyCount.Text = PhaseEnemyCount.ToString();
			Stat.KillCount.Text = PhaseKillCount.ToString();
			Stat.KillPercentage.Text = string.Format("{0}%", percentage.ToString("0.00"));
			Stat.GainedPoint.Text = PhasePoint.ToString();
			Stat.HitlessBonus.Text = bonusPoint.ToString();
			Stat.TotalPoint.Text = StagePoint.ToString();

			Stat.Display();

			// reset & move to next phase
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
		// statistics
		PhaseEnemyCount = 0;
		PhaseLossCount = 0;
		PhaseKillCount = 0;
		PhasePoint = 0;
		PhaseEnterHealth = Player.Health;
		//
		CurrentPhase++;
		if (CurrentPhase == Stage.Count) {
			StageComplete();
			return;
		}
		// spawner
		PhaseEnemyCount = CountEnemyInPhase(CurrentPhase);
		GD.Print(String.Format("Phase = {0}; Count = {1}", CurrentPhase, PhaseEnemyCount));
		// enable spawners in this phase
		foreach (Spawner s in Stage[CurrentPhase]) {
			s.SetProcess(true);
			s.PlayPhaseMusic();
		}
	}

	public virtual void StageComplete() {
		// edit this later
		GetParent().RemoveChild(this);
	}

	/** @ tools */
	public void AddPhase(List<string> ls) {
		List<Spawner> objs = new List<Spawner>();
		foreach (string i in ls) {
			Spawner child = GetNode<Spawner>(i);
			// spawners are disable before their phase begins
			child.SetProcess(false);
			objs.Add(child);
		}
		Stage.Add(objs);
	}
}
