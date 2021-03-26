using System;
using System.Linq;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            LlamadaBaseDeDatosPorLambdaV1();
            LlamadaBaseDeDatosPorLambdaV2();
            Console.WriteLine();
            LlamadaBaseDeDatosPorQuery();

            Console.ReadLine();
        }

        private static void LlamadaBaseDeDatosPorLambdaV1()
        {
            using (var bdEscuela = new BaseD.EscuelaModificadoEntities())
            {
                var alumnosObtenidos1 = bdEscuela.alumno
                    .Where(x => x.id_mat2 == x.materia.id_mat).ToList();

                var profesoresObtenidos = bdEscuela.profesor
                    .Select(x => new
                    {
                        idMat = x.id_mat1,
                        nombreProf = x.nom_p
                    });
                Console.WriteLine("".PadRight(15, '-') + "    Por Expresion lambda V1    " + "".PadRight(15, '-'));
                Console.WriteLine("Id.".PadRight(5, ' ') + "Alumno".PadRight(12, ' ') + "Materia".PadRight(16, ' ') + "Profesor");
                foreach (var item1 in alumnosObtenidos1)
                {
                    foreach (var item2 in profesoresObtenidos)
                    {
                        if (item1.id_mat2 == item2.idMat)
                        {
                            Console.WriteLine(item1.id_mat_alu.ToString().PadRight(5, ' ') + item1.nombre_alu.PadRight(12, ' ') + item1.materia.nombre_mat.PadRight(16, ' ') + item2.nombreProf);
                        }
                    }
                }
            }

        }

        private static void LlamadaBaseDeDatosPorLambdaV2()
        {
            using (var bdEscuela = new BaseD.EscuelaModificadoEntities())
            {
                var alumnosObtenidos2 = bdEscuela.alumno
                   .Where(x => x.id_mat2 == x.materia.id_mat).ToList();

                Console.WriteLine("".PadRight(15, '-') + "    Por Expresion lambda V2    " + "".PadRight(15, '-'));
                Console.WriteLine("Id.".PadRight(5, ' ') + "Alumno".PadRight(12, ' ') + "Materia".PadRight(16, ' ') + "Profesor");
                foreach (var item1 in alumnosObtenidos2)
                {
                    foreach (var item2 in item1.materia.profesor)
                    {
                        if (item1.id_mat2 == item2.id_mat1)
                        {
                            Console.WriteLine(item1.id_mat_alu.ToString().PadRight(5, ' ') + item1.nombre_alu.PadRight(12, ' ') + item1.materia.nombre_mat.PadRight(16, ' ') + item2.nom_p);
                        }
                    }
                }
            }
        }

        private static void LlamadaBaseDeDatosPorQuery()
        {
            using (var bdEscuela = new BaseD.EscuelaModificadoEntities())
            {
                var query = from alu in bdEscuela.alumno
                            join mat in bdEscuela.materia on alu.id_mat2 equals mat.id_mat
                            join pro in bdEscuela.profesor on mat.id_mat equals pro.id_mat1
                            where alu.id_mat_alu > 0 && alu.id_mat_alu <= 20
                            orderby alu.id_mat_alu ascending
                            select new { alu.id_mat_alu, alu.nombre_alu, mat.nombre_mat, pro.nom_p };

                Console.WriteLine("".PadRight(15, '-') + "    Por Expresion query    " + "".PadRight(15, '-'));
                Console.WriteLine("Id.".PadRight(5, ' ') + "Alumno".PadRight(12, ' ') + "Materia".PadRight(16, ' ') + "Profesor");
                foreach (var item1 in query)
                {
                    Console.WriteLine(item1.id_mat_alu.ToString().PadRight(5, ' ') + item1.nombre_alu.PadRight(12, ' ') + item1.nombre_mat.PadRight(16, ' ') + item1.nom_p);
                }
            }
        }
    }
}
