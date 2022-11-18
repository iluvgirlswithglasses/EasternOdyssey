using Godot;

public class MoonRabitSpawner : Spawner {
	private PackedScene enemyScene = (PackedScene) GD.Load("res://Asset/Object/Enemy/MoonRabit.tscn");

	public override void _Ready() {
		base._Ready();
		SpawnRate = 0;
		EnemyCount = 1;
	}

	protected override void Spawn() {
		MoonRabit moonRabbit = (MoonRabit) enemyScene.Instance();
		moonRabbit.Manager = Manager;
		Scene.AddChild(moonRabbit);
		moonRabbit.Position = this.GlobalPosition;
	}
}
