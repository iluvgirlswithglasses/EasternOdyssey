using Godot;

public class GameCompleteDisplayer : GameOverDisplayer {

	public float Delta;
	public float AnimationDuration = Constants.PHASE_TRANSITION_TIME - 0.5f;

	public override void _Ready() {
		base._Ready();
		this.Modulate = new Color(0, 0, 0, 0);
		this.Visible = false;
		this.SetProcess(false);
	}

	public override void _Process(float delta) {
		Delta += delta;
		if (AnimationDuration < Delta) {
			Modulate = new Color(1, 1, 1, (Delta - AnimationDuration) / AnimationDuration);
		}
		if (Delta >= AnimationDuration * 2) {
			SetProcess(false);
		}
	}
}
