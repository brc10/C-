
namespace DO;
public record Castumer(int CastumerId, string name,string street,int numCall)
{
    public Castumer() : this(0, "null", "null", 0) { }
}
