namespace CompatibilityCheckerTests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Reflection.PortableExecutable;
    using System.Security.Cryptography;
    using System.Xml.Linq;
    using CompatibilityChecker;
    using File = System.IO.File;
    using Path = System.IO.Path;

    internal static class TestUtility
    {
        public static ReadOnlyCollection<Message> AnalyzeAssemblies(string referenceAssemblyFile, string newAssemblyFile)
        {
            XDocument referenceDocumentation = LoadDocumentationForAssembly(referenceAssemblyFile);
            XDocument newDocumentation = LoadDocumentationForAssembly(newAssemblyFile);

            using (PEReader referenceAssembly = new PEReader(File.OpenRead(referenceAssemblyFile)))
            {
                using (PEReader newAssembly = new PEReader(File.OpenRead(newAssemblyFile)))
                {
                    TestMessageLogger logger = new TestMessageLogger();
                    Analyzer analyzer = new Analyzer(referenceAssembly, referenceDocumentation, newAssembly, newDocumentation, logger);
                    analyzer.Run();

                    return logger.RawMessages;
                }
            }
        }

        private static XDocument LoadDocumentationForAssembly(string assemblyFile)
        {
            string documentationFile = Path.ChangeExtension(assemblyFile, ".xml");
            if (!File.Exists(documentationFile))
                return null;

            return XDocument.Load(documentationFile);
        }

        public static StrongNameKeyPair GenerateStrongNameKeyPair()
        {
            using (var provider = new RSACryptoServiceProvider(1024, new CspParameters { KeyNumber = 2 }))
            {
                byte[] keyPairArray = provider.ExportCspBlob(true);
                return new StrongNameKeyPair(keyPairArray);
            }
        }

        internal class TestMessageLogger : IMessageLogger
        {
            private readonly List<Message> _rawMessages = new List<Message>();
            private readonly List<string> _messages = new List<string>();

            public ReadOnlyCollection<Message> RawMessages
            {
                get
                {
                    return _rawMessages.AsReadOnly();
                }
            }

            public ReadOnlyCollection<string> Messages
            {
                get
                {
                    return _messages.AsReadOnly();
                }
            }

            public void Report(Message message)
            {
                _rawMessages.Add(message);
                _messages.Add(message.ToString());
            }
        }
    }
}
