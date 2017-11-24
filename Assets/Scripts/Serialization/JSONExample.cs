using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class JSONExample : MonoBehaviour
{
    Transform boxes;
    void Start()
    {
        boxes = transform;
    }

    public void Load()
    {
        BoxesContainer boxesContainer = new BoxesContainer();
        boxesContainer = boxesContainer.Load();
        foreach (Box b in boxesContainer.boxes)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.SetParent(boxes);
            obj.transform.position = b.GetPositions();
            obj.transform.rotation = b.GetRotation();
        }
        boxesContainer.Save();
    }

    public void Save()
    {
        BoxesContainer boxesContainer = new BoxesContainer();
        foreach (Transform t in boxes)
        {
            boxesContainer.boxes.Add(new Box(t.position, t.rotation));
        }
        boxesContainer.Save();
    }

    public class BoxesContainer
    {
        public List<Box> boxes = new List<Box>();
        public BoxesContainer Load()
        {
            using (System.IO.StreamReader file =
             new System.IO.StreamReader(Application.persistentDataPath + "/Boxes.json"))
            {
                string input ="";
                while (!file.EndOfStream)
                    input+= file.ReadLine();
                return JsonUtility.FromJson<BoxesContainer>(input);
            }
        }

        public void Save()
        {
            using (System.IO.StreamWriter file =
             new System.IO.StreamWriter(Application.persistentDataPath + "/Boxes.json"))
            {
                file.WriteLine(JsonUtility.ToJson(this));
            }
        }

        public BoxesContainer() { }
    }

    [Serializable]
    public class Box
    {
        public float pX;
        public float pY;
        public float pZ;
        public float rX;
        public float rY;
        public float rZ;
        public float rW;
        public Box() { }
        public Box(Vector3 pos, Quaternion rot)
        {
            this.pX = pos.x;
            this.pY = pos.y;
            this.pZ = pos.z;
            this.rX = rot.x;
            this.rY = rot.y;
            this.rZ = rot.z;
            this.rW = rot.w;
        }

        public Quaternion GetRotation()
        {
            return new Quaternion(rX, rY, rZ, rW);
        }

        public Vector3 GetPositions()
        {
            return new Vector3(pX, pY, pZ);
        }
    }

}

