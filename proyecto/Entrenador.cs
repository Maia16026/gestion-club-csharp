using System;

namespace proyecto
{
	public class Entrenador:Persona
	{
		private double sueldo;
		
		public Entrenador(string nombre, int edad, int dni, double sueldo):base(nombre, edad, dni)
		{
			this.sueldo=sueldo;
		}
		public double Sueldo{
			set{sueldo=value;}
			get{return sueldo;}
		}
	}
}
