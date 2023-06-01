using ASPNedjelja3.DataAccess;
using ASPNedjelja3Vjezbe.Application.UseCases.Commands;
using ASPNedjelja3Vjezbe.Application.UseCases.DTO;
using ASPNedjelja3Vjezbe.Domain;

namespace ASPNedjelja3Vjezbe.Implementation.UseCases.Commands
{
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        public EfCreateCategoryCommand(Vjezbe3DbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Create Category EF";

        public string Description => "Crate category using entity framework";

        public void Execute(CreateCategoryDTO request)
        {
            Context.Categories.Add(new Category
            {
                Name = request.Name,
                ParentId = request.ParentCategoryId
            });
            Context.SaveChanges();
        }
    }
}
