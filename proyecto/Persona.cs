/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/10/2024
 * Hora: 07:28
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace proyecto
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
	{
		protected string nombre;
		protected int edad, dni;
		
		public Persona(string nombre, int edad, int dni)
		{
			this.nombre=nombre;
			this.edad=edad;
			this.dni=dni;	
		}
		public string Nombre{
			set{nombre=value;}
			get{return nombre;}
		}
		
		public int Edad{
			set{edad=value;}
			get{return edad;}
		}
		public int Dni{
			set{dni=value;}
			get{return dni;}
		}
	}
}
