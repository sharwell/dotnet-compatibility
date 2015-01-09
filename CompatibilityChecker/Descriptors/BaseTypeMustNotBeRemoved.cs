namespace CompatibilityChecker.Descriptors
{
    using System;

    /// <summary>
    /// A base type cannot be removed from a publicly-accessible type. This diagnostic can be reported if the immediate
    /// base type violates <see cref="TypeMustNotBeRemoved"/>, or if the immediate base type is changed to a new type
    /// which does not extend the original base type. This includes changing a <c>struct</c>  to a <c>class</c>, which
    /// causes the <see cref="ValueType"/> base type to be removed.
    /// </summary>
    internal class BaseTypeMustNotBeRemoved : CompatibilityDescriptor
    {
        private const string Id = nameof(BaseTypeMustNotBeRemoved);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "A base type of a publicly-accessible type cannot be removed.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly BaseTypeMustNotBeRemoved Instance = new BaseTypeMustNotBeRemoved();

        private BaseTypeMustNotBeRemoved()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
