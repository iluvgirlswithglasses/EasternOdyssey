using Godot;
using System;

class EndingDialogueController : DialogueController {
	public override void NextStage() {
		GetTree().ChangeScene("res://Asset/TitleScene/TitleScene.tscn");
	}
}
