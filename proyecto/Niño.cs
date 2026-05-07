using System;
using System.Collections;

namespace proyecto
{
	public class Niño:Persona
	{
		private int mes_pago;
		private bool esSocio;
		private double descuento;
		private Deporte deporte;
		
		public Niño(string nombre, int edad, int dni,int mes, Deporte deporte,  double descuento, bool socio) : base(nombre,edad,dni)
		{
			mes = mes_pago;
			this.descuento = descuento;
			socio = esSocio;
			this.deporte = deporte;
		}
		public int MesPago{
			set{mes_pago=value;}
			get{return mes_pago;}
		}
		public bool EsSocio{
			set{esSocio=value;}
			get{return esSocio;}
		}
		public double Descuento{
			set{descuento=value;}
			get{return descuento;}
		}
	}
}
