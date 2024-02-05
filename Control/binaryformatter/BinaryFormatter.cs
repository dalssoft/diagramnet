using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Diagram.NET.binaryformatter
{
    public class BinaryFormatter : IFormatter
    {
        public FormatterAssemblyStyle AssemblyFormat { get; internal set; }

        public object Deserialize(Stream mem) => Serializer.Deserialize<object>(mem);

        public void Serialize(Stream mem, object o) => Serializer.Serialize(mem, o);
    }
}
