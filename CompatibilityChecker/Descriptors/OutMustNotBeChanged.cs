namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>out</c> keyword cannot be added to or removed from a parameter.
    /// </summary>
    /// <remarks>
    /// <para>In some cases, violations of this rule may be reported as <see cref="MemberMustNotBeRemoved"/> or
    /// <see cref="RefMustNotBeChanged"/>.</para>
    /// </remarks>
    internal class OutMustNotBeChanged : CompatibilityDescriptor
    {
        private const string Id = nameof(OutMustNotBeChanged);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'out' keyword cannot be added to or removed from a parameter.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly OutMustNotBeChanged Instance = new OutMustNotBeChanged();

        private OutMustNotBeChanged()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
