namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <see langword="static"/> modifier must not be added to a publicly-accessible member.
    /// </summary>
    internal class StaticMustNotBeAddedToMember : CompatibilityDescriptor
    {
        private const string Id = nameof(StaticMustNotBeAddedToMember);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'static' modifier must not be added to a member.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly StaticMustNotBeAddedToMember Instance = new StaticMustNotBeAddedToMember();

        private StaticMustNotBeAddedToMember()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
