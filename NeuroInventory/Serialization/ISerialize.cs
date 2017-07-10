namespace NeuroInventory
{
    interface ISerialize<T>
    {
        void Serialize(T pObject, string path);
        void Serialize(T[] pObjects, string path);
        T Deserialize(string path);
        T[] DeserializeMulti(string path);
    }
}
