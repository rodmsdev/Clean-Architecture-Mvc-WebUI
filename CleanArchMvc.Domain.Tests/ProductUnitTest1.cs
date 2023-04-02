using CleanArchMvcDomain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,"Product Image");
        action.Should()
            .NotThrow<CleanArchMvcDomain.Validation.DomainExceptionValidation>();
    }
    
    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99,"Product Image");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }
    
    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "PN", "Product Description", 9.99m, 99,"Product Image");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Minimum 3 characters");
    }
    
    [Fact]
    public void CreateProduct_InvalidPriceValue_DomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99,"Product Image");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Fact]
    public void CreateProduct_LongImageValue_DomainExceptionLongImageName()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,"Product Image 1234567891011121314151617181920212223242526272829303132333435363738394041424344454647484950515253545556575859606162636465666768697071727374757677787980818283848586878990919293949596979899100102103104105106107108109110111112113114115116117");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image. Maximum 250 characters");
    }
    
    [Fact]
    public void CreateProduct_WithNullImageValue_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,null);
        action.Should()
            .NotThrow<CleanArchMvcDomain.Validation.DomainExceptionValidation>();
    }
    
    [Fact]
    public void CreateProduct_WithNullImageValue_NoNullReferenceException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,null);
        action.Should()
            .NotThrow<NullReferenceException>();
    }
    
    [Fact]
    public void CreateProduct_WithEmptyImageValue_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,"");
        action.Should()
            .NotThrow<CleanArchMvcDomain.Validation.DomainExceptionValidation>();
    }
    
    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value,"Product Image 1234567891011121314151617181920212223242526272829303132333435363738394041424344454647484950515253545556575859606162636465666768697071727374757677787980818283848586878990919293949596979899100102103104105106107108109110111112113114115116117");
        action.Should()
            .Throw<CleanArchMvcDomain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}