using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiplayer_flashero.Entidades.objetos;
using Multiplayer_flashero.Entidades.objetos.consumibles;

namespace Multiplayer_flashero.Entidades.vivos
{
    class Jugador : Individuo
    {
        private int cobre;
        //protected int exp;
        private Arma armaEquipada = null;
        private Armadura armaduraEquipada = null;
        
        
        public Jugador(string nombre, int nivel)
        {
            this.vidaMax = 100;
            this.armaduraMax = 30;
            this.vida = 100;
            this.defensa = 3;
            this.armadura = this.armaduraMax;
            this.danio = 10;
            this.nombre = nombre;
            this.nivel = nivel;
            this.cobre = 100;
            //this.exp = 0;
            if (nombre == "Pepa Pig")
            {
                new Arma(1000, "Celular de Pepa", 0, " llama a papa pig y este atropella a ").usarObjeto(this);
            }
        }

        public override void atacar(Individuo atacado)
        {
            if (armaEquipada == null)
            {
                Console.WriteLine(this.nombre + " a atacado a " + atacado.getNombre());
            }
            else
            {
                Console.WriteLine(this.nombre + armaEquipada.getMensageAtaque() + atacado.getNombre());
            }
            atacado.recibirDanio(this.danio);
        }

        public bool equiparArma(Arma arma)
        {
            if (armaEquipada == null)
            {
                this.armaEquipada = arma;
                this.danio += armaEquipada.getDanio();
                return true;
            }
            else if((arma.getId() == "Tenedor" && this.armaEquipada.getId() == "Cuchillo") || (arma.getId() == "Cuchillo" && this.armaEquipada.getId() == "Tenedor"))
            {
                this.armaEquipada = new Arma(16, "Tenedor y Cuchillo", 0, " arma un asado con sus nuevos cubiertos y no invita a ");
                this.danio += armaEquipada.getDanio();
                return true;
            }
            else
            {
                Console.WriteLine("Ya tienes un arma equipada");
                Console.ReadKey();
                return false;
            }
        }
        public void curarVida(int vidax, string id)
        {
            Console.WriteLine(this.nombre + " come "+ id + " y se cura " + vidax);
            this.vida += vidax;
            if (this.vida > this.vidaMax)
            {
                this.vida = this.vidaMax;
            }
        }
        public void setCobre(int cantidad)
        {
            this.cobre += cantidad;
        }
        
        public void setVidaMax(int vidax)
        {
            this.vidaMax += vidax;
        }
        public void setArmadura(int armadura)
        {
            this.armadura += armadura;
            if (this.armadura > this.armaduraMax)
            {
                this.armadura = this.armaduraMax;
            }
        }

        public void setArmaduraMax(int armadura)
        {
            this.armaduraMax += armadura;
        }


        public bool equiparArmadura(Armadura armadura)
        {
            if (this.armaduraEquipada == null)
            {
                this.armaduraEquipada = armadura;
                this.armaduraMax += armaduraEquipada.getArmadura();
                this.defensa += armaduraEquipada.getDefensa();
                setArmadura(armaduraEquipada.getArmadura());
                return true;
            }
            
            else
            {
                Console.WriteLine("Ya tienes un armarmadura equipada");
                Console.ReadKey();
                return false;
            }
        }




        /////////////////////////////////////////////////////////////////// GETTERS /////////////////////////////////////////////////////////////////////


        public Arma getArma()
        {
            return this.armaEquipada;
        }

        public Armadura getArmaduraE()
        {
            return this.armaduraEquipada;
        }
        public int getCobre()
        {
            return this.cobre;
        }


    }
}
