namespace ToDoApp.Common
{
    public interface ISerializer
    {
        string Serialize(object obj);

        T Deserialize<T>(string serializedObj);
    }
}
