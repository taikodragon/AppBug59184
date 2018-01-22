using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppBug59184.Model
{
    public class NullableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }
        //public bool NotNullable1 { get; set; }
        //public bool NotNullable2 { get; set; }
        //public bool NotNullable3 { get; set; }
        //public bool NotNullable4 { get; set; }
        //public bool NotNullable5 { get; set; }
        //public bool NotNullable6 { get; set; }
        //public bool NotNullable7 { get; set; }
        public long? Nullable1 { get; set; }
        public long? Nullable2 { get; set; }
        public long? Nullable3 { get; set; }
        public long? Nullable4 { get; set; }
        //public long? Nullable5 { get; set; }
        //public long? Nullable6 { get; set; }
        //public long? Nullable7 { get; set; }
        //public long? Nullable8 { get; set; }
        //public long? Nullable9 { get; set; }
        //public long? Nullable10 { get; set; }
        //public long? Nullable11 { get; set; }
        //public long? Nullable12 { get; set; }
        //public long? Nullable13 { get; set; }
        //public long? Nullable14 { get; set; }
        //public long? Nullable15 { get; set; }

        public NullableEntity()
        {
            Key = 0;
            //NotNullable1 = false;
            //NotNullable2 = false;
            //NotNullable3 = false;
            //NotNullable4 = false;
            //NotNullable5 = false;
            //NotNullable6 = false;
            //NotNullable7 = false;
        }
    }
}
