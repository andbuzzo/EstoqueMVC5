namespace EstoqueMVC5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("produto")]
    public partial class produto
    {
        public int id { get; set; }

        [StringLength(50)]
        public string descricao { get; set; }

        public int? id_categoria { get; set; }

        public int? id_fornecedor { get; set; }

        public int? quantidade { get; set; }

        public virtual categoria categoria { get; set; }

        public virtual fornecedor fornecedor { get; set; }
    }
}
