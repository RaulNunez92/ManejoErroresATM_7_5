namespace ManejoErroresATM;

public class CajeroATM
{
    private readonly CuentaBancaria _cuenta;

    public CajeroATM(CuentaBancaria cuenta)
    {
        _cuenta = cuenta ?? throw new ArgumentNullException(nameof(cuenta));
    }

    public void Iniciar()
    {
        bool enSesion = true;

        do
        {
            Console.WriteLine("\n========================================================");
            Console.WriteLine("          SISTEMA ATM - CONTROL DE EXCEPCIONES          ");
            Console.WriteLine($" Titular: {_cuenta.Titular} | Cuenta: #{_cuenta.NumeroCuenta}");
            Console.WriteLine("========================================================");
            Console.WriteLine("1. Consultar Saldo Actual");
            Console.WriteLine("2. Retirar Efectivo");
            Console.WriteLine("3. Finalizar Sesión");
            Console.WriteLine("--------------------------------------------------------");
            Console.Write("Seleccione una opción: ");

            string entradaOpcion = Console.ReadLine() ?? "";

            // Validación de opciones numéricas (Optimización de tipo: byte)
            if (!byte.TryParse(entradaOpcion, out byte opcion))
            {
                Console.WriteLine(">> Resultado esperado: Operación no válida");
                Pausar();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"\n>> Su saldo disponible actual es: RD$ {_cuenta.Saldo:N2}");
                    Pausar();
                    break;

                case 2:
                    ProcesarRetiroConManejoDeErrores();
                    Pausar();
                    break;

                case 3:
                    Console.WriteLine("\n>> Sesión finalizada correctamente. ¡Hasta pronto!");
                    enSesion = false;
                    break;

                default:
                    // Escenario: Seleccionar opción inexistente (ej. opción 9)
                    Console.WriteLine(">> Resultado esperado: Operación no válida");
                    Pausar();
                    break;
            }

        } while (enSesion);
    }

    private void ProcesarRetiroConManejoDeErrores()
    {
        Console.WriteLine("\n--- Solicitud de Retiro ---");
        Console.Write("Ingrese el monto a retirar: RD$ ");
        string entradaMonto = Console.ReadLine() ?? "";

        // IMPLEMENTACIÓN JUSTIFICADA DE TRY / CATCH / FINALLY
        try
        {
            // Escenario: Entrada no numérica ("ABC")
            if (!decimal.TryParse(entradaMonto, out decimal monto))
            {
                throw new FormatException("Entrada no numérica");
            }

            // Invocación a la lógica bancaria
            _cuenta.Retirar(monto);
            Console.WriteLine(">> Resultado esperado: Retiro exitoso");
            Console.WriteLine($"   Monto dispensado: RD$ {monto:N2} | Saldo restante: RD$ {_cuenta.Saldo:N2}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($">> Resultado esperado: {ex.Message}");
        }
        catch (MontoInvalidoException ex)
        {
            Console.WriteLine($">> Resultado esperado: {ex.Message}");
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine($">> Resultado esperado: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($">> Error inesperado del sistema: {ex.Message}");
        }
        finally
        {
            // EL BLOQUE FINALLY SIEMPRE SE EJECUTA (Auditoría contable)
            Console.WriteLine($"[Auditoría]: Operación concluida. Saldo asegurado en cuenta: RD$ {_cuenta.Saldo:N2}");
        }
    }

    private static void Pausar()
    {
        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
}