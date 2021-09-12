using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ItemCollection")]
public class ItemContainer {

    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    //////    public static List<Item> items = new List<Item>();
    public List<Item> items = new List<Item>();

  public static ItemContainer Load(string path)
    ////    public ItemContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        StringReader reader = new StringReader(_xml.text);

        ItemContainer items_tmp = serializer.Deserialize(reader) as ItemContainer;

        reader.Close();

        return items_tmp;
    }


    public static void Save(string path, ItemContainer items_par)
    {
  
        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        FileStream stream = new FileStream(path, FileMode.Create);

        serializer.Serialize(stream, items_par);

        stream.Close();

        return ;
    }







}
