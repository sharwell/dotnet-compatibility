namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>readonly</c> modifier must not be added to a publicly-accessible field.
    /// </summary>
    internal class ReadonlyMustNotBeAddedToField : CompatibilityDescriptor
    {
        private const string Id = nameof(ReadonlyMustNotBeAddedToField);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'readonly' modifier cannot be added to a field.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly ReadonlyMustNotBeAddedToField Instance = new ReadonlyMustNotBeAddedToField();

        private ReadonlyMustNotBeAddedToField()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
