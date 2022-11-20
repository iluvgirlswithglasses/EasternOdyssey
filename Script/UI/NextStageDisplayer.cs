using Godot;
using System;

public class NextStageDisplayer : Control {

	public void NextStage() {
		if (PickupLevel.CurrentLevel == PickupLevel.FinalLevel) {
			GD.Print("Ending Scene not implemented");
		}
		PickupMusic.D = 0;
		GetTree().ChangeScene(string.Format("res://Asset/Level/Level{0}.tscn", PickupLevel.CurrentLevel + 1));
	}
}
