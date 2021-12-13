using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel(RatingManager rating) 
    {
        //Open up a Binary Formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //Decides where the file will be saved
        string path = Application.persistentDataPath + "/Level.dp";
        //Creates a file in the Path
        FileStream stream = new FileStream(path, FileMode.Create);
        //Create the save data and runs the Constructor instantly
        PlayerData data = new PlayerData(rating);

        //Insert the Data into the file
        formatter.Serialize(stream, data);
        //Close the File
        stream.Close();
    }

    public static PlayerData LoadPlayer() 
    {
        //Go to where the Save file will be stored
        string path = Application.persistentDataPath + "/Level.dp";
        //Check if a File exists in the path
        if (File.Exists(path))
        {
            //Open up a Binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //Opens the File in the path
            FileStream stream = new FileStream(path, FileMode.Open);

            //Converts Binary to the old readable format
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Close the file
            stream.Close();

            return data;
        }
        else //If it doesnt exist then return null
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
