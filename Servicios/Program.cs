using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Opciones();
        }

        private static void Opciones()
        {
            var salir = false;
            do
            {
                Console.WriteLine("\n".PadRight(37, '-') + "\n".PadRight(37, '-'));
                Console.WriteLine("-- 1. Mostrar legajo completo.    --");
                Console.WriteLine("-- 2. Mostrar materias.           --");
                Console.WriteLine("-- 3. Mostrar profesores.         --");
                Console.WriteLine("-- 4. Insertar un nuevo alumno.   --");
                Console.WriteLine("-- 5. Insertar un nuevo profesor. --");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("-- X. Para salir.                 --");
                Console.WriteLine("".PadRight(36, '-') + "\n".PadRight(37, '-'));
                Console.Write("-- Ingrese su opcion: ");
                String opcion = Console.ReadLine();

                if (opcion == "1") MostarDatos();

                else if (opcion == "2") MostarMateria();

                else if (opcion == "3") MostarProfesor();

                else if (opcion == "4") InsertarNuevoAlumno();

                else if (opcion == "5") InsertarNuevoProfesor();

                //else if (opcion == "6") ActualizarUnaCiudad();

                else if (opcion.ToUpper() == "X") salir = true;

                else Console.WriteLine("Valor ingesado incorrecto!! Ingrese un valor nuevamente.");

            } while (!salir);
        }

        private static void MostarDatos()
        {
            using (var bdEscuela = new EscuelaModificadoContenx())
            {
                var elementos = bdEscuela.alumnoes.Include("materia.profesors").Where(x => x.id_mat_alu <= 101).ToList();

                Console.WriteLine("".PadRight(77, '-'));
                Console.WriteLine("".PadLeft(19, '-') + "".PadLeft(10, ' ') + "Legajo de alumnos.".PadRight(29, ' ') + "".PadRight(19, '-'));
                Console.WriteLine("".PadRight(77, '-'));
                Console.WriteLine("-- Legajo".PadRight(10, ' ') + "Nombre".PadRight(12, ' ') + "Edad".PadRight(6, ' ') + "Genero".PadRight(11, ' ') + "Materia".PadRight(19, ' ') + "Profesor".PadRight(17, ' ') + "--");

                foreach (var a in elementos)
                {
                    foreach (var q in a.materia.profesors)
                    {
                        Console.Write("--" + $"{a.id_mat_alu}".PadLeft(4, ' ').PadRight(8, ' ') + $"{a.nombre_alu}".PadRight(13, ' ') + $"{a.edad_alu}".PadRight(5, ' ') + $"{a.genero_alu}".PadRight(11, ' ') + $"{a.materia.nombre_mat}".PadRight(19, ' '));
                        Console.WriteLine(q.nom_p.PadRight(17, ' ') + "--");
                    }
                }
                Console.WriteLine("".PadRight(77, '-'));
                Console.WriteLine("".PadRight(77, '-'));


            }
        }

        private static void MostarMateria()
        {
            Console.WriteLine("".PadRight(61, '-'));
            Console.WriteLine("".PadLeft(15, '-').PadRight(22, ' ') + "LISTA DE MATERIAS".PadRight(24, ' ') + "".PadRight(15, '-'));
            Console.WriteLine("".PadRight(61, '-'));
            Console.WriteLine("--" + " id.".PadRight(5, ' ') + "Materia".PadRight(35, ' ') + "Profesor".PadRight(17, ' ') + "--");
            using (var bdEscuela = new EscuelaModificadoContenx())
            {
                var materiasObtenidas = bdEscuela.materias.Include("profesors").Where(x => x.id_mat > 0).ToList();

                foreach (var matObtenido in materiasObtenidas)
                {
                    foreach (var prof in matObtenido.profesors)
                        Console.WriteLine("-- " + matObtenido.id_mat.ToString().PadRight(4, ' ') + matObtenido.nombre_mat.PadRight(17, ' ') + " es impartida por " + prof.nom_p.PadRight(17, ' ') + "--");
                }
            }
            Console.WriteLine("".PadRight(61, '-'));
            Console.WriteLine("".PadRight(61, '-'));
        }

        private static void MostarProfesor()
        {
            Console.WriteLine("".PadRight(68, '-'));
            Console.WriteLine("".PadLeft(15, '-').PadRight(26, ' ') + "LISTA DE PROFESORES".PadRight(27, ' ') + "".PadRight(15, '-'));
            Console.WriteLine("".PadRight(68, '-'));

            Console.WriteLine("--" + " id.".PadRight(5, ' ') + "Nombre".PadRight(21, ' ') + "Celular".PadRight(13, ' ') + "Ingreso".PadRight(11, ' ') + "Horarios".PadRight(9, ' ') + "id.M " + "--");
            using (var bdEscuela = new EscuelaModificadoContenx())
            {
                var profesoresObtenidas = bdEscuela.profesors.Where(x => x.id_prof > 0).ToList();

                foreach (var profObtenido in profesoresObtenidas)
                {
                    Console.WriteLine("-- " + profObtenido.id_prof.ToString().PadRight(4, ' ') + profObtenido.nom_p.PadRight(17, ' ') + "(+54)" +
                        profObtenido.tel_p.ToString().PadRight(12, ' ') + profObtenido.hor_p.ToString().PadRight(22, ' ') + profObtenido.id_mat1.ToString().PadRight(3, ' ') + "--");
                }
            }
            Console.WriteLine("".PadRight(68, '-'));
            Console.WriteLine("".PadRight(68, '-'));
        }

        private static void InsertarNuevoAlumno()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-- Ingresando a un nuevo alumno --");
            Console.WriteLine("----------------------------------");
            Console.Write("-- Ingrese el nombre del alumno : ");
            String nombre = DatosAlumno.getNombre();
            Console.Write("-- Ingrese la edad del alumno : ");
            int edad = DatosAlumno.getEdadAlumno();
            Console.Write("-- Ingrese el genero del alumno [Masculino/Femenino]: ");
            String genero = DatosAlumno.getGeneroAlumno();
            Console.Write("-- Ingrese el id de la carrera alumno : ");
            int carreraa = DatosAlumno.getIdCarrera();
            Console.Write("-- Ingrese el id de la materia alumno : ");
            int materiaa = DatosAlumno.getIdMateria();

            using (var bdEscuela = new EscuelaModificadoContenx())
            {
                using (var transicion = bdEscuela.Database.BeginTransaction())
                {
                    try
                    {
                        alumno nuevoAlumno = new alumno { nombre_alu = nombre, edad_alu = edad, genero_alu = genero, id_carre1 = carreraa, id_mat2 = materiaa };
                        
                        bdEscuela.alumnoes.Add(nuevoAlumno);
                        bdEscuela.SaveChanges();

                        transicion.Commit();
                    }
                    catch (Exception)
                    {
                        transicion.Rollback();
                    }
                }
            }
            Console.Write("ENTER para continuar...");
            Console.ReadLine();
        }

        private static void InsertarNuevoProfesor()
        {
            
            using (var bdEscuela = new EscuelaModificadoContenx())
            {
                using (var transicion = bdEscuela.Database.BeginTransaction())
                {
                    try
                    {
                        DatosProfesor profe = new DatosProfesor();

                        DateTime horario = new DateTime(0,0,0, profe.getTimeProf(),0,0);

                        profesor agregarProfesor = new profesor { nom_p = profe.getName(), tel_p = profe.getPhone(), hor_p = horario, id_mat1 = profe.getMateria() };

                        bdEscuela.profesors.Add(agregarProfesor);
                        bdEscuela.SaveChanges();

                        transicion.Commit();
                    }
                    catch (Exception)
                    {
                        transicion.Rollback();
                    }
                }
            }
        }

    }
    
    class DatosAlumno
    {
        private static int legajoAlumno, edadAlumno, idCarrera, idMateria = new int();
        private static String nombreAlumno, generoAlumno;
    
        public static String getNombre()
        {
            nombreAlumno = Console.ReadLine();
            return nombreAlumno;
        }

        public static int getLegajoAlumno()
        {
            int.TryParse(Console.ReadLine(), out legajoAlumno);
            return legajoAlumno;
        }

        public static int getEdadAlumno()
        {
            int.TryParse(Console.ReadLine(), out edadAlumno);
            return edadAlumno;
        }

        public static String getGeneroAlumno()
        {
            generoAlumno = Console.ReadLine();
            return generoAlumno;
        }

        public static int getIdCarrera()
        {
            int.TryParse(Console.ReadLine(), out idCarrera);
            return idCarrera;
        }

        public static int getIdMateria()
        {
            int.TryParse(Console.ReadLine(), out idMateria);
            return idMateria;
        }

    }

    class DatosProfesor
    {
        public DatosProfesor()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("-- Ingresando a un nuevo profesor --");
            Console.WriteLine("------------------------------------");
            Console.Write("-- Ingrese el nombre del profesoraa : ");
            nombreP = Console.ReadLine();
            Console.Write("-- Ingrese el telefono del profesor/a : ");
            int.TryParse(Console.ReadLine(), out telefono);
            Console.Write("-- Ingrese el horario del profesor/a (07:) en adelante : ");
            int.TryParse(Console.ReadLine(), out horarioP);
            Console.Write("-- Ingrese el id de la materia que imparte : ");
            int.TryParse(Console.ReadLine(), out idMateria);
        }

        private static String nombreP;
        private static int telefono, idMateria, horarioP = new int();

        public string getName() => nombreP;

        public int getTimeProf() => horarioP;

        public int getPhone() => telefono;

        public int getMateria() => idMateria;
    }
}
