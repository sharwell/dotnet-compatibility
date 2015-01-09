namespace CompatibilityChecker.Descriptors
{
    using System;

    /// <summary>
    /// Certain attributes, such as <see cref="NonSerializedAttribute"/>, alter the runtime behavior of a type in a
    /// manner that is not compatible with previous releases. These attributes must not be removed.
    /// </summary>
    internal class AttributeMustNotBeRemoved : CompatibilityDescriptor
    {
        private const string Id = nameof(AttributeMustNotBeRemoved);
        private static readonly string _title = TitleHelper.GenerateTitle(Id);
        private static readonly string _messageFormat = "Attributes cannot be removed from a type.";
        private static readonly string _category = Categories.Type;
        private static readonly Severity _defaultSeverity = Severity.Error;
        private static readonly string _description = null;

        private static readonly AttributeMustNotBeRemoved Instance = new AttributeMustNotBeRemoved();

        private AttributeMustNotBeRemoved()
            : base(Id, _title, _messageFormat, _category, _defaultSeverity, _description)
        {
        }

        internal static Message CreateMessage()
        {
            return new Message(Instance);
        }
    }
}
