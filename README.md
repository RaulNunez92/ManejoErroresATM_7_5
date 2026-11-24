# Caso Práctico 7.5 — Manejo de Errores en el ATM

Implementación de programación defensiva y control estructurado de excepciones con `try`, `catch` y `finally` en C# (.NET 8).

---

## 📌 ENTREGABLE 1: Enlace al Repositorio Oficial
- **GitHub:** [https://github.com/RaulNunez92/ManejoErroresATM_7_5](https://github.com/RaulNunez92/ManejoErroresATM_7_5)

---

## 📐 ENTREGABLE 2: Explicación de las Validaciones Implementadas

### 1. Jerarquía de Excepciones de Dominio
- **`MontoInvalidoException`:** Atrapa valores menores o iguales a cero en solicitudes de retiro.
- **`SaldoInsuficienteException`:** Impide sobregiros cuando el importe excede el saldo en cuenta.
- **`FormatException`:** Captura entradas alfanuméricas ("ABC") evitando que la aplicación se caiga.

### 2. Justificación del Bloque `finally`
Se utiliza para tareas de auditoría financiera indispensables: emitir el registro de conclusión y confirmar en pantalla que el saldo permanece íntegro e inalterado tras cualquier operación rechazada.

---

## 📊 ENTREGABLE 3: Diagrama de Clases y Excepciones
*(Diagrama vectorial disponible en `/docs/Diagrama_Errores_ATM.pdf`)*

```
     Exception (C# System)
          ^            ^
          |            | (hereda)
[MontoInvalido]  [SaldoInsuficiente]
          ^            ^
          | (lanza)    | (lanza)
      +--------------------+
      |   CuentaBancaria   | <--- Atrapadas en CajeroATM (try/catch/finally)
      +--------------------+
```

---

## 📸 ENTREGABLE 4: Evidencias de Ejecución (Casos de Prueba del Documento)

### 1. Retiro Exitoso (RD$500 con saldo RD$2,000)
Resultado: `Retiro exitoso`
![Retiro Exitoso](./docs/evidencia_retiro_exitoso.png)

### 2. Saldo Insuficiente (Retirar RD$3,000 con saldo RD$2,000)
Resultado: `Saldo insuficiente`
![Saldo Insuficiente](./docs/evidencia_saldo_insuficiente.png)

### 3. Monto Inválido (Retirar RD$0)
Resultado: `Monto inválido`
![Monto Inválido](./docs/evidencia_monto_cero.png)

### 4. Entrada No Numérica (Monto "ABC")
Resultado: `Entrada no numérica`
![Entrada No Numérica](./docs/evidencia_monto_letras.png)

### 5. Operación No Válida (Seleccionar opción 9)
Resultado: `Operación no válida`
![Opción Inválida](./docs/evidencia_opcion_invalida.png)

---

## 📦 ENTREGABLE 5: Compilación y Ejecución Independiente

```bash
# Ejecutar en consola interactiva
dotnet run

# Publicar binario autónomo:
dotnet publish -c Release -r win-x64 --self-contained false
```