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
    public class BitacoraRepository : IBitacoraRepository
    {
        private readonly DBConnectionFactory _dBConnectionFactory;

        public BitacoraRepository(DBConnectionFactory dBConnectionFactory)
        {
            _dBConnectionFactory = dBConnectionFactory;
        }

        public async Task<IEnumerable<Bitacora>> ListarBitacoraAsync()
        {
            var olist = new List<Bitacora>();

            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("ListarBitacora", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        olist.Add(new Bitacora
                        {
                            IdBitacora = Convert.ToInt32(dr["IdBitacora"]),
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Accion = dr["Accion"].ToString() ?? string.Empty,
                            Modulo = dr["Modulo"].ToString() ?? string.Empty,
                            TablaAfectada = dr["TablaAfectada"].ToString(),
                            RegistroAfectado = Convert.ToInt32(dr["RegistroAfectado"]),
                            ValorAnterior = dr["ValorAnterior"].ToString(),
                            ValorNuevo = dr["ValorNuevo"].ToString(),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                            
                        });
                    }
                }
            }
            return olist;
        }
                
            
        public async Task NuevaBitacoraAsync(Bitacora obitacora)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("InsertarBitacora",con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Accion", obitacora.Accion));
                cmd.Parameters.Add(new SqlParameter("@Modulo", obitacora.Modulo));
                cmd.Parameters.Add(new SqlParameter("@TablaAfectada", obitacora.TablaAfectada));
                cmd.Parameters.Add(new SqlParameter("@RegistroAfectado", obitacora.RegistroAfectado));
                cmd.Parameters.Add(new SqlParameter("@ValorAnterior", obitacora.ValorAnterior));
                cmd.Parameters.Add(new SqlParameter("@ValorNuevo", obitacora.ValorNuevo));
                cmd.Parameters.Add(new SqlParameter("@Fecha", obitacora.Fecha));

                await cmd.ExecuteNonQueryAsync();
            }
        }
        public async Task EditarBitacoraAsync(Bitacora obitacora)
        {
            using var con = _dBConnectionFactory.CreateConnection( );
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("EditarBitacora", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdBitacora", obitacora.IdBitacora));
                cmd.Parameters.Add(new SqlParameter("@IdUsuario", obitacora.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@Accion", obitacora.Accion));
                cmd.Parameters.Add(new SqlParameter("@Modulo", obitacora.Modulo));
                cmd.Parameters.Add(new SqlParameter("@TablaAfectada", obitacora.TablaAfectada));
                cmd.Parameters.Add(new SqlParameter("@RegistroAfectado", obitacora.RegistroAfectado));
                cmd.Parameters.Add(new SqlParameter("@ValorAnterior", obitacora.ValorAnterior));
                cmd.Parameters.Add(new SqlParameter("@ValorNuevo", obitacora.ValorNuevo));
                cmd.Parameters.Add(new SqlParameter("@Fecha", obitacora.Fecha));

                await cmd.ExecuteNonQueryAsync();
            }


        }

        public async Task EliminarBitacoraAsync(int id)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("EliminarBitacora",con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdBitacora", id));
                cmd.Parameters.Add(new SqlParameter("@IdUsuario", id));

                await cmd.ExecuteNonQueryAsync();
            }
        }




    }
}
