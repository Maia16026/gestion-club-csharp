using System;
using System.Collections;

namespace proyecto
{
	public class Club
	{
		private string nombre;
		private List<Deporte> deportes;
		private List<Entrenador> entrenadores;
		
		public Club(string nombre)
		{
			this.nombre=nombre;
			deportes=new List<Deporte>();
			entrenadores=new List<Entrenador>();
		}
		public void AltaEntrenador(Entrenador entrenador)
        {
            entrenadores.Add(entrenador);
		}
		public void BajaEntrenador(int dni)
        {
            Entrenador entrenador = BuscarEntrenador(dni);

            entrenadores.Remove(entrenador);
		}
		public Entrenador BuscarEntrenador(int dni)
        {
            foreach (Entrenador e in entrenadores)
            {
                if (e.Dni == dni)
                {
                    return e;
                }
            }

            throw new Exception("Entrenador no encontrado");
		}
		public void AgregarDeporte(Deporte deporte)
        {
            deportes.Add(deporte);
		}
		public void EliminarDeporte(string nombre, string categoria)
        {
            Deporte deporte = BuscarDeporte(nombre, categoria);

            if (deporte.Inscriptos.Count > 0)
            {
                throw new Exception("El deporte tiene inscriptos");
            }

            deportes.Remove(deporte);
		}
		public Deporte BuscarDeporte(string nombre, string categoria)
        {
            foreach (Deporte d in deportes)
            {
                if (
                    d.Nombre.ToLower() == nombre.ToLower()
                    &&
                    d.Categoria.ToLower() == categoria.ToLower()
                )
                {
                    return d;
                }
            }

            throw new Exception("Deporte no encontrado");
		}
		public void ListarInscriptos()
        {
            foreach (Deporte d in deportes)
            {
                Console.WriteLine("\nDEPORTE: "+ d.Nombre + " - "+ d.Categoria);

                foreach (Nino n in d.Inscriptos)
                {
                    Console.WriteLine(n.Nombre + " | DNI: "+ n.Dni);
                }
            }
		}
		public void ListarDeudores(int mesActual)
        {
            foreach (Deporte d in deportes)
            {
                foreach (Nino n in d.Inscriptos)
                {
                    if (n.MesPago < mesActual)
                    {
                        Console.WriteLine( n.Nombre+ " | DNI: "+ n.Dni+ " | Deuda desde mes "+ n.MesPago);
                    }
                }
            }
		}
	}
}
