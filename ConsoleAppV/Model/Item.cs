namespace ConsoleAppV.Model
{
    public class Item
    {
        //Propiedades => Caracteristicas => Atributos
        public string Nombre { get; }
        public int Vida { get; }
        public int Fuerza { get; }
        public int Coste { get; }

        //TODO: Generar Items con RV, Critico, Evasion, Armadura
        //Constructor
        //__init__()
        public Item(string nombre, int vida, int fuerza, int coste)
        {
            Nombre = nombre;
            Vida = vida;
            Fuerza = fuerza;
            Coste = coste;
        }

    }
}
