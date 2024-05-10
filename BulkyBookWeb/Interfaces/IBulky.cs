namespace BulkyBookWeb.Interfaces
{
    public interface IBulky<Type,Id,Ret>
    {
        Task<Ret>Create(Type type); 

        Task<List<Ret>> GetAll();

        Task<Type> Read(Id id);

        Task<Ret>Update(Type type);
        
        Task<bool> Delete(Id type);
    }
}
