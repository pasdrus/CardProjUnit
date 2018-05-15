using System.Collections.Generic;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif
using UnityEngine;
[CreateAssetMenu(fileName = "NewDataBase", menuName = "DataBase/UtilCards")]
public class UtilCardDataBase : ScriptableObject
{
    private const string DataObjectPath = "/Cards/UtilCards/"; // path to the repository where there are action cards
    public UtilCardData[] dataAsArray; // the container of all action cards

    // this method return the card with the id referenced
    public UtilCardData Get(string id)
    {
        for (var i = 0; i < dataAsArray.Length; i++)
        {
            if (dataAsArray[i].Id.Equals(id))
                return dataAsArray[i];
        }
        return null;
    }

#if UNITY_EDITOR
    // load the data base
    [ContextMenu("Update Data Base")] // On the editor, allow programmer to update the database easily. Click on the cog-wheel at Right Top and select the option "Update Data Base".
    public void FillDatabase()
    {
        var paths = Directory.GetFiles(Application.dataPath + DataObjectPath, "*.asset", SearchOption.AllDirectories);
        dataAsArray = new UtilCardData[paths.Length];
        for (var i = 0; i < paths.Length; i++)
        {
            var path = paths[i].Replace(Application.dataPath, "Assets");
            Debug.Log("Path to load : " + path);
            var asset = AssetDatabase.LoadAssetAtPath<UtilCardData>(path);
            dataAsArray[i] = asset;
        }
    }
#endif
}
