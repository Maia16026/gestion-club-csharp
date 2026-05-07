# Gestión de Club (Legacy)

Este repositorio contiene mi proyecto final para la materia **Algoritmos y Programación** (UNAJ). 

> **Nota importante:** Este código representa mis primeros pasos en la Programación Orientada a Objetos (POO). 

## Estado del Código (Deuda Técnica)
Como fue uno de mis primeros desarrollos complejos en **C#**, el proyecto presenta:
- **Lógica centralizada:** La mayoría de las funciones de gestión (`AltaEntrenador`, `PagoCuota`) residen en la clase `Program`, rompiendo el principio de encapsulamiento.
- **Estructura Monolítica:** El flujo del programa depende de un menú extenso y métodos estáticos.
- **Mejoras pendientes:** Reducción de acoplamiento y migración de métodos a sus clases correspondientes (`Socio`, `Club`, `Entrenador`).

## Lo rescatable (Lógica de Negocio)
A pesar de la estructura, el proyecto resuelve problemas reales de gestión:
- Manejo de **Excepciones Personalizadas** (`NoDeporte`, `SinCupoException`).
- Gestión de colecciones de objetos (`ArrayList`, `List`).
- Implementación de herencia básica.
