//Coleccion (muchos)
using ConsoleAppV.Model;

List<Item> listadoItems = new List<Item>()
{
    new Item("Espada",0,120,200),
    new Item("Escudo",120, 0, 200),
    new Item("Cuchillo", 0, 30, 80),
    new Item("Pocion", 30,10, 50),
    new Item("Botiquin", 100, 0, 100)
};

Item item6 = new Item("Armadura", 150, 20, 200);
listadoItems.Add(item6);

Item item7 = new Item("Guante", 50, 60, 100);
listadoItems.Add(item7);


Personaje Player1 = new Personaje("Player 1");
Personaje Player2 = new Personaje("Player 2");


bool Turno = true; 
// True => Turno jugador 1 --- False => Turno Jugador 2


do
{
    Console.Clear();

    //Console.SetCursorPosition(10, 0);

    Console.WriteLine("=====Juego PvP=====");
    if (Turno) Console.WriteLine("Turno Jugador 1");
    else Console.WriteLine("Turno Jugador 2");

    Console.WriteLine("--------------------");

    //Estadisticas de los Players
    Console.WriteLine($"Stats Jugador 1: Vida: { Player1.Vida }, Fuerza: {Player1.Fuerza}, Oro: {Player1.Oro}");
    Console.WriteLine($"Stats Jugador 2: Vida: { Player2.Vida }, Fuerza: {Player2.Fuerza}, Oro: {Player2.Oro}");


    //Menu

    Console.WriteLine("[1] - Atacar");
    Console.WriteLine("[2] - Comprar");

    Console.Write("Que quieres hacer: ");
    string Opcion = Console.ReadLine();

    switch (Opcion)
    {
        case "1": //Ataco
            if (Turno) Player1.Atacar(Player2);
            else Player2.Atacar(Player1);
            break;

        case "2": //Comprar
            Console.Clear();
            Console.WriteLine("=====Tiendita=====");

            foreach (Item item in listadoItems)
            {
                Console.WriteLine($"{item.Nombre}, Vida: +{item.Vida}, " +
                    $"Fuerza: +{item.Fuerza}, Coste: {item.Coste}");
            }
            Console.Write("Elige el Itemque quiere Comprar: ");
            string compra = Console.ReadLine();

            Item? i = listadoItems.Find(x => x.Nombre == compra);

            if (Turno) Player1.Comprar(i);
            else Player2.Comprar(i);

            Console.WriteLine("Item Comprado, Presiona Enter para Continuar...");

            break;
    }


    Turno = !Turno;
    //Console.ReadLine();
    
} while (true);