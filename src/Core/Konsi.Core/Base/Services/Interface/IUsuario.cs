namespace KonsiCred.Core
{
    public interface IUsuario
    {
        string Name { get; }
        bool IsAuthenticated();

    }
}
