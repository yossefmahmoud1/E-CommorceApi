﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Producr;

namespace Domain_Layer.Contracts
{
    public interface ISpecification<TEntity ,Tkey> where TEntity : BaseEntity<Tkey>
    {
        public Expression<Func<TEntity , bool>> Crietria { get;  }   
        List <Expression<Func<TEntity , object>>> IncludeExpressions { get;  }   
        Expression<Func<TEntity , object>> OrderBy { get;  }   
        Expression<Func<TEntity , object>> OrderByDescending { get;  }   
        public int Take{ get;  }
        public int Skip{ get;  }
        public bool IsPaginate{ get; set; }
    }
}
