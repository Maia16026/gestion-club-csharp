using System;
using System.Collections;

namespace proyecto
{
	
	public class Deporte
	{
		private string nombre;
		private int cupo;			
		private string categoria;
		private double costoCuota;
		private Entrenador entrenador;
		private ArrayList inscriptos;
			
		public Deporte(string nombre, string categoria, int cupo, Entrenador entrenador, double costoCuota)
		{
			this.nombre=nombre;
			this.cupo=cupo;
			this.categoria=categoria;
			this.entrenador=entrenador;
			this.costoCuota=costoCuota;
			inscriptos=new ArrayList();
		}
		public string Nombre{
			set{nombre=value;}
			get{return nombre;}
		}
		public int Cupo{
			set{cupo=value;}
			get{return cupo;}
		}
		public string Categoria{
			set{categoria=value;}
			get{return categoria;}
		}
		public double CostoCuota{
			set{costoCuota=value;}
			get{return costoCuota;}
		}
		public ArrayList Inscriptos{
			get{return inscriptos;}
		}
	}
}
