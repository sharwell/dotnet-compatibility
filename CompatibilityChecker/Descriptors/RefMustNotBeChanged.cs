namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>ref</c> keyword cannot be added or removed from a parameter.
    /// </summary>
    /// <remarks>
    /// <para>In some cases, violations of this rule may be reported as <see cref="MemberMustNotBeRemoved"/> or
    /// <see cref="OutMustNotBeChanged"/>.</para>
    /// </remarks>
    internal class RefMustNotBeChanged : CompatibilityDescriptor
    {
        private const string Id = nameof(RefMustNotBeChanged);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'ref' keyword cannot be added to or removed from a parameter.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly RefMustNotBeChanged Instance = new RefMustNotBeChanged();

        private RefMustNotBeChanged()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
