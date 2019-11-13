public delegate void limiteSueldoDelegado(double sueldo, Entidades.Empleado aux);//Firma del metodo

public delegate void LimiteSueldoMejorado(Entidades.Empleado e, Entidades.EmpleadoEventArgs ev);

public enum TipoManejador
{
    LimiteSueldo,
    LimiteSueldoMejorado,
    Todos
}