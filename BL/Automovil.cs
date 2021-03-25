using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Automovil
    {
        public static ML.Result Add(ML.Automovil automovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BALfaroAPIGoogleMapsEntities context = new DL.BALfaroAPIGoogleMapsEntities())
                {
                    var Agregar = context.AutomovilAdd(automovil.Matricula, automovil.Marca, automovil.Modelo, automovil.Color,automovil.LatitudInicial,automovil.LongitudInicial,automovil.LatitudFinal,automovil.LongitudFinal);
                    if (Agregar == 0)
                    {
                        result.Correct=false;
                        result.ErrorMessage = "No se pudo agregar correctaente el automovil";
                    }
                    else
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BALfaroAPIGoogleMapsEntities context = new DL.BALfaroAPIGoogleMapsEntities())
                {
                    var ListaAutomoviles = context.AutomovilGetAll().ToList();
                    result.Objects = new List<object>();
                    foreach (var obj in ListaAutomoviles)
                    {
                        ML.Automovil automovil = new ML.Automovil();
                        automovil.Matricula = obj.Matricula;
                        automovil.Marca = obj.Marca;
                        automovil.Modelo = obj.Modelo;
                        automovil.Color = obj.Color;
                        automovil.LatitudInicial = (obj.LatitudInicial != null ? obj.LatitudInicial : " ");
                        automovil.LongitudInicial = (obj.LongitudInicial != null ? obj.LongitudInicial : " ");
                        automovil.LatitudFinal = (obj.LatitudFinal != null? obj.LatitudFinal: " ");
                        automovil.LongitudFinal = (obj.LongitudFinal != null? obj.LongitudFinal: " ");

                        result.Objects.Add(automovil);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(string Matricula)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BALfaroAPIGoogleMapsEntities context = new DL.BALfaroAPIGoogleMapsEntities())
                {
                    var Borrar = context.AutomovilDelete(Matricula);
                    if (Borrar == 0)
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar correctamente el registro";
                    }
                    else
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(string Matricula)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BALfaroAPIGoogleMapsEntities context = new DL.BALfaroAPIGoogleMapsEntities())
                {
                    var Registro = context.AutomovilGetById(Matricula).FirstOrDefault();
                    if (Registro != null)
                    {
                        ML.Automovil automovil = new ML.Automovil();
                        automovil.Matricula = Registro.Matricula;
                        automovil.Marca = Registro.Marca;
                        automovil.Modelo = Registro.Modelo;
                        automovil.Color = Registro.Color;
                        automovil.LatitudInicial = Registro.LatitudInicial;
                        automovil.LongitudInicial = Registro.LongitudInicial;
                        automovil.LatitudFinal = Registro.LatitudFinal;
                        automovil.LongitudFinal = Registro.LongitudFinal;
                        result.Object = automovil;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro con la matricula: "+Matricula;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Automovil automovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BALfaroAPIGoogleMapsEntities context = new DL.BALfaroAPIGoogleMapsEntities())
                {
                    var Actualizar = context.AutomovilUpdate(automovil.Matricula, automovil.Marca, automovil.Modelo, automovil.Color, automovil.LatitudInicial, automovil.LongitudInicial, automovil.LatitudFinal, automovil.LongitudFinal);
                    if (Actualizar == 0)
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualiar correctamente";
                    }
                    else
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
