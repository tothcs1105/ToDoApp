using ToDoApp.Common;
using ToDoApp.DTOs;

namespace ToDoApp.DataAccess.FileSystem
{
    internal abstract class FileSystemRepositoryBase<T, K> where T : class, new() where K: IEquatable<K>
    {
        protected FileInfo _destinationFile;
        protected ISerializer _serializer;

        public FileSystemRepositoryBase(FileInfo destinationFile, ISerializer serializer)
        {
            _destinationFile = destinationFile ?? throw new ArgumentNullException(nameof(destinationFile));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        protected void CreateFileIfNotExists(IEnumerable<T> initialValue = null)
        {
            if (!_destinationFile.Exists)
            {
                _destinationFile.Create();

                if (initialValue != null)
                {
                    WriteFile(initialValue);
                }
            }
        }

        protected IDictionary<K, T> ReadFile(Func<T, K> keySelector)
        {
            var objList = _serializer.Deserialize<IEnumerable<T>>(File.ReadAllText(_destinationFile.FullName));

            return objList.ToDictionary(keySelector, value => value);
        }

        protected void WriteFile(IEnumerable<T> objList)
        {
            var serializedObjList = _serializer.Serialize(objList);

            File.WriteAllText(_destinationFile.FullName, serializedObjList);
        }
    }
}
