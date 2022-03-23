using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiplayer_flashero.Entidades.objetos;
using Multiplayer_flashero.Entidades.vivos;

namespace Multiplayer_flashero.Entidades.objetos.consumibles
{
    class Pocion : Objeto
    {
        private int curacion;
        
        
        public Pocion(string id, int curacion, int valor)
        {
            this.curacion = curacion;
            this.id = id;
            this.valor = valor;
            this.nivel = 1;
            this.cantidad = 0;
        }

        public override bool usarObjeto(Jugador jugador)
        {
            if (this.cantidad > 0)
            {
                this.disminuirCantidad();
                jugador.curarVida(getCuracion(), getId());
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getCuracion()
        {
            return this.curacion;
        }
        
    }
}
