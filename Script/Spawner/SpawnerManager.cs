using Godot;
using System;
using System.Collections.Generic;

// this class should have been named "Level manager" tbh

public class SpawnerManager : Node2D {
	
	// Stage[i]: All Spawner of a Phase
	public List<List<Spawner>> Stage = new List<List<Spawner>>();
	// Collectible[i]: The item dropped to player once they've finish Phase[i]
	public List<string> Collectible;

	public int CurrentPhase;
	private bool IsGameOver = false;
	
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

	private Vector2 ScreenSize;
	protected Node Scene;
	protected AudioStreamPlayer AudioPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		CurrentPhase = -1;
		ScreenSize = GetViewportRect().Size;
		Scene = GetTree().Root.GetChild(0);
		AudioPlayer = (AudioStreamPlayer) GetTree().Root.GetChild(0).GetNode("BackgroundMusicPlayer");
		Player = (Actor) Scene.GetNode("Player");
		Stat = (StatDisplayer) Scene.GetNode("StatDisplayer");
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
		if (IsGameOver) return;
		
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

			// spawn collectible
			if (Collectible[CurrentPhase] != "") {
				PackedScene itemScene = (PackedScene) GD.Load(
					string.Format("res://Asset/Object/Collectible/{0}.tscn", Collectible[CurrentPhase])
				);
				CollectibleItem item = (CollectibleItem) itemScene.Instance();
				Scene.AddChild(item);
				item.Position = new Vector2(
					ScreenSize.x * 2 / 3,
					ScreenSize.y / 2
				);
			}

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
			Stat.AutoDisappear = false;
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
		// remove all strays bullets
		foreach (Node i in Scene.GetChildren()) {
			if (i.IsInGroup("EnemyBullet")) {
				Bullet b = i as Bullet;
				b.Destroy();
			}
		}
		// remove unnecessary ui element
		Scene.GetNode<Control>("PlayerHealthBar").Visible = false;
		Scene.GetNode<Control>("BossHealthBar").Visible = false;
		// 
		if (PickupLevel.CurrentLevel == PickupLevel.FinalLevel) {
			// the player won the game

			// if the player pressed "continue" on the title scene
			// the last level will be played
		} else {
			// go to next stage
			Scene.GetNode<Control>("NextStageDisplayer").Visible = true;
		}
	}

	/** @ game over */
	public virtual void GameOver() {
		// remove all ui element
		foreach (Node i in Scene.GetChildren()) {
			if (i is Control) {
				Control j = i as Control;
				j.Visible = false;
			}
		}
		//
		GameOverDisplayer displayer = (GameOverDisplayer) Scene.GetNode("GameOverDisplayer");
		displayer.Visible = true;
		displayer.Score.Text = String.Format("Score: {0}", StagePoint + PhasePoint);
		IsGameOver = true;
		AudioPlayer.VolumeDb = -12;
	}

	public virtual void Retry() {
		PickupMusic.D = AudioPlayer.GetPlaybackPosition();
		GetTree().ReloadCurrentScene();
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
