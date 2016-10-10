using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("MonsterCollection")]
public class MonsterContainer : MonoBehaviour
{
    [XmlArray("Monsters")]
    [XmlArrayItem("Monster")]
    public List<Monster> monsters = new List<Monster>();

    public void Save(string path)
    {


        var serializer = new XmlSerializer(typeof(MonsterContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static MonsterContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(MonsterContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as MonsterContainer;
        }
    }
}
