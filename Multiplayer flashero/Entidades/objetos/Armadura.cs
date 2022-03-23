using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiplayer_flashero.Entidades.vivos;

namespace Multiplayer_flashero.Entidades.objetos
{
    class Armadura : Objeto
    {
        private int defensa;
        private int armadura;
        public Armadura(string id, int valor, int nivel)
        {
            this.id = id;
            this.valor = valor;
            this.nivel = nivel;
            this.defensa = 2 * nivel;
            this.armadura = 10 * nivel;
        }

        public int getDefensa()
        {
            return this.defensa;
        }
        public int getArmadura()
        {
            return this.armadura;
        }

        public override bool usarObjeto(Jugador jugador)
        {
            bool estado = jugador.equiparArmadura(this);
            if (estado)
            {

                this.disminuirCantidad();
                Console.WriteLine(jugador.getNombre() + " se equipa la " + this.getId());
            }

            return estado;

        }

    }
}
