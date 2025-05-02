using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

public static class SaveSystem
{
    private static string path = "save.json";

    public static void Save(GameData data)
    {
        using (FileStream stream = new FileStream("save.dat", FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }

    public static GameData Load()
    {
        if (File.Exists("save.dat"))
        {
            using (FileStream stream = new FileStream("save.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (GameData)formatter.Deserialize(stream);
            }
        }
        else
        {
            return new GameData(); 
        }
    }

}

