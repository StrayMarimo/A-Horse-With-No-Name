// This script contains the function to save and load the highscores from an XML file
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
public class XMLManager : MonoBehaviour
{
    public static XMLManager instance;
    public Leaderboard leaderboard;
    private string filePath;
    private string fileName = "highscores.xml";
    
    // called when the game starts
    void Awake()
    {
        // set file path to application data path
        filePath = Application.persistentDataPath + "/HighScores/";
        // create singleton
        instance = this;

        // create directory for XML file if it doesn't exist
        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);
        
    }

    /// <summary>
    /// Saves the given list of high scores to an XML file.
    /// </summary>
    /// <param name="scoresToSave"></param>
    public void SaveScores(List<HighScoreEntry> scoresToSave)
    {
        // save scores to list
        leaderboard.list = scoresToSave;
        // create serializer
        XmlSerializer serializer = new(typeof(Leaderboard)); 
        // create file stream to save to XML file in application data path
        FileStream stream = new(filePath + fileName, FileMode.Create);
        // serialize and save to file
        serializer.Serialize(stream, leaderboard);
        // close file stream
        stream.Close();
    }

    /// <summary>
    /// Loads the high scores from an XML file.
    /// </summary>
    /// <returns></returns>
    public List<HighScoreEntry> LoadScores()
    {
        // if file exists, load from file
        if (File.Exists(filePath + fileName))
        {
            // create serializer
            XmlSerializer serializer = new(typeof(Leaderboard));
            // create file stream to load from XML file in application data path
            FileStream stream = new(filePath + fileName, FileMode.Open);
            // deserialize and load from file
            leaderboard = serializer.Deserialize(stream) as Leaderboard;
            // close file stream
            stream.Close();
        }
        // else return empty list
        return leaderboard.list;
    }
}
[System.Serializable]
public class Leaderboard
{
    public List<HighScoreEntry> list = new();
}