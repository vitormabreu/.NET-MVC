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
                
        //public IEnumerable<Medicos> ListarMedicosPorCidadeEspecialidade(int idCidade, int idEspecialidade)
        //{
            

        //    var cn = Db.Database.Connection;
        //    var sql = @"select m.Nome, m.crm" +
        //              "from Medicos m inner join Cidades c " +
        //              "on m.IDCidade = c.IDCidade inner join Especialidades e" +
        //              "on m.IDEspecialidade = e.IDEspecialidade" +
        //              "where m.IDCidade = @sidCidade" +
        //              "and m.IDEspecialidade = @sidEspecialidade ",
        //    new {sidCidade = idCidade};
            
            
        //    //var cmd = new SqlCommand(sql);
        //    //return (IEnumerable<Medicos>) cmd.ExecuteScalar();
        //}
    }
}