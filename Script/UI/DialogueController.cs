using Godot;
using System;
using System.Collections.Generic;

public class DialogueController : Control {

	protected float Delta;

	// the first dialogue is shown when scene starts
	// so current dialogue is the second one
	protected int CurrentDialogue = 1; 
	List<Label> Dialogues;

	protected AudioStreamPlayer AudioPlayer;
	protected Label Tutor;
	protected Control Container;

	public override void _Ready() {
		Tutor = GetNode<Label>("Tutorial");
		Container = GetNode<Control>("Container");
		AudioPlayer = GetNode<AudioStreamPlayer>("BackgroundMusic");

		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/doll.mp3");
		AudioPlayer.Stream = stream;
		AudioPlayer.VolumeDb = -4;
		AudioPlayer.Play();

		Dialogues = new List<Label>();
		foreach (Label i in Container.GetChildren()) {
			i.Visible = false;
			Dialogues.Add(i);
		}
		Dialogues[0].Visible = true;

		Tutor.SelfModulate = new Color(0, 0, 0, 0);
	}

	public override void _PhysicsProcess(float delta) {
		// tutorial animation
		Delta += delta;
		Tutor.SelfModulate = new Color(1, 1, 1, (float) Math.Cos(Delta));
		// dialogue
		if (Input.IsActionJustPressed("next_dialogue")) {
			if (CurrentDialogue == Dialogues.Count) {
				NextStage();
			} else {
				Dialogues[CurrentDialogue++].Visible = true;
			}
		}
	}

	public virtual void NextStage() {
		GetTree().ChangeScene(string.Format("res://Asset/Level/Level{0}.tscn", PickupLevel.CurrentLevel));
	}
}
