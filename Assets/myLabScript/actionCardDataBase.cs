using System.Collections.Generic;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif
using UnityEngine;
[CreateAssetMenu(fileName = "NewDatabase", menuName = "Base de données/ActionCards")]
public class actionCardDataBase : ScriptableObject
{
    private const string DataObjectPath = "/myLabScript/"; // path to the repository where there are action cards
    public myActionCard[] dataAsArray; // the container of all action cards

    // this method return the card with the id referenced
    public myActionCard Get(string id)
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
        dataAsArray = new myActionCard[paths.Length];
        for (var i = 0; i < paths.Length; i++)
        {
            var path = paths[i].Replace(Application.dataPath, "Assets");
            Debug.Log("Path to load : " + path);
            var asset = AssetDatabase.LoadAssetAtPath<myActionCard>(path);
            dataAsArray[i] = asset;
        }
    }
#endif
}
