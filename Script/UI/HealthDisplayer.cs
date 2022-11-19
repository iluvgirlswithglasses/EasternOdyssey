using Godot;

public class HealthDisplayer : Control {

	// the healthbar MUST BE LOADED before the object which use it does

	public int MaxHealth;
	
	public ProgressBar bar;
	public Label label;

	public override void _Ready() {
		base._Ready();
		bar = (ProgressBar) GetNode("Bar");
	}

	public void SetMaxHealth(int h) {
		MaxHealth = h;
		bar.MaxValue = MaxHealth;
	}

	public void SetCurrentHealth(int h) {
		if (h < 0) h = 0;
		if (h > MaxHealth) h = MaxHealth;
		bar.Value = h;
	}

	public void SetLabel(string s) {
		label.Text = s;
	}
}
