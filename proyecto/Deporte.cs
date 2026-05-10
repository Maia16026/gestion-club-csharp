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
		private List<Nino> inscriptos;
			
		public Deporte(string nombre, string categoria, int cupo, Entrenador entrenador, double costoCuota)
		{
			this.nombre=nombre;
			this.cupo=cupo;
			this.categoria=categoria;
			this.entrenador=entrenador;
			this.costoCuota=costoCuota;
			inscriptos=new List<Nino>();
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
		public List<Nino> Inscriptos{
			get{return inscriptos;}
		}
		public void AgregarInscripto(Nino nino)
        {
            if (cupo <= 0)
            {
                throw new Exception("No hay cupo");
            }

            inscriptos.Add(nino);

            cupo--;
		}
		public void EliminarInscripto(int dni)
        {
            Nino nino = BuscarNino(dni);

            inscriptos.Remove(nino);

            cupo++;
		}
		public Nino BuscarNio(int dni)
        {
            foreach (Nino n in inscriptos)
            {
                if (n.Dni == dni)
                {
                    return n;
                }
            }

            throw new Exception("Niño no encontrado");
		}
	}
}
