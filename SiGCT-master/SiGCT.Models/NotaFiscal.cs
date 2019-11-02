﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NHibernate.Helper.Generics;

namespace SiGCT.Models
{
    /// <summary>
    /// Nota-fiscal
    /// </summary>
    public class NotaFiscal : GenericEntity<long>
    {
        public virtual int Sequencial { get; set; }

        public virtual Conta Conta { get; set; }

        public virtual DateTime Emissao { get; set; }

        public virtual DateTime Vencimento { get; set; }

        public virtual Operadora Operadora { get; set; }

        public virtual Decimal ValorTotal { get; set; }

        public virtual TipoNfEnum Tipo { get; set; }

        public virtual String Numero { get; set; }

        [MaxLength(204)]
        public virtual String Filler { get; set; }

        [MaxLength(50)]
        public virtual String Obs { get; set; }

        public virtual IList<Chamada> Chamadas { get; set; }
        public virtual IList<Servico> Servicos { get; set; }
        public virtual IList<Desconto> Descontos { get; set; }
        public virtual IList<Plano> Planos { get; set; }

    }
}