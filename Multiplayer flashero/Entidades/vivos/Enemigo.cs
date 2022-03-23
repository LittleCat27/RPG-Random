using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiplayer_flashero.Entidades.objetos;

namespace Multiplayer_flashero.Entidades.vivos
{
    class Enemigo : Individuo
    {
        public Enemigo(string nombre, int nivel)
        {
            this.nivel = nivel;
            this.vidaMax = 50 * this.nivel;
            this.vida = vidaMax;
            this.defensa = 1 * nivel;
            this.armaduraMax = 10 * nivel;
            this.armadura = this.armaduraMax;
            this.danio = 2*nivel;
            this.nombre = nombre;
            
        }
        public int decidir()
        {
            Random x = new Random();
            int nro = x.Next(1, 5);
            return nro;
        }
        public void aumentarDanio()
        {
            Console.WriteLine(this.nombre + " toma Vodka y aumenta +1 su daño");
            this.danio++;
        }
        public void aumentarDefensa()
        {
            Console.WriteLine(this.nombre + " toma un mate y aumenta +1 su defensa");
            this.defensa++;
        }

        public override void atacar(Individuo atacado)
        {
            Random x = new Random();
            
            switch (x.Next(1, 6))
            {
                case 1:
                    Console.WriteLine(this.nombre + " a atacado a " + atacado.getNombre());
                    break;
                case 2:
                    Console.WriteLine(this.nombre + " le cebo un mate frio a " + atacado.getNombre());
                    break;
                case 3:
                    Console.WriteLine(this.nombre + " le dice feo a " + atacado.getNombre());
                    break;
                case 4:
                    Console.WriteLine(this.nombre + " bloquea en whatsapp a " + atacado.getNombre());
                    break;
                case 5:
                    Console.WriteLine(this.nombre + " le descarga tiktok en su celular a " + atacado.getNombre());
                    break;
            }
            
            atacado.recibirDanio(this.danio);
        }





        // para "crear" un nuevo enemigo
        public void reset (string nombre, int nivel)
        {
            this.nivel = nivel;
            this.vidaMax = 50 * this.nivel;
            this.vida = vidaMax;
            this.defensa = 1 * nivel;
            this.armaduraMax = 10 * nivel;
            this.armadura = this.armaduraMax;
            this.danio = 3 * nivel;
            this.nombre = nombre;
        }
        
    }
}
