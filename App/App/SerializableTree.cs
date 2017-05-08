using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    /// <summary>
    /// Represents simple tree with multiple children.
    /// </summary>
    /// <typeparam name="T">Class of tree note.</typeparam>
    /// <typeparam name="K">Class of children.</typeparam>
    [Serializable()]
    public class SerializableTree<T>
    {
        /// <summary>
        /// Note information.
        /// </summary>
        public T Data;

        /// <summary>
        /// List of children.
        /// </summary>
        public List<SerializableTree<T>> Children;

        /// <summary>
        /// Parent of current note.
        /// </summary>
        public SerializableTree<T> Parent;

        /// <summary>
        /// Appends new child to current note.
        /// </summary>
        /// <param name="newChild">Reference to child to be appended.</param>
        public void AddChild(SerializableTree<T> newChild)
        {
            Children.Add(newChild);
        }

        /// <summary>
        /// Saves current note to file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>True if operation was successful.</returns>
        public bool WriteToFile(string path)
        {
            try
            {
                var output = System.IO.File.Open(path, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binFormatter.Serialize(output, this);
                output.Close();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Creates note from file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>New instance of class.</returns>
        public static SerializableTree<T> ReadFromFile(string path)
        {
            try
            {
                var input = System.IO.File.Open(path, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                SerializableTree<T> note = (SerializableTree<T>)binFormatter.Deserialize(input);
                input.Close();
                return note;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
