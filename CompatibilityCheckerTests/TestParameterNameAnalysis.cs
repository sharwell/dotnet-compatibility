namespace CompatibilityCheckerTests
{
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Reflection.Emit;
    using CompatibilityChecker;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestParameterNameAnalysis
    {
        [TestMethod]
        public void TestParameterMustNotBeRenamed_InstanceMethod_Pass()
        {
            AssemblyName assemblyName = new AssemblyName("Test.Assembly");
            AssemblyBuilder referenceAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder referenceModuleBuilder = referenceAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.dll");
            TypeBuilder referenceTypeBuilder = referenceModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            referenceTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder methodBuilder = referenceTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public, typeof(void), new[] { typeof(object) });
            methodBuilder.DefineParameter(1, ParameterAttributes.None, "refName");
            ILGenerator referenceILGenerator = methodBuilder.GetILGenerator();
            referenceILGenerator.Emit(OpCodes.Ret);
            referenceTypeBuilder.CreateType();
            referenceAssemblyBuilder.Save("Test.Assembly.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            AssemblyBuilder newAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder newModuleBuilder = newAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.V2.dll");
            TypeBuilder newTypeBuilder = newModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            newTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder newMethodBuilder = newTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public, typeof(void), new[] { typeof(object) });
            newMethodBuilder.DefineParameter(1, ParameterAttributes.None, "refName");
            ILGenerator newILGenerator = newMethodBuilder.GetILGenerator();
            newILGenerator.Emit(OpCodes.Ret);
            newTypeBuilder.CreateType();
            newAssemblyBuilder.Save("Test.Assembly.V2.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            ReadOnlyCollection<Message> messages = TestUtility.AnalyzeAssemblies("Test.Assembly.dll", "Test.Assembly.V2.dll");
            Assert.AreEqual(0, messages.Count);
        }

        [TestMethod]
        public void TestParameterMustNotBeRenamed_InstanceMethod_Fail()
        {
            AssemblyName assemblyName = new AssemblyName("Test.Assembly");
            AssemblyBuilder referenceAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder referenceModuleBuilder = referenceAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.dll");
            TypeBuilder referenceTypeBuilder = referenceModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            referenceTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder methodBuilder = referenceTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public, typeof(void), new[] { typeof(object) });
            methodBuilder.DefineParameter(1, ParameterAttributes.None, "refName");
            ILGenerator referenceILGenerator = methodBuilder.GetILGenerator();
            referenceILGenerator.Emit(OpCodes.Ret);
            referenceTypeBuilder.CreateType();
            referenceAssemblyBuilder.Save("Test.Assembly.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            AssemblyBuilder newAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder newModuleBuilder = newAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.V2.dll");
            TypeBuilder newTypeBuilder = newModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            newTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder newMethodBuilder = newTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public, typeof(void), new[] { typeof(object) });
            newMethodBuilder.DefineParameter(1, ParameterAttributes.None, "newName");
            ILGenerator newILGenerator = newMethodBuilder.GetILGenerator();
            newILGenerator.Emit(OpCodes.Ret);
            newTypeBuilder.CreateType();
            newAssemblyBuilder.Save("Test.Assembly.V2.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            ReadOnlyCollection<Message> messages = TestUtility.AnalyzeAssemblies("Test.Assembly.dll", "Test.Assembly.V2.dll");
            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual("Error ParameterMustNotBeRenamed: The name of a method parameter cannot change.", messages[0].ToString());
        }

        [TestMethod]
        public void TestParameterMustNotBeRenamed_StaticMethod_Pass()
        {
            AssemblyName assemblyName = new AssemblyName("Test.Assembly");
            AssemblyBuilder referenceAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder referenceModuleBuilder = referenceAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.dll");
            TypeBuilder referenceTypeBuilder = referenceModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            referenceTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder methodBuilder = referenceTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public | MethodAttributes.Static, typeof(void), new[] { typeof(object) });
            methodBuilder.DefineParameter(1, ParameterAttributes.None, "refName");
            ILGenerator referenceILGenerator = methodBuilder.GetILGenerator();
            referenceILGenerator.Emit(OpCodes.Ret);
            referenceTypeBuilder.CreateType();
            referenceAssemblyBuilder.Save("Test.Assembly.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            AssemblyBuilder newAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder newModuleBuilder = newAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.V2.dll");
            TypeBuilder newTypeBuilder = newModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            newTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder newMethodBuilder = newTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public | MethodAttributes.Static, typeof(void), new[] { typeof(object) });
            newMethodBuilder.DefineParameter(1, ParameterAttributes.None, "refName");
            ILGenerator newILGenerator = newMethodBuilder.GetILGenerator();
            newILGenerator.Emit(OpCodes.Ret);
            newTypeBuilder.CreateType();
            newAssemblyBuilder.Save("Test.Assembly.V2.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            ReadOnlyCollection<Message> messages = TestUtility.AnalyzeAssemblies("Test.Assembly.dll", "Test.Assembly.V2.dll");
            Assert.AreEqual(0, messages.Count);
        }

        [TestMethod]
        public void TestParameterMustNotBeRenamed_StaticMethod_Fail()
        {
            AssemblyName assemblyName = new AssemblyName("Test.Assembly");
            AssemblyBuilder referenceAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder referenceModuleBuilder = referenceAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.dll");
            TypeBuilder referenceTypeBuilder = referenceModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            referenceTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder methodBuilder = referenceTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public | MethodAttributes.Static, typeof(void), new[] { typeof(object) });
            methodBuilder.DefineParameter(1, ParameterAttributes.None, "refName");
            ILGenerator referenceILGenerator = methodBuilder.GetILGenerator();
            referenceILGenerator.Emit(OpCodes.Ret);
            referenceTypeBuilder.CreateType();
            referenceAssemblyBuilder.Save("Test.Assembly.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            AssemblyBuilder newAssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);
            ModuleBuilder newModuleBuilder = newAssemblyBuilder.DefineDynamicModule(assemblyName.Name, "Test.Assembly.V2.dll");
            TypeBuilder newTypeBuilder = newModuleBuilder.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public, typeof(object));
            newTypeBuilder.DefineDefaultConstructor(MethodAttributes.Family);
            MethodBuilder newMethodBuilder = newTypeBuilder.DefineMethod("MethodName", MethodAttributes.Public | MethodAttributes.Static, typeof(void), new[] { typeof(object) });
            newMethodBuilder.DefineParameter(1, ParameterAttributes.None, "newName");
            ILGenerator newILGenerator = newMethodBuilder.GetILGenerator();
            newILGenerator.Emit(OpCodes.Ret);
            newTypeBuilder.CreateType();
            newAssemblyBuilder.Save("Test.Assembly.V2.dll", PortableExecutableKinds.ILOnly, ImageFileMachine.AMD64);

            ReadOnlyCollection<Message> messages = TestUtility.AnalyzeAssemblies("Test.Assembly.dll", "Test.Assembly.V2.dll");
            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual("Error ParameterMustNotBeRenamed: The name of a method parameter cannot change.", messages[0].ToString());
        }
    }
}
