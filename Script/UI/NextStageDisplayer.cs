using Godot;
using System;

public class NextStageDisplayer : Control {

	public void NextStage() {
		GetTree().ChangeScene(string.Format("res://Asset/Level/Level{0}.tscn", PickupLevel.CurrentLevel));
	}
}
