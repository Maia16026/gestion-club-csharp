using System;
using System.Collections;

namespace proyecto
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Club c = new Club("El Olimpo");
			//                                  nom y ape    edad   dni   sueldo
			Entrenador JORGE = new Entrenador("Jorge Molina", 32, 23, 100000);
			//                            nombre  categ   cupo  entr cuota
			Deporte FUTBOL = new Deporte("futbol", "junior", 30, JORGE, 1000);	
			
			//                     nombre    edad dni UltMesPa  Deporte  Descuento socio
			Niño PEPE = new Niño("Pepe Coco", 12, 2323, 2, FUTBOL, 10, true);
			
			// Futbol, Voley, Tenis, Natacion, Basket"	

		//	Deporte VOLEY = new Deporte("voley", "junior", 22, JORGE, 1000);
			
		//	Deporte TENIS = new Deporte("tenis", "junior", 25, JORGE, 1000);
			
		//	Deporte NATACION = new Deporte("natacion", "junior", 24, JORGE, 1000);
			
			c.Deportes.Add(FUTBOL);
			FUTBOL.Inscriptos.Add(PEPE);
			c.Entrenadores.Add(JORGE);
			int opcion; bool opcionCorrecta = true;
		
			do {
				try {	
					Console.Clear();
					Console.WriteLine("Menú Principal");
					Console.WriteLine("1. Dar de alta a un entrenador");
					Console.WriteLine("2. Dar de baja a un entrenador");
					Console.WriteLine("3. Dar de alta a un niño/socio en un deporte.");
					Console.WriteLine("4. Dar de baja a un niño/socio en un deporte");
					Console.WriteLine("5. Pagar cuota");
					Console.WriteLine("6. Submenú de listados");
					Console.WriteLine("7. Listado de deudores");
					Console.WriteLine("8. Agregar un deporte");
					Console.WriteLine("9. Eliminar un deporte");
					Console.WriteLine("0. Salir");
					Console.WriteLine("");
					Console.WriteLine("Ingrese una opción: ");
					opcion = int.Parse(Console.ReadLine());
					switch(opcion) {
						case 1:
							AltaEntrenador(c);
							break;
						case 2:
							BajaEntrenador(c);
							break;
						case 3:
							AltaNiñoDeporte(c);
							break;
						case 4:
							BajaNiñoDeporte(c);
							break;
						case 5:
							PagoCuouta(c);
							break;
						case 6:
							do {
								Console.Clear();
								Console.WriteLine("Menú de Listados");
								Console.WriteLine("1. Listado de inscriptos por deporte");
								Console.WriteLine("2. Listado de inscriptos por deporte y categoria");
								Console.WriteLine("3. Listado de inscriptos total");
								Console.WriteLine("0. Volver al menu principal");
								Console.WriteLine("");
								Console.WriteLine("Ingrese una opción: ");
								opcion = int.Parse(Console.ReadLine());
								switch(opcion){
									case 1:
										InscriptosDeporte(c);
										break;
									case 2:
										InscriptosDeporteYCategoria(c);
										break;
									case 3:
										TotalInscriptos(c);
										break;
									case 0:
										Console.WriteLine("Saliendo del menu de Listados");
										break;
									default:
										Console.Write("Opcion incorrecta.");
										break;
								}
								if(opcion!=0) {
									Console.Write("\nPresione una tecla para continuar...");
									Console.ReadKey();
								}	
							} while(opcion!=0);
							break;
						case 7:
							InformoDeudores(c);
							break;
						case 8:
							AgregarDeporte(c);
							break;
						case 9:
							EliminarDeporte(c);
							break;
						case 0:
							Console.WriteLine("Saliendo del menu");
							opcionCorrecta = false;
							break;
						default:
							Console.Write("Opcion incorrecta.");
							break;
					}
					if(opcion!=0) {
						Console.Write("\nPresione una tecla para continuar...");
					}
					
				}
				catch(SinCupoException ex) {
					Console.WriteLine(ex.motivo);
					Console.Write("\nPresione una tecla para continuar...");
				}
				catch (ListaVacia ex) {
					Console.WriteLine(ex.motivo);
					Console.Write("\nPresione una tecla para continuar...");
				}
				catch (NoDeporte ex) {
					Console.WriteLine(ex.motivo);
					Console.Write("\nPresione una tecla para continuar...");
				}				
				catch (NoCategoria ex) {
					Console.WriteLine(ex.motivo);
					Console.Write("\nPresione una tecla para continuar...");
				}

				catch (NoNiño ex) {
					Console.WriteLine(ex.motivo);
					Console.Write("\nPresione una tecla para continuar...");
				}
				catch(Exception ex) {
					Console.WriteLine("Error: " + ex.Message);
					Console.Write("\nPresione una tecla para continuar...");
				}
				
				Console.ReadKey();
			} while(opcionCorrecta);
		}
		
		
		// EXCEPCIONES
		public class SinCupoException : Exception
		{
			public string motivo;
			public SinCupoException(string motivo)
			{
				this.motivo = "La lista esta vacia";
			}
		}
		
		
		public class ListaVacia : Exception 
		{
			public string motivo;
			public ListaVacia(string motivo)
			{
				this.motivo = motivo;
			}
		}

		public class NoDeporte : Exception
		{
			public string motivo;
			public NoDeporte(string motivo)
			{
				this.motivo = motivo;
			}
		}	

		public class NoCategoria : Exception
		{
			public string motivo;
			public NoCategoria(string motivo)
			{
				this.motivo = motivo;
			}
		}

		public class NoNiño : Exception
		{
			public string motivo;
			public NoNiño(string motivo)
			{
				this.motivo = motivo;
			}
		}
		
		/* MENU */
		/* Case 1 */
		public static void AltaEntrenador(Club c)
		{
			string nombreEntrenador; int edadEntrenador, dniEntrenador; double sueldoEntrenador;
			// pedir nombre
			Console.WriteLine("Ingrese el nombre del nuevo entrenador: ");
			nombreEntrenador = Console.ReadLine();
			// pedir edad
			Console.WriteLine("Ingrese la edad del nuevo entrenador: ");
			edadEntrenador = int.Parse(Console.ReadLine());
			// pedir dni
			Console.WriteLine("Ingrese el dni del nuevo entrenador: ");
			dniEntrenador = int.Parse(Console.ReadLine()) ;
			// pedir el sueldo
			Console.WriteLine("Ingrese el sueldo del nuevo entrenador: ");
			sueldoEntrenador = double.Parse(Console.ReadLine());
			Entrenador nuevoEntrenador = new Entrenador(nombreEntrenador, edadEntrenador, dniEntrenador, sueldoEntrenador);
			c.Entrenadores.Add(nuevoEntrenador);
			Console.WriteLine("Se ha dado de alta a un entrenador exitosamente");
		}
				
		/* Case 2 */
		public static void BajaEntrenador(Club c)
		{
			int dniEntrenador; bool rst=false;
			Console.WriteLine("Ingrese el dni del entrenador: ");
			dniEntrenador=int.Parse(Console.ReadLine());
			foreach( Entrenador e in c.Entrenadores){
				if ( e.Dni == dniEntrenador)
				{
					c.Entrenadores.Remove(e);
					rst = true;
					Console.WriteLine("Se ha dado de baja al entrenador exitosamente");
					break;
				}
			}
			if(!rst)
				Console.WriteLine("No se encontro al entrenador");
		}

		/* Case 3 */
		/* Verificar que tenga cupo con excepcion */
		public static void AltaNiñoDeporte(Club c)
		{
			string nombreNiño, categoria = "", rta, nombreDeporte = ""; int edadNiño, dniNiño, opcion; double descuento=0; bool socio=false, DeporteEncontrado=false;
	
			Console.WriteLine("Los deportes existentes son:\n 0 - Futbol\n 1 - Voley\n 2 - Tenis\n 3 - Natacion\n 4 - Basket\n");
			Console.WriteLine("Ingrese el número del deporte donde se va a inscribir: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					nombreDeporte = "futbol";
					break;
				case 1:
					nombreDeporte = "voley";
					break;
				case 2:
					nombreDeporte = "tenis";
					break;
				case 3:
					nombreDeporte = "natacion";
					break;
				case 4:
					nombreDeporte = "basket";
					break;	
				default:
					throw new NoDeporte("Opción incorrecta");
			}
			
			Console.WriteLine("Las categorias existentes son:\n 0 - Infantil\n 1 - Junior\n 2 - Juvenil\n");
			Console.WriteLine("Ingrese el número de la categoria: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					categoria = "infantil";
					break;
				case 1:
					categoria = "junior";
					break;
				case 2:
					categoria = "juvenil";
					break;
				default:
					throw new NoCategoria("Opción incorrecta");					
			}
			
			foreach(Deporte d in c.Deportes) {
				if(d.Nombre.ToLower() == nombreDeporte && d.Categoria.ToLower() == categoria){
					DeporteEncontrado = true;
					if(d.Cupo > 0) {
						Console.WriteLine("Ingrese el nombre del niño: ");
						nombreNiño = Console.ReadLine();
						Console.WriteLine("Ingrese la edad del niño: ");
						edadNiño = int.Parse(Console.ReadLine());
						Console.WriteLine("Ingrese el dni del niño: ");
						dniNiño = int.Parse(Console.ReadLine());
						Console.WriteLine("¿Es socio? s/n: ");
						rta = Console.ReadLine();
						if (rta == "s")
							socio = true;
						if(socio){
							Console.WriteLine("Ingrese el descuento: ");
							descuento = double.Parse(Console.ReadLine());
							Niño nuevoSocio = new Niño(nombreNiño, edadNiño, dniNiño, 0, d, descuento, true);
							d.Inscriptos.Add(nuevoSocio);
						}
						else{
							Niño nuevoNiño = new Niño(nombreNiño, edadNiño, dniNiño, 0, d, descuento, false);
							d.Inscriptos.Add(nuevoNiño);
						}
						d.Cupo -- ;
						Console.WriteLine("Se ha dado de alta a un niño exitosamente");
					}
					else
						throw new SinCupoException("NO hay cupo suficiente para este deporte");
				}
			}
			if(!DeporteEncontrado)
				throw new NoDeporte("No se encontro el deporte");
		}
	
	
		/* Case 4 */
		public static void BajaNiñoDeporte(Club c)
		{
			string nombreDeporte = "", categoria = ""; int dniNiño, opcion; bool DeporteEncontrado = false, NiñoEncontrado = false;
			Console.WriteLine("Los deportes existentes son:\n 0 - Futbol\n 1 - Voley\n 2 - Tenis\n 3 - Natacion\n 4 - Basket\n");
			Console.WriteLine("Ingrese el número del deporte donde se va a dar de baja: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					nombreDeporte = "futbol";
					break;
				case 1:
					nombreDeporte = "voley";
					break;
				case 2:
					nombreDeporte = "tenis";
					break;
				case 3:
					nombreDeporte = "natacion";
					break;
				case 4:
					nombreDeporte = "basket";
					break;
				default:
					throw new NoDeporte("Opción incorrecta");	
			}
			
			Console.WriteLine("Las categorias existentes son:\n 0 - Infantil\n 1 - Junior\n 2 - Juvenil\n");
			Console.WriteLine("Ingrese el número de la categoria de la que se va a dar de baja: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					categoria = "infantil";
					break;
				case 1:
					categoria = "junior";
					break;
				case 2:
					categoria = "juvenil";
					break;
				default:
					throw new NoCategoria("Opción incorrecta");						
			}
			
			foreach(Deporte d in c.Deportes){ 
				if(d.Nombre.ToLower() == nombreDeporte &&  d.Categoria.ToLower() == categoria)
				{
					DeporteEncontrado = true;
					Console.WriteLine("Ingrese el dni del niño:");
					dniNiño = int.Parse(Console.ReadLine()); 
					foreach( Niño n in d.Inscriptos ) {
						if ( n.Dni == dniNiño ) {
							NiñoEncontrado = true; 
							d.Inscriptos.Remove(n);
				 			Console.WriteLine("Se ha dado de baja al niño exitosamente");
				 			break;
						}
					}
				}
			}
			
			if(!DeporteEncontrado)
				throw new NoDeporte("No se encontro el deporte");
			else {
				if(!NiñoEncontrado)
					throw new NoNiño("No se encontro al niño"); 
			}
		}	
		
		/* Case 5 */
		public static void PagoCuouta(Club c)
		{
			string nombreDeporte= "", categoria = ""; int dniNiño, mesActual, opcion; double precio; bool DeporteEncontrado=false, NiñoEncontrado=false;
			Console.WriteLine("Los deportes existentes son:\n 0 - Futbol\n 1 - Voley\n 2 - Tenis\n 3 - Natacion\n 4 - Basket\n");
			Console.WriteLine("Ingrese el número del deporte: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					nombreDeporte = "futbol";
					break;
				case 1:
					nombreDeporte = "voley";
					break;
				case 2:
					nombreDeporte = "tenis";
					break;
				case 3:
					nombreDeporte = "natacion";
					break;
				case 4:
					nombreDeporte = "basket";
					break;	
				default:
					throw new NoDeporte("Opción incorrecta");
			}
			
			Console.WriteLine("Las categorias existentes son:\n 0 - Infantil\n 1 - Junior\n 2 - Juvenil\n");
			Console.WriteLine("Ingrese el número de la categoria: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					categoria = "infantil";
					break;
				case 1:
					categoria = "junior";
					break;
				case 2:
					categoria = "juvenil";
					break;
				default:
					throw new NoCategoria("Opción incorrecta");					
			}
			
			foreach(Deporte d in c.Deportes){
				if(d.Nombre.ToLower() == nombreDeporte && d.Categoria.ToLower() == categoria){
					DeporteEncontrado=true;
				 	Console.WriteLine("Ingrese el dni del niño:");
				 	dniNiño=int.Parse(Console.ReadLine());
				 	foreach( Niño n in d.Inscriptos){
				 		if ( n.Dni == dniNiño){
				 			NiñoEncontrado=true;
				 			Console.WriteLine("Ingrese el mes actual (numericamente del 1 al 12):");
				 			mesActual=int.Parse(Console.ReadLine());
				 			if(mesActual < 1 || mesActual > 12)
								Console.WriteLine("No esta en el rango pedido");
				 			else {
				 				precio=d.CostoCuota;
				 				if(n.EsSocio){
				 					double desc=n.Descuento;
				 					precio *= (1 - (desc/100));
				 				}
				 				Console.WriteLine("El precio es $" + precio);
				 				n.MesPago=mesActual;
				 				Console.WriteLine("Se pago la cuota correctamente");
				 			}
				 		}
				 	}
				}
			}
			if(!DeporteEncontrado)
				throw new NoDeporte("No se encontro el deporte");
			else {
				if(!NiñoEncontrado)
				throw new NoNiño("No se encontro al niño");
			}
		}
		
		/* Case 6 SUBMENU */
		public static void InscriptosDeporte(Club c)
		{
			bool opcionValida = false; string nombreDeporte = ""; int opcion;
			Console.WriteLine("Los deportes existentes son:\n 0 - Futbol\n 1 - Voley\n 2 - Tenis\n 3 - Natacion\n 4 - Basket\n");
			Console.WriteLine("Ingrese el número del deporte: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					nombreDeporte = "futbol";
					break;
				case 1:
					nombreDeporte = "voley";
					break;
				case 2:
					nombreDeporte = "tenis";
					break;
				case 3:
					nombreDeporte = "natacion";
					break;
				case 4:
					nombreDeporte = "basket";
					break;	
				default:
					throw new NoDeporte("Opción incorrecta");
			}
			
			foreach(Deporte d in c.Deportes){
				    if(d.Nombre.ToLower() == nombreDeporte)
				    {
						opcionValida=true;
						if (d.Inscriptos.Count == 0)
							throw new ListaVacia("La lista esta vacia");
						
						else {
						foreach (Niño n in d.Inscriptos){
							Console.WriteLine("Nombre " + n.Nombre + " Edad " + n.Edad + " Dni " + n.Dni + " Ultimo mes pago " + n.MesPago);	
						}
					}
				}
				
			}
			if(!opcionValida)
				throw new NoDeporte("No se encontro el deporte");
		}
		public static void InscriptosDeporteYCategoria(Club c){
			bool opcionValida = false; int opcion;string nombreDeporte = "", categoria = "";
			Console.WriteLine("Los deportes existentes son:\n 0 - Futbol\n 1 - Voley\n 2 - Tenis\n 3 - Natacion\n 4 - Basket\n");
			Console.WriteLine("Ingrese el número del deporte: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					nombreDeporte = "futbol";
					break;
				case 1:
					nombreDeporte = "voley";
					break;
				case 2:
					nombreDeporte = "tenis";
					break;
				case 3:
					nombreDeporte = "natacion";
					break;
				case 4:
					nombreDeporte = "basket";
					break;	
				default:
					throw new NoDeporte("Opción incorrecta");
			}
			
			Console.WriteLine("Las categorias existentes son:\n 0 - Infantil\n 1 - Junior\n 2 - Juvenil\n");
			Console.WriteLine("Ingrese el número de la categoria: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					categoria = "infantil";
					break;
				case 1:
					categoria = "junior";
					break;
				case 2:
					categoria = "juvenil";
					break;
				default:
					throw new NoCategoria("Opción incorrecta");					
			}
			
			foreach(Deporte d in c.Deportes){
				if(d.Nombre.ToLower()==nombreDeporte && d.Categoria.ToLower()==categoria){
					opcionValida = true;
					if (d.Inscriptos.Count == 0)
					{
						throw new ListaVacia("La lista de inscriptos esta vacia");
					}
					foreach (Niño n in d.Inscriptos){
						Console.WriteLine("Nombre " + n.Nombre + " Edad " + n.Edad + " Dni " + n.Dni + " Ultimo mes pago " + n.MesPago);
					}
				}
			}
			if(!opcionValida)
				throw new NoDeporte("No se encontro el deporte");
		}
		
		public static void TotalInscriptos(Club c){
			bool hayInscriptos = false;
			foreach(Deporte d in c.Deportes) {
				foreach(Niño n in d.Inscriptos) {
					Console.WriteLine("Nombre " + n.Nombre + " Edad " + n.Edad + " Dni " + n.Dni + " Ultimo mes pago " + n.MesPago);
					hayInscriptos = true;		
				}
			}
			if (!hayInscriptos)
				throw new ListaVacia("Las listas estan vacias");
		}
		
		
		/* Case 7 */
		public static void InformoDeudores(Club c){
			int MesActual;
			Console.WriteLine("Ingrese el mes actual (numericamente del 1 al 12):");
			MesActual=int.Parse(Console.ReadLine());
			if(MesActual < 1 || MesActual > 12)
				Console.WriteLine("No esta en el rango pedido");
			else{
				foreach(Deporte d in c.Deportes){
					foreach(Niño n in d.Inscriptos){
						if(n.MesPago<MesActual){
							Console.WriteLine("Nombre " + n.Nombre + " Edad " + n.Edad + " Dni " + n.Dni + " Ultimo mes pago " + n.MesPago);
						}
					}
				}
			}		
		}
		
		/* Case 8 */
		public static void AgregarDeporte(Club c){
			string nombreDeporte = "", categoria = ""; int cupoDeporte, costoCuota, dniEntrenador, opcion; bool opcionValida = false;
			Console.WriteLine("Los deportes que se pueden añadir son:\n 0 - Futbol\n 1 - Voley\n 2 - Tenis\n 3 - Natacion\n 4 - Basket\n");
			Console.WriteLine("Ingrese el número del deporte que va a añadir: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					nombreDeporte = "futbol";
					break;
				case 1:
					nombreDeporte = "voley";
					break;
				case 2:
					nombreDeporte = "tenis";
					break;
				case 3:
					nombreDeporte = "natacion";
					break;
				case 4:
					nombreDeporte = "basket";
					break;				
				default:
					throw new NoDeporte("Opción incorrecta");						
			}
			
			Console.WriteLine("Las categorias existentes son:\n 0 - Infantil\n 1 - Junior\n 2 - Juvenil\n");
			Console.WriteLine("Ingrese el número de la categoria que va a añadir: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					categoria = "infantil";
					break;
				case 1:
					categoria = "junior";
					break;
				case 2:
					categoria = "juvenil";
					break;
				default:
					throw new NoCategoria("Opción incorrecta");						
			}
				Console.WriteLine("Ingrese el cupo de {0}: ", nombreDeporte);
				cupoDeporte = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese el valor de la cuota de {0}: ", nombreDeporte);
				costoCuota = int.Parse(Console.ReadLine());
				Console.WriteLine("Ingrese el dni del entrenador de {0}: ", nombreDeporte);
				dniEntrenador = int.Parse(Console.ReadLine());
				
				foreach(Entrenador e in c.Entrenadores) {
					if(e.Dni == dniEntrenador){
						Deporte deporte = new Deporte(nombreDeporte, categoria, cupoDeporte, e, costoCuota);
						c.Deportes.Add(deporte);
						Console.WriteLine("El deporte fue añadido");
						opcionValida = true;
						break;
					}
			}
				
			if (!opcionValida)
				throw new NoDeporte("El deporte NO fue añadido debido a que no se encontro un entrenador");
		}
		
		/* Case 9 */
		public static void EliminarDeporte(Club c)
		{
			string nombreDeporte = "", categoria = ""; int opcion; bool opcionValida = false;
			Console.WriteLine("Los deportes que se pueden eliminar son:\n 0 - Futbol\n 1 - Voley\n 2 - Tenis\n 3 - Natacion\n 4 - Basket\n");
			Console.WriteLine("Ingrese el número del deporte que va a eliminar: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					nombreDeporte = "futbol";
					break;
				case 1:
					nombreDeporte = "voley";
					break;
				case 2:
					nombreDeporte = "tenis";
					break;
				case 3:
					nombreDeporte = "natacion";
					break;
				case 4:
					nombreDeporte = "basket";
					break;				
				default:
					throw new NoDeporte("Opción incorrecta");						
			}
			
			Console.WriteLine("Las categorias existentes son:\n 0 - Infantil\n 1 - Junior\n 2 - Juvenil\n");
			Console.WriteLine("Ingrese el número de la categoria que va a eliminar: ");
			opcion = int.Parse(Console.ReadLine());
			switch(opcion)
			{
				case 0:
					categoria = "infantil";
					break;
				case 1:
					categoria = "junior";
					break;
				case 2:
					categoria = "juvenil";
					break;
				default:
					throw new NoCategoria("Opción incorrecta");						
			}
			
			foreach(Deporte d in c.Deportes){
				if(d.Nombre.ToLower()==nombreDeporte && d.Categoria.ToLower()==categoria){
					opcionValida=true;
					if(d.Inscriptos.Count==0) {
						c.Deportes.Remove(d);
						Console.WriteLine("El deporte fue eliminado exitosamente");
						break;
					}
					else
						Console.WriteLine("Error: No debe tener inscriptos");
				}
			}
			if (!opcionValida)
				throw new NoDeporte("El deporte NO fue encontrado");	
		}
		
	} // PROGRAM 
} // NAMESPACE