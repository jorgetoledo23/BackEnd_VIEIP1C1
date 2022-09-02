namespace ConsoleAppV.Model
{
    public class Personaje
    {
        //TODO: Podriamos generar habilidades ()
        public string Nombre { get; }
        public int Vida { get; set; } = 100;
        public int Fuerza { get; set; } = 100;
        public int Oro { get; set; } = 1000;
        public List<Item> Inventario { get; set; }


        public Personaje(string nombre)
        {
            //asdasdAASDDASaasaads Aasdasd Aasdasd
            Nombre = nombre.ToUpper();
            Inventario = new List<Item>();
        }

        public int Atacar(Personaje Objetivo)
        {
            //TODO: Aplicar mas Factores (Robo de Vida, Evasion, Critico)
            Objetivo.Vida -= Fuerza / 15 + 10;
            return Objetivo.Vida; // 80
        }

        public void Comprar(Item item)
        {
            Oro -= item.Coste;
            Fuerza += item.Fuerza;
            Vida += item.Vida;
            Inventario.Add(item);
        }


    }
}
