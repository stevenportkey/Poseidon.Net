namespace Poseidon.Net.Test;

public class PoseidonHashTest
{
    [Theory]
    [InlineData("123", "9904028930859697121695025471312564917337032846528014134060777877259199866166")]
    [InlineData("123,456", "19620391833206800292073497099357851348339828238212863168390691880932172496143")]
    [InlineData("0", "19014214495641488759237505126948346942972912379615652741039992445865937985820")]
    [InlineData("21888242871839275222246405745257275088548364400416034343698204186575808495617",
        "19014214495641488759237505126948346942972912379615652741039992445865937985820")]
    public void TestHash(string data, string hash)
    {
        var actualHash = new Poseidon().Hash(data.Split(",").Select(x => x.Trim()).ToList());
        Assert.Equal(hash, actualHash);
    }


    [Fact]
    public void TestInvalidInput_Empty()
    {
        Assert.Throws<InvalidInputException>(() => new Poseidon().Hash(new List<string>() { "" }));
    }


    [Fact]
    public void TestInvalidInput_NonDigit()
    {
        Assert.Throws<InvalidInputException>(() => new Poseidon().Hash(new List<string>() { "e" }));
    }
}