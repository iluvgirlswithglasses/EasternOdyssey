using System;
using Godot;

public class PyroButterfly : VeloMovementEnemy {

	public SpiralShotgun gun;

	public override void _Ready(){
		base._Ready();
		gun = GetNode<SpiralShotgun>("Gun");
	}

	public override void ChangeRelativeToPlayer(int r) {
		gun.RelativeToPlayer = Convert.ToBoolean(r);
	}
}
