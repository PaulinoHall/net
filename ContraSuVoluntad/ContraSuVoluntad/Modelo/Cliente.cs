using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public enum TipoContrato { Silver = 0, Platino = 1, Gold = 2 }
    //Silver : 300.000 anual
    //Gold 1.000.000
    //Platino: 500.000

    public class Cliente
    {
        private string _rut;
        private string _nombre;
        private int _telefono;
        private string _direccion;
        private int _edad;
        private TipoContrato _tipoContrato;
        private int _cantidadCuotas;
        private string _adicionales;

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public int Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public int Edad
        {
            get
            {
                return _edad;
            }

            set
            {
                if (value >= 18)
                {
                    _edad = value;
                }
                else
                {
                    throw new Exception("Debe ser mayor de edad.");
                }
            }
        }

        public TipoContrato TipoContrato
        {
            get
            {
                return _tipoContrato;
            }

            set
            {
                _tipoContrato = value;
            }
        }

        public int CantidadCuotas
        {
            get
            {
                return _cantidadCuotas;
            }

            set
            {
                if (value >= 3 && value <= 12)
                {
                    _cantidadCuotas = value;
                }
                else
                {
                    throw new Exception("Cantidad de cuotas fuera de rango.");
                }
            }
        }

        public string Adicionales
        {
            get
            {
                return _adicionales;
            }

            set
            {
                _adicionales = value;
            }
        }
    }
}
