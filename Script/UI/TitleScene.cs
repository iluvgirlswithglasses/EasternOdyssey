using Godot;

public partial class TitleScene : Control {
	// one of the buttons is clicked
	public bool Clicked = false;

	private AudioStreamPlayer backgroundPlayer;
	private AudioStreamPlayer effectPlayer;

	private Node2D title;
	private Control menu;
	private Control tutor;

	public override void _Ready() {
		base._Ready();
		backgroundPlayer = (AudioStreamPlayer) GetNode("BackgroundMusicPlayer");
		effectPlayer = (AudioStreamPlayer) GetNode("EffectPlayer");

		// Scarlet Beyond a Crimson Dream 
		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/TitleScene.mp3");
		backgroundPlayer.Stream = stream;
		backgroundPlayer.Play();

		// open menu, hide tutorial
		title = GetNode<Node2D>("Title");
		menu = GetNode<Control>("Menu");
		tutor = GetNode<Control>("Tutorial");
		HideTutorial();
	}

	public void StartGame() {
		PickupLevel.CurrentLevel = 1;
		ContinueGame();
	}

	public void ContinueGame() {
		GetTree().ChangeScene(string.Format("res://Asset/Level/Level{0}.tscn", PickupLevel.CurrentLevel));
	}

	public void QuitGame() {
		GetTree().Quit();
	}

	public void ViewTutorial() {
		title.Visible = false;
		menu.Visible = false;
		tutor.Visible = true;
	}

	public void HideTutorial() {
		title.Visible = true;
		menu.Visible = true;
		tutor.Visible = false;
	}
}
