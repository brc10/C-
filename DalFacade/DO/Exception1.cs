
namespace DO
{
    //שגיאה אם האוביקט כבר קיים
    [Serializable]
    public class objectAlreadyExsist : Exception
    {
        public objectAlreadyExsist(int id):base($"ID {id} already exists.") {}
     
    }
    //שגיאה אם האוביקט לא נמצא
    [Serializable]
    public class objectNotFound : Exception
    {
        public objectNotFound(int id):base($"ID {id} not found.") {}
    }        
}
