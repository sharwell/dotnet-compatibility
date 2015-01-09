namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>readonly</c> modifier must not be removed from a publicly-accessible field.
    /// </summary>
    internal class ReadonlyMustNotBeRemovedFromField : CompatibilityDescriptor
    {
        private const string Id = nameof(ReadonlyMustNotBeRemovedFromField);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'readonly' modifier cannot be removed from a field.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Warning;
        private static readonly string _description = null;

        private static readonly ReadonlyMustNotBeRemovedFromField Instance = new ReadonlyMustNotBeRemovedFromField();

        private ReadonlyMustNotBeRemovedFromField()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
