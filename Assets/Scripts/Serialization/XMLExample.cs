using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLExample : MonoBehaviour {
    Transform boxes;
	void Start () {
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
            boxesContainer.boxes.Add(new Box(t.position,t.rotation));
        }
        boxesContainer.Save();
    }

    [XmlRoot("BoxesContainer")]
    public class BoxesContainer
    {
        [XmlArray("Boxes")]
        [XmlArrayItem("Level")]
        public List<Box> boxes = new List<Box>();
        public BoxesContainer Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BoxesContainer));
            try
            {
                using (var stream = new FileStream(Application.persistentDataPath + "/Boxes.xml", FileMode.Open))
                    return serializer.Deserialize(stream) as BoxesContainer;
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                return new BoxesContainer();
            }
        }

        public void Save()
        {
            Debug.Log(Application.persistentDataPath);
            XmlSerializer serializer = new XmlSerializer(typeof(BoxesContainer));
            using (var stream = new FileStream(Application.persistentDataPath + "/Boxes.xml", FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }

        public BoxesContainer(){}
    }

    public class Box {
        [XmlAttribute("pX")]
        public float pX;
        [XmlAttribute("pY")]
        public float pY;
        [XmlAttribute("pZ")]
        public float pZ;
        [XmlAttribute("rX")]
        public float rX;
        [XmlAttribute("rY")]
        public float rY;
        [XmlAttribute("rZ")]
        public float rZ;
        [XmlAttribute("rW")]
        public float rW;
        public Box(){ }
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
