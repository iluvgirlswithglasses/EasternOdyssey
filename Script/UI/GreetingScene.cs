using Godot;

public partial class GreetingScene : Control {

	private float MaxTimeShown = Constants.PHASE_TRANSITION_TIME - 0.5f;
	private float AnimationDuration;

	// display mechanism
	private bool IsShown = false;
	private float TimeShown = 0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		AnimationDuration = MaxTimeShown / 3;

		Visible = false;
		Modulate = new Color(0, 0, 0, 0);
	}

	public override void _Process(float delta) {
		if (IsShown) {
			TimeShown += delta;

			if (TimeShown <= AnimationDuration)
				Modulate = new Color(1, 1, 1, TimeShown / AnimationDuration);
			if (TimeShown >= AnimationDuration * 2)
				Modulate = new Color(1, 1, 1, (MaxTimeShown - TimeShown) / AnimationDuration);

			if (TimeShown >= MaxTimeShown) {
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
