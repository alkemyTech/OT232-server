using System;
using Microsoft.EntityFrameworkCore;
using OngProject.Entities;

namespace OngProject.DataAccess
{
    public static class ActivitiesSeeds
    {
        public static void ActivitiesSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(
            new Activity
            {
                Id = 1,
                IsDeleted = false,
                Name = @"Programas Educativos",
                Content = @"Mediante nuestrso programas educativos,buscamos incrementar la capacidad intelectual, moral y afectivas de las personas de acuerdo con la cultura y las normas de convivencia de la sociedad a la que pertenecen",
                Image = @"programasEducativos.jpg",
                LastModified = DateTime.Now,

            },
            new Activity
            {
                Id = 2,
                IsDeleted = false,
                Name = @"Apoyo Escolar para el nivel Primario",
                Content = @"El espacio de apoyo escolar es el corazon del area educativa. Se realizan los talleres de lunes a jueves de 10 a 12 horas y de 14 a 16 horas en el contraturno, los sabados tambien se realiza el taller para niños y niñas que asisten a la escuela doble turno. Tenemos un espacio especial para los de 1er grado 2 veces por semana ya que ellos necesitan atencion especial!
Actualmente se encuentran inscriptos a este programa 150 niños y niñas de 6 a 15 años. Este taller esta pensado para ayudar a los alumnos con el material que traen de la escuela, tambien tenemos una docente que les da clases de lengua y matematica con una planificacion propia que armamos en Manos para nivelar a los niños y que vayan con mas herramientas a la escuela",
                Image = @"apoyoEscolarPrimario.jpg",
                LastModified = DateTime.Now,

            },
            new Activity
            {
                Id = 3,
                IsDeleted = false,
                Name = @"Apoyo Escolar nivel Secundaria",
                Content = @"Del mismo modo que en la primaria, este taller es el corazon del area secundaria. Se realizan talleres de lunes a viernes de 10 a 12 horas y de 16 a 18horas en el contraturno. Actualmente se encuentran inscriptos en el taller 50 adolescentes entre 13 y 20 años. Aqui los joveces se presentan con el material que traen del colegio y una docente de la institucion y un grupo de voluntarios los recibe para ayudarlos a estudiar o hacer la tarea. Este espacio tambien es utilizado por los jovenes como un punto de encuentro y relacion entre ellos y la institucion",
                Image = @"apoyoEscolarSecundario.jpg",
                LastModified = DateTime.Now,

            },
            new Activity
            {
                Id = 4,
                IsDeleted = false,
                Name = @"Tutorias",
                Content = @"Es un programa destinado a joveces a partir del tercer año de secundaria, cuyo objetivo es garantizar su permanencia en la escuela y construir un proyecto de vida que da sentido al colegio.El objetivo de esta propuesta es lograr la integracion escolar de niños y jovenes del barrio promoviendo el soporte socioeducativo y emocional apropiado, desarrollando los recursos institucionales necesarios a traves de la articulacion de nuestras intervenciones con las escuelas que los alojan con las familias de los alumnos y las instancias municipales, provinciales y nacionales que correspondan",
                Image = @"tutorias.jpg",
                LastModified = DateTime.Now,

            });
            

        }
    }
}
