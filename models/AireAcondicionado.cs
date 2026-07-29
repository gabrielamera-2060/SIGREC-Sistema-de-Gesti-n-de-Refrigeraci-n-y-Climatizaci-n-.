using System.Collections.Generic;

namespace TorneoPOO_CEspinoza.Models
{
    public class Equipo
    {
        // Atributos
        private string nombre;
        private string ciudad;
        private string color;
        private string estadio;
        private string apodo;
        private string entrenador;
        private List<string> jugadores;

        // Constructor
        public Equipo(string nombre, string ciudad, string color, string estadio, string apodo, string entrenador)
        {
            this.nombre = nombre;
            this.ciudad = ciudad;
            this.color = color;
            this.estadio = estadio;
            this.apodo = apodo;
            this.entrenador = entrenador;
            this.jugadores = new List<string>(); // importante inicializar la lista
        }

        // Métodos Get y Set - por si los necesitas
        public string GetNombre() { return nombre; }
        public void SetNombre(string nombre) { this.nombre = nombre; }

        public string GetCiudad() { return ciudad; }
        public void SetCiudad(string ciudad) { this.ciudad = ciudad; }

        public string GetColor() { return color; }
        public void SetColor(string color) { this.color = color; }

        public string GetEstadio() { return estadio; }
        public void SetEstadio(string estadio) { this.estadio = estadio; }

        public string GetApodo() { return apodo; }
        public void SetApodo(string apodo) { this.apodo = apodo; }

        public string GetEntrenador() { return entrenador; }
        public void SetEntrenador(string entrenador) { this.entrenador = entrenador; }

        // Métodos para la lista de jugadores
        public void AgregarJugador(string jugador)
        {
            jugadores.Add(jugador);
        }

        public List<string> GetJugadores()
        {
            return jugadores;
        }
    }
}