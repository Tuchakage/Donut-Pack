using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveDict
{
    public static void SaveDictionary(LevelData level) 
    {
        //Get the Dictionary stored in the Level Manager
        var data = level.levelRating;
        var data2 = level.isLevelComplete;

        // Get string from Dictionaries.
        string value = GetLine(data);
        string value2 = GetLine(data2);
        string path = Application.persistentDataPath + "/dict.txt";
        string path2 = Application.persistentDataPath + "/dict2.txt";
        // Saves the Dictionary to the file
        File.WriteAllText(path, value);
        File.WriteAllText(path2, value2);

        // Get dictionary again.
        //var result = GetDict(Application.persistentDataPath + "/dict.txt");
        //foreach (var pair in result)
        //{
        //    Console.WriteLine("PAIR: " + pair);
        //    Debug.Log("Ibjec" + pair);
        //}
    }


    public static void LoadDictionary(LevelData level,Dictionary<string,int> rating, Dictionary<string, int> check) 
    {
        int r = 0;
        string path = Application.persistentDataPath + "/dict.txt";
        string path2 = Application.persistentDataPath + "/dict2.txt";
        if (File.Exists(path))
        {
            //Gets all the value in the dictionary
            var result = GetDict(path);

            foreach (var pair in result)
            {

                //If there is no key for this Level
                if (!rating.TryGetValue(pair.Key, out r))
                {
                    //Load the data of the dictionaries text file back into the actual Dictionaries
                    rating.Add(pair.Key, pair.Value);
                    Debug.Log("Creating " + pair + " dictionary");
                }
                else //If the Level already has a key
                {
                    rating[pair.Key] = pair.Value;
                    Debug.Log("Changing " + pair + " value in Dictionary");
                }
            }
        }
        else 
        {
            SaveDictionary(level);
            Debug.Log("Cant find");
        }

        var result2 = GetDict(path2);

        foreach (var pair in result2)
        {

            //Debug.Log("Data2: " + pair);
            if (!check.TryGetValue(pair.Key, out r))
            {
                //Load the data of the dictionaries text file back into the actual Dictionaries
                check.Add(pair.Key, pair.Value);
            }
            else //If the Level already has a key
            {
                check[pair.Key] = pair.Value;
            }
        }

        Debug.Log(Application.persistentDataPath);
    }

    public static void ClearDictionary(Dictionary<string, int> rating, Dictionary<string, int> check) 
    {
        //Gets all the value in the dictionary
        var result = GetDict(Application.persistentDataPath + "/dict.txt");
        var result2 = GetDict(Application.persistentDataPath + "/dict2.txt");
        
        foreach (var pair in result)
        {
            //Delete The Dictionary
            rating.Remove(pair.Key);
        }

        foreach (var pair in result2)
        {
            //Delete The Dictionary
            check.Remove(pair.Key);
        }
    }
    static string GetLine(Dictionary<string, int> data)
    {
        // Build up the string data.
        StringBuilder builder = new StringBuilder();
        foreach (var pair in data)
        {
            builder.Append(pair.Key).Append(":").Append(pair.Value).Append(',');
        }
        string result = builder.ToString();
        // Remove the end comma.
        result = result.TrimEnd(',');
        return result;
    }

    static Dictionary<string, int> GetDict(string file)
    {
        var result = new Dictionary<string, int>();
        string value = File.ReadAllText(file);
        // Split the string.
        string[] tokens = value.Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
        // Build up our dictionary from the string.
        for (int i = 0; i < tokens.Length; i += 2)
        {
            string name = tokens[i];
            string freq = tokens[i + 1];

            // Parse the int.
            int count = int.Parse(freq);
            // Add the value to our dictionary.
            if (result.ContainsKey(name))
            {
                result[name] += count;
            }
            else
            {
                result.Add(name, count);
            }
        }
        return result;
    }

}
