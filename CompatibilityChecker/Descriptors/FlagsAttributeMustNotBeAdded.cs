namespace CompatibilityChecker.Descriptors
{
    using System;

    /// <summary>
    /// The <see cref="FlagsAttribute"/> must not be added to a publicly-accessible enumeration type.
    /// </summary>
    internal class FlagsAttributeMustNotBeAdded : CompatibilityDescriptor
    {
        private const string Id = nameof(FlagsAttributeMustNotBeAdded);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The FlagsAttribute cannot be added to an enumeration type.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly FlagsAttributeMustNotBeAdded Instance = new FlagsAttributeMustNotBeAdded();

        private FlagsAttributeMustNotBeAdded()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
