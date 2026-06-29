using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using SaloNic.Application;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using SaloNic.Infrastructure.DataBase;
using SaloNic.Infrastructure.Persistence;

namespace SaloNic.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly DBConnectionFactory _dBConnectionFactory;

        public ClienteRepository(DBConnectionFactory dBConnectionFactory)
        {
            _dBConnectionFactory = dBConnectionFactory;
        }

        public async Task<IEnumerable<Cliente>> ListarClienteAsync()
        {
            var olist = new List<Cliente>();

            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("ListarCliente", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        olist.Add(new Cliente
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Cedula = dr["Cedula"].ToString() ?? string.Empty,
                            Nombres = dr["Nombres"].ToString() ?? string.Empty,
                            Apellidos = dr["Apellidos"].ToString() ?? string.Empty,
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"])

                        });
                    }
                }
            }
            return olist;
        }
        

        public async Task NuevoClienteAsync(Cliente ocliente)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("InsertarCliente", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Cedula", ocliente.Cedula));
                cmd.Parameters.Add(new SqlParameter("@Nombres", ocliente.Nombres));
                cmd.Parameters.Add(new SqlParameter("@Apellidos", ocliente.Apellidos));
                cmd.Parameters.Add(new SqlParameter("@Telefono", ocliente.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Correo", ocliente.Correo));
                cmd.Parameters.Add(new SqlParameter("@Direccion", ocliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", ocliente.FechaCreacion));

                await cmd.ExecuteNonQueryAsync();
            }
        }
        public async Task EditarClienteAsync(Cliente ocliente)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("EditarCliente", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdCliente",ocliente.IdCliente));
                cmd.Parameters.Add(new SqlParameter("@IdUsuario", ocliente.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@Cedula", ocliente.Cedula));
                cmd.Parameters.Add(new SqlParameter("@Nombres", ocliente.Nombres));
                cmd.Parameters.Add(new SqlParameter("@Apellidos", ocliente.Apellidos));
                cmd.Parameters.Add(new SqlParameter("@Telefono", ocliente.Telefono));
                cmd.Parameters.Add(new SqlParameter("@Correo", ocliente.Correo));
                cmd.Parameters.Add(new SqlParameter("@Direccion", ocliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", ocliente.FechaCreacion));



                await cmd.ExecuteNonQueryAsync();
            }
        }
         
        public async Task EliminarClienteAsync(int id)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("EliminarCliente", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdCliente", id));
                cmd.Parameters.Add(new SqlParameter("@IdUsuario", id));

                await cmd.ExecuteNonQueryAsync();
            }
        }




    }
}
