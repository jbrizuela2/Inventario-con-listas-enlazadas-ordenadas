using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Inventario
    {

        private Producto inicial;

        public void agregar(string codigo, string nombre, int cantidad, double precio)
        {
            Producto nuevo = new Producto(codigo, nombre, cantidad, precio);
            if (inicial == null){
                inicial = nuevo;
            }else{
                if(int.Parse(nuevo.getCodigo()) < int.Parse(inicial.getCodigo()))
                {
                    Producto temp = inicial;
                    inicial = nuevo;
                    inicial.siguiente = temp;
                }else
                {
                    Producto actual = inicial;
                    while(actual.siguiente != null)
                    {
                        if (int.Parse(nuevo.getCodigo()) > int.Parse(actual.siguiente.getCodigo()))
                        {
                            actual = actual.siguiente;
                        }
                        else
                            break;                        
                    }
                    Producto temp = actual.siguiente;
                    actual.siguiente = nuevo;
                    nuevo.siguiente = temp;
                }
            }
        }

        public void borrar(string cod)
        {
            Producto actual = inicial;
            if (actual.getCodigo().Equals(cod))
            {
                inicial = actual.siguiente;
            }
            else
            {
                while (int.Parse(actual.siguiente.getCodigo()) <= int.Parse(cod))
                {
                    if (int.Parse(actual.siguiente.getCodigo()).Equals(int.Parse(cod))){
                        actual.siguiente = actual.siguiente.siguiente;
                    }else
                    {
                        actual = actual.siguiente;
                    }
                }
            }
        }


        public Producto buscar(string cod)
        {
            Producto actual = inicial;
            while (int.Parse(actual.siguiente.getCodigo()) <= int.Parse(cod))
            {
                if (int.Parse(actual.siguiente.getCodigo()).Equals(int.Parse(cod)))
                {
                    return actual.siguiente;
                }
                else
                {
                    actual = actual.siguiente;
                }

            }
            return null;
        }

        public String reporte()
        {
            String s = "";
            Producto actual = inicial;
            while (actual != null)
            {
                s += actual.ToString() + Environment.NewLine;
                actual = actual.siguiente;
            }
            return s;
        }

    }
}
