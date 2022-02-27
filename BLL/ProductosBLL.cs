
using RegistroProductosDetalles.Entidades;
using RegistroProductosDetalles.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RegistroProductosDetalles.BLL
{
    public class ProductosBLL
    {
        public static bool Existe(int ProductoId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.productos.Any(p => p.ProductoId == ProductoId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Guardar(Productos producto)
        {
            if (!Existe(producto.ProductoId))
            {
                return Insertar(producto);
            }
            else
            {

                return Modificar(producto);
            }
        }


        public static bool Insertar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {


                if (contexto.productos.Add(producto)
                    != null)
                    /* 
                    {

                        var detalle = new ProductosDetalles
                        {
                            ProductosId = 0,
                            ProductosDetallesId = 2,
                            Presentacion = "6 pack",
                            Cantidad = 6,
                            Precio = producto.Precio
                        };

                        contexto.Entry(detalle).State = EntityState.Added;
                    } */
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
              /*   contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalles where ProductoID = {producto.ProductoId}");

                foreach (var anterior in producto.ProductosDetalles)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                } */

                contexto.Entry(producto).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.productos.Find(id);

                contexto.Entry(eliminar).State = EntityState.Deleted;

                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }
            return paso;
        }

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos producto = new Productos();

            try
            {
                producto = contexto.productos.Include(p => p.ProductosDetalles).Where(p => p.ProductoId == id).SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return producto;
        }
        public static List<Productos> GetLista(Expression<Func<Productos, bool>> producto)
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.productos.Where(producto).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Productos> GetLista()
        {
            Contexto contexto = new Contexto();
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = contexto.productos.ToList();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}