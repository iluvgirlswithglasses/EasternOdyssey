using Godot;
using System;

public class GameOverDisplayer : Control {

	private	SpawnerManager manager;
	public Label Score;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		manager = (SpawnerManager) GetTree().Root.GetChild(0).GetNode("SpawnerManager");
		Score = GetNode<Control>("VBoxContainer").GetNode<Label>("Score");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta) {
		
	}

	protected void _on_Retry_button_down() {
		manager.Retry();
	}

	protected virtual void _on_Title_button_down() {
		PickupMusic.D = 0f;	// turn off current stage's music
		GetTree().ChangeScene("res://Asset/TitleScene/TitleScene.tscn");
	}
}
