using Godot;

static public class ScreenTool {
    static public bool IsOutOfScreen(Vector2 s, Vector2 p) {
        return p.x < 0 || s.x <= p.x || p.y < 0 || s.y <= p.y;
    }
}
