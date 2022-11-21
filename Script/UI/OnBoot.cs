using Godot;

public class OnBoot : Node2D {
	public override void _Ready() {
		base._Ready();
		// load level
		PickupLevel.GetLevelFromFile();
		GD.Print("Picked up level: ", PickupLevel.CurrentLevel);
		// to title scene
		GetTree().ChangeScene("res://Asset/TitleScene/TitleScene.tscn");
	}
}
