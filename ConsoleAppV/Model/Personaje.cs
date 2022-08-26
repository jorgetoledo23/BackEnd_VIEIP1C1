namespace ConsoleAppV.Model
{
    public class Personaje
    {
        public string Nombre { get; }
        public int Vida { get; set; } = 100;
        public int Fuerza { get; set; } = 100;
        public int Oro { get; set; } = 1000;
        public List<Item> ItemsEquipados { get; set; }


        public Personaje(string nombre)
        {
            Nombre = nombre;
            ItemsEquipados = new List<Item>();
        }

        public void Atacar(Personaje Objetivo)
        {
            Objetivo.Vida -= Fuerza / 15 + 10;
        }

        public void Comprar(Item item)
        {
            Oro -= item.Coste;
            Fuerza += item.Fuerza;
            Vida += item.Vida;
            ItemsEquipados.Add(item);
        }


    }
}
