using Godot;

public partial class PistolGun : Gun {

	private PackedScene bulletScene = (PackedScene) GD.Load("res://Asset/Object/Bullet/Player/Pistol.tscn");

	const int DAMAGE = 4;
	const float SPEED = 800.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		this.FireRate = 0.2f;
		this.HostileLayer = Constants.ENEMY_LAYER;
		this.Target = "Enemy";
	}

	public override void Shoot() {
		// setup bullet
		Bullet bullet = (Bullet) bulletScene.Instance();
		bullet.Init(DAMAGE, SPEED, 0.0f, 0.0f, this.HostileLayer, "Enemy");
		// add
		Scene.AddChild(bullet);
		bullet.Position = GlobalPosition;
	}
}
