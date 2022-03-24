using Multiplayer_flashero.Entidades.vivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer_flashero.Entidades.objetos.consumibles
{
    class Sustancia : Objeto
    {
        public Sustancia(string id, int valor)
        {
            
            this.id = id;
            this.valor = valor;
            this.nivel = 1;
            this.cantidad = 0;
        }

        public override bool usarObjeto(Jugador jugador)
        {
            this.disminuirCantidad();
            switch (this.getId())
            {
                case "Porro":
                    jugador.setVida(jugador.getVidaMax());
                    Console.WriteLine(jugador.getNombre() + " se fuma esa cosa y cura su vida al maximo");
                    break;
                case "Leche":
                    jugador.setVidaMax(50);
                    jugador.setVida(jugador.getVida() + 50);
                    Console.WriteLine(jugador.getNombre() + " se arma una chocolatada con la leche en polvo y aumenta su vida maxima");
                    break;
                case "Repelente":
                    jugador.setArmadura(10);
                    Console.WriteLine(jugador.getNombre() + " se coloca repelente y recupera su armadura");
                    break;
            }

            return true;
        }

    }
}
