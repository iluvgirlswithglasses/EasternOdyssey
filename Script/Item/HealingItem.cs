using Godot;

public class HealingItem : CollectibleItem {
	[Export]
	public int HealValue = 10;

	public override void OnPlayerContact() {
		base.OnPlayerContact();
		PlayerObj.Heal(HealValue);
	}
}
