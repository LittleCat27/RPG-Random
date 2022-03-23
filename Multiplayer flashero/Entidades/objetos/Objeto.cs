using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiplayer_flashero.Entidades.vivos;

///Creo esto para poder crear el inventario del jugador
namespace Multiplayer_flashero.Entidades.objetos
{
    class Objeto
    {
        protected string id;
        protected int valor;
        protected int nivel;
        protected int cantidad;

        public Objeto()
        {
            this.id = "";
            this.valor = 9999999;
            this.nivel = 0;
            this.cantidad = 0;
        }


        public void aumentarCantidad(int cantidad)
        {
            this.cantidad += cantidad;
        }
        public void disminuirCantidad()
        {
            this.cantidad--;
        }

        public virtual bool usarObjeto(Jugador jugador)
        {

            return false;
        }




        /////////////////////////////////////////////////// GETTERS ////////////////////////////////////////////////////////////////////////



        public int getCantidad()
        {
            return this.cantidad;
        }
        

        public int getValor()
        {
            return this.valor;
        }

        public string getId()
        {
            return this.id;
        }






        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////7
        
    }
}
