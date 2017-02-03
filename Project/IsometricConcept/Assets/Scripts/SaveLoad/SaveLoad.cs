using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class SaveLoad
{

    public static void SaveObjDict(Dictionary<Vector2, TileObj> dict, string fileName)
    {
        StringBuilder builder = new StringBuilder();
        foreach (KeyValuePair<Vector2, TileObj> pair in dict)
        {
            builder.Append(pair.Key.x).Append(' ').Append(pair.Key.y).Append(":").Append(pair.Value).Append(',');
        }
        string result = builder.ToString();
        result = result.TrimEnd(',');
        File.WriteAllText(fileName, result);
    }

    public static Dictionary<Vector2, TileObj> LoadObjDict(string fileName)
    {
        Dictionary<Vector2, TileObj> dict = new Dictionary<Vector2, TileObj>();
        string s = File.ReadAllText(fileName);
        string[] tokens = s.Split(new char[] { ':', ',' });
        for (int i = 0; i < tokens.Length; i += 2)
        {
            string name = tokens[i];
            string freq = tokens[i + 1];
            Vector2 coord = new Vector2(0,0);
            for (int l = 0; l < name.Length; ++l)
            {
                string[] values = name.Split(' ');
                coord = new Vector2(float.Parse(values[0]), float.Parse(values[1]));
            }
            dict.Add(coord, (TileObj)System.Enum.Parse(typeof(TileObj), freq));
        }
        return dict;
    }

}
