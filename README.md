# Gestión de Club

Este repositorio contiene mi proyecto final para la materia **Algoritmos y Programación** (UNAJ). 

> **Nota importante:** Este código representa mis primeros pasos en la Programación Orientada a Objetos (POO). 

## Primera versión del código (Deuda Técnica)
Como fue uno de mis primeros desarrollos complejos en **C#**, el proyecto presentaba:
- **Lógica centralizada:** La mayoría de las funciones de gestión (`AltaEntrenador`, `PagoCuota`) residían en la clase `Program`, rompiendo el principio de encapsulamiento.
- **Estructura Monolítica:** El flujo del programa dependía de un menú extenso y métodos estáticos.
- **Mejoras pendientes:** Reducción de acoplamiento y migración de métodos a sus clases correspondientes (`Socio`, `Club`, `Entrenador`).

## Características Técnicas Actuales
- **Arquitectura:** Programación Orientada a Objetos con herencia y polimorfismo.
- **Robustez:** Manejo de **Excepciones Personalizadas** para validar reglas de negocio.
- **Colecciones Dinámicas:** Uso eficiente de `System.Collections.Generic`.
- **Lógica de Negocio:** Sistema completo de inscripciones, control de cupos por categoría y gestión de pagos.

## Contexto Académico
Este proyecto es un testimonio de mi crecimiento técnico. La versión actual demuestra la capacidad de identificar código heredado (Legacy), diagnosticar sus fallas y aplicar patrones de diseño para mejorar su mantenibilidad.
