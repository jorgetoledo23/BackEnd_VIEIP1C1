﻿using ConsoleAppEntityFramework.Migrations;
using ConsoleAppEntityFramework.Model;
using Microsoft.EntityFrameworkCore;

do
{
    Console.Clear();
    Console.WriteLine("[1] - Insertar Producto");
    Console.WriteLine("[2] - Ver Productos");
    Console.WriteLine("[3] - Actualizar Info Producto");
    Console.WriteLine("[4] - Eliminar Producto");
    Console.WriteLine("-------------------");
    Console.WriteLine("[5] - Insertar Cliente");
    Console.WriteLine("[6] - Ver Clientes");
    Console.WriteLine("-------------------");
    Console.WriteLine("[7] - Insertar Venta");
    Console.WriteLine("[8] - Ver Ventas");
    Console.WriteLine("-------------------");
    Console.WriteLine("[9] - Insertar Categoria");
    Console.WriteLine("[10] - Ver Categorias");
    Console.WriteLine("[11] - Ver Categorias por Id");
    Console.WriteLine("[12] - Ver Categorias por Nombre");


    Console.Write("\nSelecciona una Opcion: ");
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "9":
            Console.Clear();
            Console.Write("Nombre: "); var nameC = Console.ReadLine();
            Console.Write("Descripcion: "); var descC = Console.ReadLine();

            Categoria Cat = new Categoria()
            {
                Name = nameC,
                Descripcion = descC,
            };

            using (var context = new AppDbContext())
            {
                context.Add(Cat);
                context.SaveChanges();
            }

            Console.WriteLine("Categoria Agregada");
            Console.ReadLine();
            break;

        case "10":

            using (var context = new AppDbContext())
            {
                var Categorias = context.tblCategorias.ToList();
                foreach (var item in Categorias)
                {
                    Console.WriteLine($"Id: {item.CategoriaId} | Nombre: {item.Name} | Desc: {item.Descripcion}");
                }
            }
            Console.ReadLine();
            break;

        case "11":
            Console.Clear();
            Console.Write("Id que estas Buscando: ");
            var idBuscado = Convert.ToInt32(Console.ReadLine());
            using (var context = new AppDbContext())
            {
                var CategoriaBuscada = context.tblCategorias.Find(idBuscado);
                if (CategoriaBuscada != null)
                    Console.WriteLine($"Id: {CategoriaBuscada.CategoriaId} | Nombre: {CategoriaBuscada.Name} | Desc: {CategoriaBuscada.Descripcion}");
                else Console.WriteLine("No se encontro Categoria con el id proporcionado!");
            }
            Console.ReadLine();
            break;

        case "12":
            Console.Clear();
            Console.Write("Categoria que estas Buscando: ");
            var nombreBuscado = Console.ReadLine();
            using (var context = new AppDbContext())
            {
                var CategoriaBuscada2 = context.tblCategorias.Where(c=> c.Name.Contains(nombreBuscado)).ToList();
                if (CategoriaBuscada2.Count != 0)
                {
                    foreach (var item in CategoriaBuscada2)
                    {
                        Console.WriteLine($"Id: {item.CategoriaId} | Nombre: {item.Name} | Desc: {item.Descripcion}");
                    }
                }
                else Console.WriteLine("No se encontraron Categorias con el nombre proporcionado!");
            }
            Console.ReadLine();
            break;


        case "1":

            Console.Clear();
            Console.Write("Nombre: "); var name = Console.ReadLine();
            Console.Write("Precio: "); var precio = Convert.ToInt32(Console.ReadLine());
            Console.Write("Stock: "); var stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Url: "); var url = Console.ReadLine();
            Console.Write("Id Categoria: "); var catid = Convert.ToInt32(Console.ReadLine());

            Producto P = new Producto()
            {
                Name = name,
                Precio = precio,
                Stock = stock,
                UrlImagen = url,
                CategoriaId = catid
            };

            using (var context = new AppDbContext())
            {
                context.Add(P);
                context.SaveChanges();
            }

            Console.WriteLine("Producto Agregado");
            Console.ReadLine();
            break;

        case "2":
            Console.Clear();
            using (var context = new AppDbContext())
            {
                var ProductosGuardados = context.tblProductos.Include(p=>p.Categoria).ToList();
                foreach (var item in ProductosGuardados)
                {
                    Console.WriteLine($"Id: {item.Id} | Name: {item.Name} | " +
                        $"Precio: {item.Precio} | Stock: {item.Stock} | " +
                        $"Url: {item.UrlImagen} | Categoria: {item.Categoria.Name}");
                }
            }
            Console.WriteLine("Productos Listados...");
            Console.ReadLine();
            break;

        case "3":
            //Actualizar Producto
            Console.Write("Ingresa el Id del Producto que quieres Actualizar: ");
            var Id = Convert.ToInt32(Console.ReadLine());

            using (var context = new AppDbContext())
            {
                Producto? X = context.tblProductos.Find(Id);

                if (X != null)
                {
                    Console.Clear();
                    Console.Write("Nombre: "); var nameEditado = Console.ReadLine();
                    Console.Write("Precio: "); var precioEditado = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Stock: "); var stockEditado = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Url: "); var urlEditado = Console.ReadLine();

                    X.Name = nameEditado;
                    X.Precio = precioEditado;
                    X.Stock = stockEditado;
                    X.UrlImagen = urlEditado;

                    context.Update(X);
                    context.SaveChanges();
                    Console.WriteLine("Producto Editado");
                }
                else
                {
                    Console.WriteLine("Producto No Encontrado!");
                }
                Console.ReadLine();
            }

            break;

        case "4":

            Console.Write("Ingresa el Id del Producto que quieres Eliminar: ");
            var IdEliminar = Convert.ToInt32(Console.ReadLine());

            using (var context = new AppDbContext())
            {
                Producto? Z = context.tblProductos.Find(IdEliminar);

                if (Z != null)
                {
                    context.Remove(Z);
                    context.SaveChanges();
                    Console.WriteLine("Producto Eliminado");
                }
                else
                {
                    Console.WriteLine("Producto No Encontrado!");
                }
                Console.ReadLine();
            }

            break;

        case "5":

            Console.Clear();
            Console.Write("Nombre: "); var nameCliente = Console.ReadLine();
            Console.Write("Apellido: "); var apellido = Console.ReadLine();
            Console.Write("Telefono: "); var telefono = Console.ReadLine();
            Console.Write("Rut: "); var Rut = Console.ReadLine();

            Cliente C = new Cliente()
            {
                Nombre = nameCliente,
                Apellido = apellido,
                Telefono = telefono,
                Rut = Rut
            };

            using (var context = new AppDbContext())
            {
                context.Add(C);
                context.SaveChanges();
            }

            Console.WriteLine("Cliente Agregado");
            Console.ReadLine();
            break;

        case "6":
            Console.Clear();
            using (var context = new AppDbContext())
            {
                var ClientesGuardados = context.tblClientes.ToList();
                foreach (var cliente in ClientesGuardados)
                {
                    Console.WriteLine($"Rut: {cliente.Rut} | Name: {cliente.Nombre} | " +
                        $"Apellido: {cliente.Apellido} | Telefono: {cliente.Telefono}");
                }
            }
            Console.WriteLine("Clientes Listados...");
            Console.ReadLine();
            break;

        case "7":

            Console.Clear();
            Console.Write("Total: "); var Total = Convert.ToInt32(Console.ReadLine());
            Console.Write("Iva: "); var Iva = Convert.ToInt32(Console.ReadLine());
            Console.Write("Rut: "); var RutCliente = Console.ReadLine();

            Venta V = new Venta()
            {
                Total = Total,
                IVA = Iva,
                ClienteRut = RutCliente,
                Fecha = DateTime.Now
            };

            using (var context = new AppDbContext())
            {
                context.Add(V);
                context.SaveChanges();
            }

            Console.WriteLine("Venta Agregada");
            Console.ReadLine();
            break;

        case "8":
            Console.Clear();
            using (var context = new AppDbContext())
            {
                var VentasRealizadas = context.tblVentas
                    .Include(v => v.Cliente)
                    .ToList();

                foreach (var venta in VentasRealizadas)
                {
                    Console.WriteLine($"Id Venta: {venta.Id} | Total: {venta.Total} | " +
                        $"IVA: {venta.IVA} | Rut Cliente: {venta.ClienteRut} | " +
                        $"Nombre Cliente: {venta.Cliente.Nombre} {venta.Cliente.Apellido} |" +
                        $"Fecha: {venta.Fecha.ToString("f")}");
                }
            }
            Console.WriteLine("Ventas Listadas...");
            Console.ReadLine();
            break;



        default:
            break;
    }





} while (true);