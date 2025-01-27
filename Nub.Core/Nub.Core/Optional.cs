using System.Diagnostics.CodeAnalysis;

namespace Nub.Core;

public readonly struct Optional<TValue>
{
    public static Optional<TValue> Empty() => new();

    public static Optional<TValue> OfNullable(TValue? value)
    {
        return value ?? Empty();
    }

    public Optional()
    {
        Value = default;
        HasValue = false;
    }

    public Optional(TValue value)
    {
        Value = value;
        HasValue = true;
    }

    public TValue? Value { get; }

    [MemberNotNullWhen(true, nameof(Value))]
    public bool HasValue { get; }

    public static implicit operator Optional<TValue>(TValue value) => new(value);
}