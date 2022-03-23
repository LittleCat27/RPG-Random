using Multiplayer_flashero.Entidades.vivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer_flashero.Entidades.objetos
{
    class Arma : Objeto
    {
        private int danio;
        private string mensageAtaque;
        public Arma(int nivel, string id, int valor, string mensageAtaque)
        {
            this.id = id;
            this.valor = valor;
            this.nivel = nivel;
            this.danio = 2 * nivel;
            this.cantidad = 0;
            this.mensageAtaque = mensageAtaque;
        }



        public int getDanio()
        {
            return this.danio;
        }
        public string getMensageAtaque()
        {
            return this.mensageAtaque;
        }

        public override bool usarObjeto(Jugador jugador)
        {
            bool estado = jugador.equiparArma(this);
            if (estado)
            { 
            
                this.disminuirCantidad();
                Console.WriteLine(jugador.getNombre() + " se equipa el " + this.getId());
            }
            
            return estado;

        }

    }
}
