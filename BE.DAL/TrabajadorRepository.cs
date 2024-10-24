using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.BE;

namespace TP2.DAL
{
    public class TrabajadorRepository
    {
        private static List<Trabajador> _trabajadores;
        private static string _filePath = "trabajadores.txt"; // Ruta del archivo de texto

        // Constructor que inicializa la lista leyendo desde un archivo de texto
        static TrabajadorRepository()
        {
            _trabajadores = new List<Trabajador>();
            CargarDesdeArchivo();
        }

        // Método para cargar trabajadores desde el archivo de texto
        private static void CargarDesdeArchivo()
        {
            if (!File.Exists(_filePath))
            {
                // Si el archivo no existe, lo creamos vacío
                File.Create(_filePath).Close();
            }
            else
            {
                var lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    var data = line.Split(';'); // Usamos ';' como separador en el archivo
                    if (data.Length == 13 )// Asegurarse de que el formato es correcto
                    {
                        _trabajadores.Add(new Trabajador
                        {
                            Id = int.Parse(data[0]),
                            Apellido = data[1],
                            Nombre = data[2],
                            Domicilio = data[3],
                            Localidad = data[4],
                            Provincia = data[5],
                            NroCelular = (int)long.Parse(data[6]),
                            Categoria = new Categoria { Nombre = data[7] },
                            Rango = new Rango { Nombre = data[8] },
                            AreaTrabajo = data[9],
                            CantidadHoras = int.Parse(data[10]),
                            ValorHora = decimal.Parse(data[11]),
                            FechaIngreso = DateTime.Parse(data[12])
                        });
                    }
                }
            }
        }

        // Método para guardar trabajadores en el archivo de texto
        private static void GuardarEnArchivo()
        {
            var lines = _trabajadores.Select(t =>
                $"{t.Id};{t.Apellido};{t.Nombre};{t.Domicilio};{t.Localidad};{t.Provincia};{t.NroCelular};{t.Categoria.Nombre};{t.Rango.Nombre};{t.AreaTrabajo};{t.CantidadHoras};{t.ValorHora};{t.FechaIngreso}"
            );
            File.WriteAllLines(_filePath, lines);
        }

        // Obtener todos los trabajadores
        public List<Trabajador> ObtenerTrabajadores()
        {
            return _trabajadores;
        }

        // Editar un trabajador existente
        public void EditarTrabajador(int id, Trabajador nuevoTrabajador)
        {
            var trabajador = _trabajadores.FirstOrDefault(t => t.Id == id);
            if (trabajador != null)
            {
                trabajador.Apellido = nuevoTrabajador.Apellido;
                trabajador.Nombre = nuevoTrabajador.Nombre;
                trabajador.Domicilio = nuevoTrabajador.Domicilio;
                trabajador.Localidad = nuevoTrabajador.Localidad;
                trabajador.Provincia = nuevoTrabajador.Provincia;
                trabajador.NroCelular = nuevoTrabajador.NroCelular;
                trabajador.Categoria = nuevoTrabajador.Categoria;
                trabajador.Rango = nuevoTrabajador.Rango;
                trabajador.AreaTrabajo = nuevoTrabajador.AreaTrabajo;
                trabajador.CantidadHoras = nuevoTrabajador.CantidadHoras;
                trabajador.ValorHora = nuevoTrabajador.ValorHora;
                trabajador.FechaIngreso = nuevoTrabajador.FechaIngreso;

                GuardarEnArchivo(); // Guardar cambios en el archivo
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Trabajador no encontrado.");
            }
        }

        // Agregar un nuevo trabajador
        public void AgregarTrabajador(Trabajador trabajador)
        {
            if (trabajador == null)
            {
                throw new ArgumentNullException(nameof(trabajador), "El trabajador no puede ser nulo.");
            }
            trabajador.Id = _trabajadores.Count > 0 ? _trabajadores.Max(t => t.Id) + 1 : 1; // Asignar un ID el primer trabajador tiene id=1
            _trabajadores.Add(trabajador);
            GuardarEnArchivo(); // Guardar en el archivo
        }

        // Eliminar un trabajador por ID
        public void EliminarTrabajador(int id)
        {
            var trabajador = _trabajadores.FirstOrDefault(t => t.Id == id);
            if (trabajador != null)
            {
                _trabajadores.Remove(trabajador);
                GuardarEnArchivo(); // Guardar cambios en el archivo
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Trabajador no encontrado.");
            }
        }
    }
}
