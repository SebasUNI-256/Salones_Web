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
    public class CancelacionRepository : ICancelacionRepository
    {
        private readonly DBConnectionFactory _dBConnectionFactory;

        public CancelacionRepository(DBConnectionFactory dBConnectionFactory)
        {
            _dBConnectionFactory = dBConnectionFactory;
        }

        public async Task<IEnumerable<Cancelacion>> ListarCancelacionAsync()
        {
            var olist = new List<Cancelacion>();

            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("ListarCancelacion", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        olist.Add(new Cancelacion
                        {
                            IdCancelacion = Convert.ToInt32(dr["IdCancelacion"]),
                            IdReservacion = Convert.ToInt32(dr["IdReservacion"]),
                            Motivo = dr["Motivo"].ToString(),
                            FechaCancelacion = Convert.ToDateTime(dr["FechaCancelacion"])

                        });
                    }
                }
            }
            return olist;
        }
        

        public async Task NuevaCancelacionAsync(Cancelacion ocancelacion)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("InsertarCancelacion", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Motivo", ocancelacion.Motivo));
                cmd.Parameters.Add(new SqlParameter("@FechaCancelacion", ocancelacion.FechaCancelacion));

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task EditarCancelacionAsync(Cancelacion ocancelacion)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("EditarCancelacion", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdCancelacion", ocancelacion.IdCancelacion));
                cmd.Parameters.Add(new SqlParameter("@IdReservacion", ocancelacion.IdReservacion));
                cmd.Parameters.Add(new SqlParameter("@FechaCancelacion", ocancelacion.FechaCancelacion));

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task EliminarCancelacionAsync(int id)
        {
            using var con = _dBConnectionFactory.CreateConnection();
            await con.OpenAsync();

            using (SqlCommand cmd = new SqlCommand("EliminarCancelacion", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdCancelacion", id));
                cmd.Parameters.Add(new SqlParameter("@IdReservacion", id));

                await cmd.ExecuteNonQueryAsync();
            }
        }




    }
}
