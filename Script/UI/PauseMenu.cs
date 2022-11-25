using Godot;
using System;

public class PauseMenu : Control {
	private SpawnerManager Manager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Manager = (SpawnerManager) GetTree().Root.GetChild(0).GetNode("SpawnerManager");
	}

	protected void Continue() {
		Manager.TooglePlaying();
	}

	protected void Retry() {
		Manager.Retry();
	}

	protected void ToTitle() {
		PickupMusic.D = 0f;	// turn off current stage's music
		GetTree().ChangeScene("res://Asset/TitleScene/TitleScene.tscn");
	}
}
