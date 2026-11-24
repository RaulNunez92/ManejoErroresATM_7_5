namespace ManejoErroresATM;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("========================================================");
        Console.WriteLine("        CONFIGURACIÓN INICIAL DEL CAJERO                ");
        Console.WriteLine("========================================================");

        // Captura interactiva del cliente sin valores fijos
        Console.Write("Ingrese el nombre del Titular: ");
        string titular = Console.ReadLine() ?? "Cliente General";

        Console.Write("Ingrese el Número de Cuenta: ");
        int.TryParse(Console.ReadLine(), out int noCuenta);
        if (noCuenta <= 0) noCuenta = 1001;

        // Según los casos de prueba del documento, se inicia normalmente con RD$ 2,000.00
        Console.Write("Ingrese el Saldo Inicial (Ejemplo para pruebas: 2000): RD$ ");
        decimal.TryParse(Console.ReadLine(), out decimal saldo);
        if (saldo <= 0) saldo = 2000m;

        CuentaBancaria cuentaCliente = new CuentaBancaria(noCuenta, titular, saldo);
        CajeroATM atm = new CajeroATM(cuentaCliente);

        atm.Iniciar();
    }
}
