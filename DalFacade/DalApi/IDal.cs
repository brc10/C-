
namespace DalApi;
 public interface IDal
 {
    //מאפשר איתחול של הרשימות
    ICastumer castumer { get; }
    Iproduct product { get; }
    Isail sail { get; }
 }
