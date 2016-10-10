using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MonsterManager : MonoBehaviour
{
    public List<Monster> monsters = new List<Monster>();
    public string filePath;
    public string fileName;

    void Awake()
    {
        fileName = "MonstersInc";
        filePath = Application.dataPath + "/../" + fileName + "/Monsters.xml";
    }

	public void Save()
    {
        MonsterContainer monsterContainer = GetComponent<MonsterContainer>();
        monsterContainer.monsters = monsters;
        monsterContainer.Save(filePath);
    }
}
