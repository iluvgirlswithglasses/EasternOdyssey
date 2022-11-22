using Godot;
using System;

public class NextStageDisplayer : Control {

	// this function WILL NOT BE CALLED by SpawnerManager
	// if the player has reached the last stage
	public void NextStage() {
		// restart music time stamp
		PickupMusic.D = 0;
		// dealing with level
		PickupLevel.CurrentLevel++;
		PickupLevel.SaveLevelToFile();
		GetTree().ChangeScene(string.Format("res://Asset/LevelDialogue/Level{0}.tscn", PickupLevel.CurrentLevel));
	}
}
