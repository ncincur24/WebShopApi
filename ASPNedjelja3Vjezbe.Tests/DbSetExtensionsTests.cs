using ASPNedjelja3.DataAccess;
using ASPNedjelja3Vjezbe.DataAccess.Exceptions;
using ASPNedjelja3Vjezbe.DataAccess.Extensions;
using ASPNedjelja3Vjezbe.Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ASPNedjelja3Vjezbe.Tests
{
    public class DbsetExtensionsTests
    {
        [Fact]
        public void NonGenericDeactivate_ChangesIsActiveToFalse()
        {
            var category = new Category
            {
                Name = "Test 1",
                IsActive = true,
            };
            var context = new Vjezbe3DbContext(new TestUser());
            context.Entry(category).State.Should().Be(EntityState.Detached);

            context.Deactivate(category);

            context.Entry(category).State.Should().Be(EntityState.Modified);
            category.IsActive.Should().BeFalse();
        }

        [Fact]
        public void GenericDeactivateThrows_WhenEntityDoesntExist()
        {
            var context = new Vjezbe3DbContext(new TestUser());

            Action a = () => context.Deactivate<Category>(-500);

            a.Should().ThrowExactly<EntityNotFoundException>();
        }

        [Fact]
        public void GenericDeactivate_ChangesIsActiveToFalse()
        {
            var context = new Vjezbe3DbContext(new TestUser());
            var category = context.Set<Category>().Find(1);

            category.IsActive.Should().BeTrue();

            context.Deactivate<Category>(1);

            context.Entry(category).State.Should().Be(EntityState.Modified);
            category.IsActive.Should().BeFalse();
        }
    }

    public class TestUser : IApplicationUser
    {
        public string Identity => "Hardcoded User";
    }
}