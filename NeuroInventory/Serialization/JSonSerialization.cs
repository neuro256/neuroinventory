using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace NeuroInventory
{
    class JSonSerialization<T> : ISerialize<T>
    {
        public T Deserialize(string path)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                T newObject = (T)formatter.ReadObject(fs);
                Console.WriteLine("Объект десериализован");
                return newObject;
            }
        }

        public T[] DeserializeMulti(string path)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                T[] newObjects = (T[])formatter.ReadObject(fs);
                Console.WriteLine("Объекты десериализованы");
                return newObjects;
            }
        }

        public void Serialize(T[] pObjects, string path)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, pObjects);
                Console.WriteLine("Объекты сериализованы");
            }
        }

        public void Serialize(T pObject, string path)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, pObject);
                Console.WriteLine("Объект сериализован");
            }
        }
    }
}
