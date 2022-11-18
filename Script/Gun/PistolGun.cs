using Godot;

public partial class PistolGun : Gun {

	private PackedScene bulletScene = (PackedScene) GD.Load("res://Asset/Object/Bullet/Player/Pistol.tscn");

	[Export] public int DAMAGE = 4;
	[Export] public float SPEED = 2000.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		this.FireRate = 0.2f;
		this.Target = "Enemy";
	}

	public override void Shoot() {
		// setup bullet
		Bullet bullet = (Bullet) bulletScene.Instance();
		bullet.Init(DAMAGE, SPEED, 0.0f, 0.0f, Constants.ENEMY_LAYER, Constants.ENEMY_LAYER, "Enemy");
		// add
		Scene.AddChild(bullet);
		bullet.Position = GlobalPosition;
	}
}
