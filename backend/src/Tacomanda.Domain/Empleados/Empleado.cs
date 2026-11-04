namespace Tacomanda.Domain.Empleados;

public sealed class Empleado
{
    private Empleado() { }

    public Empleado(Guid id, string usuario, string nombre, string passwordHash, EmployeeRole rol)
    {
        if (id == Guid.Empty || string.IsNullOrWhiteSpace(usuario) ||
            string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(passwordHash))
        {
            throw new ArgumentException("Datos de empleado incompletos.");
        }

        Id = id;
        Usuario = usuario;
        Nombre = nombre;
        PasswordHash = passwordHash;
        Rol = rol;
        Activo = true;
    }

    public Guid Id { get; private set; }
    public string Usuario { get; private set; } = "";
    public string Nombre { get; private set; } = "";
    public string PasswordHash { get; private set; } = "";
    public EmployeeRole Rol { get; private set; }
    public bool Activo { get; private set; }
}
