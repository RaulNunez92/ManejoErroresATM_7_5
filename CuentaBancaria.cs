namespace ManejoErroresATM;

public class CuentaBancaria
{
    public int NumeroCuenta { get; }
    public string Titular { get; }
    public decimal Saldo { get; private set; }

    public CuentaBancaria(int numeroCuenta, string titular, decimal saldoInicial)
    {
        if (numeroCuenta <= 0)
            throw new ArgumentException("El número de cuenta debe ser positivo.");

        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("El titular no puede estar vacío.");

        if (saldoInicial < 0)
            throw new ArgumentException("El saldo inicial no puede ser negativo.");

        NumeroCuenta = numeroCuenta;
        Titular = titular;
        Saldo = saldoInicial;
    }

    // Reglas de negocio protegidas mediante excepciones específicas
    public void Retirar(decimal monto)
    {
        // Validación 1: Monto mayor que cero
        if (monto <= 0)
        {
            throw new MontoInvalidoException("Monto inválido");
        }

        // Validación 2: Fondos suficientes
        if (monto > Saldo)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente");
        }

        // Si no hay excepciones, se debita el dinero
        Saldo -= monto;
    }
}