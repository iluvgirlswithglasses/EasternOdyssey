using Godot;
using System;

static public class PickupLevel {
    // the last level that the player's playing on
    static public int CurrentLevel = 1;
    // the last level of this game
    static public int FinalLevel = 3;

    static public string SaveFileDir = "user://eastern_odyssey_save_file.dat";
    static public File SaveFile = new File();

    static public void GetLevelFromFile() {
        if (SaveFile.FileExists(SaveFileDir)) {
            SaveFile.Open(SaveFileDir, File.ModeFlags.Read);
            CurrentLevel = Convert.ToInt32(SaveFile.GetAsText());
            SaveFile.Close();
        }
    }

    static public void SaveLevelToFile() {
        SaveFile.Open(SaveFileDir, File.ModeFlags.Write);
        SaveFile.StoreString(CurrentLevel.ToString());
        SaveFile.Close();
    }
}
