using Godot;

public class YuukaSpawner : Spawner {
	private PackedScene yuukaScene = (PackedScene) GD.Load("res://Asset/Object/Enemy/Yuuka.tscn");

	public override void _Ready() {
		base._Ready();
		SpawnRate = 0;
		EnemyCount = 1;
	}

	protected override void Spawn() {
		Yuuka yuuka = (Yuuka) yuukaScene.Instance();
		yuuka.Manager = Manager;
		Scene.AddChild(yuuka);
		yuuka.Position = this.GlobalPosition;
	}
}
