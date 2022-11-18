using Godot;
using System;

public class StatDisplayer : Control {

	public Label Annoucement;
	public Label EnemyCount;
	public Label KillCount;
	public Label KillPercentage;
	public Label HitlessBonus;
	public Label GainedPoint;
	public Label TotalPoint;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Annoucement = (Label) GetNode("Container/Annoucement");
		EnemyCount = (Label) GetNode("Container/EnemyCount");
		KillCount = (Label) GetNode("Container/KillCount");
		KillPercentage = (Label) GetNode("Container/KillPercentage");
		HitlessBonus = (Label) GetNode("Container/HitlessBonus");
		GainedPoint = (Label) GetNode("Container/GainedPoint");
		TotalPoint = (Label) GetNode("Container/TotalPoint");

		Visible = false;
	}

	// display mechanism
	private bool IsShown = false;
	private float TimeShown = 0f;

	private float MaxTimeShown = Constants.PHASE_TRANSITION_TIME - 0.5f;
	private float AppearAnimationStart = (Constants.PHASE_TRANSITION_TIME - 0.5f) / 3;
	private float DisappearAnimationStart = (Constants.PHASE_TRANSITION_TIME - 0.5f) * 2 / 3;

	public override void _Process(float delta) {
		if (IsShown) {
			TimeShown += delta;

			if (TimeShown <= AppearAnimationStart)
				SelfModulate = new Color(1, 1, 1, TimeShown / AppearAnimationStart);
			if (TimeShown >= DisappearAnimationStart)
				SelfModulate = new Color(1, 1, 1, 1 - (MaxTimeShown - TimeShown) / AppearAnimationStart);

			if (TimeShown >= MaxTimeShown) {
				IsShown = false;
				TimeShown = 0f;
				Visible = false;
				
			}
		}
	}

	public void Display() {
		IsShown = true;
		Visible = true;
	}
}
