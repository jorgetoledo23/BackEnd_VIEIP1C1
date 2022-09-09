using ConsoleApp_BD.Model;

string opcion = "";
do
{
    Console.Clear();
    Console.WriteLine("[1] - Insertar Nuevo Item");
    Console.WriteLine("[2] - Revisar Items");

    Console.Write("Selecciona la Opcion: ");
    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Nombre del Item: ");
            string Nombre = Console.ReadLine();

            Console.Write("Vida que proporciona el Item: ");
            string Vida = Console.ReadLine();

            Console.Write("Fuerza que proporciona el Item: ");
            string Fuerza = Console.ReadLine();

            Console.Write("Valor del Item: ");
            string Valor = Console.ReadLine();


            Item item = new Item()
            {
                Nombre = Nombre,
                Vida = Convert.ToInt32(Vida),
                Fuerza = Convert.ToInt32(Fuerza),
                Coste = Convert.ToInt32(Valor)
            };

            using (AppDbContext _context = new AppDbContext())
            {
                _context.tablaItems.Add(item); //Insert into tablaItems values ('Nombre', 'Fuerza', 'Vida', 990)
                _context.SaveChanges();
            }

            Console.WriteLine("Item creado exitosamente. Presione Enter para Continuar!");
            Console.ReadLine();

            break;


        case "2":

            using (AppDbContext _context = new AppDbContext())
            {
                var listadoItems = _context.tablaItems.ToList(); //Select * From tablaItems

                foreach (var i in listadoItems)
                {
                    Console.WriteLine($"Id: {i.ItemId}, Nombre: {i.Nombre}, Vida: {i.Vida}, " +
                        $"Fuerza: {i.Fuerza}, Coste: {i.Coste}");
                }
                Console.WriteLine("Items Listados... Presione Enter para Continuar!");
                Console.ReadLine();

            }



            break;
    }


} while (true);
