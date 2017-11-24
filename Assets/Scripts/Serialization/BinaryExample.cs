using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BinaryExample: MonoBehaviour
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
    [Serializable]
    public class BoxesContainer
    {
        public List<Box> boxes = new List<Box>();
        public BoxesContainer Load()
        {
            using (var stream = new FileStream(Application.persistentDataPath + "/Boxes.bin", FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return binaryFormatter.Deserialize(stream) as BoxesContainer;
            }
        }

        public void Save()
        {
            using (var stream = new FileStream(Application.persistentDataPath + "/Boxes.bin", FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, this);
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
