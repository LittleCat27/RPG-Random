using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer_flashero.Entidades.vivos
{
    class Individuo
    {
        protected int vidaMax;
        protected int vida;
        protected int defensa;
        protected int armadura;
        protected int danio;
        protected string nombre;
        protected int nivel;
        protected int armaduraMax;

        

        public virtual void atacar(Individuo atacado)
        {
            Console.WriteLine(this.nombre + " a atacado a " + atacado.getNombre());
            atacado.recibirDanio(this.danio);
        }

        public void recibirDanio(int danio)
        {    
            if (this.armadura > 0)
            {
                danio -= this.defensa;
                if (danio < 1)
                {
                    danio = 1;
                }
                this.armadura -= danio;
                if (this.armadura < 0)
                {
                    this.vida += this.armadura;
                    this.armadura = 0;
                }
            }
            else
            {
                this.vida -= danio;
            }
            Console.WriteLine(this.nombre + " a recibido " + danio + " de daño");
        }
        /////////////////////////////////////////////////////////==== GETTERS =====/////////////////////////////////////////////////////////////////////////////////////
       
        public int getDanio()
        {
            return this.danio;
        }
        public int getNivel()
        {
            return this.nivel;
        }
        public int getDefensa()
        {
            return this.defensa;
        }

        public int getArmaduraMax()
        {
            return this.armaduraMax;
        }
        public int getArmadura()
        {
            return this.armadura;
        }
        public int getVidaMax()
        {
            return this.vidaMax;
        }
        public int getVida()
        {
            return this.vida;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///SETTERS
        public void setNivel(int nro)
        {
            this.nivel = nro;
        }
        public void setVida(int vidax)
        {
            this.vida = vidax;
        }
    }
}
