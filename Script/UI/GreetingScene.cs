using Godot;

// still a prototype
public partial class GreetingScene : Control {

	private float MaxTimeShown = Constants.PHASE_TRANSITION_TIME - 0.5f;
	private float AnimationDuration;

	// display mechanism
	private float TimeShown = 0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		AnimationDuration = MaxTimeShown / 3;
		Visible = true;
	}

	public override void _PhysicsProcess(float delta) {
		TimeShown += delta;
		
		if (TimeShown <= AnimationDuration)
			Modulate = new Color(1, 1, 1, TimeShown / AnimationDuration);
		else if (TimeShown >= AnimationDuration * 2)
			Modulate = new Color(1, 1, 1, (MaxTimeShown - TimeShown) / AnimationDuration);
		
		else if (TimeShown >= MaxTimeShown) {
			Modulate = new Color(0, 0, 0, 0);
			Visible = false;
			SetPhysicsProcess(false);
		}
	}
}
