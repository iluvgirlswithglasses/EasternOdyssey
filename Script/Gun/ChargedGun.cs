using Godot;

public partial class ChargedGun : Gun {

	private PackedScene bulletScene = (PackedScene) GD.Load("res://Asset/Object/Bullet/Player/ChargedGun.tscn");
	private AnimatedSprite animation;

	[Export] public int DAMAGE = 8;
	[Export] public float SPEED = 2000.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		base._Ready();
		animation = GetNode<AnimatedSprite>("AnimatedSprite");
		animation.Frame = 0;
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
