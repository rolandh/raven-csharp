using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SharpRaven.Utilities
{
    public static class Serializer
    {
        public static byte[] SerialiseBytes(this object obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        public static T DeserialiseBytes<T>(this byte[] buffer)
        {
            if (buffer == null || buffer.Length <= 0) throw new ArgumentException("Attempted to deserialise an empty array", "buffer");
            using (var stream = new MemoryStream(buffer))
            {
                var result = (T)new BinaryFormatter().Deserialize(stream);
                return result;
            }
        }
    }
}
