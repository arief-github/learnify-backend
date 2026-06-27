namespace Entity.Specifications
{
    public class CategoryWithCourseSpecification: BaseSpecification<Category>
    {
        public CategoryWithCourseSpecification(int id): base(x => x.Id == id)
        {
            IncludeMethod(c => c.Courses);
        }
    }
}