using Godot;
using System;

public class NextStageDisplayer : Control {

	public void NextStage() {
		// if this is THE LAST level
		if (PickupLevel.CurrentLevel == PickupLevel.FinalLevel) {
			GD.Print("Ending Scene not implemented");
			return;
		}
		// restart music time stamp
		PickupMusic.D = 0;
		// dealing with level
		// saving these information to files is the job of level managers
		// so here does nothing else than changing scenes
		GetTree().ChangeScene(string.Format("res://Asset/Level/Level{0}.tscn", PickupLevel.CurrentLevel + 1));
	}
}
