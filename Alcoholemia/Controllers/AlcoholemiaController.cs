using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alcoholemia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcoholemiaController : ControllerBase
    {

        /*Nombre de la escuela: Universidad Tecnologica Metropolitana

        Asignatura: Aplicaciones Web Orientadas a Servicios

        Nombre del Maestro: Chuc Uc Joel Ivan

        Nombre de la actividad: Actividad 2 "Cálculo de nivel del alcohol en la sangre"

        Nombre del alumno: Fabian Francisco Aguilar Rivero

        Cuatrimestre: 4

        Grupo: B

        Parcial: 2
        */
        [HttpGet]

        [Route("Ejercicio2_Alcoholemia")]


        public IActionResult Calculo(string tipo, int cantidad, int kilogramos)
        {
            var Respuesta = "";

            Bebida bebida = new Bebida();
            bebida.Tipo = tipo;

            switch (bebida.Tipo)
            {
                case "Cerveza":
                    bebida.Mililitros = 330;
                    bebida.Grado = 0.05;
                    break;

                case "Vino":
                    bebida.Mililitros = 100;
                    bebida.Grado = 0.12;
                    break;

                case "Vermú":
                    bebida.Mililitros = 70;
                    bebida.Grado = 0.17;
                    break;

                case "Licor":
                    bebida.Mililitros = 45;
                    bebida.Grado = 0.23;
                    break;

                case "Brandy":
                    bebida.Mililitros = 45;
                    bebida.Grado = 0.38;
                    break;

                case "Combinado":
                    bebida.Mililitros = 50;
                    bebida.Grado = 0.38;
                    break;

                default:
                    Respuesta = ($"El tipo de bebida es: {tipo} ");
                    return Ok(Respuesta);

            }

            double TotalAlcohol = (bebida.Mililitros * cantidad);
            double CervezaConsumida = bebida.Grado * TotalAlcohol;
            double DirectoSangre = 0.15 * CervezaConsumida;
            double Etanol = 0.789 * DirectoSangre;
            double VolumPeso = 0.08 * kilogramos;
            double Alcoholemia = Etanol / VolumPeso;

            if (Alcoholemia > 0.8)
            {
                Respuesta = ($"Tiene una cantidad de alcohol en la sangre de {Alcoholemia.ToString("##,##0.00000")}, debe poner solicitar apoyo para el conductor");
            }
            else
            {
                Respuesta = ($"¡Tenga un excelente viaje!");
            }

            return Ok(Respuesta);


        }


    }
}
