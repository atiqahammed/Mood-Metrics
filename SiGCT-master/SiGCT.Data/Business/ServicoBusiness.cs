﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Helper.Generics;
using SiGCT.Data.DAO;
using SiGCT.Models;
using SiGCT.Utils;

namespace SiGCT.Data.Business
{
    /// <summary>
    /// Centralizar as regras de negocio de <see cref="Servico"/> - tipo 40
    /// </summary>
    public class ServicoBusiness : GenericBusiness<long, Servico, ServicoDAO>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        internal Servico Parse(string[] array, Conta conta)
        {
            var servico = new Servico();
            servico.Sequencial = int.Parse(array[1]);
            servico.Conta = conta;

            servico.Recurso = new RecursoBusiness().GetByNumero(array[5]);
            servico.DataHoraServico = DateTime.ParseExact(string.Concat(array[8],array[15]), "yyyyMMddHHmmss", null);
            servico.Codigo = array[9].Contains("00") ? TipoCodigoEnum.Internacional : TipoCodigoEnum.Nacional;
            servico.NumeroChamado = array[10];
            servico.OperadoraRoaming = int.Parse(array[11]) > 0 ? int.Parse(array[11]) : (int?)null;
            servico.Operadora = Tools.IsNullOrEmpty(array[12]) ? null : new OperadoraBusiness().SaveAndReturn(array[12]);
            servico.QtdeUtilizada = Tools.IsNullOrEmpty(array[13]) ? (int?)null : int.Parse(array[13]);
            servico.Unidade = array[14];
            servico.Categoria = new CategoriaBusiness().SaveAndReturn(array[16], array[17], array[18]);
            servico.ValorComImposto = decimal.Parse(array[19]) / 100;
            servico.ValorSemImposto = decimal.Parse(array[20]) / 10000;
            servico.NotaFiscal = Tools.IsNullOrEmpty(array[22]) ? null : new NotaFiscalBusiness().SaveAndReturn(numero: array[22], tipo: (TipoNfEnum)int.Parse(array[21]));
            servico.Filler = Tools.IsNullOrEmpty(array[23]) ? null : array[23];
            servico.Obs = Tools.IsNullOrEmpty(array[24]) ? null : array[24];

            return servico;
        }
    }
}
