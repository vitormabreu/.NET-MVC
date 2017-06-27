using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VMA.CadeMeuMedico.Models;

namespace VMA.CadeMeuMedico.AppService
{
    public class CadeMeuMedicoAppService
    {
        private readonly CadeMeuMedicoBDEntities Db;

        public CadeMeuMedicoAppService(CadeMeuMedicoBDEntities context)
        {
            Db = context;
        }

        public IEnumerable<Medicos> ListarMedicosPorCidadeEspecialidade(int idCidade, int idEspecialidade)
        {


            var cn = Db.Database.Connection.ConnectionString;
            var sql = @"select m.Nome, m.crm" +
                      "from Medicos m inner join Cidades c " +
                      "on m.IDCidade = c.IDCidade inner join Especialidades e" +
                      "on m.IDEspecialidade = e.IDEspecialidade" +
                      "where m.IDCidade =" + idCidade +
                      "and m.IDEspecialidade =" + idEspecialidade;
            using (var strCnn = new SqlConnection(cn))
            {
                strCnn.Open();
                var cmd = new SqlCommand(string.Format(sql), strCnn);
                return (IEnumerable<Medicos>) cmd.ExecuteScalar();
            }

            //    //var cmd = new SqlCommand(sql);
            //    //return (IEnumerable<Medicos>) cmd.ExecuteScalar();

        }

        public IEnumerable<Especialidades> ListarEspecialidadePorCidade(int idCidade)
        {
            var cn = Db.Database.Connection.ConnectionString;
            var sql = @"Select e.IDEspecialidade, e.Nome" +
                      "from Especialidades e inner join Medicos m" +
                      "on m.IDEspecialidade = e.IDEspecialidade inner join Cidades c" +
                      "on m.IDCidade = c.IDCidade" +
                      "where m.IDCidade =" + idCidade;

            using (var strCnn = new SqlConnection(cn))
            {
                strCnn.Open();
                var cmd = new SqlCommand(string.Format(sql), strCnn);
                return (IEnumerable<Especialidades>)cmd.ExecuteScalar();
            }
        }
    }
}