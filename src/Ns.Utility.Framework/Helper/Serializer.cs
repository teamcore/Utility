using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ns.Utility.Framework.Helper
{
    /// <summary>
    /// Serializer
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Serializes the specified graph.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <returns></returns>
        public static byte[] Serialize(object graph)
        {
            byte[] serializedData;
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, graph);
                serializedData = stream.ToArray();
            }
            return serializedData;
        }

        /// <summary>
        /// Deserializes the specified serialized data.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <returns></returns>
        public static object Deserialize(byte[] serializedData)
        {
            object graph = null;
            if (serializedData != null)
            {
                using (var stream = new MemoryStream())
                {
                    for (int i = 0; i < serializedData.Length; i++)
                    {
                        stream.WriteByte(serializedData[i]);
                    }
                    stream.Position = 0;
                    var formatter = new BinaryFormatter();
                    graph = formatter.Deserialize(stream);
                }
            }
            return graph;
        }
    }
}
