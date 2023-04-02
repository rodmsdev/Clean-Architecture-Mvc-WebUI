using CleanArchMvcDomain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchMvcDomain.Validation.DomainExceptionValidation>();
    }
    
    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }
    
    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Minimum 3 characters");
    }
    
    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
    
    [Fact]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}