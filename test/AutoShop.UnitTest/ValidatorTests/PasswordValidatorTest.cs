using AutoShop.Service.Validators;

namespace AutoShop.UnitTest.ValidatorTests;

public class PasswordValidatorTest
{

    [Theory]
    [InlineData("AAaa@@11")]
    [InlineData("AAwdfsdfc@34231sd")]
    [InlineData("AAw!#@#$sdfdfsdfc@34231sd")]
    [InlineData("AAw!#@#$sdfdfsdfc@3423sdffd1sd")]
    [InlineData("AAw!#@#$sdfdfsdfc@34231sdfsdd")]
    [InlineData("AAw!#@#$sdf112wdfsdfs:dfsdfc@34231sd")]
    [InlineData("AAw!#@#$sdfdfsdfc@3423adsdf1sd")]
    [InlineData("AAw!#@#$sdfdfsdfc@34231ssdfs2d")]
    

    public void isStrongPassword(string password)
    {
        var result = PasswordValidator.IsStrongPassword(password);
        Assert.True(result.isValiid);

    }
    [Theory]
    [InlineData("12345678")]
    [InlineData("qwertyu")]
    [InlineData("qwerty1234")]
    [InlineData("1A2B3C4D")]
    [InlineData("1a2b3c4d")]
    [InlineData("1234abcd")]
    [InlineData("AAaa!!1")]
    [InlineData("aaaa@@11")]
    [InlineData("kkkkkkkk")]
    [InlineData("aaaaaaaA")]
    [InlineData("AAssddfgh")]
    public void ShouldReturnWeakPassword(string password)
    {
        var result = PasswordValidator.IsStrongPassword(password);
        //Assert.False(result.IsValiid);
        Assert.False(result.isValiid);
    }

}
