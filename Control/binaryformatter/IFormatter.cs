
namespace Diagram.NET.BinaryFormatter
{
    public interface IFormatter
    {
        object Deserialize(Stream mem);
        void Serialize(Stream mem, object o);
    }
}