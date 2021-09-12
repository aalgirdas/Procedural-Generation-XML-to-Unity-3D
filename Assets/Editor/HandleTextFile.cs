using UnityEngine;
using UnityEditor;
using System.IO;

using System.Collections;

public class HandleTextFile
{
    [MenuItem("Tools/Write file")]
    static void WriteString()
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load("test") as TextAsset;

        //Print the text from the file
        Debug.Log(asset.text);



        int iNumber_OfObjects = 0;

        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject)); //typeof takes a type name    Mesh returns 0
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            Debug.Log("<color=red>iNumber :</color>  " + iNumber_OfObjects + " Name: " + g.name + " Type: " + g.GetType());
            Debug.Log(g.transform.localScale);
            Debug.Log(g.transform.localPosition);
            Debug.Log(g.transform.localRotation);
            Debug.Log("<color=blue> ParentName :</color>  " + ((g.transform.parent == null) ? "No-Parent" : g.transform.parent.gameObject.name));
            Debug.Log("<color=blue> ----------------------------------------------------------------------------------------------</color>  ");

            //       Destroy(g, .5f);
            //        yield return WaitForSeconds(10);
            iNumber_OfObjects++;
        }

        Debug.Log("Number of objects in the scene: " + iNumber_OfObjects);





    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
















}