using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Contracts;
using Domain_Layer.Models.Producr;

namespace Service.Specification
{
    //هذا هو الهيكل العظمي الذي تبني عليه كل مواصفاتك المخصصة. بدلاً من أن يبدأ كل Specification من الصفر، فإنه يرث من هذا الكلاس الذي يوفر له:


    abstract class BaseSpecifications<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        //Constructor: طريقة سهلة لاستقبال شرط الفلترة (Criteria) عند إنشاء المواصفة.

        #region Where
        protected BaseSpecifications(Expression<Func<TEntity, bool>>? CriteriaExpression)
        {
            Crietria = CriteriaExpression;
        }





        public Expression<Func<TEntity, bool>> ?Crietria { get; private set; }
        #endregion


        //IncludeExpressions List: قائمة جاهزة لتخزين كل الـ Includes التي تحتاجها.
        #region Include

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];

  


        //AddInclude Method: دالة مساعدة محمية (protected) لإضافة الـ Includes إلى القائمة بطريقة نظيفة ومنظمة داخل كل مواصفة.


        protected void AddInclude(Expression<Func<TEntity, object>> IncludeExpression)
        {
            IncludeExpressions.Add(IncludeExpression);


        }
        #endregion



        #region OrderBy
        public Expression<Func<TEntity, object>> OrderBy {  get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

       

        protected void AddOrderby(Expression<Func<TEntity, object>> OrderByExp)
        {

            OrderBy = OrderByExp;

        }
    protected void AddOrderbyDes(Expression<Func<TEntity, object>> OrderByDesExp)
        {

            OrderByDescending = OrderByDesExp;

        }








        #endregion

        #region Pagination
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginate { get;  set; }

        protected void ApplyPagination(int Pagesize, int PageIndex)
        {
            IsPaginate=true;
            Take = Pagesize;
            Skip = (PageIndex -1) * Pagesize;


        }
        #endregion

    }
}
