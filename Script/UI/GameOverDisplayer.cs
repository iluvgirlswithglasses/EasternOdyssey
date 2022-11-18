using Godot;
using System;

public class GameOverDisplayer : Control {

	SpawnerManager manager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		manager = (SpawnerManager) GetTree().Root.GetChild(0).GetNode("SpawnerManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		
	}

	private void _on_Retry_button_down() {
		manager.Retry();
	}
}
