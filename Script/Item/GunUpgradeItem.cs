using Godot;

public class GunUpgradeItem : CollectibleItem {
	public PackedScene Gun = (PackedScene) GD.Load("res://Asset/Gun/ChargedGun.tscn");

	public override void OnPlayerContact() {
		Gun gun = (Gun) Gun.Instance();
		PlayerObj.AddChild(gun);
		gun.Position = new Vector2(10, 0);
		GD.Print("here");
	}
}
