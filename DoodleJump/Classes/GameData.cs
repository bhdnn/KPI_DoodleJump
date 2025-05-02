using System;

[Serializable]
public class GameData
{
    public int coins = 0;
    public bool soccerUnlocked = false;
    public bool ninjaUnlocked = false;
    public bool nightNinjaUnlocked = false;

    public void AddCoins(int amount)
    {
        coins += amount;
    }
}
