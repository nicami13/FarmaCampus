using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Persistence.Data;

namespace Aplication.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IRolRepository _Roles;
         private IUserRepository _Users;
        private readonly InventarioContext _context;

        public IPais _paises;
        public ICiudad _ciudad;
        public IDepartamento _departamento;
        public IContactoPersona _contactopersona;
        public IDetalleMovimientoInventario _detalleinventario;
        public IFactura _factura;
        public IFormaPago _formapago;
        public IInventario _inventario;
        public IMarca _marca;
        public IMovimientoInventario _movimientoinventario;
        public IPersona _persona;
        public IPresentacion _presentacion;
        public IProducto _producto;
        public IRolPersona _rolpersona;
        public ITipoContacto _tipocontacto;
        public ITipoDocumento _tipodocumento;
        public ITipoMovimientoInventario _tipomovimientoinventario;
        public ITipoPersona _tipopersona;
        public IUbicacionPersona _ubicacionpersona;



        public UnitOfWork(InventarioContext context)
        {
            _context = context;
        }

        public ICiudad Ciudades {
            get{
                if(_ciudad==null)
                {
                    _ciudad=new CiudadRepository(_context);
                }
                return _ciudad;
            }
        }

        public IDepartamento Departamentos {
            get{
                if(_departamento==null)
                {
                    _departamento=new DepartamentoRepository(_context);
                }
                return _departamento;
            }
        }

        public IPais Paises {
            get{
                if(_paises==null)
                {
                    _paises=new PaisRepository(_context);
                }
                return _paises;
            }
        }

        public IContactoPersona ContactosPersonas {
            get{
                if(_contactopersona==null)
                {
                    _contactopersona=new ContactoPersonaRepository(_context);
                }
                return _contactopersona;
            }
        }

        public IDetalleMovimientoInventario DetallesMovimientosInventarios {
            get{
                if(_detalleinventario==null)
                {
                    _detalleinventario=new DetalleMovimientoInventarioRepository(_context);
                }
                return _detalleinventario;
            }
        }

        public IFactura Facturas {
            get{
                if(_factura==null)
                {
                    _factura=new FacturaRepository(_context);
                }
                return _factura;
            }
        }

        public IFormaPago FormasPagos {
            get{
                if(_formapago==null)
                {
                    _formapago=new FormaPagoRepository(_context);
                }
                return _formapago;
            }
        }

        public IInventario Inventarios {
            get{
                if(_inventario==null)
                {
                    _inventario=new InventarioRepository(_context);
                }
                return _inventario;
            }
        }

        public IMarca Marcas {
            get{
                if(_marca==null)
                {
                    _marca=new MarcaRepository(_context);
                }
                return _marca;
            }
        }

        public IMovimientoInventario MovimientosInventarios {
            get{
                if(_movimientoinventario==null)
                {
                    _movimientoinventario=new MovimientoInventarioRepository(_context);
                }
                return _movimientoinventario;
            }
        }

        public IPersona Personas {
            get{
                if(_persona==null)
                {
                    _persona=new PersonaRepository(_context);
                }
                return _persona;
            }
        }

        public IPresentacion Presentaciones {
            get{
                if(_presentacion==null)
                {
                    _presentacion=new PresentacionRepository (_context);
                }
                return _presentacion;
            }
        }

        public IProducto Productos {
            get{
                if(_producto==null)
                {
                    _producto=new ProductoRepository(_context);
                }
                return _producto;
            }
        }

        public IRolPersona RolesPersonas {
            get{
                if(_rolpersona==null)
                {
                    _rolpersona=new RolPersonaRepository(_context);
                }
                return _rolpersona;
            }
        }

        public ITipoContacto TiposContactos {
            get{
                if(_tipocontacto==null)
                {
                    _tipocontacto=new TipoContactoRepository(_context);
                }
                return _tipocontacto;
            }
        }

        public ITipoDocumento TiposDocumentos {
            get{
                if(_tipodocumento==null)
                {
                    _tipodocumento=new TipoDocumentoRepository(_context);
                }
                return _tipodocumento;
            }
        }

        public ITipoPersona TiposPersonas {
            get{
                if(_tipopersona==null)
                {
                    _tipopersona=new TipoPersonaRepository(_context);
                }
                return _tipopersona;
            }
        }

        public IUbicacionPersona UbicacionesPersonas {
            get{
                if(_ubicacionpersona==null)
                {
                    _ubicacionpersona=new UbicacionPersonaRepository(_context);
                }
                return _ubicacionpersona;
            }
        }

        public ITipoMovimientoInventario TipoMovimiento {
            get{
                if(_tipomovimientoinventario==null)
                {
                    _tipomovimientoinventario=new TipoMovimientoInventarioRepository(_context);
                }
                return _tipomovimientoinventario;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public IRolRepository Roles{
            get 
            {
            if(Roles==null)
            {
                _Roles=new RolRepository(_context);
            }
            return _Roles;
            }
        }
        public IUserRepository Users
        {
            get{
                if(_Users==null){
                    _Users= new UserRepository(_context);
                }
                return _Users;
            }
        }
}
}