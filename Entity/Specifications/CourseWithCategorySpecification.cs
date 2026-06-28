using System;
using System.Linq.Expressions;

namespace Entity.Specifications
{
    public class CourseWithCategorySpecification: BaseSpecification<Course>
    {
        public CourseWithCategorySpecification()
        {
            IncludeMethod(x => x.Category);
        }

        public CourseWithCategorySpecification(Guid id) : base(x => x.Id == id)
        {
            IncludeMethod(c => c.Requirements);
            IncludeMethod(c => c.Learnings);
        }
    }
}