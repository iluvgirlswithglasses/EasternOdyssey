using Godot;
using System;

static public class Constants {
	/*
	Since the player and her bullets would NEVER collide with each others
	these object will present in a layer

	And since the enemies and their bullets would VERY LIKELY to collide
	these object will present in a mask

	Why? Because Godot's collision sucks. That's why.
	*/
	// these are BIT MASKS
	static public uint NO_LAYER = 0;
	static public uint PLAYER_LAYER = 1;
	static public uint ENEMY_LAYER = 2;

	// default time gap between phases
	static public float PHASE_TRANSITION_TIME = 0.5f;
}
