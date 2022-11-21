using Godot;

public partial class TitleScene : Control {
	// one of the buttons is clicked
	public bool Clicked = false;

	private AudioStreamPlayer backgroundPlayer;
	private AudioStreamPlayer effectPlayer;

	public override void _Ready() {
		base._Ready();
		backgroundPlayer = (AudioStreamPlayer) GetNode("BackgroundMusicPlayer");
		effectPlayer = (AudioStreamPlayer) GetNode("EffectPlayer");

		// Scarlet Beyond a Crimson Dream 
		AudioStreamMP3 stream = (AudioStreamMP3) GD.Load("res://Audio/Background/TitleScene.mp3");
		backgroundPlayer.Stream = stream;
		backgroundPlayer.Play();
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
}
