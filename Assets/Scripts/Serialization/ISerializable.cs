public interface ISerializable<T> where T : DataTransferObject
{
    T Serialized();

    void Deserialize(T dataTransferObject);
}