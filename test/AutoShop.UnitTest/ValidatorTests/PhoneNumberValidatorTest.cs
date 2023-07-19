using AutoShop.Service.Validators;

namespace AutoShop.UnitTest.ValidatorTests;

public class PhoneNumberValidatorTest
{
    [Theory]
    [InlineData("+998991234567")]
    [InlineData("+998901234267")]
    [InlineData("+998911234167")]
    [InlineData("+998931232356")]
    [InlineData("+998941234556")]
    [InlineData("+998771234555")]
    [InlineData("+998339423456")]
    [InlineData("+998509934567")]
    [InlineData("+998909334567")]
    [InlineData("+998997734567")]
    [InlineData("+998913334567")]
    public void ShouldReturn(string phone)
    {
        var result = PhoneNumberValidator.IsValid(phone);
        Assert.True(result);
    }

    [Theory]
    [InlineData("998909000908")]
    [InlineData("99877007O9639")]
    [InlineData("AAAbbCCdd")]
    [InlineData("+99877007963912")]
    [InlineData("+9987845121212W")]
    [InlineData("+998 454567898")]
    [InlineData("+99899103aa45")]
    [InlineData("+99877007a56a")]
    [InlineData("+99899 007 9639")]
    [InlineData("+998 99 007 96 39")]
    public void ShouldReturnWrong(string phone1)
    {
        var result = PhoneNumberValidator.IsValid(phone1);
        Assert.False(result);
    }
}
