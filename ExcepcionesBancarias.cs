namespace ManejoErroresATM;

// Excepción lanzada cuando el monto es menor o igual a cero
public class MontoInvalidoException : Exception
{
    public MontoInvalidoException(string mensaje) : base(mensaje) { }
}

// Excepción lanzada cuando el retiro supera el saldo disponible
public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException(string mensaje) : base(mensaje) { }
}