using IMDB.Base.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMDB.Base.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        private DateTime _addedDate = DateTime.Now;
        public DateTime AddedDate { get { return _addedDate; } set { _addedDate = value; } }

        public DateTime? ModifiedDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
