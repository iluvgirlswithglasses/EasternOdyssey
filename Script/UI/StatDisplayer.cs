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


	// display mechanism
	private float MaxTimeShown = Constants.PHASE_TRANSITION_TIME - 0.5f;
	public bool AutoDisappear = true;
	private float AnimationDuration;
	private bool IsShown = false;
	private float TimeShown = 0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Annoucement = (Label) GetNode("Container/Annoucement");
		EnemyCount = (Label) GetNode("Container/EnemyCount");
		KillCount = (Label) GetNode("Container/KillCount");
		KillPercentage = (Label) GetNode("Container/KillPercentage");
		GainedPoint = (Label) GetNode("Container/GainedPoint");
		HitlessBonus = (Label) GetNode("Container/HitlessBonus");
		TotalPoint = (Label) GetNode("Container/TotalPoint");

		AnimationDuration = MaxTimeShown / 3;

		Visible = false;
		Modulate = new Color(0, 0, 0, 0);
	}

	public override void _Process(float delta) {
		if (IsShown) {
			TimeShown += delta;

			if (TimeShown <= AnimationDuration)
				Modulate = new Color(1, 1, 1, TimeShown / AnimationDuration);
			
			if (AutoDisappear && TimeShown >= AnimationDuration * 2)
				Modulate = new Color(1, 1, 1, (MaxTimeShown - TimeShown) / AnimationDuration);

			if (AutoDisappear && TimeShown >= MaxTimeShown) {
				IsShown = false;
				TimeShown = 0f;
				Visible = false;
			}
		} else {
			Modulate = new Color(0, 0, 0, 0);
			SetProcess(false);
		}
	}

	public void Display() {
		IsShown = true;
		TimeShown = 0f;
		Visible = true;
		SetProcess(true);
	}
}
