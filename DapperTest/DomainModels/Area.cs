using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FastCrud;

namespace DapperTest.DomainModels
{
    [Table("Area")]
    public class Area
    {
        /// <summary>
        /// 区域ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long AreaId { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public virtual string AreaName { get; set; }

        /// <summary>
        /// 区域描述
        /// </summary>
        public virtual string AreaDes { get; set; }

        /// <summary>
        /// 父级区域ID
        /// </summary>
        public virtual long ParentAreaId { get; set; }

        /// <summary>
        /// 区域描述
        /// </summary>
        public virtual string FullName { get; set; }

        [DatabaseGeneratedDefaultValue]
        public virtual DateTime CreateTime { get; set; }

        public virtual Guid RowIdentity { get; set; }
    }
}
