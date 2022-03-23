using System;
using Multiplayer_flashero.Entidades.objetos;
using Multiplayer_flashero.Entidades.vivos;
using Multiplayer_flashero.Entidades.objetos.consumibles;

namespace Multiplayer_flashero
{
    class Program
    {

        public static Jugador jugador = new Jugador(Console.ReadLine(), 1);
        public static Objeto[] inv = new Objeto[20];
        public static Enemigo enemigo = new Enemigo("Aaraña", 1);
        static void Main(string[] args)
        {

            Console.Write(">Eliga un nombre para su personaje: ");
            int nivel = 1;
            Random x = new Random();
            /////////////////////////////////////////////  PARTIDA  /////////////////////////////////////
            do
            {
                enemigo.reset("Araña", nivel);
                menuInicial();
                while (enemigo.getVida() > 0 && jugador.getVida() > 0)
                {
                    menu();
                    turnoJugador();
                    turnoEnemigo();

                    Console.ReadKey();
                }

                int c = x.Next((15 * nivel), (28 * nivel));

                if (enemigo.getVida() <= 0) Console.WriteLine(enemigo.getNombre() + " se muere y suelta " + (c) + " de cobre"); Console.ReadKey();
                jugador.setCobre(c);
                nivel++;
                jugador.setNivel(jugador.getNivel() + 1);
                jugador.setVidaMax(5*nivel);


            } while (jugador.getVida() > 0);

            Console.WriteLine(jugador.getNombre() + " es asesinado por " + enemigo.getNombre() + " Nivel: " + enemigo.getNivel());
            ///////////////////////////////////////////////////////////////////////////////////////////////////
        }






        //////////////////////////////////////////////// MENU ///////////////////////////////////////////////////////
        public static void menu()
        {
            
            Console.Clear();
            //estadisticas jugador
            Console.WriteLine("=======================================================================================");
            Console.WriteLine(@"    /\     ");
            Console.WriteLine("    ||    " + jugador.getNombre() + " Nivel: " + jugador.getNivel());
            Console.WriteLine("    ||    Vida: " + jugador.getVida() + "/" + jugador.getVidaMax() + " + Armadura: " + jugador.getArmadura() + "/" + jugador.getArmaduraMax());
            Console.WriteLine("  =={}==  Defensa: " + jugador.getDefensa() + " Daño: " + jugador.getDanio());
            Console.WriteLine("    []   ");
            Console.WriteLine("=======================================================================================");

            //estadisticas enemigo
            Console.WriteLine("=======================================================================================");
            Console.WriteLine(@"      ");
            Console.WriteLine(@"  \_|_|_/   " + enemigo.getNombre() + " Nivel: " + enemigo.getNivel());
            Console.WriteLine(@"   (>:D)    Vida: " + enemigo.getVida() + "/" + enemigo.getVidaMax() + " + Armadura: " + enemigo.getArmadura() + "/" + enemigo.getArmaduraMax());
            Console.WriteLine(@"  /¯|¯|¯\   Defensa: " + enemigo.getDefensa() + " Daño: " + enemigo.getDanio());
            Console.WriteLine(@"       ");
            Console.WriteLine("=======================================================================================");
        }

        private static void menuInicial()
        {
            Console.Clear();
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("1-> Entrar al MaxiKiosco");
            Console.WriteLine("2-> Ir a cagarse a piñas con una araña");
            Console.WriteLine("3-> Chabon con sustancias ilicitas");
            Console.WriteLine("4-> Mostrar inventario");
            Console.WriteLine("5-> Estado");
            Console.WriteLine("=======================================================================================");
           /* 
            * 
            * Nuevo metodo
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine(Console.ReadLine());
            }
            */



            try
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        tienda(jugador.getNivel());
                        break;
                    case '2':
                        break;
                    case '3':
                        tiendaIlicita();
                        break;
                    case '4':
                        Console.Clear();
                        mostrarInventario();
                        menuInicial();
                        break;
                    case '5':
                        estado();
                        break;
                    default: menuInicial(); break;
                }
            }
            catch (Exception ex)
            {
                menuInicial();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////// TURNOS ////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void turnoJugador()
        {
            menu();
            Console.WriteLine("¿Que quieres hacer?\n1->Atacar\n2->Inventario");

            try
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case '1': Console.WriteLine(""); jugador.atacar(enemigo); break;
                    case '2': menu(); if (mostrarInventario() == true) { break; } else { turnoJugador(); break; }
                    default: Console.WriteLine(jugador.getNombre() + " no entiende lo que hace"); break;
                }
            }
            catch (FormatException ex)
            {
                jugador.atacar(enemigo);
            }
        }
        public static void turnoEnemigo()
        {
            switch (enemigo.decidir())
            {
                case 1:
                    enemigo.aumentarDanio();
                    break;
                case 2: 
                    enemigo.aumentarDefensa();
                    break;
                default: 
                    enemigo.atacar(jugador); 
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////RELACIONADO A INVENTARIO O TIENDA///////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void estado()
        {
            string arma = "Ninguna";
            string armadura = "Ninguna";
            try
            {
                if (jugador.getArma() != null)
                {
                    arma = jugador.getArma().getId();
                }
                if (jugador.getArmaduraE().getId() != null)
                {
                    armadura = jugador.getArmaduraE().getId();
                }
            } catch (NullReferenceException ex)
            {

            }
            Console.Clear();
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("     " + jugador.getNombre() + " Nivel: " + jugador.getNivel());
            Console.WriteLine("     Vida: " + jugador.getVida() + "/" + jugador.getVidaMax() + " + Armadura: " + jugador.getArmadura() + "/" + jugador.getArmaduraMax());
            Console.WriteLine("     Defensa: " + jugador.getDefensa() + " Daño: " + jugador.getDanio());
            Console.WriteLine("     Arma Equipada: " + arma + " - Armadura Equipada: " + armadura);
            Console.WriteLine("=======================================================================================");

            Console.ReadKey();
            menuInicial();
        }

        private static bool mostrarInventario()
        {
            bool estado = false;
            sbyte cont = 0;
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("Mochila - Cobre actual: " + jugador.getCobre() + "$");
            Console.WriteLine("0-> Volver");
            while (inv[cont]!= null)
            {
                Console.WriteLine((cont+1) + "->" + inv[cont].getId() + " x" + inv[cont].getCantidad());
                cont++;
            }
            Console.WriteLine("=======================================================================================");
            int num = Convert.ToInt32(Convert.ToString(Console.ReadKey().KeyChar));
            Console.WriteLine("");
            if (num != 0)
            {
                --num;

                try
                {


                    estado = inv[num].usarObjeto(jugador);

                    if (inv[num].getCantidad() == 0)
                    {
                        bool t = false;
                        while (t == false)
                        {
                            inv[num] = inv[num + 1];
                            if (inv[num + 1] == null)
                            {
                                t = true;
                            }
                            else
                            {
                                num++;
                            }
                        }
                    }
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine("No tenes na, pelagato");
                    Console.ReadKey();
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Ya quisieras tener esa cantidad de cosas");
                    Console.ReadKey();
                }
            }
            return estado;
        }

        private static void tienda(int nivel)
        {
            bool salir = false;
            Console.Clear();
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("MaxiKiosco - Cobre actual: " + jugador.getCobre() + "$\n");
            Console.WriteLine("0-> Salir de la tienda");
            Console.WriteLine("1-> Arroz $10");
            Console.WriteLine("2-> Cuchillo $50");
            if (nivel >= 3)
            {
                Console.WriteLine("3-> Pollo $20");
                Console.WriteLine("4-> Tenedor $100");
            }
            if (nivel >= 5)
            {
                Console.WriteLine("5-> Remera con estampado de Creeper $250");
            }
            if (nivel >= 20)
            {

            }
            if (nivel >= 50)
            {

            }
            if (nivel >= 75)
            {

            }
            Console.WriteLine("=======================================================================================");
            try
            {
                int seleccion = Convert.ToInt32(Convert.ToString(Console.ReadKey().KeyChar));
                if (seleccion != 0)
                {
                    comprar(item(seleccion, nivel));
                }
                else
                {
                    salir = true;
                    menuInicial();
                }

                if (salir == false)
                {
                    tienda(nivel);
                }
            }
            catch (Exception ex)
            {
                tienda(nivel);
            }
        }

        private static Objeto item(int objeto, int nivel)
        {
            switch (objeto)
            {
                case 1:
                    return new Pocion("Arroz", 20, 10);
                case 2:
                    return new Arma(3, "Cuchillo", 50, " se corta un cacho de torta y le da envidia a ");
                case 3:
                    if (nivel > 4) return new Pocion("Pollo", 50, 20);
                    return null;
                case 4:
                    if (nivel > 4) return new Arma(8, "Tenedor", 100, " no comas con las manos ");
                    return null;
                case 5:
                    if (nivel > 9) return new Armadura("Remera de Creeper", 250, 4);
                    return null;
                default: return null;
            }
                

            
        }

        private static void comprar(Objeto item)
        {

            if (jugador.getCobre() >= item.getValor())
            {
                sbyte cont = 0;
                bool salir = false;
                do
                {
                    try
                    {
                        if (inv[cont].getId() == item.getId())
                        {
                            inv[cont].aumentarCantidad(1);
                            salir = true;
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                    }
                    if (inv[cont] == null)
                    {
                        inv[cont] = item;
                        salir = true;
                        inv[cont].aumentarCantidad(1);
                    }
                    
                    cont++;
                } while (salir == false);
                
                jugador.setCobre(-item.getValor());
            }
            else
            {
                Console.WriteLine("Eres muy pobre");
                Console.ReadKey();
            }

        }


        private static void tiendaIlicita()
        {
            Console.Clear();
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("Traficante - Cobre actual: " + jugador.getCobre() + "$\n");
            Console.WriteLine("0-> Volver");
            Console.WriteLine("1-> Porro de yerba mate 150$ (Cura la vida al maximo)");
            Console.WriteLine("2-> Leche en polvo 120$ (Aumenta vida maxima en 50)");
            Console.WriteLine("3-> Repelente de mosquitos 80$ (Da 10 de armadura)");
            Console.WriteLine("=======================================================================================");

            try
            {
                bool salir = true;
                switch (Console.ReadKey().KeyChar)
                {
                    case '0':
                        menuInicial();
                        salir = false;
                        break;
                    case '1':
                        comprar(new Sustancia("Porro", 150));
                        break;
                    case '2':
                        comprar(new Sustancia("Leche", 120));
                        break;
                    case '3':
                        comprar(new Sustancia("Repelente", 80));
                        break;
                }
                if (salir) tiendaIlicita();
            }
            catch (Exception ex)
            {
                tiendaIlicita();
            }

        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    }
}