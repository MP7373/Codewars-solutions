//https://www.codewars.com/kata/589394ae1a880832e2000092
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

public static class Kata
{
  private static AssemblyBuilder _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("RuntimeAssembly"), AssemblyBuilderAccess.Run);
  private static ModuleBuilder _moduleBuilder = _assemblyBuilder.DefineDynamicModule("Module");
  private static HashSet<string> _usedClassNames = new HashSet<string>();
  
  public static bool DefineClass(string className, Dictionary<string, Type> properties, ref Type actualType)
  {
    if (_usedClassNames.Contains(className))
    {
      return false;
    }
    _usedClassNames.Add(className);
    
    // create a type with the passed in class name
    var typeBuilder = _moduleBuilder.DefineType(className, TypeAttributes.Public);
    
    // create the properties
    foreach (var nameAndType in properties)
    {
      var name = nameAndType.Key;
      var type = nameAndType.Value;
      var fieldBuilder = typeBuilder.DefineField($"_{name}", type, FieldAttributes.Public);
      
      // I got everything to work in example tests using public fields but copy pastaed this
      // section on defining getters and setters for properties from:
      // https://stackoverflow.com/questions/3862226/how-to-dynamically-create-a-class/34689068#34689068
      PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.HasDefault, type, null);
      MethodBuilder getPropMthdBldr = typeBuilder.DefineMethod("get_" + name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, type, Type.EmptyTypes);
      ILGenerator getIl = getPropMthdBldr.GetILGenerator();

      getIl.Emit(OpCodes.Ldarg_0);
      getIl.Emit(OpCodes.Ldfld, fieldBuilder);
      getIl.Emit(OpCodes.Ret);

      MethodBuilder setPropMthdBldr =
          typeBuilder.DefineMethod("set_" + name,
            MethodAttributes.Public |
            MethodAttributes.SpecialName |
            MethodAttributes.HideBySig,
            null, new[] { type });

      ILGenerator setIl = setPropMthdBldr.GetILGenerator();
      Label modifyProperty = setIl.DefineLabel();
      Label exitSet = setIl.DefineLabel();

      setIl.MarkLabel(modifyProperty);
      setIl.Emit(OpCodes.Ldarg_0);
      setIl.Emit(OpCodes.Ldarg_1);
      setIl.Emit(OpCodes.Stfld, fieldBuilder);

      setIl.Emit(OpCodes.Nop);
      setIl.MarkLabel(exitSet);
      setIl.Emit(OpCodes.Ret);

      propertyBuilder.SetGetMethod(getPropMthdBldr);
      propertyBuilder.SetSetMethod(setPropMthdBldr);
    }
    
    actualType = typeBuilder.CreateType();
    
    return true;
  }
}
