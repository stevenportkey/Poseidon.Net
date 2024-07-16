# Poseidon.Net

This is a .NET wrapper for the rust library of Poseidon using `Bn254` curve. The rust library can be found [here](https://github.com/stevenportkey/libposeidon).

## Example Usage:
```csharp
var hash = new Poseidon().Hash(new List<string>() { "123", "456" });
```

The result hash will be "19620391833206800292073497099357851348339828238212863168390691880932172496143".

Note the input values have to be decimal strings and the number must be less than the order number of the Bn254 curve `21888242871839275222246405745257275088548364400416034343698204186575808495617`.
