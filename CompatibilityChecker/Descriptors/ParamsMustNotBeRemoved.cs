namespace CompatibilityChecker.Descriptors
{
    /// <summary>
    /// The <c>params</c> keyword cannot be removed from a parameter.
    /// </summary>
    internal class ParamsMustNotBeRemoved : CompatibilityDescriptor
    {
        private const string Id = nameof(ParamsMustNotBeRemoved);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "The 'params' keyword cannot be removed from a parameter.";
        private static readonly string _category = Categories.Member;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly ParamsMustNotBeRemoved Instance = new ParamsMustNotBeRemoved();

        private ParamsMustNotBeRemoved()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
