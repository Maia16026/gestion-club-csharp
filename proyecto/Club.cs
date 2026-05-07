using System;
using System.Collections;

namespace proyecto
{
	public class Club
	{
		private string nombre;
		private ArrayList deportes;
		private ArrayList entrenadores;
		
		public Club(string nombre)
		{
			this.nombre=nombre;
			deportes=new ArrayList();
			entrenadores=new ArrayList();
		}
		public ArrayList Deportes{
			get{ return deportes; }
		}
		public ArrayList Entrenadores{
			get{ return entrenadores; }
		}
	}
}
