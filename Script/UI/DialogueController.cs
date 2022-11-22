using Godot;
using System;
using System.Collections.Generic;

public class DialogueController : Control {

	protected float Delta;

	// the first dialogue is shown when scene starts
	// so current dialogue is the second one
	protected int CurrentDialogue = 1; 
	List<Label> Dialogues;

	protected Label Tutor;
	protected Control Container;

	public override void _Ready() {
		Tutor = GetNode<Label>("Tutorial");
		Container = GetNode<Control>("Container");

		Dialogues = new List<Label>();
		foreach (Label i in Container.GetChildren()) {
			i.Visible = false;
			Dialogues.Add(i);
		}
		Dialogues[0].Visible = true;

		Tutor.SelfModulate = new Color(0, 0, 0, 0);
	}

	public override void _Process(float delta) {
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

    }
}
